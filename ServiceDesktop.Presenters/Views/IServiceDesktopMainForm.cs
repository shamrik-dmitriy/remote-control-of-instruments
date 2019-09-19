using System;
using Core.Devices.SMB100A;

namespace ServiceDesktop.Presenter.Views
{
    public interface IServiceDesktopMainForm
    {
        /// <summary>
        ///     Переопределение события показа формы
        /// </summary>
        event EventHandler ShowingForm;

        /// <summary>
        ///     Переопределение события закрытия формы
        /// </summary>
        event EventHandler ClosingForm;

        /// <summary>
        ///     Событие на установку значения постоянного тока
        /// </summary>
        event Action<string, string> GetVoltage;

        /// <summary>
        ///     Событие на установку значения максимального тока потребления
        /// </summary>
        event Action<string, string> GetAmperage;

        /// <summary>
        ///     Событие на установку значения частоты сигнала
        /// </summary>
        event Action<string, string, string> GetFrequency;

        /// <summary>
        ///     Событие на установку значения мощности сигнала
        /// </summary>
        event Action<string, string, string> GetPow;

        /// <summary>
        ///     Событие на установку значения длительности импульса сигнала
        /// </summary>
        event Action<string, string, string> GetPulseWidth;

        /// <summary>
        ///     Событие на установку значения частоты повторения сигнала
        /// </summary>
        event Action<string, string, string> GetPulsePeriod;

        /// <summary>
        ///     Событие на установку значения девиации сигнала
        /// </summary>
        event Action<string, string, string> GetDeviation;

        /// <summary>
        ///     Событие на установку значения задержки между импульсами
        /// </summary>
        event Action<string, string, string> GetPulseDelay;

        event Action<bool> GetPowerSupplyPowerControl;
        event Action<bool> GetSignalGeneratorRfControl;
        event Action<bool> GetSignalGeneratorModulationControl;
        event Action GetSignalGeneratorReset;

        event Action<Smb100A.Frequency> SelectFrequencySignalGenerator;
        event Action<Smb100A.Pow> SelectPowSignalGenerator;
        event Action<Smb100A.Deviation> SelectDeviationSignalGenerator;
        event Action<Smb100A.PulseDelay> SelectPulseDelaySignalGenerator;
        event Action<Smb100A.PulsePeriod> SelectPulsePeriodSignalGenerator;
        event Action<Smb100A.PulseWidth> SelectPulseWidthSignalGenerator;
        event Action<Smb100A.SelectMode> SelectModeSignalGenerator;

        void SetErrorField(string fieldName);

        /// <summary>
        ///     Устанавливает значение индекса всех комбобоксов в заданное значение
        /// </summary>
        /// <param name="number">Значение</param>
        void SetAllCombobox(int number);

        /// <summary>
        ///     Устанавливает свойство Enabled групбокса генератора сигналов в заданное состояние
        /// </summary>
        /// <param name="isEnabled">True - активно, False - не активно</param>
        void SetEnabledGroupBoxSignalGenerator(bool isEnabled);

        /// <summary>
        ///     Устанавливает свойство Enabled групбокса источника питания в заданное состояние
        /// </summary>
        /// <param name="isEnabled">True - активно, False - не активно</param>
        void SetEnabledGroupBoxPowerSupply(bool isEnabled);

        /// <summary>
        ///     Устанавливает значение поля внутри класса
        /// </summary>
        /// <param name="fieldName">Имя поля</param>
        /// <param name="fieldValue">Значение, которое необходимо задать полю</param>
        void SetOutputData(string fieldName, string fieldValue);

        /// <summary>
        ///     Устанавливает значение поля внутри класса
        /// </summary>
        /// <param name="fieldName">Имя поля</param>
        /// <param name="fieldValue">Значение, которое необходимо задать полю</param>
        void SetOutputData(string fieldName, bool fieldState);

        void Show();

        void Close();
    }
}
