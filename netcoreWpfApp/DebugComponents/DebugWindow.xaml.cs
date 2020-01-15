using System;
using System.Diagnostics;
using System.Windows;

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
