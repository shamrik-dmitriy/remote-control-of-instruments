using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using ServiceDesktop.Models.ApplicationModels.MainForm;
using ServiceDesktop.Presenter.Presenters;
using ServiceDesktop.Services.MessageServices;
using ServiceDesktop.Views.MainFormView;

namespace ServiceDesktop.Views
{
    static class Program
    {
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
                new ServiceDesktopPresenter(new MainForm(), new ServiceDesktopModel(), new MessageService());
            presenter.Run();
        }
    }
}