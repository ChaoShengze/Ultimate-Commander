using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Ultimate_Commander
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        /// <summary>
        /// 初始化
        /// Initialization
        /// </summary>
        private void Init()
        {
            // 系列检查
            BaseFramework
                .GetInstance()
                .InitLanguage()
                .CheckDllDir()
                .CheckSelfName()
                .CheckSingleProcess()
                .CheckLicence(() => { Hide(); new LicencePopup().ShowDialog(); Show(); })
                .SetHotKey(new IntPtr(), null);
        }
    }
}
