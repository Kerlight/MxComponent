using HslCommunication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MxComponentApp
{
    public partial class HslReConntionFrm : Form
    {
        private System.Timers.Timer KeepAliveTime = null;
        private HslCommunication.Profinet.Melsec.MelsecA1ENet Melsec_net = null;
        public HslReConntionFrm()
        {
            InitializeComponent();
        }
        private void HslReConntionFrm_Load(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            ////PLC初始化
            Task<CustomMessage> taskplc = initMelsecPLC(ip);
            //检测PLC连接状态
            KeepAliveTime = new System.Timers.Timer(5000);
            KeepAliveTime.Elapsed += new ElapsedEventHandler(KeepAliveMethod);
            KeepAliveTime.AutoReset = true;
            KeepAliveTime.Enabled = false;
            KeepAliveTime.SynchronizingObject = this;
            KeepAliveTime.Start();

            if (!taskplc.Wait(500))
            {
                MessageBox.Show("连接超时", "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetDeviceState(taskplc, labPLC);
            }
        }

        /// <summary>
        /// PLC初始化
        /// </summary>
        private Task<CustomMessage> initMelsecPLC(string ipaddress)
        {
            Task<CustomMessage> taskplc = Task.Factory.StartNew(() =>
            {
                CustomMessage cm = new CustomMessage() { success = false, message = "" };
                try
                {
                    if (Melsec_net == null)
                    {
                        string[] array = ipaddress.Split(new char[] { ',' });
                        Melsec_net = new HslCommunication.Profinet.Melsec.MelsecA1ENet()
                        {
                            IpAddress = array[0],
                            Port = int.Parse(array[1]),
                            ConnectTimeOut = 3000
                        };
                        OperateResult result = Melsec_net.ConnectServer();
                        if (result.IsSuccess)
                        {
                            cm.success = true;
                        }
                        else
                        {
                            cm.success = false;
                            cm.message = result.Message;
                        }

                    }
                }
                catch (Exception ex)
                {
                    cm.success = false;
                    cm.message = ex.ToString();
                    return cm;
                }

                return cm;
            });
            return taskplc;
        }
        /// <summary>
        /// 定时读取，判定PLC状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeepAliveMethod(object sender, System.Timers.ElapsedEventArgs e)
        {
            KeepAliveTime.Stop();
            OperateResult<bool> result = Melsec_net.ReadBool("M8000");
            if (!result.IsSuccess)
            {
                SetTextEditStatus(labPLC, "未连接", Color.Red);
            }
            else
            {
                SetTextEditStatus(labPLC, "已连接", Color.Green);
            }
            KeepAliveTime.Start();
        }

        /// <summary>
        /// TextBox 文本框值及前景色
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="text"></param>
        /// <param name="colr"></param>
        private void SetTextEditStatus(Label txt, string text, Color colr)
        {
            Action<string> action = (string x) =>
            {
                txt.Text = text;
                txt.ForeColor = colr;
            };
            txt.BeginInvoke(action, new object[] { text });
        }
        private void SetDeviceState(Task<CustomMessage> task, Label lab)
        {
            if (!task.Result.success)
            {
                SetTextEditStatus(lab, "未连接", Color.Red);
                WriteLog.WriteTextLog(null, "连接出错：" + task.Result.message, "");
                MessageBox.Show(task.Result.message, "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetTextEditStatus(lab, "已连接", Color.Green);
            }
        }

        private void HslReConntionFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KeepAliveTime != null)
            {
                KeepAliveTime.Enabled = false;
                KeepAliveTime.Elapsed -= new System.Timers.ElapsedEventHandler(KeepAliveMethod);
                KeepAliveTime.Dispose();
            }
            if (Melsec_net != null)
            {
                Melsec_net.ConnectClose();
            }
        }
    }

    public class CustomMessage
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
}
