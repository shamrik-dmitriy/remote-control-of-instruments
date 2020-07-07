using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using RCLD.Presenter.Views;

namespace RCLD.Views
{
    public partial class MainView : Form, IMainView
    {
        #region Private Properties

        #region Input Data

        /// <summary>
        ///     Input voltage value
        /// </summary>
        private TextBox VoltageInput => InputVoltageConstAmperage;

        /// <summary>
        ///     Input amperage value
        /// </summary>
        private TextBox AmperageInput => InputMaxAmperageConsumption;

        /// <summary>
        ///     Input frequency value
        /// </summary>
        private TextBox FrequencyInput => InputFrequency;

        /// <summary>
        ///     Input frequency type value
        /// </summary>
        private string FrequencyType => comboBoxFrequencyValue.Text;

        /// <summary>
        ///     Input pow value
        /// </summary>
        private TextBox PowInput => InputPow;

        /// <summary>
        ///     Input pow type value
        /// </summary>
        private string PowType => comboBoxPowValue.Text;

        /// <summary>
        ///     Input pulse width value
        /// </summary>
        private TextBox PulseWidthInput => InputPulseWidth;

        /// <summary>
        ///     Input pulse width type value
        /// </summary>
        private string PulseWidthType => comboBoxPulseWidthValue.Text;

        /// <summary>
        ///     Input pulse period value
        /// </summary>
        private TextBox PulsePeriodInput => InputPulsePeriod;

        /// <summary>
        ///     Input pulse period type value
        /// </summary>
        private string PulsePeriodType => comboBoxPulsePeriodValue.Text;
        
        /// <summary>
        ///     Input pulse delay value
        /// </summary>
        private TextBox PulseDelayInput => InputPulseDelay;

        /// <summary>
        ///     Input pulse delay type value
        /// </summary>
        private string PulseDelayType => comboBoxPulseDelayValue.Text;

        #endregion

        #region Output Data

