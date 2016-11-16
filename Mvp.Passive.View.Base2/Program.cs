using log4net;
using ManyConsole;
using Mvp.Passive.View.Base2.Model.Application;
using Mvp.Passive.View.Base2.Presenter.Application;
using Mvp.Passive.View.Base2.View.Application;
using System;
using System.Linq;
using System.Threading;

namespace Mvp.Passive.View.Base2
{
    internal static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        private static readonly ApplicationRepository M = new ApplicationRepository();

        private static readonly ApplicationView V = new ApplicationView();

        private static readonly ApplicationPresenterImpl P = new ApplicationPresenterImpl(M, V);

        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Any())
            {
                var commands = ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(Program));
                ConsoleCommandDispatcher.DispatchCommand(commands, args, new Log4NetTextWriter());
            }
            else
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.ApplicationExit += Dispose;
                System.Windows.Forms.Application.ThreadException += OnThreadException;

                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

                System.Windows.Forms.Application.Run(V);
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error(e.ExceptionObject.ToString());
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Log.Error(e.Exception.ToString());
        }

        private static void Dispose(object sender, EventArgs e)
        {
            V.Dispose();
            M.Dispose();
            P.Dispose();

            GC.Collect();
        }
    }
}
