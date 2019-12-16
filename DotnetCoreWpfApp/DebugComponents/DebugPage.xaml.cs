using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotnetCoreWpfApp.DebugComponents
{
    /// <summary>
    /// DebugPage.xaml 的交互逻辑
    /// </summary>
    public partial class DebugPage : Page
    {
        public DebugPage()
        {
            InitializeComponent();
        }


        private void Write(string s) { LogBox.AppendText(s); LogBox_Scroller.ScrollToEnd(); }
        private void WriteLine(string s) => Write(s + Environment.NewLine);
        private void LogBox_Clear(object sender, RoutedEventArgs e) => LogBox.Clear();

        private void Test_Function(object sender, RoutedEventArgs e)
        {
            WriteLine("Test_Function in DebugPage");
        }
    }
}
