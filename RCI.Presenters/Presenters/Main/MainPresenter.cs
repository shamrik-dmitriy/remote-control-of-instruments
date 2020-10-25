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
    /// <summary>
    ///     Презентер главной формы
    /// </summary>
    public class MainPresenter : IRichTextBoxView
    {
        #region Private Properties

        /// <summary>
        ///     Экземпляр формы
        /// </summary>
        private IMainView MainView { get; set; }

        /// <summary>
        ///     Экземпляр модели
        /// </summary>
        private IMainModel MainModel { get; set; }

        /// <summary>
        ///     Источник токена отмены
        /// </summary>
        private static CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        /// <summary>
        ///     Токен отмены
        /// </summary>
        private CancellationToken CancellationToken { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор презентера главной формы
        /// </summary>
        /// <param name="mainView">Экземпляр формы, реализующий соответствующий интерфейс</param>
        /// <param name="mainModel">Экземпляр модели, реализующий соответствующий интерфейс</param>
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

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
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