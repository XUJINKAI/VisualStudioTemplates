using CommandDotNet;
using CommandDotNet.Models;
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using Console = Colorful.Console;

namespace DotnetCoreConsoleApp
{
    class Program
    {
        public static AppRunner<App> AppRunner;

        static void Main(string[] args)
        {
            Console.WriteAscii("ConsoleApp", Color.Red);
            Console.WriteLine(@"dotnet core Template App.
GitHub: https://github.com/XUJINKAI/CSharpTemplates
Author: http://xujinkai.net
", Color.Gray);

            var setting = new AppSettings()
            {
                ThrowOnUnexpectedArgument = true,
                Help = new AppHelpSettings()
                {
                    UsageAppNameStyle = UsageAppNameStyle.Executable,
                },
            };
            AppRunner = new AppRunner<App>(setting);

            AppRunner.Run(args);

            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                args = CommandLineToArgs(line);
                AppRunner.Run(args);
            }
        }

        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        static string[] CommandLineToArgs(string commandLine)
        {
            if (string.IsNullOrEmpty(commandLine))
                return Array.Empty<string>();

            var argv = CommandLineToArgvW(commandLine, out int argc);
            if (argv == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();

            try
            {
                var args = new string[argc];
                for (var i = 0; i < args.Length; i++)
                {
                    var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                    args[i] = Marshal.PtrToStringUni(p);
                }

                return args;
            }
            finally
            {
                Marshal.FreeHGlobal(argv);
            }
        }
    }
}
