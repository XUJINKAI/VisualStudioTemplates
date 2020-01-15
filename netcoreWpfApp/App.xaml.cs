using System;
using System.Threading.Tasks;
using System.Windows;

namespace DotnetCoreWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            HandleGlobalExceptions();
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
            (this.MainWindow = new MainWindow()).Show();
        }

        public static void ProcessException(string From, Exception? e, bool ShowMessageBox)
        {
            var msg = $"Source: {From}{Environment.NewLine}Message: {e?.Message}{Environment.NewLine}StackTrace:{Environment.NewLine}{e?.StackTrace}";
            if (ShowMessageBox) MessageBox.Show(msg, "App Exception");
            System.Diagnostics.Trace.TraceError(msg);
        }

        private void HandleGlobalExceptions()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exp = e.ExceptionObject as Exception;
            ProcessException("AppDomain.UnhandledException", exp, e.IsTerminating);
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            ProcessException("App.DispatcherUnhandledException", e.Exception, false);
            e.Handled = false;
        }

        private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            ProcessException("TaskScheduler.UnobservedTaskException", e.Exception, false);
        }

    }
}
