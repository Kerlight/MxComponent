using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MxComponentApp
{
    public partial class MxComponentConnFrm : Form
    {
        public bool startStopProduct = false;
        public bool connectionStatus = false;
        MxComponentCla mxComponentCla;
        public MxComponentConnFrm()
        {
            InitializeComponent();
        }

        private void MxComponentConnFrm_Load(object sender, EventArgs e)
        {
            mxComponentCla = new MxComponentCla(axActUtlType1, "9");
            mxComponentCla.MxOpen();
            if (mxComponentCla.PlcSatte() == 1)
            {
                connectionStatus = true;
                label3.Text = "已连接";
                label3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                connectionStatus = false;
                label3.Text = "未连接";
                label3.ForeColor = System.Drawing.Color.Red;
            }
            Task task = Task.Factory.StartNew(() =>
            {
               KeepAlivePLC();
            });
        }
        /// <summary>
        /// 开始生产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_conn_Click(object sender, EventArgs e)
        {
            if (connectionStatus)
            {
                startStopProduct = true;
                btn_conn.Enabled = false;
            }
            else
            {
                MessageBox.Show("PLC断线重连中,请等待PLC重连成功后再尝试", " 武汉镭立科技友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Task<int> taskint;
        private void KeepAlivePLC()
        {
            while (true)
            {
                int x = -1; short arrayval = 0;
                taskint = Task.Factory.StartNew<int>(new Func<int>(() => { return mxComponentCla.Read("M8000", out arrayval); }));
                bool bol = taskint.Wait(new TimeSpan(0, 0, 0, 3));
                if (!bol)
                {
                    connectionStatus = false;
                    this.Invoke(new Action(() => { label3.Text = "未连接"; label3.ForeColor = System.Drawing.Color.Red; }));
                    if (startStopProduct)
                    {
                        startStopProduct = false;
                        this.Invoke(new Action(() => { btn_conn.Enabled=true; }));
                        MessageBox.Show("PLC请求超时，请检查PLC连接状态，重启客户端", " 武汉镭立科技友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    x = taskint.Result;
                    if (x != 0)
                    {
                        connectionStatus = false;
                        this.Invoke(new Action(() => { label3.Text = "未连接"; label3.ForeColor = System.Drawing.Color.Red; }));
                        if (startStopProduct)
                        {
                            startStopProduct = false;
                            this.Invoke(new Action(() => { btn_conn.Enabled = true; }));
                            MessageBox.Show("PLC连接已断开，请检查PLC连接状态，重启客户端", " 武汉镭立科技友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                  
                }
                if (!connectionStatus)
                {
                    if (mxComponentCla != null)
                    {
                        mxComponentCla.MxClose();
                        mxComponentCla = null;
                    }
                    mxComponentCla = new MxComponentCla(axActUtlType1, "9");
                    int m = mxComponentCla.MxOpen();
                    if (m == 0 && mxComponentCla.PlcSatte() == 1)
                    {
                        connectionStatus = true;
                        this.Invoke(new Action(() => { label3.Text = "已连接"; label3.ForeColor = System.Drawing.Color.Green; }));
                    }
                    else
                    {
                        connectionStatus = false;
                        this.Invoke(new Action(() => { label3.Text = "未连接"; label3.ForeColor = System.Drawing.Color.Red; }));
                    }
                }

                Thread.Sleep(2000);
            }
        }
        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (connectionStatus)
            {
                string arry = textBox1.Text.Trim();
                short arrayval = 0;
                int i = mxComponentCla.Read(arry, out arrayval);
                if (i == 0)
                    SetTextBoxInfo(string.Format("读取寄存器【{0}】成功,值【{1}】", arry, arrayval.ToString()));
                else
                    SetTextBoxInfo(string.Format("读取寄存器【{0}】失败", arry));

            }
            else
            {
                MessageBox.Show("PLC断线重连中,请等待PLC重连成功后再尝试", " 武汉镭立科技友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// 写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (connectionStatus)
            {
                string arry = txtWriteAddress.Text.Trim();
                short arrayval = short.Parse(txtWriteValue.Text.Trim());
                int x = mxComponentCla.Write(arry, arrayval);
                if (x == 0)
                    SetTextBoxInfo(string.Format("写入成功,寄存器【{0}】,值【{1}】", arry, arrayval));
                else
                    SetTextBoxInfo(string.Format("写入失败,寄存器【{0}】", arry));
            }
            else
            {
                MessageBox.Show("PLC断线重连中,请等待PLC重连成功后再尝试", " 武汉镭立科技友情提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 刷新结果展示区
        /// </summary>
        /// <param name="result"></param>
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
    }
}
