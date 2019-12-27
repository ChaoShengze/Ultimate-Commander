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
using System.Windows.Shapes;

namespace Ultimate_Commander
{
    /// <summary>
    /// MsgBox.xaml 的交互逻辑
    /// </summary>
    public partial class MsgBox : Window
    {
        private static MsgBox Instance;
        private MsgBox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取MsgBox的单例
        /// </summary>
        /// <returns></returns>
        public static MsgBox GetMsgBox()
        {
            if (Instance == null)
                Instance = new MsgBox();

            return Instance;
        }

        public void Show(string info, string title)
        {
            Title = title;
            tb_info.Text = info;

            ShowDialog();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
