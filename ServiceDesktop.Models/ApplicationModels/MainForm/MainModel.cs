using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Core.Devices.N5746A;
using Core.Devices.SMB100A;
using Core.Properties;
using RCLD.Models.ComponentsAbstraction;

namespace RCLD.Models.ApplicationModels.MainForm
{
    public class MainModel : IMainModel
    {
        #region Public Enums, Events and Properties

        #region Public Enums

        /// <summary>
        ///     Device list
        /// </summary>
        public enum DeviceList
        {
            SignalGenerator,
            PowerSupply
        }

        #endregion

        #region Output Signal Generator

        public event Action GetDataPowerSupplyComplete;
        public event Action GetDataSignalGeneratorComplete;

        public event Func<bool> GetStateConnectionSignalGenerator;
        public event Func<bool> GetStateConnectionPowerSupply;

        public bool OutputModulationState { get; set; }
        public bool OutputRfState { get; set; }
        public double OutputFrequency { get; set; }
        public double OutputPow { get; set; }
        public double OutputPulseWidth { get; set; }
        public double OutputPulsePeriod { get; set; }
        public double OutputPulseDeviation { get; set; }
        public double OutputPulseDelay { get; set; }

        public Smb100A.Frequency FrequencySelector { get; set; }
        public Smb100A.Pow PowSelector { get; set; }
        public Smb100A.PulseWidth PulseWidthSelector { get; set; }
        public Smb100A.PulsePeriod PulsePeriodSelector { get; set; }
        public Smb100A.Deviation DeviationSelector { get; set; }
        public Smb100A.PulseDelay PulseDelaySelector { get; set; }

        #endregion

        #region Output Power Supply

        public double OutputVoltage { get; set; }
        public double OutputAmperage { get; set; }
        public double OutputMaxAmperage { get; set; }

        public bool OutputOutState { get; set; }

        #endregion

        #endregion

        #region Private Properties

        #region Input Signal Generator

        /// <summary>
        ///     Value of frequency
        /// </summary>
        private string InputFrequency { get; set; }

        /// <summary>
        ///     Value of pow
        /// </summary>
        private string InputPow { get; set; }

        /// <summary>
        ///     Value of pulse width
        /// </summary>
        private string InputPulseWidth { get; set; }

        /// <summary>
        ///     Value of pulse period
        /// </summary>
        private string InputPulsePeriod { get; set; }

        /// <summary>
        ///     Value of pulse delay
        /// </summary>
        private string InputPulseDelay { get; set; }

        /// <summary>
        ///     Value of deviation
        /// </summary>
        private string InputDeviation { get; set; }

        #endregion

        #region Input Power Supply

        /// <summary>
        ///     Value of voltage
        /// </summary>
        private string InputVoltageConstAmperage { get; set; }

        /// <summary>
        ///     Value of amperage
        /// </summary>
        private string InputMaxAmperageConsumption { get; set; }

        #endregion

        #region Other Fields

        /// <summary>
        ///     Value of name field
        /// </summary>
        private string NameField { get; set; }

        /// <summary>
        ///     Instance of signal generator
        /// </summary>
        private Smb100A SignalGenerator { get; set; }

        /// <summary>
        ///     Instance of power supply
        /// </summary>
        private N5746A PowerSupply { get; set; }

        /// <summary>
        ///     Interface component
        /// </summary>
        private IComponentModel ComponentModel { get; set; }

        #endregion

        #endregion

        #region Private Member Variables

        #region Cancellation Token

        /// <summary>
        ///     Token cancel of power supply
        /// </summary>
        private CancellationTokenSource CancellationTokenSourcePowerSupply { get; set; }

        /// <summary>
        ///     Token cancel of signal generator
        /// </summary>
        private CancellationTokenSource CancellationTokenSourceSignalGenerator { get; set; }

        #endregion

        #region Ratios for signal generator

        /// <summary>
        ///     Collection for multiple frequency
        /// </summary>
        private readonly Dictionary<Smb100A.Frequency, double> _frequencyRatio =
            new Dictionary<Smb100A.Frequency, double>()
            {
                {Smb100A.Frequency.Hz, 1},
                {Smb100A.Frequency.KHz, 0.001},
                {Smb100A.Frequency.Mhz, 0.000001},
                {Smb100A.Frequency.Ghz, 0.000000001},
            };

        /// <summary>
        ///     Collection for multiple pow
        /// </summary>
        private readonly Dictionary<Smb100A.Pow, double> _powRatio = new Dictionary<Smb100A.Pow, double>()
        {
            {Smb100A.Pow.Dbm, 1},
            {Smb100A.Pow.DBuV, Math.Round(10 * Math.Log10(50) + 90)}
        };

