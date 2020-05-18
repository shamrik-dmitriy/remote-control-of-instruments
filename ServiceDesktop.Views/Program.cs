using System;
using System.Text;
using System.Windows.Forms;
using Core;
using RCLD.Models.ApplicationModels.MainForm;
using ServiceDesktop.Presenter.Presenters;
using Services.MessagesServices.MessageBoxServices;

namespace RCLD.Views
{
    static class Program
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationModel.Logger = ApplicationModel.GetApplicationModel.CreateLoggingConfiguration();

            var presenter =
                new MainPresenter(new MainView(), new MainModel(), new MessageBoxService());
            presenter.Run();
        }

        #endregion

        #region Private Methods

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
    }
}