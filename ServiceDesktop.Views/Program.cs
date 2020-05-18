using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Core;
using RCLD.Models.ApplicationModels.MainForm;
using RCLD.Presenter.Presenters;
using Services.MessagesServices.MessageBoxServices;

namespace RCLD.Views
{
    internal static class Program
    {
        #region Private Properties

        /// <summary>
        ///     Flag for develop or master version software
        /// </summary>
        private static bool DevelopVersion { get; } = true;

        #endregion

        #region Private Member Variables

        /// <summary>
        ///     Name of Software
        /// </summary>
        private const string Name = "Remote Control Power Supply and Signal Generator";

        #endregion

        #region  Public properties

        public static string Title => $"{Name} {GetCurrentVersion}";

        #endregion

        #region Constructor

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PreparingApplication();

            Services.Services.GetServices.GetLogService.CreateConfiguration();
            Services.Services.GetServices.GetLogService.Info("Запуск приложения");

            RunningApplication();
        }

        #endregion

        #region Private Methods

        #region Dll imports

        /// <summary>
        ///     Установка окна на передний или задний план
        /// </summary>
        /// <param name="hWnd">Идентификатор окна</param>
        /// <returns>True - На переднем плане, False - На заднем плане</returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        /// <summary>
        ///     Контролирует запуск приложения
        /// </summary>
        private static void RunningApplication()
        {
            try
            {
                using (var mutex = new Mutex(false, Process.GetCurrentProcess().ProcessName))
                {
                    if (mutex.WaitOne(TimeSpan.FromSeconds(3)))
                    {
                        var presenter =
                            new MainPresenter(new MainView(), new MainModel(), new MessageBoxService());
                        presenter.Run();
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

        /// <summary>
        ///     Подготавливает приложение к запуску, установка базовых настроек приложения
        /// </summary>
        private static void PreparingApplication()
        {
            Application.CurrentCulture = PreparingCultureInfo();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationCriticalHandling();
        }

        #region Critical Events Handling

        /// <summary>
        ///     Задание обработчиков для критических событий
        /// </summary>
        private static void ApplicationCriticalHandling()
        {
            Application.ApplicationExit += ApplicationOnApplicationExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;
        }

        /// <summary>
        ///     Обработчик события выхода из процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnProcessExit(object sender, EventArgs e)
        {
            Services.Services.GetServices.GetLogService.Info("Приложение было закрыто");
            Services.Services.GetServices.GetLogService.Shutdown();
        }

        /// <summary>
        ///     Обработчик события непредвиденной ошибки в процессе выполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Services.Services.GetServices.GetLogService.Fatal("Возникла непредвиденная ошибка: " + e.ExceptionObject);

            new MessageBoxService().ShowError(e.ExceptionObject.ToString(),
                "Возникла непредвиденная ошибка. Выполнение программы было остановлено.\r\n Дополнительная информация находится в логе");
            Services.Services.GetServices.GetLogService.Info("Приложение было закрыто...");
            Services.Services.GetServices.GetLogService.Shutdown();
        }

        /// <summary>
        ///     Обработчик события выхода из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ApplicationOnApplicationExit(object sender, EventArgs e)
        {
        }

        #endregion

        #region Culture Options

        /// <summary>
        ///     Устанавливает региональные параметры, в частности десятичный разделитель
        /// </summary>
        /// <returns>Экземпляр класса сведений о региональных параметрах</returns>
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

        #region Getting Application Info

        /// <summary>
        ///     Get current software version
        /// </summary>
        private static string GetCurrentVersion
        {
            get
            {
                var prepareVersion = new StringBuilder();
                var versionApp = Version.Parse(Application.ProductVersion);
                prepareVersion.Append(versionApp.Major).Append(".").Append(versionApp.Minor);
                prepareVersion.Append(versionApp.Build > 0 ? "." + versionApp.Build : "");
                prepareVersion.Append(versionApp.Revision > 0 ? "." + versionApp.Build : "");
                prepareVersion.Append(DevelopVersion ? " Develop version" : "");
                return prepareVersion.ToString();
            }
        }

        #endregion

        #endregion
    }
}