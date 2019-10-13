namespace ServiceDesktop.Views.MainFormView
{
    partial class MainView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.buttonSetPulsePeriod = new System.Windows.Forms.Button();
            this.comboBoxPulsePeriodValue = new System.Windows.Forms.ComboBox();
            this.OutputPulsePeriod = new System.Windows.Forms.TextBox();
            this.InputPulsePeriod = new System.Windows.Forms.TextBox();
            this.ControlSignalGeneratorRfOut = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonSetPulseWidth = new System.Windows.Forms.Button();
            this.comboBoxPulseWidthValue = new System.Windows.Forms.ComboBox();
            this.OutputPulseWidth = new System.Windows.Forms.TextBox();
            this.InputPulseWidth = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonSetPow = new System.Windows.Forms.Button();
            this.comboBoxPowValue = new System.Windows.Forms.ComboBox();
            this.OutputPow = new System.Windows.Forms.TextBox();
            this.InputPow = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSetFrequency = new System.Windows.Forms.Button();
            this.comboBoxFrequencyValue = new System.Windows.Forms.ComboBox();
            this.OutputFrequency = new System.Windows.Forms.TextBox();
            this.InputFrequency = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripBottomPowerSupply = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripCheckConnectionPowerSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripBottomSignalGenerator = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripCheckConnectionSignalGenerator = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputVoltageConstAmperage = new System.Windows.Forms.TextBox();
            this.ControlPowerSupplyOut = new System.Windows.Forms.Button();
            this.groupBoxPowerSupply = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSetAmperage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputMaxAmperageConsumption = new System.Windows.Forms.TextBox();
            this.InputMaxAmperageConsumption = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputAmperage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSetVoltage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputVoltageConstAmperage = new System.Windows.Forms.TextBox();
            this.InputDeviation = new System.Windows.Forms.TextBox();
            this.ControlSignalGeneratorReset = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.buttonSetPulseDelay = new System.Windows.Forms.Button();
            this.comboBoxPulseDelayValue = new System.Windows.Forms.ComboBox();
            this.OutputPulseDelay = new System.Windows.Forms.TextBox();
            this.InputPulseDelay = new System.Windows.Forms.TextBox();
            this.ControlSignalGeneratorModulationOut = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonSetPulseDeviation = new System.Windows.Forms.Button();
            this.comboBoxDeviationValue = new System.Windows.Forms.ComboBox();
            this.OutputDeviation = new System.Windows.Forms.TextBox();
            this.groupBoxSignalGenerator = new System.Windows.Forms.GroupBox();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBoxPowerSupply.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBoxSignalGenerator.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttonSetPulsePeriod);
            this.groupBox7.Controls.Add(this.comboBoxPulsePeriodValue);
            this.groupBox7.Controls.Add(this.OutputPulsePeriod);
            this.groupBox7.Controls.Add(this.InputPulsePeriod);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(6, 186);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(424, 55);
            this.groupBox7.TabIndex = 148;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Частота повторения сигнала";
            // 
            // buttonSetPulsePeriod
            // 
            this.buttonSetPulsePeriod.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetPulsePeriod.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPulsePeriod.Location = new System.Drawing.Point(318, 18);
            this.buttonSetPulsePeriod.Name = "buttonSetPulsePeriod";
            this.buttonSetPulsePeriod.Size = new System.Drawing.Size(96, 30);
            this.buttonSetPulsePeriod.TabIndex = 26;
            this.buttonSetPulsePeriod.Text = "Задать";
            this.buttonSetPulsePeriod.UseVisualStyleBackColor = false;
            this.buttonSetPulsePeriod.Click += new System.EventHandler(this.buttonSetPulsePeriod_Click);
            // 
            // comboBoxPulsePeriodValue
            // 
            this.comboBoxPulsePeriodValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPulsePeriodValue.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPulsePeriodValue.FormattingEnabled = true;
            this.comboBoxPulsePeriodValue.Items.AddRange(new object[] {
            "с",
            "нс",
            "мс",
            "мкс"});
            this.comboBoxPulsePeriodValue.Location = new System.Drawing.Point(241, 18);
            this.comboBoxPulsePeriodValue.Name = "comboBoxPulsePeriodValue";
            this.comboBoxPulsePeriodValue.Size = new System.Drawing.Size(65, 28);
            this.comboBoxPulsePeriodValue.TabIndex = 25;
            this.comboBoxPulsePeriodValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxRepeatFrequencyValue_SelectedIndexChanged);
            // 
            // OutputPulsePeriod
            // 
            this.OutputPulsePeriod.BackColor = System.Drawing.Color.Black;
            this.OutputPulsePeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputPulsePeriod.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputPulsePeriod.ForeColor = System.Drawing.Color.Lime;
            this.OutputPulsePeriod.Location = new System.Drawing.Point(10, 21);
            this.OutputPulsePeriod.Name = "OutputPulsePeriod";
            this.OutputPulsePeriod.ReadOnly = true;
            this.OutputPulsePeriod.Size = new System.Drawing.Size(119, 22);
            this.OutputPulsePeriod.TabIndex = 7;
            this.OutputPulsePeriod.TabStop = false;
            this.OutputPulsePeriod.Text = "0";
            this.OutputPulsePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputPulsePeriod
            // 
            this.InputPulsePeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPulsePeriod.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPulsePeriod.Location = new System.Drawing.Point(135, 18);
            this.InputPulsePeriod.Name = "InputPulsePeriod";
            this.InputPulsePeriod.Size = new System.Drawing.Size(100, 29);
            this.InputPulsePeriod.TabIndex = 24;
            this.InputPulsePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ControlSignalGeneratorRfOut
            // 
            this.ControlSignalGeneratorRfOut.BackColor = System.Drawing.Color.Transparent;
            this.ControlSignalGeneratorRfOut.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlSignalGeneratorRfOut.Location = new System.Drawing.Point(436, 26);
            this.ControlSignalGeneratorRfOut.Name = "ControlSignalGeneratorRfOut";
            this.ControlSignalGeneratorRfOut.Size = new System.Drawing.Size(110, 104);
            this.ControlSignalGeneratorRfOut.TabIndex = 33;
            this.ControlSignalGeneratorRfOut.Text = "Включить RF";
            this.ControlSignalGeneratorRfOut.UseVisualStyleBackColor = false;
            this.ControlSignalGeneratorRfOut.Click += new System.EventHandler(this.buttonControlSignalGeneratorRFOut_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonSetPulseWidth);
            this.groupBox6.Controls.Add(this.comboBoxPulseWidthValue);
            this.groupBox6.Controls.Add(this.OutputPulseWidth);
            this.groupBox6.Controls.Add(this.InputPulseWidth);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(6, 131);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(424, 55);
            this.groupBox6.TabIndex = 147;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Длительность импульса сигнала";
            // 
            // buttonSetPulseWidth
            // 
            this.buttonSetPulseWidth.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetPulseWidth.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPulseWidth.Location = new System.Drawing.Point(318, 20);
            this.buttonSetPulseWidth.Name = "buttonSetPulseWidth";
            this.buttonSetPulseWidth.Size = new System.Drawing.Size(96, 30);
            this.buttonSetPulseWidth.TabIndex = 23;
            this.buttonSetPulseWidth.Text = "Задать";
            this.buttonSetPulseWidth.UseVisualStyleBackColor = false;
            this.buttonSetPulseWidth.Click += new System.EventHandler(this.buttonSetPulseWidth_Click);
            // 
            // comboBoxPulseWidthValue
            // 
            this.comboBoxPulseWidthValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPulseWidthValue.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPulseWidthValue.FormattingEnabled = true;
            this.comboBoxPulseWidthValue.Items.AddRange(new object[] {
            "с",
            "нс",
            "мс",
            "мкс"});
            this.comboBoxPulseWidthValue.Location = new System.Drawing.Point(241, 20);
            this.comboBoxPulseWidthValue.Name = "comboBoxPulseWidthValue";
            this.comboBoxPulseWidthValue.Size = new System.Drawing.Size(65, 28);
            this.comboBoxPulseWidthValue.TabIndex = 22;
            this.comboBoxPulseWidthValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxPulseWidthValue_SelectedIndexChanged);
            // 
            // OutputPulseWidth
            // 
            this.OutputPulseWidth.BackColor = System.Drawing.Color.Black;
            this.OutputPulseWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputPulseWidth.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputPulseWidth.ForeColor = System.Drawing.Color.Lime;
            this.OutputPulseWidth.Location = new System.Drawing.Point(10, 21);
            this.OutputPulseWidth.Name = "OutputPulseWidth";
            this.OutputPulseWidth.ReadOnly = true;
            this.OutputPulseWidth.Size = new System.Drawing.Size(119, 22);
            this.OutputPulseWidth.TabIndex = 6;
            this.OutputPulseWidth.TabStop = false;
            this.OutputPulseWidth.Text = "0";
            this.OutputPulseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputPulseWidth
            // 
            this.InputPulseWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPulseWidth.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPulseWidth.Location = new System.Drawing.Point(135, 20);
            this.InputPulseWidth.Name = "InputPulseWidth";
            this.InputPulseWidth.Size = new System.Drawing.Size(100, 29);
            this.InputPulseWidth.TabIndex = 21;
            this.InputPulseWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonSetPow);
            this.groupBox5.Controls.Add(this.comboBoxPowValue);
            this.groupBox5.Controls.Add(this.OutputPow);
            this.groupBox5.Controls.Add(this.InputPow);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 75);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(424, 55);
            this.groupBox5.TabIndex = 146;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Мощность сигнала";
            // 
            // buttonSetPow
            // 
            this.buttonSetPow.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetPow.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPow.Location = new System.Drawing.Point(318, 18);
            this.buttonSetPow.Name = "buttonSetPow";
            this.buttonSetPow.Size = new System.Drawing.Size(96, 30);
            this.buttonSetPow.TabIndex = 20;
            this.buttonSetPow.Text = "Задать";
            this.buttonSetPow.UseVisualStyleBackColor = false;
            this.buttonSetPow.Click += new System.EventHandler(this.buttonSetPow_Click);
            // 
            // comboBoxPowValue
            // 
            this.comboBoxPowValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPowValue.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPowValue.FormattingEnabled = true;
            this.comboBoxPowValue.Items.AddRange(new object[] {
            "дБм",
            "дБмкВ"});
            this.comboBoxPowValue.Location = new System.Drawing.Point(241, 18);
            this.comboBoxPowValue.Name = "comboBoxPowValue";
            this.comboBoxPowValue.Size = new System.Drawing.Size(65, 28);
            this.comboBoxPowValue.TabIndex = 19;
            this.comboBoxPowValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxPowValue_SelectedIndexChanged);
            // 
            // OutputPow
            // 
            this.OutputPow.BackColor = System.Drawing.Color.Black;
            this.OutputPow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputPow.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputPow.ForeColor = System.Drawing.Color.Lime;
            this.OutputPow.Location = new System.Drawing.Point(10, 21);
            this.OutputPow.MaxLength = 5;
            this.OutputPow.Name = "OutputPow";
            this.OutputPow.ReadOnly = true;
            this.OutputPow.Size = new System.Drawing.Size(119, 22);
            this.OutputPow.TabIndex = 5;
            this.OutputPow.TabStop = false;
            this.OutputPow.Text = "0";
            this.OutputPow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputPow
            // 
            this.InputPow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPow.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPow.Location = new System.Drawing.Point(135, 18);
            this.InputPow.Name = "InputPow";
            this.InputPow.Size = new System.Drawing.Size(100, 29);
            this.InputPow.TabIndex = 18;
            this.InputPow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSetFrequency);
            this.groupBox4.Controls.Add(this.comboBoxFrequencyValue);
            this.groupBox4.Controls.Add(this.OutputFrequency);
            this.groupBox4.Controls.Add(this.InputFrequency);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(6, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 55);
            this.groupBox4.TabIndex = 145;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Частота сигнала";
            // 
            // buttonSetFrequency
            // 
            this.buttonSetFrequency.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetFrequency.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetFrequency.Location = new System.Drawing.Point(318, 18);
            this.buttonSetFrequency.Name = "buttonSetFrequency";
            this.buttonSetFrequency.Size = new System.Drawing.Size(96, 30);
            this.buttonSetFrequency.TabIndex = 17;
            this.buttonSetFrequency.Text = "Задать";
            this.buttonSetFrequency.UseVisualStyleBackColor = false;
            this.buttonSetFrequency.Click += new System.EventHandler(this.buttonSetFrequency_Click);
            // 
            // comboBoxFrequencyValue
            // 
            this.comboBoxFrequencyValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequencyValue.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFrequencyValue.FormattingEnabled = true;
            this.comboBoxFrequencyValue.Items.AddRange(new object[] {
            "Гц",
            "кГц",
            "мГц",
            "Ггц"});
            this.comboBoxFrequencyValue.Location = new System.Drawing.Point(241, 18);
            this.comboBoxFrequencyValue.Name = "comboBoxFrequencyValue";
            this.comboBoxFrequencyValue.Size = new System.Drawing.Size(65, 28);
            this.comboBoxFrequencyValue.TabIndex = 16;
            this.comboBoxFrequencyValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrequencyValue_SelectedIndexChanged);
            // 
            // OutputFrequency
            // 
            this.OutputFrequency.BackColor = System.Drawing.Color.Black;
            this.OutputFrequency.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputFrequency.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFrequency.ForeColor = System.Drawing.Color.Lime;
            this.OutputFrequency.Location = new System.Drawing.Point(10, 21);
            this.OutputFrequency.Name = "OutputFrequency";
            this.OutputFrequency.ReadOnly = true;
            this.OutputFrequency.Size = new System.Drawing.Size(119, 22);
            this.OutputFrequency.TabIndex = 4;
            this.OutputFrequency.TabStop = false;
            this.OutputFrequency.Text = "0";
            this.OutputFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputFrequency
            // 
            this.InputFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputFrequency.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFrequency.Location = new System.Drawing.Point(135, 18);
            this.InputFrequency.Name = "InputFrequency";
            this.InputFrequency.Size = new System.Drawing.Size(100, 29);
            this.InputFrequency.TabIndex = 15;
            this.InputFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBottomPowerSupply,
            this.toolStripStatusLabel1,
            this.ToolStripBottomSignalGenerator});
            this.statusStrip.Location = new System.Drawing.Point(0, 579);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(571, 26);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 104;
            this.statusStrip.Text = "StatusStrip";
            // 
            // ToolStripBottomPowerSupply
            // 
            this.ToolStripBottomPowerSupply.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripBottomPowerSupply.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripCheckConnectionPowerSupply});
            this.ToolStripBottomPowerSupply.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripBottomPowerSupply.Image = global::ServiceDesktop.Views.Properties.Resources.volume_control_1;
            this.ToolStripBottomPowerSupply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripBottomPowerSupply.Name = "ToolStripBottomPowerSupply";
            this.ToolStripBottomPowerSupply.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ToolStripBottomPowerSupply.Size = new System.Drawing.Size(176, 24);
            this.ToolStripBottomPowerSupply.Text = "Источник питания";
            this.ToolStripBottomPowerSupply.ToolTipText = "Состояние источника питания";
            // 
            // ToolStripCheckConnectionPowerSupply
            // 
            this.ToolStripCheckConnectionPowerSupply.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripCheckConnectionPowerSupply.Image = global::ServiceDesktop.Views.Properties.Resources.share_2;
            this.ToolStripCheckConnectionPowerSupply.Name = "ToolStripCheckConnectionPowerSupply";
            this.ToolStripCheckConnectionPowerSupply.Size = new System.Drawing.Size(262, 24);
            this.ToolStripCheckConnectionPowerSupply.Text = "Проверка подключения";
            this.ToolStripCheckConnectionPowerSupply.Click += new System.EventHandler(this.ToolStripCheckConnectionPowerSupply_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 21);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // ToolStripBottomSignalGenerator
            // 
            this.ToolStripBottomSignalGenerator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripCheckConnectionSignalGenerator});
            this.ToolStripBottomSignalGenerator.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripBottomSignalGenerator.Image = global::ServiceDesktop.Views.Properties.Resources.volume_control;
            this.ToolStripBottomSignalGenerator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripBottomSignalGenerator.Name = "ToolStripBottomSignalGenerator";
            this.ToolStripBottomSignalGenerator.Size = new System.Drawing.Size(192, 24);
            this.ToolStripBottomSignalGenerator.Text = "Генератор сигналов";
            this.ToolStripBottomSignalGenerator.ToolTipText = "Состояние генератора сигналов";
            // 
            // ToolStripCheckConnectionSignalGenerator
            // 
            this.ToolStripCheckConnectionSignalGenerator.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripCheckConnectionSignalGenerator.Image = global::ServiceDesktop.Views.Properties.Resources.share_2;
            this.ToolStripCheckConnectionSignalGenerator.Name = "ToolStripCheckConnectionSignalGenerator";
            this.ToolStripCheckConnectionSignalGenerator.Size = new System.Drawing.Size(262, 24);
            this.ToolStripCheckConnectionSignalGenerator.Text = "Проверка подключения";
            this.ToolStripCheckConnectionSignalGenerator.Click += new System.EventHandler(this.ToolStripCheckConnectionSignalGenerator_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 28);
            this.menuStrip1.TabIndex = 105;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsSoftwareToolStripMenuItem,
            this.AboutSoftwareToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = global::ServiceDesktop.Views.Properties.Resources.app;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(93, 24);
            this.toolStripMenuItem1.Text = "Сервис";
            // 
            // SettingsSoftwareToolStripMenuItem
            // 
            this.SettingsSoftwareToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsSoftwareToolStripMenuItem.Image = global::ServiceDesktop.Views.Properties.Resources.settings;
            this.SettingsSoftwareToolStripMenuItem.Name = "SettingsSoftwareToolStripMenuItem";
            this.SettingsSoftwareToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.SettingsSoftwareToolStripMenuItem.Text = "Настройки";
            this.SettingsSoftwareToolStripMenuItem.Click += new System.EventHandler(this.SettingsSoftwareToolStripMenuItem_Click);
            // 
            // AboutSoftwareToolStripMenuItem
            // 
            this.AboutSoftwareToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutSoftwareToolStripMenuItem.Image = global::ServiceDesktop.Views.Properties.Resources.info;
            this.AboutSoftwareToolStripMenuItem.Name = "AboutSoftwareToolStripMenuItem";
            this.AboutSoftwareToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.AboutSoftwareToolStripMenuItem.Text = "О программе";
            this.AboutSoftwareToolStripMenuItem.Click += new System.EventHandler(this.AboutSoftwareToolStripMenuItem_Click);
            // 
            // OutputVoltageConstAmperage
            // 
            this.OutputVoltageConstAmperage.BackColor = System.Drawing.Color.Black;
            this.OutputVoltageConstAmperage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputVoltageConstAmperage.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputVoltageConstAmperage.ForeColor = System.Drawing.Color.Lime;
            this.OutputVoltageConstAmperage.Location = new System.Drawing.Point(10, 23);
            this.OutputVoltageConstAmperage.Name = "OutputVoltageConstAmperage";
            this.OutputVoltageConstAmperage.ReadOnly = true;
            this.OutputVoltageConstAmperage.Size = new System.Drawing.Size(172, 22);
            this.OutputVoltageConstAmperage.TabIndex = 1;
            this.OutputVoltageConstAmperage.TabStop = false;
            this.OutputVoltageConstAmperage.Text = "0";
            this.OutputVoltageConstAmperage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ControlPowerSupplyOut
            // 
            this.ControlPowerSupplyOut.BackColor = System.Drawing.Color.Transparent;
            this.ControlPowerSupplyOut.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlPowerSupplyOut.Location = new System.Drawing.Point(436, 26);
            this.ControlPowerSupplyOut.Name = "ControlPowerSupplyOut";
            this.ControlPowerSupplyOut.Size = new System.Drawing.Size(110, 160);
            this.ControlPowerSupplyOut.TabIndex = 14;
            this.ControlPowerSupplyOut.Text = "Включить выход источника";
            this.ControlPowerSupplyOut.UseVisualStyleBackColor = false;
            this.ControlPowerSupplyOut.Click += new System.EventHandler(this.buttonControlPowerSupplyOut_Click);
            // 
            // groupBoxPowerSupply
            // 
            this.groupBoxPowerSupply.BackColor = System.Drawing.Color.White;
            this.groupBoxPowerSupply.Controls.Add(this.groupBox3);
            this.groupBoxPowerSupply.Controls.Add(this.groupBox2);
            this.groupBoxPowerSupply.Controls.Add(this.groupBox1);
            this.groupBoxPowerSupply.Controls.Add(this.ControlPowerSupplyOut);
            this.groupBoxPowerSupply.Enabled = false;
            this.groupBoxPowerSupply.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPowerSupply.Location = new System.Drawing.Point(9, 27);
            this.groupBoxPowerSupply.Name = "groupBoxPowerSupply";
            this.groupBoxPowerSupply.Size = new System.Drawing.Size(552, 190);
            this.groupBoxPowerSupply.TabIndex = 102;
            this.groupBoxPowerSupply.TabStop = false;
            this.groupBoxPowerSupply.Text = "Источник питания";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSetAmperage);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.OutputMaxAmperageConsumption);
            this.groupBox3.Controls.Add(this.InputMaxAmperageConsumption);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 55);
            this.groupBox3.TabIndex = 145;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Максимальный ток потребления";
            // 
            // buttonSetAmperage
            // 
            this.buttonSetAmperage.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetAmperage.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetAmperage.Location = new System.Drawing.Point(318, 15);
            this.buttonSetAmperage.Name = "buttonSetAmperage";
            this.buttonSetAmperage.Size = new System.Drawing.Size(96, 30);
            this.buttonSetAmperage.TabIndex = 13;
            this.buttonSetAmperage.Text = "Задать";
            this.buttonSetAmperage.UseVisualStyleBackColor = false;
            this.buttonSetAmperage.Click += new System.EventHandler(this.buttonSetAmperage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(288, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 146;
            this.label2.Text = "А";
            // 
            // OutputMaxAmperageConsumption
            // 
            this.OutputMaxAmperageConsumption.BackColor = System.Drawing.Color.Black;
            this.OutputMaxAmperageConsumption.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputMaxAmperageConsumption.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputMaxAmperageConsumption.ForeColor = System.Drawing.Color.Lime;
            this.OutputMaxAmperageConsumption.Location = new System.Drawing.Point(10, 23);
            this.OutputMaxAmperageConsumption.Name = "OutputMaxAmperageConsumption";
            this.OutputMaxAmperageConsumption.ReadOnly = true;
            this.OutputMaxAmperageConsumption.Size = new System.Drawing.Size(172, 22);
            this.OutputMaxAmperageConsumption.TabIndex = 3;
            this.OutputMaxAmperageConsumption.TabStop = false;
            this.OutputMaxAmperageConsumption.Text = "0";
            this.OutputMaxAmperageConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputMaxAmperageConsumption
            // 
            this.InputMaxAmperageConsumption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputMaxAmperageConsumption.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputMaxAmperageConsumption.Location = new System.Drawing.Point(188, 19);
            this.InputMaxAmperageConsumption.Name = "InputMaxAmperageConsumption";
            this.InputMaxAmperageConsumption.Size = new System.Drawing.Size(94, 29);
            this.InputMaxAmperageConsumption.TabIndex = 12;
            this.InputMaxAmperageConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.OutputAmperage);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 55);
            this.groupBox2.TabIndex = 145;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ток потребления";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(395, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 146;
            this.label3.Text = "А";
            // 
            // OutputAmperage
            // 
            this.OutputAmperage.BackColor = System.Drawing.Color.Black;
            this.OutputAmperage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputAmperage.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputAmperage.ForeColor = System.Drawing.Color.Lime;
            this.OutputAmperage.Location = new System.Drawing.Point(10, 24);
            this.OutputAmperage.Name = "OutputAmperage";
            this.OutputAmperage.ReadOnly = true;
            this.OutputAmperage.Size = new System.Drawing.Size(379, 22);
            this.OutputAmperage.TabIndex = 2;
            this.OutputAmperage.TabStop = false;
            this.OutputAmperage.Text = "0";
            this.OutputAmperage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSetVoltage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.OutputVoltageConstAmperage);
            this.groupBox1.Controls.Add(this.InputVoltageConstAmperage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 55);
            this.groupBox1.TabIndex = 102;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Напряжение постоянного тока";
            // 
            // buttonSetVoltage
            // 
            this.buttonSetVoltage.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetVoltage.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetVoltage.Location = new System.Drawing.Point(318, 16);
            this.buttonSetVoltage.Name = "buttonSetVoltage";
            this.buttonSetVoltage.Size = new System.Drawing.Size(96, 30);
            this.buttonSetVoltage.TabIndex = 11;
            this.buttonSetVoltage.Text = "Задать";
            this.buttonSetVoltage.UseVisualStyleBackColor = false;
            this.buttonSetVoltage.Click += new System.EventHandler(this.buttonSetVoltage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 145;
            this.label1.Text = "В";
            // 
            // InputVoltageConstAmperage
            // 
            this.InputVoltageConstAmperage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputVoltageConstAmperage.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputVoltageConstAmperage.ForeColor = System.Drawing.Color.Black;
            this.InputVoltageConstAmperage.Location = new System.Drawing.Point(188, 19);
            this.InputVoltageConstAmperage.Name = "InputVoltageConstAmperage";
            this.InputVoltageConstAmperage.Size = new System.Drawing.Size(94, 29);
            this.InputVoltageConstAmperage.TabIndex = 10;
            this.InputVoltageConstAmperage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputDeviation
            // 
            this.InputDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputDeviation.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputDeviation.Location = new System.Drawing.Point(135, 18);
            this.InputDeviation.Name = "InputDeviation";
            this.InputDeviation.Size = new System.Drawing.Size(100, 29);
            this.InputDeviation.TabIndex = 27;
            this.InputDeviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ControlSignalGeneratorReset
            // 
            this.ControlSignalGeneratorReset.BackColor = System.Drawing.Color.Transparent;
            this.ControlSignalGeneratorReset.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlSignalGeneratorReset.Location = new System.Drawing.Point(436, 241);
            this.ControlSignalGeneratorReset.Name = "ControlSignalGeneratorReset";
            this.ControlSignalGeneratorReset.Size = new System.Drawing.Size(110, 110);
            this.ControlSignalGeneratorReset.TabIndex = 35;
            this.ControlSignalGeneratorReset.Text = "Сброс параметров";
            this.ControlSignalGeneratorReset.UseVisualStyleBackColor = false;
            this.ControlSignalGeneratorReset.Click += new System.EventHandler(this.buttonControlSignalGeneratorReset_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.buttonSetPulseDelay);
            this.groupBox9.Controls.Add(this.comboBoxPulseDelayValue);
            this.groupBox9.Controls.Add(this.OutputPulseDelay);
            this.groupBox9.Controls.Add(this.InputPulseDelay);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(6, 296);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(424, 55);
            this.groupBox9.TabIndex = 150;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Задержка между импульсами";
            // 
            // buttonSetPulseDelay
            // 
            this.buttonSetPulseDelay.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetPulseDelay.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPulseDelay.Location = new System.Drawing.Point(318, 19);
            this.buttonSetPulseDelay.Name = "buttonSetPulseDelay";
            this.buttonSetPulseDelay.Size = new System.Drawing.Size(96, 30);
            this.buttonSetPulseDelay.TabIndex = 32;
            this.buttonSetPulseDelay.Text = "Задать";
            this.buttonSetPulseDelay.UseVisualStyleBackColor = false;
            this.buttonSetPulseDelay.Click += new System.EventHandler(this.buttonSetPulseDelay_Click);
            // 
            // comboBoxPulseDelayValue
            // 
            this.comboBoxPulseDelayValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPulseDelayValue.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPulseDelayValue.FormattingEnabled = true;
            this.comboBoxPulseDelayValue.Items.AddRange(new object[] {
            "с",
            "нс",
            "мс",
            "мкс"});
            this.comboBoxPulseDelayValue.Location = new System.Drawing.Point(241, 19);
            this.comboBoxPulseDelayValue.Name = "comboBoxPulseDelayValue";
            this.comboBoxPulseDelayValue.Size = new System.Drawing.Size(65, 28);
            this.comboBoxPulseDelayValue.TabIndex = 31;
            this.comboBoxPulseDelayValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxPulseDelayValue_SelectedIndexChanged);
            // 
            // OutputPulseDelay
            // 
            this.OutputPulseDelay.BackColor = System.Drawing.Color.Black;
            this.OutputPulseDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputPulseDelay.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputPulseDelay.ForeColor = System.Drawing.Color.Lime;
            this.OutputPulseDelay.Location = new System.Drawing.Point(10, 21);
            this.OutputPulseDelay.Name = "OutputPulseDelay";
            this.OutputPulseDelay.ReadOnly = true;
            this.OutputPulseDelay.Size = new System.Drawing.Size(119, 22);
            this.OutputPulseDelay.TabIndex = 9;
            this.OutputPulseDelay.TabStop = false;
            this.OutputPulseDelay.Text = "0";
            this.OutputPulseDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // InputPulseDelay
            // 
            this.InputPulseDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPulseDelay.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPulseDelay.Location = new System.Drawing.Point(135, 19);
            this.InputPulseDelay.Name = "InputPulseDelay";
            this.InputPulseDelay.Size = new System.Drawing.Size(100, 29);
            this.InputPulseDelay.TabIndex = 30;
            this.InputPulseDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ControlSignalGeneratorModulationOut
            // 
            this.ControlSignalGeneratorModulationOut.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlSignalGeneratorModulationOut.Location = new System.Drawing.Point(436, 136);
            this.ControlSignalGeneratorModulationOut.Name = "ControlSignalGeneratorModulationOut";
            this.ControlSignalGeneratorModulationOut.Size = new System.Drawing.Size(110, 99);
            this.ControlSignalGeneratorModulationOut.TabIndex = 34;
            this.ControlSignalGeneratorModulationOut.Text = "Включить модуляцию";
            this.ControlSignalGeneratorModulationOut.UseVisualStyleBackColor = true;
            this.ControlSignalGeneratorModulationOut.Click += new System.EventHandler(this.buttonControlSignalGeneratorModulation_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.buttonSetPulseDeviation);
            this.groupBox8.Controls.Add(this.comboBoxDeviationValue);
            this.groupBox8.Controls.Add(this.OutputDeviation);
            this.groupBox8.Controls.Add(this.InputDeviation);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(6, 241);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(424, 55);
            this.groupBox8.TabIndex = 149;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Девиация сигнала";
            // 
            // buttonSetPulseDeviation
            // 
            this.buttonSetPulseDeviation.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetPulseDeviation.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetPulseDeviation.Location = new System.Drawing.Point(318, 18);
            this.buttonSetPulseDeviation.Name = "buttonSetPulseDeviation";
            this.buttonSetPulseDeviation.Size = new System.Drawing.Size(96, 30);
            this.buttonSetPulseDeviation.TabIndex = 29;
            this.buttonSetPulseDeviation.Text = "Задать";
            this.buttonSetPulseDeviation.UseVisualStyleBackColor = false;
            this.buttonSetPulseDeviation.Click += new System.EventHandler(this.buttonSetPulseDeviation_Click);
            // 
            // comboBoxDeviationValue
            // 
            this.comboBoxDeviationValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeviationValue.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDeviationValue.FormattingEnabled = true;
            this.comboBoxDeviationValue.Items.AddRange(new object[] {
            "Гц",
            "кГц",
            "мГц"});
            this.comboBoxDeviationValue.Location = new System.Drawing.Point(241, 18);
            this.comboBoxDeviationValue.Name = "comboBoxDeviationValue";
            this.comboBoxDeviationValue.Size = new System.Drawing.Size(65, 28);
            this.comboBoxDeviationValue.TabIndex = 28;
            this.comboBoxDeviationValue.SelectedIndexChanged += new System.EventHandler(this.comboBoxDeviationValue_SelectedIndexChanged);
            // 
            // OutputDeviation
            // 
            this.OutputDeviation.BackColor = System.Drawing.Color.Black;
            this.OutputDeviation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OutputDeviation.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputDeviation.ForeColor = System.Drawing.Color.Lime;
            this.OutputDeviation.Location = new System.Drawing.Point(10, 21);
            this.OutputDeviation.Name = "OutputDeviation";
            this.OutputDeviation.ReadOnly = true;
            this.OutputDeviation.Size = new System.Drawing.Size(119, 22);
            this.OutputDeviation.TabIndex = 8;
            this.OutputDeviation.TabStop = false;
            this.OutputDeviation.Text = "0";
            this.OutputDeviation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxSignalGenerator
            // 
            this.groupBoxSignalGenerator.Controls.Add(this.ControlSignalGeneratorReset);
            this.groupBoxSignalGenerator.Controls.Add(this.groupBox9);
            this.groupBoxSignalGenerator.Controls.Add(this.ControlSignalGeneratorModulationOut);
            this.groupBoxSignalGenerator.Controls.Add(this.groupBox8);
            this.groupBoxSignalGenerator.Controls.Add(this.groupBox7);
            this.groupBoxSignalGenerator.Controls.Add(this.ControlSignalGeneratorRfOut);
            this.groupBoxSignalGenerator.Controls.Add(this.groupBox6);
            this.groupBoxSignalGenerator.Controls.Add(this.groupBox5);
            this.groupBoxSignalGenerator.Controls.Add(this.groupBox4);
            this.groupBoxSignalGenerator.Enabled = false;
            this.groupBoxSignalGenerator.Font = new System.Drawing.Font("Microsoft JhengHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSignalGenerator.Location = new System.Drawing.Point(9, 219);
            this.groupBoxSignalGenerator.Name = "groupBoxSignalGenerator";
            this.groupBoxSignalGenerator.Size = new System.Drawing.Size(552, 359);
            this.groupBoxSignalGenerator.TabIndex = 103;
            this.groupBoxSignalGenerator.TabStop = false;
            this.groupBoxSignalGenerator.Text = "Генератор сигналов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 605);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBoxPowerSupply);
            this.Controls.Add(this.groupBoxSignalGenerator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удалённое управление генератором сигналов и источникм питания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxPowerSupply.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBoxSignalGenerator.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button buttonSetPulsePeriod;
        private System.Windows.Forms.ComboBox comboBoxPulsePeriodValue;
        private System.Windows.Forms.TextBox OutputPulsePeriod;
        private System.Windows.Forms.TextBox InputPulsePeriod;
        private System.Windows.Forms.Button ControlSignalGeneratorRfOut;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonSetPulseWidth;
        private System.Windows.Forms.ComboBox comboBoxPulseWidthValue;
        private System.Windows.Forms.TextBox OutputPulseWidth;
        private System.Windows.Forms.TextBox InputPulseWidth;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonSetPow;
        private System.Windows.Forms.ComboBox comboBoxPowValue;
        private System.Windows.Forms.TextBox OutputPow;
        private System.Windows.Forms.TextBox InputPow;
        private System.Windows.Forms.ToolStripMenuItem SettingsSoftwareToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonSetFrequency;
        private System.Windows.Forms.ComboBox comboBoxFrequencyValue;
        private System.Windows.Forms.TextBox OutputFrequency;
        private System.Windows.Forms.TextBox InputFrequency;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripDropDownButton ToolStripBottomPowerSupply;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCheckConnectionPowerSupply;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton ToolStripBottomSignalGenerator;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCheckConnectionSignalGenerator;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AboutSoftwareToolStripMenuItem;
        private System.Windows.Forms.TextBox OutputVoltageConstAmperage;
        private System.Windows.Forms.Button ControlPowerSupplyOut;
        private System.Windows.Forms.GroupBox groupBoxPowerSupply;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSetAmperage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OutputMaxAmperageConsumption;
        private System.Windows.Forms.TextBox InputMaxAmperageConsumption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OutputAmperage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSetVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputVoltageConstAmperage;
        private System.Windows.Forms.TextBox InputDeviation;
        private System.Windows.Forms.Button ControlSignalGeneratorReset;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button buttonSetPulseDelay;
        private System.Windows.Forms.ComboBox comboBoxPulseDelayValue;
        private System.Windows.Forms.TextBox OutputPulseDelay;
        private System.Windows.Forms.TextBox InputPulseDelay;
        private System.Windows.Forms.Button ControlSignalGeneratorModulationOut;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonSetPulseDeviation;
        private System.Windows.Forms.ComboBox comboBoxDeviationValue;
        private System.Windows.Forms.TextBox OutputDeviation;
        private System.Windows.Forms.GroupBox groupBoxSignalGenerator;
    }
}

