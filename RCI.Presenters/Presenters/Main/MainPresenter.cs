using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RCI.Models.ViewModels.Interfaces.Main;
using RCI.Presenters.Interfaces.Views.Main;

namespace RCI.Presenters.Presenters.Main
{
    public class MainPresenter : IRichTextBoxView
    {
        #region Private Properties

        private IMainView MainView { get; set; }

        private IMainModel MainModel { get; set; }

        private Task TaskOfConnection { get; }

        private static CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        private CancellationToken CancellationToken { get; }

        #endregion

        #region Constructor

        public MainPresenter(IMainView mainView, IMainModel mainModel)
        {
            MainView = mainView;
            MainModel = mainModel;

            CancellationToken = CancellationTokenSource.Token;
            //TaskOfConnection = new Task<bool>(() => ConnectionStateTask(CancellationToken));

            MainView.ShowForm += MainViewOnShowForm;
            MainView.CloseForm += MainViewOnCloseForm;
        }

        #endregion

        #region Public Methods

        public void Run()
        {
            MainView.Show();
        }

        #region Messages

        public void ClearInfoBlock()
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetContextRegularMessage(string message)
        {
            MainView.SetContextRegularMessage(message);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetContextFailMessage(string message)
        {
            MainView.SetContextFailMessage(message);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetContextAttentionMessage(string message)
        {
            MainView.SetContextAttentionMessage(message);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetContextPassedMessage(string message)
        {
            MainView.SetContextPassedMessage(message);
        }

        #endregion

        #endregion

        #region Private Methods

        #region Form

        private void MainViewOnCloseForm()
        {
            CancellationTokenSource.Cancel();
        }

        private async void MainViewOnShowForm()
        {
            await Task.Run(() => ConnectionStateTask(CancellationToken));
        }

        #endregion

        #region Task

        private Task<bool> ConnectionStateTask(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (!MainModel.GetStateConnectionOfSignalGenerator())
                {
                    try
                    {
                        MainModel.ConnectOfSignalGenerator();
                        MainView.SetContextPassedMessage("Соединение с генератором сигналов установлено");
                    }
                    catch (Exception exception)
                    {
                        MainView.SetContextFailMessage("Генератор сигналов недоступен: " + exception.Message);
                    }
                }

                if (!MainModel.GetStateConnectionOfPowerSupply())
                {
                    try
                    {
                        MainModel.ConnectOfPowerSupply();
                        MainView.SetContextPassedMessage("Соединение с источником питания установлено");
                    }
                    catch (Exception exception)
                    {
                        MainView.SetContextFailMessage("Источник питания недоступен: " + exception.Message);
                    }
                }

                Thread.Sleep(1000);
            }

            MainModel.DisconnectOfSignalGenerator();
            MainModel.DisconnectOfPowerSupply();

            return Task.FromResult<bool>(false);
        }

        #endregion

        #endregion
    }
}