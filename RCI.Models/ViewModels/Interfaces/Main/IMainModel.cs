using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.Models.ViewModels.Interfaces.Main
{
    /// <summary>
    ///     Интерфейс для главной формы
    /// </summary>
    public interface IMainModel
    {
        #region Methods

        /// <summary>
        ///     Осуществляет соединение с генератором сигналов
        /// </summary>
        void ConnectOfSignalGenerator();

        /// <summary>
        ///     Осуществляет соединение с источником питания
        /// </summary>
        void ConnectOfPowerSupply();

        /// <summary>
        ///     Разрывает соединение с генератором сигналов
        /// </summary>
        void DisconnectOfSignalGenerator();

        /// <summary>
        ///     Разрывает соединение с источником питания
        /// </summary>
        void DisconnectOfPowerSupply();

        /// <summary>
        ///     Получает состояние соединения с генератором сигналов
        /// </summary>
        /// <returns>True - соединение установлено, False - соединение разорвано или отсутствует</returns>
        bool GetStateConnectionOfSignalGenerator();

        /// <summary>
        ///     Получает состояние соединения с источником питания
        /// </summary>
        /// <returns>True - соединение установлено, False - соединение разорвано или отсутствует</returns>
        bool GetStateConnectionOfPowerSupply();

        #endregion
    }
}