        /// <summary>
        ///     Collection for multiple pulse width
        /// </summary>
        private readonly Dictionary<Smb100A.PulseWidth, double> _pulseWidthRatio =
            new Dictionary<Smb100A.PulseWidth, double>()
            {
                {Smb100A.PulseWidth.S, 1},
                {Smb100A.PulseWidth.Ns, 1000000000},
                {Smb100A.PulseWidth.Ms, 1000},
                {Smb100A.PulseWidth.Us, 1000000},
            };

        /// <summary>
        ///     Collection for multiple pulse period
        /// </summary>
        private readonly Dictionary<Smb100A.PulsePeriod, double> _pulsePeriodRatio =
            new Dictionary<Smb100A.PulsePeriod, double>()
            {
                {Smb100A.PulsePeriod.S, 1},
                {Smb100A.PulsePeriod.Ns, 1000000000},
                {Smb100A.PulsePeriod.Ms, 1000},
                {Smb100A.PulsePeriod.Us, 1000000},
            };

        /// <summary>
        ///     Collection for multiple deviation
        /// </summary>
        private readonly Dictionary<Smb100A.Deviation, double> _pulseDeviationRatio =
            new Dictionary<Smb100A.Deviation, double>()
            {
                {Smb100A.Deviation.Hz, 1},
                {Smb100A.Deviation.KHz, 0.001},
                {Smb100A.Deviation.MHz, 0.000001},
            };

        /// <summary>
        ///     Collection for multiple pulse delay
        /// </summary>
        private readonly Dictionary<Smb100A.PulseDelay, double> _pulseDelayRatio =
            new Dictionary<Smb100A.PulseDelay, double>()
            {
                {Smb100A.PulseDelay.S, 1},
                {Smb100A.PulseDelay.Ns, 1000000000},
                {Smb100A.PulseDelay.Ms, 1000},
                {Smb100A.PulseDelay.Us, 1000000},
            };

        #endregion

        #region Selectors Parsing

        /// <summary>
        ///    Collection selectors for dependency of field type
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, Enum>> _selectorsDictionary =
            new Dictionary<string, Dictionary<string, Enum>>()
            {
                {
                    "InputFrequency", new Dictionary<string, Enum>()
                    {
                        {"Гц", Smb100A.Frequency.Hz},
                        {"кГц", Smb100A.Frequency.KHz},
                        {"мГц", Smb100A.Frequency.Mhz},
                        {"Ггц", Smb100A.Frequency.Ghz},
                    }
                },
                {
                    "InputPow", new Dictionary<string, Enum>()
                    {
                        {"дБм", Smb100A.Pow.Dbm},
                        {"дБмкв", Smb100A.Pow.DBuV},
                        {"нВ", Smb100A.Pow.Nv},
                        {"мкВ", Smb100A.Pow.Uv},
                        {"мВ", Smb100A.Pow.Mv},
                        {"В", Smb100A.Pow.V},
                    }
                },
                {
                    "InputPulseWidth", new Dictionary<string, Enum>()
                    {
                        {"с", Smb100A.PulseWidth.S},
                        {"нс", Smb100A.PulseWidth.Ns},
                        {"мс", Smb100A.PulseWidth.Ms},
                        {"мкс", Smb100A.PulseWidth.Us}
                    }
                },
                {
                    "InputPulsePeriod", new Dictionary<string, Enum>()
                    {
                        {"с", Smb100A.PulsePeriod.S},
                        {"нс", Smb100A.PulsePeriod.Ns},
                        {"мс", Smb100A.PulsePeriod.Ms},
                        {"мкс", Smb100A.PulsePeriod.Us}
                    }
                },
                {
                    "InputDeviation", new Dictionary<string, Enum>()
                    {
                        {"Гц", Smb100A.Deviation.Hz},
                        {"кГц", Smb100A.Deviation.KHz},
                        {"мГц", Smb100A.Deviation.MHz}
                    }
                },
                {
                    "InputPulseDelay", new Dictionary<string, Enum>()
                    {
                        {"с", Smb100A.PulseDelay.S},
                        {"нс", Smb100A.PulseDelay.Ns},
                        {"мс", Smb100A.PulseDelay.Ms},
                        {"мкс", Smb100A.PulseDelay.Us}
                    }
                },
            };

        #endregion

        #endregion

        #region Constructor

