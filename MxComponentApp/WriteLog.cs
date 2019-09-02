using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace MxComponentApp
{
   public class WriteLog
    {
        public static object locker = new object();
        private static StreamWriter sw;
        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件地址</param>
        /// <param name="Tag">传入标签（这里用于标识函数由哪个线程调用）</param>
        public static void WriteTextLog(Exception ex, string Tag, string LogAddress)
        {
            lock (locker)
            {

                try
                {
                    DateTime now = DateTime.Now;
                    string nowTime = string.Format("{0:yyyy-MM}", now);
                    string sPath = Environment.CurrentDirectory + '\\' + "错误日志" + '\\' + nowTime;
                    //如果无则创建文件夹
                    if (!Directory.Exists(sPath))
                    {
                        Directory.CreateDirectory(sPath);
                    }
                    //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
                    if (LogAddress == "" || LogAddress == null)//xuwei 2017-02-18
                    {
                        LogAddress = sPath + '\\' +
                            DateTime.Now.Year + '-' +
                            DateTime.Now.Month + '-' +
                            DateTime.Now.Day + "_Log.log";
                    }
                    sw = new StreamWriter(LogAddress, true);
                    //把异常信息输出到文件
                    sw.WriteLine(String.Concat('[', DateTime.Now.ToString(), "] Tag:" + Tag));
                    sw.WriteLine("异常信息：" + ex.Message);
                    //sw.WriteLine("异常对象：" + ex.Source);
                    //sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
                    //sw.WriteLine("触发方法：" + ex.TargetSite);
                    sw.WriteLine();
                }
                catch (Exception)
                {

                }
                finally
                {
                    sw.Close();
                }
            }
        }
    }
}
