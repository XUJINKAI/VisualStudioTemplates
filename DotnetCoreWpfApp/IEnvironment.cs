using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DotnetCoreWpfApp
{
    public interface IEnvironment
    {

        private static readonly bool _isDesignTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());

#if DEBUG
        private const bool _debug = true;
#else
        private const bool _debug = false;
#endif


        public static string EntryLocation => System.Reflection.Assembly.GetEntryAssembly().Location;

        public static string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;

        public static bool IsDesignTime => _isDesignTime;

        public static bool DEBUG => _debug;

        public static bool RELEASE => !_debug;

    }
}
