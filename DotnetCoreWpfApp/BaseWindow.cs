using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace DotnetCoreWpfApp
{
    public class BaseWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties

        public Visibility DEBUG_VISIBILITY => IEnvironment.DEBUG ? Visibility.Visible : Visibility.Collapsed;

        public IntPtr Handle { get; private set; }

        // override

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            Handle = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            System.Diagnostics.Trace.TraceInformation($"Create new window handle 0x{Handle.ToString("X")}.");
        }

        // INotifyPropertyChanged

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void SetProperty<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
        }

        // Add shortcut to window

        protected void AddCommand(ModifierKeys modifierKeys, Key key, ExecutedRoutedEventHandler handler)
        {
            RoutedCommand Cmd = new RoutedCommand();
            Cmd.InputGestures.Add(new KeyGesture(key, modifierKeys));
            CommandBindings.Add(new CommandBinding(Cmd, handler));
        }
    }
}