        public MainModel()
        {
        }

        #endregion

        #region Public Methods

        #region Power Supply

        public bool GetStatePowerSupply()
        {
            return GetStateConnectionSignalGenerator != null && GetStateConnectionSignalGenerator.Invoke();
        }

        public void CreateInstancePowerSupply()
        {
            PowerSupply = new N5746A(Device.Default.IP_ADDR_POWER_SUP, Device.Default.PORT_POWER_SUP);
        }

        public void DestroyOutputThreadPowerSupply()
        {
            CancellationTokenSourcePowerSupply?.CancelAfter(100);
        }

        public void CreateOutputThreadPowerSupply()
        {
            CancellationTokenSourcePowerSupply = new CancellationTokenSource();
            var taskPowerSupply = Task.Run(() => ThreadMethodPowerSupply(CancellationTokenSourcePowerSupply.Token),
                CancellationTokenSourcePowerSupply.Token);
        }

        public void SetPowerSupplyPowerControl(bool state)
        {
            if (!state)
            {
                PowerSupply.OutputStateOn();
            }
            else
            {
                PowerSupply.OutputStateOff();
            }
        }

        #endregion

        #region Signal Generator 

        public bool GetStateSignalGenerator()
        {
            return GetStateConnectionSignalGenerator != null && GetStateConnectionSignalGenerator.Invoke();
        }

        public void CreateInstanceSignalGenerator()
        {
            SignalGenerator = new Smb100A(Device.Default.IP_ADDR_SIGNAL_GEN, Device.Default.PORT_SIGNAL_GEN);
        }

        public void DestroyOutputThreadSignalGenerator()
        {
            CancellationTokenSourceSignalGenerator?.CancelAfter(100);
        }

        public void CreateOutputThreadSignalGenerator()
        {
            CancellationTokenSourceSignalGenerator = new CancellationTokenSource();
            var taskSignalGenerator = Task.Run(
                () => ThreadMethodSignalGenerator(CancellationTokenSourceSignalGenerator.Token),
                CancellationTokenSourceSignalGenerator.Token);
        }

        public void SetSignalGeneratorRfControl(bool state)
        {
            if (!state)
            {
                SignalGenerator.RfOutputStateOn();
            }
            else
            {
                SignalGenerator.RfOutputStateOff();
            }
        }

        public void SetSignalGeneratorModulationControl(bool state)
        {
            if (!state)
            {
                SignalGenerator.ModulationStateOn();
            }
            else
            {
                SignalGenerator.ModulationStateOff();
            }
        }

        #endregion

