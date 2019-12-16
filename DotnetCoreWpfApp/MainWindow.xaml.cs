using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DotnetCoreWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BaseWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (IEnvironment.DEBUG)
            {
                AddCommand(ModifierKeys.None, Key.Escape, (o, e) => App.Current.Shutdown());
                if (!IEnvironment.IsDesignTime) OpenDebugWindow(null, null);
            }
        }

        // Menus/Commands

        private void AppExit(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void OpenDebugWindow(object sender, RoutedEventArgs e)
        {
            new DebugComponents.DebugWindow().Show();
        }
    }
}
