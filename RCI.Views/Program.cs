using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCI.Models.ViewModels.Interfaces.Main;
using RCI.Models.ViewModels.MainViewModel;
using RCI.Presenters.Presenters.Main;

namespace RCI.Views
{
    static class Program
    {
        #region Constructor

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PreparingApplicationLaunch();
            LaunchApplication();
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Проверяет запущено ли приложение и производит запуск приложени
        /// </summary>
        private static void LaunchApplication()
        {
            try
            {
                using (var mutex = new Mutex(false, Process.GetCurrentProcess().ProcessName))
                {
                    if (mutex.WaitOne(TimeSpan.FromSeconds(3)))
                    {
                        var mainPresenter = new MainPresenter(new MainView(), new MainModel());
                        mainPresenter.Run();
                    }
                    else
                    {
                        if (MessageBox.Show(
                                @"Экземпляр " + Application.ProductName + " уже запущен.\n Показать " +
                                Application.ProductName + "?",
                                @"Приложение " + Application.ProductName + " уже запущено", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) !=
                            DialogResult.Yes) return;
                        var currentProcess = Process.GetCurrentProcess();
                        foreach (var process in Process.GetProcessesByName(currentProcess.ProcessName))
                        {
                            SetForegroundWindow(process.MainWindowHandle);
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
        }

        #region Preparing Methods

        /// <summary>
        ///     Подготавливает приложение к запуску - устанавливает культуру и обработку критических событий
        /// </summary>
        private static void PreparingApplicationLaunch()
        {
            Application.CurrentCulture = PreparingCultureInfo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PreparingCriticalEvents();
        }

        /// <summary>
        ///     Подготовка критических событий
        /// </summary>
        private static void PreparingCriticalEvents()
        {
            Application.ApplicationExit += ApplicationOnApplicationExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;
        }

        /// <summary>
        ///     Выход из процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnProcessExit(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Обработчик непредвиденной ошибки в процессе выполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        /// <summary>
        ///     Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ApplicationOnApplicationExit(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Устанавливает региональные параметры
        /// </summary>
        /// <returns>Culture info</returns>
        private static CultureInfo PreparingCultureInfo()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
            var culture = new CultureInfo(Application.CurrentCulture.Name)
            {
                NumberFormat = {NumberDecimalSeparator = ","}
            };
            return culture;
        }

        #endregion

        #region Import DLL

        /// <summary>
        ///     Установка окна на передний или задний план
        /// </summary>
        /// <param name="hWnd">Идентификатор окна</param>
        /// <returns>True - На переднем плане, False - На заднем плане</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        #endregion
    }
}