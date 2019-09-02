using HslCommunication;
using HslCommunication.Profinet;
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
    public partial class SmartForm : Form
    {

        private System.Timers.Timer timerQJZ;//前极柱采集线程
        private System.Timers.Timer timerHJZ;//后极柱采集线程

        bool Isconnect = false;
        private string[] arrayQ = new string[] { "M30.7", "DB1.70", "DB1.74", "M5.1", "M20.0" };
        private string[] arrayH = new string[] { "M30.6", "DB1.70", "DB1.74", "M5.2" };
        private SiemensTcpNet siemensTcpNet = null;
        public SmartForm()
        {
            InitializeComponent();
        }

        private void SmartForm_Load(object sender, EventArgs e)
        {
            siemensTcpNet = new SiemensTcpNet(SiemensPLCS.S1200);
            timerQJZ = new System.Timers.Timer(500);
            timerQJZ.Elapsed += new ElapsedEventHandler(ReadQJZ);
            timerQJZ.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            timerQJZ.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件 

            timerHJZ = new System.Timers.Timer(500);
            timerHJZ.Elapsed += new ElapsedEventHandler(ReadHJZ);
            timerHJZ.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            timerHJZ.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件 
        }
        /// <summary>
        /// 开始生产
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProductStart_Click(object sender, EventArgs e)
        {
            if (Isconnect)
            {
                if (BtnProductStart.Text == "开始生产")
                {
                    timerQJZ.Enabled = true;
                    timerQJZ.Start();
                    timerHJZ.Enabled = true;
                    timerHJZ.Start();
                    BtnProductStart.Text = "停止生产";
                }
                else
                {
                    timerQJZ.Enabled = false;
                    timerQJZ.Stop();
                    timerHJZ.Enabled = false;
                    timerHJZ.Stop();
                    BtnProductStart.Text = "开始生产";
                }
            }
            else
            {
                MessageBox.Show("请先连接PLC");
            }

        }

        delegate void dgvDelegate(string result);
        private void SetTextBoxInfo(string result)
        {
            if (txtMessage.InvokeRequired)
            {
                Invoke(new dgvDelegate(SetTextBoxInfo), new object[] { result });
            }
            else
            {
                txtMessage.AppendText(result + Environment.NewLine);
            }
        }

        /// <summary>
        /// 前极柱采集线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadQJZ(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerQJZ.Stop();
            try
            {
                bool flagQ = siemensTcpNet.ReadBoolFromPLC(arrayQ[0]).Content;//float QHeight = siemensTcpNet.ReadFloatFromPLC(arrayQ[1]).Content;
                if (flagQ)
                {
                    float QHeight = siemensTcpNet.ReadFloatFromPLC(arrayQ[1]).Content;
                    float QTaper = siemensTcpNet.ReadFloatFromPLC(arrayQ[2]).Content;
                    bool qutity = siemensTcpNet.ReadBoolFromPLC(arrayQ[3]).Content;
                    siemensTcpNet.WriteIntoPLC(arrayQ[0], false);
                    string quantity = qutity ? "是" : "否";
                    string s = string.Format("前极柱高度【{0}】，前极柱锥度【{1}】，是否合格【{2}】，采集时间【{3}】", QHeight, QTaper, qutity, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    SetTextBoxInfo(s);
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, "采集前极柱数据出错", "");
            }
            timerQJZ.Start();

        }
        /// <summary>
        /// 后极柱采集线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadHJZ(object sender, System.Timers.ElapsedEventArgs e)
        {
            timerHJZ.Stop();
            try
            {
                bool flagH = siemensTcpNet.ReadBoolFromPLC(arrayH[0]).Content;
                if (flagH)
                {
                    float HHeight = siemensTcpNet.ReadFloatFromPLC(arrayH[1]).Content;
                    float HTaper = siemensTcpNet.ReadFloatFromPLC(arrayH[2]).Content;
                    bool qutity = siemensTcpNet.ReadBoolFromPLC(arrayH[3]).Content;
                    siemensTcpNet.WriteIntoPLC(arrayH[0], false);
                    string quantity = qutity ? "是" : "否";
                    string s = string.Format("后极柱高度【{0}】，前极柱锥度【{1}】，是否合格【{2}】，采集时间【{3}】", HHeight, HTaper, qutity, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    SetTextBoxInfo(s);
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, "采集后极柱数据出错", "");
            }
            timerHJZ.Start();

        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // 连接
            if (!System.Net.IPAddress.TryParse(textBox1.Text, out System.Net.IPAddress address))
            {
                MessageBox.Show("Ip地址输入不正确！");
                return;
            }

            siemensTcpNet.PLCIpAddress = address;
            siemensTcpNet.ConnectTimeout = 200;//连接超时200毫秒
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                siemensTcpNet.PortRead = int.Parse(textBox2.Text);
                siemensTcpNet.PortWrite = int.Parse(textBox2.Text);
            }
            try
            {
                OperateResult connect = siemensTcpNet.ConnectServer();
                if (connect.IsSuccess)
                {
                    Isconnect = true;
                    MessageBox.Show("连接成功！");
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    Isconnect = false;
                    MessageBox.Show("连接失败！");
                }
            }
            catch (Exception ex)
            {
                Isconnect = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 断开连接
            OperateResult result = siemensTcpNet.ConnectClose();
            if (result.IsSuccess)
            {
                Isconnect = false;
            }
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>(OperateResult<T> result, string address, TextBox textBox)
        {
            if (result.IsSuccess)
            {
                textBox.AppendText(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] {result.Content}{Environment.NewLine}");
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 读取失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender(OperateResult result, string address)
        {
            if (result.IsSuccess)
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入成功");
            }
            else
            {
                MessageBox.Show(DateTime.Now.ToString("[HH:mm:ss] ") + $"[{address}] 写入失败{Environment.NewLine}原因：{result.ToMessageShowString()}");
            }
        }
        private void button_read_bool_Click(object sender, EventArgs e)
        {
            // 读取bool变量
            readResultRender(siemensTcpNet.ReadBoolFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_byte_Click(object sender, EventArgs e)
        {
            // 读取byte变量
            readResultRender(siemensTcpNet.ReadByteFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_short_Click(object sender, EventArgs e)
        {
            // 读取short变量
            readResultRender(siemensTcpNet.ReadShortFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_ushort_Click(object sender, EventArgs e)
        {
            // 读取ushort变量
            readResultRender(siemensTcpNet.ReadUShortFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_int_Click(object sender, EventArgs e)
        {
            // 读取int变量
            readResultRender(siemensTcpNet.ReadIntFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_uint_Click(object sender, EventArgs e)
        {
            // 读取uint变量
            readResultRender(siemensTcpNet.ReadUIntFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_long_Click(object sender, EventArgs e)
        {
            // 读取long变量
            readResultRender(siemensTcpNet.ReadLongFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_ulong_Click(object sender, EventArgs e)
        {
            // 读取ulong变量
            readResultRender(siemensTcpNet.ReadULongFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_float_Click(object sender, EventArgs e)
        {
            // 读取float变量
            readResultRender(siemensTcpNet.ReadFloatFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_double_Click(object sender, EventArgs e)
        {
            // 读取double变量
            readResultRender(siemensTcpNet.ReadDoubleFromPLC(textBox3.Text), textBox3.Text, textBox4);
        }

        private void button_read_string_Click(object sender, EventArgs e)
        {
            // 读取字符串
            readResultRender(siemensTcpNet.ReadStringFromPLC(textBox3.Text, ushort.Parse(textBox5.Text)), textBox3.Text, textBox4);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // bool写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, bool.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // byte写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, byte.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // short写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, short.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // ushort写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, ushort.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // int写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, int.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // uint写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, uint.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // long写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, long.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // ulong写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, ulong.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // float写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, float.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // double写入
            try
            {
                writeResultRender(siemensTcpNet.WriteIntoPLC(textBox8.Text, double.Parse(textBox7.Text)), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // string写入
            try
            {
                writeResultRender(siemensTcpNet.WriteAsciiStringIntoPLC(textBox8.Text, textBox7.Text), textBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