        /// <summary>
        ///     Field "Maximal amperage"
        /// </summary>
        private string MaxAmperageConsumptionOutput
        {
            set
            {
                OutputMaxAmperageConsumption.BeginInvoke(
                    (Action) (() => { OutputMaxAmperageConsumption.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Voltage const current"
        /// </summary>
        private string VoltageConstAmperageOutput
        {
            set
            {
                OutputVoltageConstAmperage.BeginInvoke(
                    (Action) (() => { OutputVoltageConstAmperage.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Current"
        /// </summary>
        private string AmperageOutput
        {
            set
            {
                OutputAmperage.BeginInvoke(
                    (Action) (() => { OutputAmperage.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Frequency"
        /// </summary>
        private string FrequencyOutput
        {
            set
            {
                OutputFrequency.BeginInvoke(
                    (Action) (() => { OutputFrequency.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Pow"
        /// </summary>
        private string PowOutput
        {
            set
            {
                OutputPow.BeginInvoke(
                    (Action) (() => { OutputPow.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Pulse width"
        /// </summary>
        private string PulseWidthOutput
        {
            set
            {
                OutputPulseWidth.BeginInvoke(
                    (Action) (() => { OutputPulseWidth.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Pulse period"
        /// </summary>
        private string PulsePeriodOutput
        {
            set
            {
                OutputPulsePeriod.BeginInvoke(
                    (Action) (() => { OutputPulsePeriod.Text = value; }));
            }
        }

        /// <summary>
        ///     Field "Pulse delay"
        /// </summary>
        private string PulseDelayOutput
        {
            set
            {
                OutputPulseDelay.BeginInvoke(
                    (Action) (() => { OutputPulseDelay.Text = value; }));
            }
        }

        /// <summary>
        ///     Control turn on/off power output
        /// </summary>
        private bool OutControlPowerSupply
        {
            set
            {
                ControlPowerSupplyOut.BeginInvoke((Action) (() =>
                {
                    ControlPowerSupplyOut.BackColor = value ? Color.Lime : Color.Transparent;

                    ControlPowerSupplyOut.Text =
                        value ? "Выход источника питания включён" : "Включить выход источника питания";
                }));
            }
        }

        /// <summary>
        ///     Control turn on/off rf output
        /// </summary>
        private bool OutControlSignalGeneratorRf
        {
            set
            {
                ControlSignalGeneratorRfOut.BeginInvoke((Action) (() =>
                {
                    ControlSignalGeneratorRfOut.BackColor = value ? Color.Lime : Color.Transparent;

                    ControlSignalGeneratorRfOut.Text =
                        value ? "RF включён" : "Включить RF";
                }));
            }
        }

        /// <summary>
        ///     Control turn on/off modulation output
        /// </summary>
        private bool OutControlSignalGeneratorModulation
        {
            set
            {
                ControlSignalGeneratorModulationOut.BeginInvoke((Action) (() =>
                {
                    ControlSignalGeneratorModulationOut.BackColor = value ? Color.Lime : Color.Transparent;

                    ControlSignalGeneratorModulationOut.Text =
                        value ? "Модуляция включёна" : "Модуляция выключена";
                }));
            }
        }

        /// <summary>
        ///     Set Enabled / Disabled Power Supply ToolStrip button
        /// </summary>
        private bool ToolStripDropDownButtonPowerSupplyState
        {
            set => ToolStripBottomPowerSupply.Enabled = value;
        }

        /// <summary>
        ///     Set Enabled / Disabled Signal Generator ToolStrip button
        /// </summary>
        private bool ToolStripDropDownButtonSignalGeneratorState
        {
            set => ToolStripBottomSignalGenerator.Enabled = value;
        }

        #endregion

        #endregion

        #region Public Properties

        /// <summary>
        ///     Title Text Form
        /// </summary>
        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        #endregion

        #region Public Events

        public event EventHandler ShowingForm;
        public event EventHandler ClosingForm;

        public event Action<string, string> GetVoltage;
        public event Action<string, string> GetAmperage;
        public event Action<string, string, string> GetFrequency;
        public event Action<string, string, string> GetPow;
        public event Action<string, string, string> GetPulseWidth;
        public event Action<string, string, string> GetPulsePeriod;
        public event Action<string, string, string> GetDeviation;
        public event Action<string, string, string> GetPulseDelay;

        public event Action<bool> GetPowerSupplyPowerControl;
        public event Action<bool> GetSignalGeneratorRfControl;
        public event Action<bool> GetSignalGeneratorModulationControl;
        public event Action GetSignalGeneratorReset;

        public event Action<Smb100A.Frequency> SelectFrequencySignalGenerator;
        public event Action<Smb100A.Pow> SelectPowSignalGenerator;
        public event Action<Smb100A.Deviation> SelectDeviationSignalGenerator;
        public event Action<Smb100A.PulseDelay> SelectPulseDelaySignalGenerator;
        public event Action<Smb100A.PulsePeriod> SelectPulsePeriodSignalGenerator;
        public event Action<Smb100A.PulseWidth> SelectPulseWidthSignalGenerator;
        public event Action<Smb100A.SelectMode> SelectModeSignalGenerator;

        public event Action CheckConnectionPowerSupply;
        public event Action CheckConnectionSignalGenerator;

        #endregion

        #region Constructor

        /// <summary>
        ///     Initialization parameters for main form
        /// </summary>
        public MainView()
        {
            try
            {
                InitializeComponent();
                Icon = Properties.Resources.monitor;
                Text = Program.Title;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion

        #region Public Methods

        #region Combobox Actions

        public void SetAllCombobox(int number)
        {
            comboBoxFrequencyValue.SelectedIndex = number;
            comboBoxPowValue.SelectedIndex = number;
            comboBoxPulseWidthValue.SelectedIndex = number;
            comboBoxPulsePeriodValue.SelectedIndex = number;
            comboBoxPulseDelayValue.SelectedIndex = number;
        }

        #endregion

        #region Groupbox Action

        public void SetEnabledGroupBoxSignalGenerator(bool isEnabled)
        {
            groupBoxSignalGenerator.Enabled = isEnabled;
        }

        public void SetEnabledGroupBoxPowerSupply(bool isEnabled)
        {
            groupBoxPowerSupply.Enabled = isEnabled;
        }

        #endregion

        #region ToolBox Actions

        public void SetStateButtonCheckPowerSupply(bool statePowerSupply)
        {
            ToolStripDropDownButtonPowerSupplyState = statePowerSupply;
        }

        public void SetStateButtonCheckSignalGenerator(bool stateSignalGenerator)
        {
            ToolStripDropDownButtonSignalGeneratorState = stateSignalGenerator;
        }

        #endregion

        #region Output Data Information 

        public void SetOutputData(string fieldName, string fieldValue)
        {
            SetOutputPropertiesData(fieldName, fieldValue);
        }

        public void SetOutputData(string fieldName, bool fieldState)
        {
            SetOutputPropertiesData(fieldName, fieldState);
        }

        public void SetErrorField(string fieldName)
        {
            foreach (Control control in Controls)
            {
                if (control.Name.Equals(fieldName))
                {
                    var t = new Stopwatch();
                    t.Restart();
                    while (t.ElapsedMilliseconds <= 20000)
                    {
                        //((TextBox)control).BeginInvoke(() => { })
                        ((TextBox) control).BackColor = Color.LightPink;
                        Thread.Sleep(500);
                        ((TextBox) control).BackColor = Color.White;
                    }

                    ((TextBox) control).BackColor = Color.White;
                }
            }
        }

        #endregion

        #region Form Action

        //TODO :RUN

        #endregion

        #endregion

        #region Private Methods

        #region Set Properties Values

        private void SetOutputPropertiesData(string fieldName, object obj)
        {
            try
            {
                var propertyInfo = GetType().GetProperty(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);

                if (null != propertyInfo && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(this, obj, null);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion

        #region Form Action

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Update();
            ShowingForm?.Invoke(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosingForm?.Invoke(sender, e);
        }

        private void AboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var aboutSoftware = new AboutSoftware();
            // aboutSoftware.ShowDialog();
        }

        #endregion

        #region Button Actions

        private void buttonSetVoltage_Click(object sender, EventArgs e)
        {
            GetVoltage?.Invoke(VoltageInput.Name, VoltageInput.Text);
        }

        private void buttonSetAmperage_Click(object sender, EventArgs e)
        {
            GetAmperage?.Invoke(AmperageInput.Name, AmperageInput.Text);
        }

        private void buttonSetFrequency_Click(object sender, EventArgs e)
        {
            GetFrequency?.Invoke(FrequencyInput.Name, FrequencyInput.Text, FrequencyType);
        }

        private void buttonSetPow_Click(object sender, EventArgs e)
        {
            GetPow?.Invoke(PowInput.Name, PowInput.Text, PowType);
        }

        private void buttonSetPulseWidth_Click(object sender, EventArgs e)
        {
            GetPulseWidth?.Invoke(PulseWidthInput.Name, PulseWidthInput.Text, PulseWidthType);
        }

        private void buttonSetPulsePeriod_Click(object sender, EventArgs e)
        {
            GetPulsePeriod?.Invoke(PulsePeriodInput.Name, PulsePeriodInput.Text, PulsePeriodType);
        }

        private void buttonSetPulseDelay_Click(object sender, EventArgs e)
        {
            GetPulseDelay?.Invoke(PulseDelayInput.Name, PulseDelayInput.Text, PulseDelayType);
        }

        private bool GetStatePowerOutcontrol()
        {
            return ControlPowerSupplyOut.BackColor == Color.Lime;
        }

        private bool GetStateRfControl()
        {
            return ControlSignalGeneratorRfOut.BackColor == Color.Lime;
        }

        private bool GetStateModulationControl()
        {
            return ControlSignalGeneratorModulationOut.BackColor == Color.Lime;
        }

        private void buttonControlPowerSupplyOut_Click(object sender, EventArgs e)
        {
            GetPowerSupplyPowerControl?.Invoke(GetStatePowerOutcontrol());
        }

        private void buttonControlSignalGeneratorRFOut_Click(object sender, EventArgs e)
        {
            GetSignalGeneratorRfControl?.Invoke(GetStateRfControl());
        }


        private void buttonControlSignalGeneratorModulation_Click(object sender, EventArgs e)
        {
            GetSignalGeneratorModulationControl?.Invoke(GetStateModulationControl());
        }

        private void buttonControlSignalGeneratorReset_Click(object sender, EventArgs e)
        {
            //   GetSignalGeneratorReset?.Invoke(sender, e);
        }

        private void ToolStripCheckConnectionPowerSupply_Click(object sender, EventArgs e)
        {
            CheckConnectionPowerSupply?.Invoke();
        }

        private void ToolStripCheckConnectionSignalGenerator_Click(object sender, EventArgs e)
        {
            CheckConnectionSignalGenerator?.Invoke();
        }

        #endregion

        #region Combobox Actions

        private void comboBoxFrequencyValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectFrequencySignalGenerator?.Invoke((Smb100A.Frequency) comboBoxFrequencyValue.SelectedIndex);
        }

        private void comboBoxPowValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPowSignalGenerator?.Invoke((Smb100A.Pow) comboBoxPowValue.SelectedIndex);
        }

        private void comboBoxPulseWidthValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPulseWidthSignalGenerator?.Invoke((Smb100A.PulseWidth) comboBoxPulseWidthValue.SelectedIndex);
        }

        private void comboBoxRepeatFrequencyValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPulsePeriodSignalGenerator?.Invoke((Smb100A.PulsePeriod) comboBoxPulsePeriodValue.SelectedIndex);
        }

        private void comboBoxPulseDelayValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectPulseDelaySignalGenerator?.Invoke((Smb100A.PulseDelay) comboBoxPulseDelayValue.SelectedIndex);
        }

        #endregion

        #endregion

        public new void Show()
        {
            CheckMultipleRunningSoftware();
        }

        /// <summary>
        ///     Проверка запущенных экземпляров ПО и запуск одного экземпляра
        /// </summary>
        private void CheckMultipleRunningSoftware()
        {
            using (var mutex = new Mutex(false, Process.GetCurrentProcess().ProcessName))
            {
                if (mutex.WaitOne(TimeSpan.FromSeconds(3)))
                {
                    RunApplication();
                }
                else
                {
                    ProcessingMultipleRunningSoftware();
                }
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        ///     Обработка при повторном запуске экземпляра ПО
        /// </summary>
        private static void ProcessingMultipleRunningSoftware()
        {
            try
            {
                if (MessageBox.Show(@"Один экземпляр приложения уже запущен.\n Показать окно приложения?",
                        @"Приложение уже запущено", MessageBoxButtons.YesNo, MessageBoxIcon.Information) !=
                    DialogResult.Yes) return;
                var currentProcess = Process.GetCurrentProcess();
                foreach (var process in Process.GetProcessesByName(currentProcess.ProcessName))
                {
                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///     Запуск приложения
        /// </summary>
        private void RunApplication()
        {
            try
            {
                Application.Run(this);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}