        /// <summary>
        ///     Validate field in form with/without analysis type selector
        ///     and writing result with current field
        /// </summary>
        /// <param name="nameField">Value of name field</param>
        /// <param name="valueField">Value of field</param>
        /// <param name="valueSelector">Value of selector, default = null</param>
        /// <returns>True - data in field is valid, value done for transit to device, False - data in field is not valid</returns>
        public bool Validate(string nameField, string valueField, string valueSelector = null)
        {
            try
            {
                NameField = nameField;

                if (valueSelector != null)
                {
                    ComponentModel = new TwoComponentBlocksModel(NameField, valueField, valueSelector);
                }
                else
                {
                    ComponentModel = new OneComponentBlocksModel(NameField, valueField);
                }

                if (ComponentModel.Validate())
                {
                    SetProperty(valueField);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///     Send parameters to device
        /// </summary>
        /// <param name="device">Device</param>
        /// <param name="valueSelector">Value of selector</param>
        public void SendToDevice(DeviceList device, string valueSelector)
        {
            switch (device)
            {
                case DeviceList.PowerSupply:
                {
                    switch (NameField)
                    {
                        case "InputVoltageConstAmperage":
                        {
                            PowerSupply.SetSupplyVoltage(Convert.ToDouble(InputVoltageConstAmperage));
                            break;
                        }

                        case "InputMaxAmperageConsumption":
                        {
                            PowerSupply.SetLowVoltageLim(Convert.ToDouble(InputMaxAmperageConsumption));
                            break;
                        }
                    }

                    break;
                }

                case DeviceList.SignalGenerator:
                {
                    switch (NameField)
                    {
                        case "InputFrequency":
                        {
                            SignalGenerator.SetFreq(Convert.ToDouble(InputFrequency),
                                (Smb100A.Frequency) _selectorsDictionary[NameField][valueSelector]);
                            break;
                        }

                        case "InputPow":
                        {
                            SignalGenerator.SetPow(Convert.ToDouble(InputPow),
                                (Smb100A.Pow) _selectorsDictionary[NameField][valueSelector]);
                            break;
                        }

                        case "InputPulseWidth":
                        {
                            SignalGenerator.SetPulseWidth(Convert.ToDouble(InputPulseWidth),
                                (Smb100A.PulseWidth) _selectorsDictionary[NameField][valueSelector]);
                            break;
                        }

                        case "InputPulsePeriod":
                        {
                            SignalGenerator.SetPulsePeriod(Convert.ToDouble(InputPulsePeriod),
                                (Smb100A.PulsePeriod) _selectorsDictionary[NameField][valueSelector]);
                            break;
                        }

                        case "InputDeviation":
                        {
                            SignalGenerator.SetFmDeviation(Convert.ToDouble(InputDeviation),
                                (Smb100A.Deviation) _selectorsDictionary[NameField][valueSelector]);
                            break;
                        }

                        case "InputPulseDelay":
                        {
                            SignalGenerator.SetPulseDelay(Convert.ToDouble(InputPulseDelay),
                                (Smb100A.PulseDelay) _selectorsDictionary[NameField][valueSelector]);
                            break;
                        }
                    }

                    break;
                }
            }
        }

        #endregion

        #region Private methods

        #region Task Realization

        /// <summary>
        ///     Realization task for output data from signal generator
        /// </summary>
        /// <param name="token">Cancel token</param>
        private void ThreadMethodSignalGenerator(CancellationToken token)
        {
            var signalGenerator = new Smb100A(
                Core.Properties.Device.Default.IP_ADDR_SIGNAL_GEN,
                Core.Properties.Device.Default.PORT_SIGNAL_GEN);

            while (true)
            {
                try
                {
                    token.ThrowIfCancellationRequested();

                    OutputFrequency = signalGenerator.GetFreqMhz() * _frequencyRatio[FrequencySelector];

                    OutputPow = Math.Round(PowSelector == Smb100A.Pow.Dbm
                        ? signalGenerator.GetPowdBm()
                        : signalGenerator.GetPowdBm() + _powRatio[PowSelector], 2);


                    OutputPulseWidth = signalGenerator.GetPulseWidth() * _pulseWidthRatio[PulseWidthSelector];
                    OutputPulsePeriod = signalGenerator.GetPulsePeriod() * _pulsePeriodRatio[PulsePeriodSelector];
                    OutputPulseDeviation =
                        signalGenerator.GetFreqDeviation() * _pulseDeviationRatio[DeviationSelector];
                    OutputPulseDelay = signalGenerator.GetPulseDelay() * _pulseDelayRatio[PulseDelaySelector];
                    OutputRfState = SignalGenerator.GetRfOutputState();
                    OutputModulationState = SignalGenerator.GetModulationState();

                    GetDataSignalGeneratorComplete?.Invoke();
                    Thread.Sleep(300);
                    GC.Collect();
                }
                catch (OperationCanceledException e)
                {
                    throw new Exception("Task is stopped");
                }
                catch (Exception exception)
                {
                    throw new Exception("Error of work with signal generator: " + exception.Message);
                }
            }
        }

        /// <summary>
        ///     Realization task for output data from power supply
        /// </summary>
        /// <param name="token">Cancel token</param>
        private void ThreadMethodPowerSupply(CancellationToken token)
        {
            var powerSupply = new N5746A(
                Core.Properties.Device.Default.IP_ADDR_POWER_SUP,
                Core.Properties.Device.Default.PORT_POWER_SUP);

            while (true)
            {
                try
                {
                    token.ThrowIfCancellationRequested();

                    OutputVoltage = powerSupply.GetVoltage();
                    OutputAmperage = powerSupply.GetCurrent();
                    OutputMaxAmperage = powerSupply.GetCurrentLimit();
                    OutputOutState = powerSupply.GetOutputState();

                    GetDataPowerSupplyComplete?.Invoke();
                    Thread.Sleep(300);
                    GC.Collect();
                }
                catch (OperationCanceledException e)
                {
                    throw new Exception("Task is stopped");
                }
                catch (Exception exception)
                {
                    throw new Exception("Error of work with power supply generator: " + exception.Message);
                }
            }
        }

        #endregion

        /// <summary>
        ///     Settings field values
        /// </summary>
        private void SetProperty(string valueField)
        {
            try
            {
                var propertyInfo = GetType().GetProperty(NameField, BindingFlags.NonPublic | BindingFlags.Instance);

                if (null != propertyInfo && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(this, valueField, null);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion
    }
}