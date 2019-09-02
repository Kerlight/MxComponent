using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MxComponentApp
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer KeepAliveTime = null;
        MxComponentCla mxComponentCla;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭处理
        /// </summary>
        private void CloseEvent()
        {
            try
            {
                if (mxComponentCla != null)
                {
                    mxComponentCla.MxClose();
                }
                
            }
            catch
            {

            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "连接")
            {
                if (mxComponentCla == null)
                {
                    mxComponentCla = new MxComponentCla(axActUtlType1, txtConNode.Text.Trim());
                    mxComponentCla.MxOpen();
                    DeviceStateTextEdit(label3, mxComponentCla.PlcSatte());
                    KeepAliveTime.Start();
                }
            }
            else
            {
                if (mxComponentCla != null)
                {
                    mxComponentCla.MxClose();
                    mxComponentCla = null;
                    DeviceStateTextEdit(label3, 0);
                    KeepAliveTime.Stop();
                }
            }
            
        }

        public void DeviceStateTextEdit(Label te, int i)
        {
            if (i == 1)
            {
                te.Text = "已连接";
                te.ForeColor = System.Drawing.Color.Green;
                button1.Text = "断开";
                txtConNode.Enabled = false;
            }
            else
            {
                te.Text = "未连接";
                te.ForeColor = System.Drawing.Color.Red;
                button1.Text = "连接";
                txtConNode.Enabled = true;
            }
        }
        /// <summary>
        /// 窗体关闭处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseEvent();
        }
        /// <summary>
        /// 读取整形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (mxComponentCla != null)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    string[] arry = textBox2.Text.Trim().Split(new char[] {','});
                    int len = arry.Length;
                    short[] arrayval = new short[] {};
                    for (int i = 0; i < len; i++)
                    {
                        arrayval[i] = 0;
                    }
                    int x = mxComponentCla.Read(arry, arrayval);
                    if (x == 0)
                    {
                        sb.Append("----------批量读取成功----------");
                        for (int i = 0; i < arry.Length; i++)
                        {
                            sb.AppendFormat("寄存器【{0}】成功,值【{1}】", arry[i].ToString(), arrayval[i].ToString());
                        }
                    }
                    else
                        SetTextBoxInfo("批量读取失败");
                }
                catch (Exception ex)
                {
                    SetTextBoxInfo(string.Format("读取错误:{0}", ex.Message));
                    WriteLog.WriteTextLog(ex, string.Format("读取寄存器【{0}】失败", textBox1.Text.Trim()), "");
                }
                
            }
        }
        /// <summary>
        /// 写入整形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (mxComponentCla != null)
            {
                try
                {
                    string[] arry = new string[1] { txtWriteAddress.Text.Trim() };
                    short[] arrayval = new short[1] { short.Parse(txtWriteValue.Text.Trim()) };
                    int x = mxComponentCla.Write(arry, arrayval);
                    if (x == 0)
                        SetTextBoxInfo(string.Format("写入成功,寄存器【{0}】,值【{1}】", txtWriteAddress.Text.Trim(), txtWriteValue.Text.ToString()));
                    else
                        SetTextBoxInfo(string.Format("写入失败,寄存器【{0}】,值【{1}】", txtWriteAddress.Text.Trim(), txtWriteValue.Text.ToString()));
                }
                catch (Exception ex)
                {
                    SetTextBoxInfo(string.Format("写入错误:{0}", ex.Message));
                    WriteLog.WriteTextLog(ex, string.Format("寄存器【{0}】写入失败", txtWriteAddress.Text.Trim()), "");
                }
                
            }
        }
        /// <summary>
        /// 单个读取
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (mxComponentCla != null)
            {
                string arry = textBox1.Text.Trim();
                short arrayval = 0;
                int i = mxComponentCla.Read(arry, out arrayval);
                if (i == 0)
                    SetTextBoxInfo(string.Format("读取寄存器【{0}】成功,值【{1}】", arry, arrayval.ToString()));
                else
                    SetTextBoxInfo(string.Format("读取寄存器【{0}】失败", arry));

            }
        }
        /// <summary>
        /// 单个写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (mxComponentCla != null)
            {
                string arry = txtWriteAddress.Text.Trim();
                short arrayval = short.Parse(txtWriteValue.Text.Trim());
                int x = mxComponentCla.Write(arry, arrayval);
                if (x == 0)
                    SetTextBoxInfo(string.Format("写入成功,寄存器【{0}】,值【{1}】", arry, arrayval));
                else
                    SetTextBoxInfo(string.Format("写入失败,寄存器【{0}】", arry));
            }
        }


        delegate void dgvDelegate(string result);
        private void SetTextBoxInfo(string result)
        {
            if (txtMessage.InvokeRequired)
            {
                this.Invoke(new Action<string>((str) => { txtMessage.AppendText(result + Environment.NewLine); }));
            }
            else
            {
                txtMessage.AppendText(result + Environment.NewLine);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //检测PLC连接状态
            KeepAliveTime = new System.Timers.Timer(3000);
            KeepAliveTime.Elapsed += new ElapsedEventHandler(KeepAliveMethod);
            KeepAliveTime.AutoReset = true;
            KeepAliveTime.Enabled = false;
            KeepAliveTime.SynchronizingObject = this;
        }

        /// <summary>
        /// 定时读取，判定PLC状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeepAliveMethod(object sender, System.Timers.ElapsedEventArgs e)
        {
            KeepAliveTime.Stop();
            short s = 0;
            int x = mxComponentCla.Read("M8000", out s);
            if (x == 0)
            {
                DeviceStateTextEdit(label3, 1);
            }
            else
            {
                DeviceStateTextEdit(label3, 0);
            }
            KeepAliveTime.Start();
        }

    }
}
