using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DotnetCoreWpfApp.DebugComponents
{
    /// <summary>
    /// DebugWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DebugWindow : BaseWindow
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void AppShutDown(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void DebuggerBreak(object sender, RoutedEventArgs e)
        {
            Debugger.Break();
        }

        private void ThrowException(object sender, RoutedEventArgs e)
        {
            throw new Exception("Exception from ThrowExceptionCmd by user.");
        }
    }
}
