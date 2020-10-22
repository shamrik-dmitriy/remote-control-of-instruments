using Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator.Enums;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator
{
    public interface ISignalGenerator : IScpiDevices
    {
        #region Modulation Control

        /// <summary>
        ///     Устанавливает состояние модуляции в соответствии с <see cref="state" />
        /// </summary>
        /// <param name="state">True - включить модуляцию, False - выключить модуляцию</param>
        void SetModulationState(bool state);

        /// <summary>
        ///     Возвращает состояние модуляции
        /// </summary>
        /// <returns>True - модуляция включена, False - модуляция выключена</returns>
        bool GetModulationState();

        #endregion

        #region RF Control

        /// <summary>
        ///     Устанавливает состояние RF-выхода в соответствии с <see cref="state" />
        /// </summary>
        /// <param name="state">True - включить, False - выключить</param>
        void SetRfOutputState(bool state);

        /// <summary>
        ///     Возвращает состояние RF-выхода
        /// </summary>
        /// <returns>True - выход включен, False - выход выключен</returns>
        bool GetRfOutputState();

        #endregion

        #region Pulse Modulation

        /// <summary>
        ///     Устанавливает значение выбранной полярности входного сигнала на коннекторе лицевой панели
        ///     согласно <see cref="PulseModulationExternalPolarity" />
        /// </summary>
        /// <param name="pulseModulationExternalPolarity">
        ///     <see cref="PulseModulationExternalPolarity" />
        /// </param>
        void SetPulseModulationExternalPolarity(PulseModulationExternalPolarity pulseModulationExternalPolarity);

        /// <summary>
        ///     Возвращает значение выбранной полярности входного сигнала на коннекторе лицевой панели
        /// </summary>
        /// <returns>Значение выбранной полярности входного сигнала</returns>
        string GetPulseModulationExternalPolarity();

        /// <summary>
        ///     Устанавливает задержку импульса для внутреннего генератора импульсов
        /// </summary>
        /// <param name="delay">Значение задержки импульса для внутреннего генератора импульсов</param>
        /// <param name="pulseDelay">
        ///     <see cref="PulseDelay" />
        /// </param>
        void SetPulseModulationInternalDelay(double delay, PulseDelay pulseDelay);

        /// <summary>
        ///     Возвращает значение задержки импульса для внутреннего генератора импульсов
        /// </summary>
        /// <returns>Значение задержки импульса для внутреннего генератора импульсов</returns>
        double GetPulseModulationInternalDelay();

        /// <summary>
        ///     Устанавливает скорость импульсов внутри генерируемой площади волны
        /// </summary>
        /// <param name="freq">Значение скорости импульсов внутри генерируемой площади волны</param>
        void SetPulseModulationInternalFrequency(double freq, Frequency type = Frequency.Mhz);

        /// <summary>
        ///     Возвращает значение скорости импульсов внутри генерируемой площади волны
        /// </summary>
        /// <returns>Значение скорости импульсов внутри генерируемой площади волны</returns>
        double GetPulseModulationInternalFrequency();

        /// <summary>
        ///     Устанавливает значение периода импульса для внутреннего генератора импульсов
        /// </summary>
        /// <param name="pulsePeriod">Значение периода импульса</param>
        /// <param name="type">Тип периода импульса <see cref="PulsePeriod" /></param>
        void SetPulseModulationInternalPeriod(double pulsePeriod, PulsePeriod type);

        /// <summary>
        ///     Возвращает значение периода импульса для внутреннего генератора импульсов
        /// </summary>
        /// <returns>Значение периода импульса для внутреннего генератора импульсов</returns>
        double GetPulseModulationInternalPeriod();

        /// <summary>
        ///     Устанавливает значение ширины импульсов для внутреннего генератора импульсов
        /// </summary>
        /// <param name="width">Значение ширины</param>
        /// <param name="type">
        ///     <see cref="PulseWidth" />
        /// </param>
        void SetPulseModulationInternalPulseWidth(double width, PulseWidth type);

        /// <summary>
        ///     Возвращает значение ширины импульсов дял внутреннего генератора импульсов
        /// </summary>
        /// <returns></returns>
        double GetPulseModulationInternalPulseWidth();

        /// <summary>
        ///     Устанавливает схему модялции согласно <see cref="PulseModulationInternal" /> дял внутреннего генератора сигналов
        /// </summary>
        /// <param name="type">
        ///     <see cref="PulseModulationInternal" />
        /// </param>
        void SetPulseModulationInternal(PulseModulationInternal type);

        /// <summary>
        ///     Возвращает схему модуляции для внутреннего генератор сигналов
        /// </summary>
        /// <returns></returns>
        double GetPulseModulationInternal();

        /// <summary>
        ///     Устанавливает источник импульсной модуляции в соответствии с <see cref="PulseModulationSource" />
        /// </summary>
        /// <param name="pulseModulationSource">
        ///     <see cref="PulseModulationSource" />
        /// </param>
        void SetPulseModulationInternalSource(PulseModulationSource pulseModulationSource);

        /// <summary>
        ///     Возвращает значение выбранного источника импульсной модуляции
        /// </summary>
        /// <returns>Возвращает значение выбранного источника импульсной модуляции</returns>
        string GetPulseModulationInternalSource();

        /// <summary>
        ///     Управляет состояние имульсной модуляции
        /// </summary>
        /// <param name="state">True - включить, False - выключить</param>
        void SetPulseModulationState(bool state);

        /// <summary>
        ///     Возвращает состояние импульсной модуляции
        /// </summary>
        /// <returns>True - импульсная модуляция включена, False - импульсная модуляция выключена</returns>
        bool GetPulseModulationState();

        #endregion

        #region Set Parameters

        /// <summary>
        ///     Устанвливает частоту излучаемого сигнала
        /// </summary>
        /// <param name="frequency">Значение частоты излучаемого сигнала</param>
        /// <param name="type"><see cref="Frequency" />, по умолчанию <see cref="Frequency.Mhz" /></param>
        void SetFrequency(double frequency, Frequency type = Frequency.Mhz);

        /// <summary>
        ///     Устанавливает мощность излучаемого сигнала
        /// </summary>
        /// <param name="powLevel">Значение мощности излучаемого сигнала</param>
        /// <param name="type"><see cref="Pow" />, по умолчанию <see cref="Pow.Dbm" /></param>
        void SetPowLevel(double powLevel, Pow type = Pow.Dbm);

        /// <summary>
        ///     Устанавливет длительность импульса, согласно <see cref="PulseWidth" />:
        /// </summary>
        /// <param name="width">Значение длительности импульса</param>
        /// <param name="pulseWidth">
        ///     <see cref="PulseWidth" />
        /// </param>
        void SetPulseWidth(double width, PulseWidth pulseWidth);

        /// <summary>
        ///     Устанавливет период генерации импульса, согласно  <see cref="PulsePeriod" />
        /// </summary>
        /// <param name="period">Значение периода генерации импульса</param>
        /// <param name="pulsePeriod">
        ///     <see cref="PulsePeriod" />
        /// </param>
        void SetPulsePeriod(double period, PulsePeriod pulsePeriod);

        /// <summary>
        ///     Устанавливет задержку между импульсами, согласно <see cref="PulseDelay" />
        /// </summary>
        /// <param name="delay">Значение задержки между импульсами</param>
        /// <param name="pulseDelay">
        ///     <see cref="PulseDelay" />
        /// </param>
        void SetPulseDelay(double delay, PulseDelay pulseDelay);

        #endregion

        #region Get Parameteres

        /// <summary>
        ///     Возвращает установленное значение частоты излучаемого сигнала
        /// </summary>
        /// <returns>Значение частоты излучаемого сигнала</returns>
        double GetFrequency();

        /// <summary>
        ///     Возвращает значение мощности излучаемого сигнала
        /// </summary>
        /// <returns>Значение мощности излучаемого сигнала</returns>
        double GetPowLevel();

        /// <summary>
        ///     Возвращает значение ширины импульса
        /// </summary>
        /// <returns>Значение ширины импульса</returns>
        double GetPulseWidth();

        /// <summary>
        ///     Возвращает значение периода генерации импульса
        /// </summary>
        /// <returns>Значение периода генерации импульса</returns>
        double GetPulsePeriod();

        /// <summary>
        ///     Возвращает значение задержки между импульсами
        /// </summary>
        /// <returns>Значение задержки между импульсами</returns>
        double GetPulseDelay();

        /// <summary>
        ///     Возвращает значение девиации
        /// </summary>
        /// <returns>Значение девиации</returns>
        double GetFrequencyDeviation();

        #endregion
    }
}