using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Ultimate_Commander
{
    /// <summary>
    /// 基础功能均在此实现
    /// </summary>
    public class BaseFramework
    {
        #region 单例模式

        private static BaseFramework Instance;
        private BaseFramework() { }
        public static BaseFramework GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BaseFramework();
            }
            return Instance;
        }

        #endregion

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public delegate void CallBack();

        /// <summary>
        /// 检查是否存在外置DLL文件的目录，无则创建
        /// </summary>
        public BaseFramework CheckDllDir()
        {
            var startPath = Application.StartupPath + @"\Components";
            if (!Directory.Exists(startPath))
            {
                try
                {
                    Directory.CreateDirectory(startPath);
                }
                catch (Exception e)
                {
                    Log.GetInstance().WriteLog(e.Message);
                    throw e;
                }
            }
            return this;
        }

        /// <summary>
        /// 检查自身文件名是否被修改，一是为了确保后续的单进程检查有效，二是保护版权
        /// </summary>
        /// <returns></returns>
        public BaseFramework CheckSelfName()
        {
            var totalPath = Application.ExecutablePath;
            var fileName = Path.GetFileName(totalPath);
            if (fileName != "Ultimate Commander.exe")
            {
                MessageBox.Show("请勿修改主程序文件名！");
                Process.GetCurrentProcess().Kill();
            }
            return this;
        }

        /// <summary>
        /// 检查是否是第一次运行，若是显示协议窗口
        /// </summary>
        /// <param name="callBack">用以显示协议窗口的回调函数</param>
        /// <returns></returns>
        public BaseFramework CheckLicence(CallBack callBack)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey software = key.CreateSubKey("Ultimate Commander");

            try
            {
                RegistryKey firstRun = key.OpenSubKey("Ultimate Commander", true);
                if (firstRun.GetValue("first") == null)
                {
                    software.SetValue("first", "0");
                    callBack();
                }
            }
            catch(Exception e)
            {
                Log.GetInstance().WriteLog(e.Message);
            }

            return this;
        }

        /// <summary>
        /// 确保只有一个活动的窗体
        /// </summary>
        /// <param name="callBack"></param>
        /// <returns></returns>
        public BaseFramework CheckSingleProcess()
        {
            Process[] app = Process.GetProcessesByName("Ultimate Commander");
            if (app.Length > 1)
            {
                MessageBox.Show("同时只允许一个进程运行！");
                Process.GetCurrentProcess().Kill();
            }
            else
            {

            }
            return this;
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handle)
        {
            switch (wParam.ToInt32())
            {
                default:
                    break;
            }

            return IntPtr.Zero;
        }

        public BaseFramework SetHotKey(IntPtr handle, HwndSource source)
        {
            Config.GetInstance();
            //RegisterHotKey(handle, MY_HOTKEY1, 0x0001, 0x25);
            //source.AddHook(WndProc);
            return this;
        }

        public BaseFramework DelHotKey()
        {
            return this;
        }
    }
}
