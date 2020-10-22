using System;
using Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator.Enums;
using IExchangeService = Shamrik.Dmitriy.Devices.Exchanges.IExchangeService;

namespace Shamrik.Dmitriy.Devices.SCPIDevices.SignalGenerator
{
    /// <summary>
    ///     Предоставляет программное управление генератором сигналов
    /// </summary>
    public class SignalGenerator : ISignalGenerator
    {
        #region Constructor

        /// <summary>
        ///     Конструктор, создаёт генератор сигналов.
        ///     Для соединения используется коннектор <see cref="exchange" />
        /// </summary>
        /// <param name="exchange">Коннектор</param>
        public SignalGenerator(IExchangeService exchange)
        {
            try
            {
                E8257D = new E8257D(exchange);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Private properties

        /// <summary>
        ///     Экземпляр генератора сигналов
        /// </summary>
        private E8257D E8257D { get; }

        #endregion

        #region Public Methods

        #region Controls

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Reset()
        {
            E8257D.Reset();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string Identification()
        {
            return E8257D.Identification();
        }

        public bool GetOpc()
        {
            return E8257D.GetOpc();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetOpc(bool enabled)
        {
            E8257D.SetOpc(enabled);
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public int Test()
        {
            return E8257D.Test();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetError()
        {
            return E8257D.GetError();
        }

        #endregion

        #region Modulation Control

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetModulationState(bool state)
        {
            try
            {
                E8257D.SetModulationState(state);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetModulationState()
        {
            try
            {
                return E8257D.GetModulationState();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region RF Control

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetRfOutputState(bool state)
        {
            try
            {
                E8257D.SetRfOutputState(state);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetRfOutputState()
        {
            try
            {
                return E8257D.GetRfOutputState();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Pulse Modulation

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationExternalPolarity(PulseModulationExternalPolarity pulseModulationExternalPolarity)
        {
            try
            {
                E8257D.SetPulseModulationExternalPolarity(pulseModulationExternalPolarity);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetPulseModulationExternalPolarity()
        {
            try
            {
                return E8257D.GetPulseModulationExternalPolarity();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationInternalDelay(double delay, PulseDelay pulseDelay)
        {
            try
            {
                E8257D.SetPulseModulationInternalDelay(delay, pulseDelay);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseModulationInternalDelay()
        {
            try
            {
                return E8257D.GetPulseModulationInternalDelay();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationInternalFrequency(double freq, Frequency type = Frequency.Mhz)
        {
            try
            {
                E8257D.SetPulseModulationInternalFrequency(freq, type);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseModulationInternalFrequency()
        {
            try
            {
                return E8257D.GetPulseModulationInternalFrequency();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationInternalPeriod(double pulsePeriod, PulsePeriod type)
        {
            try
            {
                E8257D.SetPulseModulationInternalPeriod(pulsePeriod, type);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseModulationInternalPeriod()
        {
            try
            {
                return E8257D.GetPulseModulationInternalPeriod();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationInternalPulseWidth(double width, PulseWidth type)
        {
            try
            {
                E8257D.SetPulseModulationInternalPulseWidth(width, type);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseModulationInternalPulseWidth()
        {
            try
            {
                return E8257D.GetPulseModulationInternalPulseWidth();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationInternal(PulseModulationInternal type)
        {
            try
            {
                E8257D.SetPulseModulationInternal(type);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseModulationInternal()
        {
            try
            {
                return E8257D.GetPulseModulationInternal();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationInternalSource(PulseModulationSource pulseModulationSource)
        {
            try
            {
                E8257D.SetPulseModulationInternalSource(pulseModulationSource);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string GetPulseModulationInternalSource()
        {
            try
            {
                return E8257D.GetPulseModulationInternalSource();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseModulationState(bool state)
        {
            try
            {
                E8257D.SetPulseModulationState(state);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public bool GetPulseModulationState()
        {
            try
            {
                return E8257D.GetPulseModulationState();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Set Data

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetFrequency(double frequency, Frequency type = Frequency.Mhz)
        {
            try
            {
                E8257D.SetFrequency(frequency, type);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPowLevel(double powLevel, Pow type = Pow.Dbm)
        {
            try
            {
                E8257D.SetPowLevel(powLevel, type);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseWidth(double width, PulseWidth pulseWidth)
        {
            try
            {
                E8257D.SetPulseWidth(width, pulseWidth);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulsePeriod(double period, PulsePeriod pulsePeriod)
        {
            try
            {
                E8257D.SetPulsePeriod(period, pulsePeriod);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void SetPulseDelay(double delay, PulseDelay pulseDelay)
        {
            try
            {
                E8257D.SetPulseDelay(delay, pulseDelay);
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #region Get Data

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetFrequency()
        {
            try
            {
                return E8257D.GetFrequency();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPowLevel()
        {
            try
            {
                return E8257D.GetPowLevel();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseWidth()
        {
            try
            {
                return E8257D.GetPulseWidth();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulsePeriod()
        {
            try
            {
                return E8257D.GetPulsePeriod();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetPulseDelay()
        {
            try
            {
                return E8257D.GetPulseDelay();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public double GetFrequencyDeviation()
        {
            try
            {
                return E8257D.GetFrequencyDeviation();
            }
            catch (Exception exception)
            {
                throw new SignalGeneratorException(exception.Message);
            }
        }

        #endregion

        #endregion
    }
}