using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxActUtlTypeLib;
using System.Windows.Forms;
using System.Configuration;

namespace MxComponentApp
{
    public class MxComponentCla
    {

        private AxActUtlType aaut;//三菱控件名称   
        private string MxAddress;//三菱设备地址
        private int iState;
        public MxComponentCla(AxActUtlType aaut, string MxAddress)//构造函数
        {
            this.aaut = aaut;
            this.MxAddress = MxAddress;
            iState = -1;

        }

        #region "Mx open函数;正常结束 : 返回0;非正常结束 : 返回0 以外"
        public int MxOpen()
        {
            try
            {
                this.aaut.ActLogicalStationNumber = int.Parse(this.MxAddress);
               
                iState = this.aaut.Open();
                WriteLog.WriteTextLog(null, "iSTATE:" + iState.ToString() + "设备" + this.aaut.ActLogicalStationNumber.ToString(), "");
            }
            catch (Exception)
            {
                MessageBox.Show("三菱PLC加载不成功，错误代码提示:" + this.MxAddress, "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return iState;
        }
        #endregion

        #region "Mx close函数"
        public int MxClose()
        {
            int i = -1;
            int j = 0;
            try
            {
                while (i != 0)
                {
                    i = this.aaut.Close();
                    j = j + 1;
                    if (j > 3)
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("三菱PLC关闭错误，错误代码提示:" + this.MxAddress, "武汉镭立提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return i;
        }
        #endregion


        #region "Mx read函数,参数1输入的变量名的集合，参数2为值"
        public int Read(string[] inDeviceName, short[] inDeviceValue)
        {
            int i = -1;
            try
            {
                string inSzDeviceName = String.Join("\n", inDeviceName);
                int inDeviceNameNum = inDeviceName.Length;
                i = this.aaut.ReadDeviceRandom2(inSzDeviceName, inDeviceNameNum, out inDeviceValue[0]);

            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, this.MxAddress + "读取失败", null);
            }
            return i;
        }
        /// <summary>
        /// 读单个寄存器
        /// </summary>
        /// <param name="inDeviceName"></param>
        /// <param name="inDeviceValue"></param>
        /// <returns></returns>
        public int Read(string inDeviceName,out short inDeviceValue)
        {
            int i = -1;
            inDeviceValue = 0;
            try
            {
                i =  this.aaut.ReadDeviceRandom2(inDeviceName, 1, out inDeviceValue);
            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, this.MxAddress + "读取失败", null);
            }
            return i;
        }

        #endregion

        #region "Mx Write函数,参数1输入的变量名的集合，参数2为值"
        public int Write(string[] outDeviceName, short[] outDeviceValue)
        {
            int i = -1;
            try
            {
                string outSzDeviceName = String.Join("\n", outDeviceName);
                int outDeviceNameNum = outDeviceName.Length;
                i = this.aaut.WriteDeviceRandom2(outSzDeviceName, outDeviceNameNum, ref outDeviceValue[0]);
            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, this.MxAddress + "发送失败", null);
            }
            return i;
        }
        /// <summary>
        /// 写单个寄存器
        /// </summary>
        /// <param name="outDeviceName">寄存器地址</param>
        /// <param name="outDeviceValue">要写入的值</param>
        /// <returns></returns>
        public int Write(string outDeviceName, short outDeviceValue)
        {
            int i = -1;
            try
            {
                i = this.aaut.WriteDeviceRandom2(outDeviceName, 1, ref outDeviceValue);
            }
            catch (Exception ex)
            {
                WriteLog.WriteTextLog(ex, this.MxAddress + "发送失败", null);
            }
            return i;
        }

        public int PlcErro()
        {
           
            int i = aaut.Connect();
            //if (aaut.Disconnect() == 0)
            //{
            //    i = 0;
            //}
            return i;
        }

        public int PlcSatte()
        {
            int i = 0;
            if (iState == 0)
            {
                i = 1;//1表示已连接
            }
            else
            {
                i = 0;
            }
          
            return i;
            
        }
        #endregion
    }
}
