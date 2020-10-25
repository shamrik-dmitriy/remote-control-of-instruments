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

            MainView.ShowForm += MainViewOnShowForm;
            MainView.CloseForm += MainViewOnCloseForm;
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Запускает показ формы
        /// </summary>
        public void Run()
        {
            MainView.Show();
        }

        #region Messages

        public void ClearInfoBlock()
        {
            MainView.ClearInfoBlock();
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

        /// <summary>
        ///     Событие закрытия формы, отменяет поток проверки соединения с устройствами
        /// </summary>
        private void MainViewOnCloseForm()
        {
            CancellationTokenSource.Cancel();
        }

        /// <summary>
        ///     Событие показа формы, запускает поток проверки соединения с устройствами
        /// </summary>
        private async void MainViewOnShowForm()
        {
            await Task.Run(() => ConnectionStateTask(CancellationToken));
        }

        #endregion

        #region Task

        /// <summary>
        ///     Поток проверки соединения с устройствами
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Нет необходимости в анализе возвращаемого значения. Сделано для использования Task.Run</returns>
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

            return Task.FromResult(false);
        }

        #endregion

        #endregion
    }
}