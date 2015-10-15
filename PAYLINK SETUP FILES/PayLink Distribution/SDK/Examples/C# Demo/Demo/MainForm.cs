using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AES;

namespace Demo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.StatusBarPanel USBDriverStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage General;
		private System.Windows.Forms.TabPage Acceptors;
		private System.Windows.Forms.TabPage Dispensers;
		private System.Windows.Forms.TabPage SwitchesLEDs;
        private System.Windows.Forms.TabPage Meter;
		private System.Windows.Forms.TabPage Barcodes;
		private System.Windows.Forms.ListBox EventListBox;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.TabPage MHEEvents;
		private System.Windows.Forms.ComboBox acceptorComboBox;
		private System.Windows.Forms.Label CoinValueLabel;
		private System.Windows.Forms.Label CoinCoubtLabel;
		private System.Windows.Forms.Label CoinRoutedPathLabel;
		private System.Windows.Forms.Label CoinDefaultPathLabel;
		private System.Windows.Forms.Label CoinNoSentLabel;
		private System.Windows.Forms.Label CoinLevelLabel;
		private System.Windows.Forms.Label CoinNoEscrowLabel;
		private System.Windows.Forms.Label CoinInhibitLabel;
		private System.Windows.Forms.Panel AcceptorPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox AcceptorStatusTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox AcceptorNoOfCoinsTextBox;
        private System.Windows.Forms.TextBox AcceptorDefaultPathTextBox;
		private System.Windows.Forms.TextBox AcceptorInterfaceNumberTextBox;
		private System.Windows.Forms.TextBox AcceptorUnitAddressTextBox;
		private System.Windows.Forms.TextBox AcceptorCurrencyTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox SwitchGroupBox;
		private System.Windows.Forms.Panel Switch_0;
		private System.Windows.Forms.Panel Switch_1;
		private System.Windows.Forms.Panel Switch_2;
		private System.Windows.Forms.Panel Switch_3;
		private System.Windows.Forms.Panel Switch_4;
		private System.Windows.Forms.Panel Switch_7;
		private System.Windows.Forms.Panel Switch_5;
		private System.Windows.Forms.Panel Switch_6;
		private System.Windows.Forms.Panel Switch_8;
		private System.Windows.Forms.Panel Switch_9;
		private System.Windows.Forms.Panel Switch_11;
		private System.Windows.Forms.Panel Switch_10;
		private System.Windows.Forms.GroupBox LEDgroupBox;
		private System.Windows.Forms.Panel LED_0;
		private System.Windows.Forms.Panel LED_1;
		private System.Windows.Forms.Panel LED_2;
		private System.Windows.Forms.Panel LED_3;
		private System.Windows.Forms.Panel LED_4;
		private System.Windows.Forms.Panel LED_5;
		private System.Windows.Forms.Panel LED_6;
		private System.Windows.Forms.Panel LED_7;
		private System.Windows.Forms.Panel LED_8;
		private System.Windows.Forms.Panel LED_9;
		private System.Windows.Forms.Panel LED_15;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox MeterNameTextBox;
		private System.Windows.Forms.TextBox MeterStatusTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown CounterNumberUpDown;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox CounterCaptionTextBox;
		private System.Windows.Forms.TextBox CounterCountTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton CounterDisplayCountRadioButton;
		private System.Windows.Forms.RadioButton CounterDisplayBothRadioButton;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button CounterIncrementButton;
		private System.Windows.Forms.NumericUpDown CounterIncrementUpDown;
		private System.Windows.Forms.Panel DispenserPanel;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox BarcodeStatusTextBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button BarcodePrintButton;
		private System.Windows.Forms.TextBox BarcodeMachineIdTextBox;
		private System.Windows.Forms.TextBox BarcodeTimeTextBox;
		private System.Windows.Forms.TextBox BarcodeDateTextBox;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox BarcodeNumericAmountTextBox;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox BarcodeAmountInWordsTextBox;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button BarcodeEscrowReturnButton;
		private System.Windows.Forms.Button BarcodeEscrowAcceptButton;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox BarcodeEscrowTicketTextBox;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox BarcodeLastTicketTextBox;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.TextBox BarcodeTicketsStackedTextBox;
		private System.Windows.Forms.GroupBox EscrowGroupBox;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.TextBox EscrowAmountTextBox;
		private System.Windows.Forms.CheckBox EscrowEnabledCheckBox;
		private System.Windows.Forms.Button EscrowAcceptButton;
		private System.Windows.Forms.Button EscrowReturnButton;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox TotalAmountAcceptedTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox JustReadTextBox;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox TotalAmountPaidOutTextBox;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox PayoutTextBox;
		private System.Windows.Forms.Button PayItButton;
		private System.Windows.Forms.Button JustReadResetButton;
        private System.Windows.Forms.Label PayStatusLabel;
        private Panel Switch_14;
        private Panel Switch_12;
        private Panel Switch_13;
        private Panel Switch_15;
        private Panel LED_10;
        private Panel LED_11;
        private Panel LED_12;
        private Panel LED_13;
        private Panel LED_14;
        private Label label36;
        private Panel panel2;
        private TextBox BarcodeReference;
        private Label label37;
        private GroupBox groupBox8;
        private PictureBox pictureBox1;
        private TabPage DES;
        private Label label38;
        private Button SetButton;
        private TextBox keyTextBox;
        private Button LockButton;
        private TextBox DESStatusTextBox;
        private Label label39;
        private Label label40;
        private Label label7;
        private TextBox AcceptorDescriptionTextBox;
        private Button ClearButton;
        private Label label41;
        private TextBox newKeyTextBox;
        private Label label42;
        private GroupBox groupBox9;
        private GroupBox groupBox11;
        private GroupBox groupBox10;
		private System.ComponentModel.IContainer components;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.USBDriverStatus = new System.Windows.Forms.StatusBarPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.PayStatusLabel = new System.Windows.Forms.Label();
            this.PayItButton = new System.Windows.Forms.Button();
            this.PayoutTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TotalAmountPaidOutTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.JustReadResetButton = new System.Windows.Forms.Button();
            this.JustReadTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TotalAmountAcceptedTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.EscrowEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.EscrowGroupBox = new System.Windows.Forms.GroupBox();
            this.EscrowReturnButton = new System.Windows.Forms.Button();
            this.EscrowAcceptButton = new System.Windows.Forms.Button();
            this.EscrowAmountTextBox = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.Acceptors = new System.Windows.Forms.TabPage();
            this.AcceptorDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.AcceptorCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.AcceptorUnitAddressTextBox = new System.Windows.Forms.TextBox();
            this.AcceptorInterfaceNumberTextBox = new System.Windows.Forms.TextBox();
            this.AcceptorDefaultPathTextBox = new System.Windows.Forms.TextBox();
            this.AcceptorNoOfCoinsTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AcceptorStatusTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CoinInhibitLabel = new System.Windows.Forms.Label();
            this.CoinNoEscrowLabel = new System.Windows.Forms.Label();
            this.CoinLevelLabel = new System.Windows.Forms.Label();
            this.CoinNoSentLabel = new System.Windows.Forms.Label();
            this.CoinDefaultPathLabel = new System.Windows.Forms.Label();
            this.CoinRoutedPathLabel = new System.Windows.Forms.Label();
            this.CoinCoubtLabel = new System.Windows.Forms.Label();
            this.CoinValueLabel = new System.Windows.Forms.Label();
            this.AcceptorPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.acceptorComboBox = new System.Windows.Forms.ComboBox();
            this.Dispensers = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.DispenserPanel = new System.Windows.Forms.Panel();
            this.Barcodes = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BarcodeTicketsStackedTextBox = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.BarcodeLastTicketTextBox = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BarcodeEscrowReturnButton = new System.Windows.Forms.Button();
            this.BarcodeEscrowAcceptButton = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.BarcodeEscrowTicketTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BarcodeReference = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.BarcodePrintButton = new System.Windows.Forms.Button();
            this.BarcodeMachineIdTextBox = new System.Windows.Forms.TextBox();
            this.BarcodeTimeTextBox = new System.Windows.Forms.TextBox();
            this.BarcodeDateTextBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.BarcodeNumericAmountTextBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.BarcodeAmountInWordsTextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.BarcodeStatusTextBox = new System.Windows.Forms.TextBox();
            this.Meter = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.CounterDisplayCountRadioButton = new System.Windows.Forms.RadioButton();
            this.CounterDisplayBothRadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CounterCaptionTextBox = new System.Windows.Forms.TextBox();
            this.CounterCountTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CounterIncrementUpDown = new System.Windows.Forms.NumericUpDown();
            this.CounterIncrementButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CounterNumberUpDown = new System.Windows.Forms.NumericUpDown();
            this.MeterStatusTextBox = new System.Windows.Forms.TextBox();
            this.MeterNameTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SwitchesLEDs = new System.Windows.Forms.TabPage();
            this.LEDgroupBox = new System.Windows.Forms.GroupBox();
            this.LED_10 = new System.Windows.Forms.Panel();
            this.LED_11 = new System.Windows.Forms.Panel();
            this.LED_12 = new System.Windows.Forms.Panel();
            this.LED_13 = new System.Windows.Forms.Panel();
            this.LED_14 = new System.Windows.Forms.Panel();
            this.LED_15 = new System.Windows.Forms.Panel();
            this.LED_9 = new System.Windows.Forms.Panel();
            this.LED_8 = new System.Windows.Forms.Panel();
            this.LED_7 = new System.Windows.Forms.Panel();
            this.LED_6 = new System.Windows.Forms.Panel();
            this.LED_5 = new System.Windows.Forms.Panel();
            this.LED_4 = new System.Windows.Forms.Panel();
            this.LED_3 = new System.Windows.Forms.Panel();
            this.LED_2 = new System.Windows.Forms.Panel();
            this.LED_1 = new System.Windows.Forms.Panel();
            this.LED_0 = new System.Windows.Forms.Panel();
            this.SwitchGroupBox = new System.Windows.Forms.GroupBox();
            this.Switch_15 = new System.Windows.Forms.Panel();
            this.Switch_14 = new System.Windows.Forms.Panel();
            this.Switch_12 = new System.Windows.Forms.Panel();
            this.Switch_13 = new System.Windows.Forms.Panel();
            this.Switch_10 = new System.Windows.Forms.Panel();
            this.Switch_9 = new System.Windows.Forms.Panel();
            this.Switch_8 = new System.Windows.Forms.Panel();
            this.Switch_6 = new System.Windows.Forms.Panel();
            this.Switch_7 = new System.Windows.Forms.Panel();
            this.Switch_4 = new System.Windows.Forms.Panel();
            this.Switch_2 = new System.Windows.Forms.Panel();
            this.Switch_1 = new System.Windows.Forms.Panel();
            this.Switch_0 = new System.Windows.Forms.Panel();
            this.Switch_5 = new System.Windows.Forms.Panel();
            this.Switch_3 = new System.Windows.Forms.Panel();
            this.Switch_11 = new System.Windows.Forms.Panel();
            this.MHEEvents = new System.Windows.Forms.TabPage();
            this.EventListBox = new System.Windows.Forms.ListBox();
            this.DES = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.newKeyTextBox = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.LockButton = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.SetButton = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.DESStatusTextBox = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.USBDriverStatus)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.General.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.EscrowGroupBox.SuspendLayout();
            this.Acceptors.SuspendLayout();
            this.AcceptorPanel.SuspendLayout();
            this.Dispensers.SuspendLayout();
            this.Barcodes.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Meter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CounterIncrementUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterNumberUpDown)).BeginInit();
            this.SwitchesLEDs.SuspendLayout();
            this.LEDgroupBox.SuspendLayout();
            this.SwitchGroupBox.SuspendLayout();
            this.MHEEvents.SuspendLayout();
            this.DES.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // USBDriverStatus
            // 
            this.USBDriverStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.USBDriverStatus.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.USBDriverStatus.Name = "USBDriverStatus";
            this.USBDriverStatus.Text = "USB Driver:";
            this.USBDriverStatus.Width = 727;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Aardvark Intelligent Coin Interface Demonstration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 528);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.USBDriverStatus});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(744, 22);
            this.statusBar.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.General);
            this.tabControl1.Controls.Add(this.Acceptors);
            this.tabControl1.Controls.Add(this.Dispensers);
            this.tabControl1.Controls.Add(this.Barcodes);
            this.tabControl1.Controls.Add(this.Meter);
            this.tabControl1.Controls.Add(this.SwitchesLEDs);
            this.tabControl1.Controls.Add(this.MHEEvents);
            this.tabControl1.Controls.Add(this.DES);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(16, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(696, 484);
            this.tabControl1.TabIndex = 15;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // General
            // 
            this.General.Controls.Add(this.pictureBox1);
            this.General.Controls.Add(this.groupBox7);
            this.General.Controls.Add(this.groupBox6);
            this.General.Controls.Add(this.EscrowEnabledCheckBox);
            this.General.Controls.Add(this.EscrowGroupBox);
            this.General.Location = new System.Drawing.Point(4, 25);
            this.General.Name = "General";
            this.General.Size = new System.Drawing.Size(688, 455);
            this.General.TabIndex = 6;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(384, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 292);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.PayStatusLabel);
            this.groupBox7.Controls.Add(this.PayItButton);
            this.groupBox7.Controls.Add(this.PayoutTextBox);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.TotalAmountPaidOutTextBox);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(16, 172);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(362, 139);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Money Pay Out";
            // 
            // PayStatusLabel
            // 
            this.PayStatusLabel.Location = new System.Drawing.Point(384, 56);
            this.PayStatusLabel.Name = "PayStatusLabel";
            this.PayStatusLabel.Size = new System.Drawing.Size(136, 23);
            this.PayStatusLabel.TabIndex = 20;
            // 
            // PayItButton
            // 
            this.PayItButton.Location = new System.Drawing.Point(277, 75);
            this.PayItButton.Name = "PayItButton";
            this.PayItButton.Size = new System.Drawing.Size(64, 23);
            this.PayItButton.TabIndex = 19;
            this.PayItButton.Text = "Payit";
            this.PayItButton.Click += new System.EventHandler(this.PayItButton_Click);
            // 
            // PayoutTextBox
            // 
            this.PayoutTextBox.CausesValidation = false;
            this.PayoutTextBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.PayoutTextBox.Location = new System.Drawing.Point(176, 75);
            this.PayoutTextBox.MaxLength = 6;
            this.PayoutTextBox.Name = "PayoutTextBox";
            this.PayoutTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PayoutTextBox.Size = new System.Drawing.Size(70, 22);
            this.PayoutTextBox.TabIndex = 18;
            this.PayoutTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label11.Location = new System.Drawing.Point(24, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(128, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Amount to Payout:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalAmountPaidOutTextBox
            // 
            this.TotalAmountPaidOutTextBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TotalAmountPaidOutTextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalAmountPaidOutTextBox.Location = new System.Drawing.Point(176, 29);
            this.TotalAmountPaidOutTextBox.Name = "TotalAmountPaidOutTextBox";
            this.TotalAmountPaidOutTextBox.ReadOnly = true;
            this.TotalAmountPaidOutTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TotalAmountPaidOutTextBox.Size = new System.Drawing.Size(70, 22);
            this.TotalAmountPaidOutTextBox.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label14.Location = new System.Drawing.Point(8, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Total Amount Paid Out:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.JustReadResetButton);
            this.groupBox6.Controls.Add(this.JustReadTextBox);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.TotalAmountAcceptedTextBox);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(16, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(362, 147);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Money Accepted";
            // 
            // JustReadResetButton
            // 
            this.JustReadResetButton.Location = new System.Drawing.Point(285, 77);
            this.JustReadResetButton.Name = "JustReadResetButton";
            this.JustReadResetButton.Size = new System.Drawing.Size(56, 23);
            this.JustReadResetButton.TabIndex = 17;
            this.JustReadResetButton.Text = "Reset";
            this.JustReadResetButton.Click += new System.EventHandler(this.JustReadResetButton_Click);
            // 
            // JustReadTextBox
            // 
            this.JustReadTextBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.JustReadTextBox.Location = new System.Drawing.Point(184, 77);
            this.JustReadTextBox.Name = "JustReadTextBox";
            this.JustReadTextBox.ReadOnly = true;
            this.JustReadTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.JustReadTextBox.Size = new System.Drawing.Size(62, 22);
            this.JustReadTextBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label10.Location = new System.Drawing.Point(48, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Amount Just Read:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalAmountAcceptedTextBox
            // 
            this.TotalAmountAcceptedTextBox.Font = new System.Drawing.Font("Arial", 9.75F);
            this.TotalAmountAcceptedTextBox.Location = new System.Drawing.Point(184, 32);
            this.TotalAmountAcceptedTextBox.Name = "TotalAmountAcceptedTextBox";
            this.TotalAmountAcceptedTextBox.ReadOnly = true;
            this.TotalAmountAcceptedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TotalAmountAcceptedTextBox.Size = new System.Drawing.Size(62, 22);
            this.TotalAmountAcceptedTextBox.TabIndex = 14;
            this.TotalAmountAcceptedTextBox.WordWrap = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F);
            this.label12.Location = new System.Drawing.Point(8, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 16);
            this.label12.TabIndex = 13;
            this.label12.Text = "Total Amount Accepted:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EscrowEnabledCheckBox
            // 
            this.EscrowEnabledCheckBox.Location = new System.Drawing.Point(27, 330);
            this.EscrowEnabledCheckBox.Name = "EscrowEnabledCheckBox";
            this.EscrowEnabledCheckBox.Size = new System.Drawing.Size(119, 24);
            this.EscrowEnabledCheckBox.TabIndex = 11;
            this.EscrowEnabledCheckBox.Text = "Escrow enabled";
            this.EscrowEnabledCheckBox.CheckedChanged += new System.EventHandler(this.EscrowEnabledCheckBox_CheckedChanged);
            // 
            // EscrowGroupBox
            // 
            this.EscrowGroupBox.Controls.Add(this.EscrowReturnButton);
            this.EscrowGroupBox.Controls.Add(this.EscrowAcceptButton);
            this.EscrowGroupBox.Controls.Add(this.EscrowAmountTextBox);
            this.EscrowGroupBox.Controls.Add(this.label35);
            this.EscrowGroupBox.Location = new System.Drawing.Point(16, 360);
            this.EscrowGroupBox.Name = "EscrowGroupBox";
            this.EscrowGroupBox.Size = new System.Drawing.Size(487, 64);
            this.EscrowGroupBox.TabIndex = 10;
            this.EscrowGroupBox.TabStop = false;
            this.EscrowGroupBox.Text = "Escrow";
            // 
            // EscrowReturnButton
            // 
            this.EscrowReturnButton.Location = new System.Drawing.Point(394, 25);
            this.EscrowReturnButton.Name = "EscrowReturnButton";
            this.EscrowReturnButton.Size = new System.Drawing.Size(75, 23);
            this.EscrowReturnButton.TabIndex = 3;
            this.EscrowReturnButton.Text = "Return";
            this.EscrowReturnButton.Click += new System.EventHandler(this.EscrowReturnButton_Click);
            // 
            // EscrowAcceptButton
            // 
            this.EscrowAcceptButton.Location = new System.Drawing.Point(277, 25);
            this.EscrowAcceptButton.Name = "EscrowAcceptButton";
            this.EscrowAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.EscrowAcceptButton.TabIndex = 2;
            this.EscrowAcceptButton.Text = "Accept";
            this.EscrowAcceptButton.Click += new System.EventHandler(this.EscrowAcceptButton_Click);
            // 
            // EscrowAmountTextBox
            // 
            this.EscrowAmountTextBox.Location = new System.Drawing.Point(168, 25);
            this.EscrowAmountTextBox.Name = "EscrowAmountTextBox";
            this.EscrowAmountTextBox.ReadOnly = true;
            this.EscrowAmountTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EscrowAmountTextBox.Size = new System.Drawing.Size(70, 22);
            this.EscrowAmountTextBox.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(144, 23);
            this.label35.TabIndex = 0;
            this.label35.Text = "Amount held in Escrow";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Acceptors
            // 
            this.Acceptors.Controls.Add(this.AcceptorDescriptionTextBox);
            this.Acceptors.Controls.Add(this.label7);
            this.Acceptors.Controls.Add(this.label40);
            this.Acceptors.Controls.Add(this.label36);
            this.Acceptors.Controls.Add(this.AcceptorCurrencyTextBox);
            this.Acceptors.Controls.Add(this.AcceptorUnitAddressTextBox);
            this.Acceptors.Controls.Add(this.AcceptorInterfaceNumberTextBox);
            this.Acceptors.Controls.Add(this.AcceptorDefaultPathTextBox);
            this.Acceptors.Controls.Add(this.AcceptorNoOfCoinsTextBox);
            this.Acceptors.Controls.Add(this.label8);
            this.Acceptors.Controls.Add(this.label6);
            this.Acceptors.Controls.Add(this.label5);
            this.Acceptors.Controls.Add(this.label4);
            this.Acceptors.Controls.Add(this.label3);
            this.Acceptors.Controls.Add(this.AcceptorStatusTextBox);
            this.Acceptors.Controls.Add(this.label2);
            this.Acceptors.Controls.Add(this.CoinInhibitLabel);
            this.Acceptors.Controls.Add(this.CoinNoEscrowLabel);
            this.Acceptors.Controls.Add(this.CoinLevelLabel);
            this.Acceptors.Controls.Add(this.CoinNoSentLabel);
            this.Acceptors.Controls.Add(this.CoinDefaultPathLabel);
            this.Acceptors.Controls.Add(this.CoinRoutedPathLabel);
            this.Acceptors.Controls.Add(this.CoinCoubtLabel);
            this.Acceptors.Controls.Add(this.CoinValueLabel);
            this.Acceptors.Controls.Add(this.AcceptorPanel);
            this.Acceptors.Controls.Add(this.acceptorComboBox);
            this.Acceptors.Location = new System.Drawing.Point(4, 25);
            this.Acceptors.Name = "Acceptors";
            this.Acceptors.Size = new System.Drawing.Size(688, 455);
            this.Acceptors.TabIndex = 0;
            this.Acceptors.Text = "Acceptors";
            this.Acceptors.UseVisualStyleBackColor = true;
            this.Acceptors.Visible = false;
            // 
            // AcceptorDescriptionTextBox
            // 
            this.AcceptorDescriptionTextBox.Location = new System.Drawing.Point(407, 15);
            this.AcceptorDescriptionTextBox.Name = "AcceptorDescriptionTextBox";
            this.AcceptorDescriptionTextBox.ReadOnly = true;
            this.AcceptorDescriptionTextBox.Size = new System.Drawing.Size(265, 22);
            this.AcceptorDescriptionTextBox.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(301, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "Description:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(24, 212);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(88, 16);
            this.label40.TabIndex = 25;
            this.label40.Text = "Desc:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(8, 18);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(64, 16);
            this.label36.TabIndex = 24;
            this.label36.Text = "Acceptor:";
            // 
            // AcceptorCurrencyTextBox
            // 
            this.AcceptorCurrencyTextBox.Location = new System.Drawing.Point(632, 110);
            this.AcceptorCurrencyTextBox.Name = "AcceptorCurrencyTextBox";
            this.AcceptorCurrencyTextBox.ReadOnly = true;
            this.AcceptorCurrencyTextBox.Size = new System.Drawing.Size(40, 22);
            this.AcceptorCurrencyTextBox.TabIndex = 23;
            // 
            // AcceptorUnitAddressTextBox
            // 
            this.AcceptorUnitAddressTextBox.Location = new System.Drawing.Point(632, 86);
            this.AcceptorUnitAddressTextBox.Name = "AcceptorUnitAddressTextBox";
            this.AcceptorUnitAddressTextBox.ReadOnly = true;
            this.AcceptorUnitAddressTextBox.Size = new System.Drawing.Size(40, 22);
            this.AcceptorUnitAddressTextBox.TabIndex = 22;
            // 
            // AcceptorInterfaceNumberTextBox
            // 
            this.AcceptorInterfaceNumberTextBox.Location = new System.Drawing.Point(632, 62);
            this.AcceptorInterfaceNumberTextBox.Name = "AcceptorInterfaceNumberTextBox";
            this.AcceptorInterfaceNumberTextBox.ReadOnly = true;
            this.AcceptorInterfaceNumberTextBox.Size = new System.Drawing.Size(40, 22);
            this.AcceptorInterfaceNumberTextBox.TabIndex = 21;
            // 
            // AcceptorDefaultPathTextBox
            // 
            this.AcceptorDefaultPathTextBox.Location = new System.Drawing.Point(438, 85);
            this.AcceptorDefaultPathTextBox.Name = "AcceptorDefaultPathTextBox";
            this.AcceptorDefaultPathTextBox.Size = new System.Drawing.Size(40, 22);
            this.AcceptorDefaultPathTextBox.TabIndex = 19;
            this.AcceptorDefaultPathTextBox.TextChanged += new System.EventHandler(this.AcceptorDefaultPathTextBox_TextChanged);
            // 
            // AcceptorNoOfCoinsTextBox
            // 
            this.AcceptorNoOfCoinsTextBox.Location = new System.Drawing.Point(438, 61);
            this.AcceptorNoOfCoinsTextBox.Name = "AcceptorNoOfCoinsTextBox";
            this.AcceptorNoOfCoinsTextBox.ReadOnly = true;
            this.AcceptorNoOfCoinsTextBox.Size = new System.Drawing.Size(40, 22);
            this.AcceptorNoOfCoinsTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(520, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 17;
            this.label8.Text = "Currency:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(520, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Unit Address:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(512, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Interface:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(326, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Default Path:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(326, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Types Handled:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AcceptorStatusTextBox
            // 
            this.AcceptorStatusTextBox.Location = new System.Drawing.Point(78, 56);
            this.AcceptorStatusTextBox.Name = "AcceptorStatusTextBox";
            this.AcceptorStatusTextBox.ReadOnly = true;
            this.AcceptorStatusTextBox.Size = new System.Drawing.Size(200, 22);
            this.AcceptorStatusTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Status:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinInhibitLabel
            // 
            this.CoinInhibitLabel.Location = new System.Drawing.Point(24, 391);
            this.CoinInhibitLabel.Name = "CoinInhibitLabel";
            this.CoinInhibitLabel.Size = new System.Drawing.Size(88, 16);
            this.CoinInhibitLabel.TabIndex = 9;
            this.CoinInhibitLabel.Text = "Inhibit:";
            this.CoinInhibitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinNoEscrowLabel
            // 
            this.CoinNoEscrowLabel.Location = new System.Drawing.Point(11, 364);
            this.CoinNoEscrowLabel.Name = "CoinNoEscrowLabel";
            this.CoinNoEscrowLabel.Size = new System.Drawing.Size(101, 16);
            this.CoinNoEscrowLabel.TabIndex = 8;
            this.CoinNoEscrowLabel.Text = "No. in Escrow:";
            this.CoinNoEscrowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinLevelLabel
            // 
            this.CoinLevelLabel.Location = new System.Drawing.Point(0, 332);
            this.CoinLevelLabel.Name = "CoinLevelLabel";
            this.CoinLevelLabel.Size = new System.Drawing.Size(112, 16);
            this.CoinLevelLabel.TabIndex = 7;
            this.CoinLevelLabel.Text = "Level to switch at:";
            this.CoinLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinNoSentLabel
            // 
            this.CoinNoSentLabel.Location = new System.Drawing.Point(0, 308);
            this.CoinNoSentLabel.Name = "CoinNoSentLabel";
            this.CoinNoSentLabel.Size = new System.Drawing.Size(112, 16);
            this.CoinNoSentLabel.TabIndex = 6;
            this.CoinNoSentLabel.Text = "No. sent to path:";
            this.CoinNoSentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinDefaultPathLabel
            // 
            this.CoinDefaultPathLabel.Location = new System.Drawing.Point(24, 284);
            this.CoinDefaultPathLabel.Name = "CoinDefaultPathLabel";
            this.CoinDefaultPathLabel.Size = new System.Drawing.Size(88, 16);
            this.CoinDefaultPathLabel.TabIndex = 5;
            this.CoinDefaultPathLabel.Text = "Default Path:";
            this.CoinDefaultPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinRoutedPathLabel
            // 
            this.CoinRoutedPathLabel.Location = new System.Drawing.Point(24, 260);
            this.CoinRoutedPathLabel.Name = "CoinRoutedPathLabel";
            this.CoinRoutedPathLabel.Size = new System.Drawing.Size(88, 16);
            this.CoinRoutedPathLabel.TabIndex = 4;
            this.CoinRoutedPathLabel.Text = "Routed Path:";
            this.CoinRoutedPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinCoubtLabel
            // 
            this.CoinCoubtLabel.Location = new System.Drawing.Point(24, 236);
            this.CoinCoubtLabel.Name = "CoinCoubtLabel";
            this.CoinCoubtLabel.Size = new System.Drawing.Size(88, 16);
            this.CoinCoubtLabel.TabIndex = 3;
            this.CoinCoubtLabel.Text = "Count:";
            this.CoinCoubtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CoinValueLabel
            // 
            this.CoinValueLabel.Location = new System.Drawing.Point(24, 188);
            this.CoinValueLabel.Name = "CoinValueLabel";
            this.CoinValueLabel.Size = new System.Drawing.Size(88, 16);
            this.CoinValueLabel.TabIndex = 2;
            this.CoinValueLabel.Text = "Value:";
            this.CoinValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AcceptorPanel
            // 
            this.AcceptorPanel.AutoScroll = true;
            this.AcceptorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AcceptorPanel.Controls.Add(this.label9);
            this.AcceptorPanel.Location = new System.Drawing.Point(112, 144);
            this.AcceptorPanel.Name = "AcceptorPanel";
            this.AcceptorPanel.Size = new System.Drawing.Size(560, 301);
            this.AcceptorPanel.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(555, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Coins/Notes";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // acceptorComboBox
            // 
            this.acceptorComboBox.DisplayMember = "Unit";
            this.acceptorComboBox.FormattingEnabled = true;
            this.acceptorComboBox.Items.AddRange(new object[] {
            this.USBDriverStatus});
            this.acceptorComboBox.Location = new System.Drawing.Point(78, 15);
            this.acceptorComboBox.Name = "acceptorComboBox";
            this.acceptorComboBox.Size = new System.Drawing.Size(200, 24);
            this.acceptorComboBox.TabIndex = 0;
            this.acceptorComboBox.SelectedIndexChanged += new System.EventHandler(this.acceptorComboBox_SelectedIndexChanged);
            this.acceptorComboBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.acceptorComboBox_Format);
            // 
            // Dispensers
            // 
            this.Dispensers.Controls.Add(this.label25);
            this.Dispensers.Controls.Add(this.label24);
            this.Dispensers.Controls.Add(this.label23);
            this.Dispensers.Controls.Add(this.label22);
            this.Dispensers.Controls.Add(this.label21);
            this.Dispensers.Controls.Add(this.label20);
            this.Dispensers.Controls.Add(this.DispenserPanel);
            this.Dispensers.Location = new System.Drawing.Point(4, 25);
            this.Dispensers.Name = "Dispensers";
            this.Dispensers.Size = new System.Drawing.Size(688, 455);
            this.Dispensers.TabIndex = 2;
            this.Dispensers.Text = "Dispensers";
            this.Dispensers.UseVisualStyleBackColor = true;
            this.Dispensers.Visible = false;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(621, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(48, 23);
            this.label25.TabIndex = 6;
            this.label25.Text = "Inhibit";
            this.label25.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(522, 10);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 23);
            this.label24.TabIndex = 5;
            this.label24.Text = "Status";
            this.label24.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(395, 10);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 23);
            this.label23.TabIndex = 4;
            this.label23.Text = "Contents";
            this.label23.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(317, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 23);
            this.label22.TabIndex = 3;
            this.label22.Text = "Coins Paid";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(259, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 23);
            this.label21.TabIndex = 2;
            this.label21.Text = "Address";
            this.label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(222, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 23);
            this.label20.TabIndex = 1;
            this.label20.Text = "Value";
            this.label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // DispenserPanel
            // 
            this.DispenserPanel.Location = new System.Drawing.Point(8, 36);
            this.DispenserPanel.Name = "DispenserPanel";
            this.DispenserPanel.Size = new System.Drawing.Size(672, 380);
            this.DispenserPanel.TabIndex = 0;
            // 
            // Barcodes
            // 
            this.Barcodes.Controls.Add(this.groupBox5);
            this.Barcodes.Controls.Add(this.groupBox4);
            this.Barcodes.Controls.Add(this.groupBox3);
            this.Barcodes.Controls.Add(this.panel1);
            this.Barcodes.Location = new System.Drawing.Point(4, 25);
            this.Barcodes.Name = "Barcodes";
            this.Barcodes.Size = new System.Drawing.Size(688, 455);
            this.Barcodes.TabIndex = 5;
            this.Barcodes.Text = "Barcodes";
            this.Barcodes.UseVisualStyleBackColor = true;
            this.Barcodes.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BarcodeTicketsStackedTextBox);
            this.groupBox5.Controls.Add(this.label34);
            this.groupBox5.Controls.Add(this.BarcodeLastTicketTextBox);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Location = new System.Drawing.Point(8, 247);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(672, 83);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Stacked Tickets";
            // 
            // BarcodeTicketsStackedTextBox
            // 
            this.BarcodeTicketsStackedTextBox.Location = new System.Drawing.Point(152, 52);
            this.BarcodeTicketsStackedTextBox.Name = "BarcodeTicketsStackedTextBox";
            this.BarcodeTicketsStackedTextBox.ReadOnly = true;
            this.BarcodeTicketsStackedTextBox.Size = new System.Drawing.Size(80, 22);
            this.BarcodeTicketsStackedTextBox.TabIndex = 3;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(24, 52);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(112, 23);
            this.label34.TabIndex = 2;
            this.label34.Text = "Tickets stacked:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BarcodeLastTicketTextBox
            // 
            this.BarcodeLastTicketTextBox.Location = new System.Drawing.Point(152, 24);
            this.BarcodeLastTicketTextBox.Name = "BarcodeLastTicketTextBox";
            this.BarcodeLastTicketTextBox.ReadOnly = true;
            this.BarcodeLastTicketTextBox.Size = new System.Drawing.Size(504, 22);
            this.BarcodeLastTicketTextBox.TabIndex = 1;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(16, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(128, 23);
            this.label33.TabIndex = 0;
            this.label33.Text = "Last ticket stacked:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BarcodeEscrowReturnButton);
            this.groupBox4.Controls.Add(this.BarcodeEscrowAcceptButton);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.BarcodeEscrowTicketTextBox);
            this.groupBox4.Location = new System.Drawing.Point(8, 336);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(672, 64);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ticket in Escrow";
            // 
            // BarcodeEscrowReturnButton
            // 
            this.BarcodeEscrowReturnButton.Location = new System.Drawing.Point(560, 32);
            this.BarcodeEscrowReturnButton.Name = "BarcodeEscrowReturnButton";
            this.BarcodeEscrowReturnButton.Size = new System.Drawing.Size(75, 23);
            this.BarcodeEscrowReturnButton.TabIndex = 3;
            this.BarcodeEscrowReturnButton.Text = "Return";
            this.BarcodeEscrowReturnButton.Click += new System.EventHandler(this.BarcodeEscrowReturnButton_Click);
            // 
            // BarcodeEscrowAcceptButton
            // 
            this.BarcodeEscrowAcceptButton.Location = new System.Drawing.Point(472, 32);
            this.BarcodeEscrowAcceptButton.Name = "BarcodeEscrowAcceptButton";
            this.BarcodeEscrowAcceptButton.Size = new System.Drawing.Size(75, 23);
            this.BarcodeEscrowAcceptButton.TabIndex = 2;
            this.BarcodeEscrowAcceptButton.Text = "Accept";
            this.BarcodeEscrowAcceptButton.Click += new System.EventHandler(this.BarcodeEscrowAcceptButton_Click);
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(16, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(48, 23);
            this.label32.TabIndex = 1;
            this.label32.Text = "Ticket:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BarcodeEscrowTicketTextBox
            // 
            this.BarcodeEscrowTicketTextBox.Location = new System.Drawing.Point(72, 32);
            this.BarcodeEscrowTicketTextBox.Name = "BarcodeEscrowTicketTextBox";
            this.BarcodeEscrowTicketTextBox.ReadOnly = true;
            this.BarcodeEscrowTicketTextBox.Size = new System.Drawing.Size(384, 22);
            this.BarcodeEscrowTicketTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BarcodeReference);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.BarcodePrintButton);
            this.groupBox3.Controls.Add(this.BarcodeMachineIdTextBox);
            this.groupBox3.Controls.Add(this.BarcodeTimeTextBox);
            this.groupBox3.Controls.Add(this.BarcodeDateTextBox);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label29);
            this.groupBox3.Controls.Add(this.BarcodeNumericAmountTextBox);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.BarcodeAmountInWordsTextBox);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(672, 233);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Print Ticket";
            // 
            // BarcodeReference
            // 
            this.BarcodeReference.Location = new System.Drawing.Point(142, 29);
            this.BarcodeReference.MaxLength = 18;
            this.BarcodeReference.Name = "BarcodeReference";
            this.BarcodeReference.Size = new System.Drawing.Size(286, 22);
            this.BarcodeReference.TabIndex = 23;
            this.BarcodeReference.Validating += new System.ComponentModel.CancelEventHandler(this.BarcodeReference_Validating);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(19, 34);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(117, 16);
            this.label37.TabIndex = 22;
            this.label37.Text = "Barcode reference:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BarcodePrintButton
            // 
            this.BarcodePrintButton.Location = new System.Drawing.Point(574, 187);
            this.BarcodePrintButton.Name = "BarcodePrintButton";
            this.BarcodePrintButton.Size = new System.Drawing.Size(75, 23);
            this.BarcodePrintButton.TabIndex = 21;
            this.BarcodePrintButton.Text = "Print";
            this.BarcodePrintButton.Click += new System.EventHandler(this.BarcodePrintButton_Click);
            // 
            // BarcodeMachineIdTextBox
            // 
            this.BarcodeMachineIdTextBox.Location = new System.Drawing.Point(142, 188);
            this.BarcodeMachineIdTextBox.Name = "BarcodeMachineIdTextBox";
            this.BarcodeMachineIdTextBox.Size = new System.Drawing.Size(100, 22);
            this.BarcodeMachineIdTextBox.TabIndex = 20;
            // 
            // BarcodeTimeTextBox
            // 
            this.BarcodeTimeTextBox.Location = new System.Drawing.Point(142, 156);
            this.BarcodeTimeTextBox.Name = "BarcodeTimeTextBox";
            this.BarcodeTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.BarcodeTimeTextBox.TabIndex = 19;
            // 
            // BarcodeDateTextBox
            // 
            this.BarcodeDateTextBox.Location = new System.Drawing.Point(142, 124);
            this.BarcodeDateTextBox.Name = "BarcodeDateTextBox";
            this.BarcodeDateTextBox.Size = new System.Drawing.Size(100, 22);
            this.BarcodeDateTextBox.TabIndex = 18;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(30, 188);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 23);
            this.label31.TabIndex = 17;
            this.label31.Text = "Machine Id:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(34, 155);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 23);
            this.label30.TabIndex = 16;
            this.label30.Text = "Time:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(34, 124);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 23);
            this.label29.TabIndex = 15;
            this.label29.Text = "Date:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BarcodeNumericAmountTextBox
            // 
            this.BarcodeNumericAmountTextBox.Location = new System.Drawing.Point(142, 92);
            this.BarcodeNumericAmountTextBox.Name = "BarcodeNumericAmountTextBox";
            this.BarcodeNumericAmountTextBox.Size = new System.Drawing.Size(100, 22);
            this.BarcodeNumericAmountTextBox.TabIndex = 14;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(22, 91);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(112, 23);
            this.label28.TabIndex = 13;
            this.label28.Text = "Numeric amount:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BarcodeAmountInWordsTextBox
            // 
            this.BarcodeAmountInWordsTextBox.Location = new System.Drawing.Point(142, 60);
            this.BarcodeAmountInWordsTextBox.Name = "BarcodeAmountInWordsTextBox";
            this.BarcodeAmountInWordsTextBox.Size = new System.Drawing.Size(504, 22);
            this.BarcodeAmountInWordsTextBox.TabIndex = 12;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(22, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(112, 23);
            this.label27.TabIndex = 11;
            this.label27.Text = "Amount in words:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.BarcodeStatusTextBox);
            this.panel1.Location = new System.Drawing.Point(8, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 40);
            this.panel1.TabIndex = 9;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(16, 8);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(152, 23);
            this.label26.TabIndex = 5;
            this.label26.Text = "Barcode Printer Status:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BarcodeStatusTextBox
            // 
            this.BarcodeStatusTextBox.Location = new System.Drawing.Point(168, 8);
            this.BarcodeStatusTextBox.Name = "BarcodeStatusTextBox";
            this.BarcodeStatusTextBox.ReadOnly = true;
            this.BarcodeStatusTextBox.Size = new System.Drawing.Size(480, 22);
            this.BarcodeStatusTextBox.TabIndex = 4;
            // 
            // Meter
            // 
            this.Meter.Controls.Add(this.groupBox1);
            this.Meter.Controls.Add(this.MeterStatusTextBox);
            this.Meter.Controls.Add(this.MeterNameTextBox);
            this.Meter.Controls.Add(this.label15);
            this.Meter.Controls.Add(this.label13);
            this.Meter.Location = new System.Drawing.Point(4, 25);
            this.Meter.Name = "Meter";
            this.Meter.Size = new System.Drawing.Size(688, 455);
            this.Meter.TabIndex = 3;
            this.Meter.Text = "Meter";
            this.Meter.UseVisualStyleBackColor = true;
            this.Meter.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.CounterNumberUpDown);
            this.groupBox1.Location = new System.Drawing.Point(20, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 321);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Counters";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.CounterDisplayCountRadioButton);
            this.groupBox8.Controls.Add(this.CounterDisplayBothRadioButton);
            this.groupBox8.Location = new System.Drawing.Point(27, 181);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(307, 88);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Display Mode";
            // 
            // CounterDisplayCountRadioButton
            // 
            this.CounterDisplayCountRadioButton.Location = new System.Drawing.Point(25, 51);
            this.CounterDisplayCountRadioButton.Name = "CounterDisplayCountRadioButton";
            this.CounterDisplayCountRadioButton.Size = new System.Drawing.Size(186, 24);
            this.CounterDisplayCountRadioButton.TabIndex = 8;
            this.CounterDisplayCountRadioButton.Text = "Count Only";
            this.CounterDisplayCountRadioButton.CheckedChanged += new System.EventHandler(this.CounterDisplayCountRadioButton_CheckedChanged);
            // 
            // CounterDisplayBothRadioButton
            // 
            this.CounterDisplayBothRadioButton.Location = new System.Drawing.Point(25, 21);
            this.CounterDisplayBothRadioButton.Name = "CounterDisplayBothRadioButton";
            this.CounterDisplayBothRadioButton.Size = new System.Drawing.Size(186, 24);
            this.CounterDisplayBothRadioButton.TabIndex = 9;
            this.CounterDisplayBothRadioButton.Text = "Count and Caption";
            this.CounterDisplayBothRadioButton.CheckedChanged += new System.EventHandler(this.CounterDisplayBothRadioButton_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.CounterCaptionTextBox);
            this.panel2.Controls.Add(this.CounterCountTextBox);
            this.panel2.Location = new System.Drawing.Point(27, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 94);
            this.panel2.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(15, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 23);
            this.label17.TabIndex = 2;
            this.label17.Text = "Caption:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(22, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 23);
            this.label18.TabIndex = 3;
            this.label18.Text = "Count:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CounterCaptionTextBox
            // 
            this.CounterCaptionTextBox.Location = new System.Drawing.Point(102, 14);
            this.CounterCaptionTextBox.Name = "CounterCaptionTextBox";
            this.CounterCaptionTextBox.Size = new System.Drawing.Size(176, 22);
            this.CounterCaptionTextBox.TabIndex = 4;
            this.CounterCaptionTextBox.Text = "textBox1";
            this.CounterCaptionTextBox.TextChanged += new System.EventHandler(this.CounterCaptionTextBox_TextChanged);
            // 
            // CounterCountTextBox
            // 
            this.CounterCountTextBox.Location = new System.Drawing.Point(102, 49);
            this.CounterCountTextBox.Name = "CounterCountTextBox";
            this.CounterCountTextBox.ReadOnly = true;
            this.CounterCountTextBox.Size = new System.Drawing.Size(100, 22);
            this.CounterCountTextBox.TabIndex = 5;
            this.CounterCountTextBox.Text = "textBox2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CounterIncrementUpDown);
            this.groupBox2.Controls.Add(this.CounterIncrementButton);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(427, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 234);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Increment Counter";
            // 
            // CounterIncrementUpDown
            // 
            this.CounterIncrementUpDown.Location = new System.Drawing.Point(32, 120);
            this.CounterIncrementUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CounterIncrementUpDown.Name = "CounterIncrementUpDown";
            this.CounterIncrementUpDown.Size = new System.Drawing.Size(80, 22);
            this.CounterIncrementUpDown.TabIndex = 3;
            this.CounterIncrementUpDown.ThousandsSeparator = true;
            // 
            // CounterIncrementButton
            // 
            this.CounterIncrementButton.Location = new System.Drawing.Point(136, 120);
            this.CounterIncrementButton.Name = "CounterIncrementButton";
            this.CounterIncrementButton.Size = new System.Drawing.Size(48, 23);
            this.CounterIncrementButton.TabIndex = 2;
            this.CounterIncrementButton.Text = "Inc";
            this.CounterIncrementButton.Click += new System.EventHandler(this.CounterIncrementButton_Click);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(21, 37);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(173, 69);
            this.label19.TabIndex = 1;
            this.label19.Text = "To increment the count of this counter, enter a value and click the \'Inc\' button";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(24, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 23);
            this.label16.TabIndex = 1;
            this.label16.Text = "Counter:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CounterNumberUpDown
            // 
            this.CounterNumberUpDown.Location = new System.Drawing.Point(107, 35);
            this.CounterNumberUpDown.Name = "CounterNumberUpDown";
            this.CounterNumberUpDown.Size = new System.Drawing.Size(40, 22);
            this.CounterNumberUpDown.TabIndex = 0;
            this.CounterNumberUpDown.ValueChanged += new System.EventHandler(this.CounterNumberUpDown_ValueChanged);
            // 
            // MeterStatusTextBox
            // 
            this.MeterStatusTextBox.Location = new System.Drawing.Point(152, 61);
            this.MeterStatusTextBox.Name = "MeterStatusTextBox";
            this.MeterStatusTextBox.ReadOnly = true;
            this.MeterStatusTextBox.Size = new System.Drawing.Size(100, 22);
            this.MeterStatusTextBox.TabIndex = 3;
            this.MeterStatusTextBox.Text = "textBox1";
            // 
            // MeterNameTextBox
            // 
            this.MeterNameTextBox.Location = new System.Drawing.Point(152, 24);
            this.MeterNameTextBox.Name = "MeterNameTextBox";
            this.MeterNameTextBox.ReadOnly = true;
            this.MeterNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.MeterNameTextBox.TabIndex = 2;
            this.MeterNameTextBox.Text = "textBox1";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(40, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 1;
            this.label15.Text = "Status:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(40, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 0;
            this.label13.Text = "Serial Number:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SwitchesLEDs
            // 
            this.SwitchesLEDs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SwitchesLEDs.Controls.Add(this.LEDgroupBox);
            this.SwitchesLEDs.Controls.Add(this.SwitchGroupBox);
            this.SwitchesLEDs.Location = new System.Drawing.Point(4, 25);
            this.SwitchesLEDs.Name = "SwitchesLEDs";
            this.SwitchesLEDs.Size = new System.Drawing.Size(688, 455);
            this.SwitchesLEDs.TabIndex = 1;
            this.SwitchesLEDs.Text = "Switches/LEDs";
            this.SwitchesLEDs.UseVisualStyleBackColor = true;
            this.SwitchesLEDs.Visible = false;
            // 
            // LEDgroupBox
            // 
            this.LEDgroupBox.Controls.Add(this.LED_10);
            this.LEDgroupBox.Controls.Add(this.LED_11);
            this.LEDgroupBox.Controls.Add(this.LED_12);
            this.LEDgroupBox.Controls.Add(this.LED_13);
            this.LEDgroupBox.Controls.Add(this.LED_14);
            this.LEDgroupBox.Controls.Add(this.LED_15);
            this.LEDgroupBox.Controls.Add(this.LED_9);
            this.LEDgroupBox.Controls.Add(this.LED_8);
            this.LEDgroupBox.Controls.Add(this.LED_7);
            this.LEDgroupBox.Controls.Add(this.LED_6);
            this.LEDgroupBox.Controls.Add(this.LED_5);
            this.LEDgroupBox.Controls.Add(this.LED_4);
            this.LEDgroupBox.Controls.Add(this.LED_3);
            this.LEDgroupBox.Controls.Add(this.LED_2);
            this.LEDgroupBox.Controls.Add(this.LED_1);
            this.LEDgroupBox.Controls.Add(this.LED_0);
            this.LEDgroupBox.Location = new System.Drawing.Point(272, 16);
            this.LEDgroupBox.Name = "LEDgroupBox";
            this.LEDgroupBox.Size = new System.Drawing.Size(110, 422);
            this.LEDgroupBox.TabIndex = 14;
            this.LEDgroupBox.TabStop = false;
            this.LEDgroupBox.Text = "Indicators";
            // 
            // LED_10
            // 
            this.LED_10.BackColor = System.Drawing.Color.Gray;
            this.LED_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_10.Location = new System.Drawing.Point(32, 270);
            this.LED_10.Name = "LED_10";
            this.LED_10.Size = new System.Drawing.Size(40, 15);
            this.LED_10.TabIndex = 12;
            this.LED_10.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_11
            // 
            this.LED_11.BackColor = System.Drawing.Color.Gray;
            this.LED_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_11.Location = new System.Drawing.Point(32, 293);
            this.LED_11.Name = "LED_11";
            this.LED_11.Size = new System.Drawing.Size(40, 15);
            this.LED_11.TabIndex = 12;
            this.LED_11.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_12
            // 
            this.LED_12.BackColor = System.Drawing.Color.Gray;
            this.LED_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_12.Location = new System.Drawing.Point(32, 318);
            this.LED_12.Name = "LED_12";
            this.LED_12.Size = new System.Drawing.Size(40, 15);
            this.LED_12.TabIndex = 12;
            this.LED_12.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_13
            // 
            this.LED_13.BackColor = System.Drawing.Color.Gray;
            this.LED_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_13.Location = new System.Drawing.Point(32, 343);
            this.LED_13.Name = "LED_13";
            this.LED_13.Size = new System.Drawing.Size(40, 15);
            this.LED_13.TabIndex = 12;
            this.LED_13.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_14
            // 
            this.LED_14.BackColor = System.Drawing.Color.Gray;
            this.LED_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_14.Location = new System.Drawing.Point(32, 368);
            this.LED_14.Name = "LED_14";
            this.LED_14.Size = new System.Drawing.Size(40, 15);
            this.LED_14.TabIndex = 11;
            this.LED_14.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_15
            // 
            this.LED_15.BackColor = System.Drawing.Color.Gray;
            this.LED_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_15.Location = new System.Drawing.Point(32, 392);
            this.LED_15.Name = "LED_15";
            this.LED_15.Size = new System.Drawing.Size(40, 15);
            this.LED_15.TabIndex = 10;
            this.LED_15.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_9
            // 
            this.LED_9.BackColor = System.Drawing.Color.Gray;
            this.LED_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_9.Location = new System.Drawing.Point(32, 243);
            this.LED_9.Name = "LED_9";
            this.LED_9.Size = new System.Drawing.Size(40, 15);
            this.LED_9.TabIndex = 9;
            this.LED_9.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_8
            // 
            this.LED_8.BackColor = System.Drawing.Color.Gray;
            this.LED_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_8.Location = new System.Drawing.Point(32, 218);
            this.LED_8.Name = "LED_8";
            this.LED_8.Size = new System.Drawing.Size(40, 15);
            this.LED_8.TabIndex = 8;
            this.LED_8.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_7
            // 
            this.LED_7.BackColor = System.Drawing.Color.Gray;
            this.LED_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_7.Location = new System.Drawing.Point(32, 193);
            this.LED_7.Name = "LED_7";
            this.LED_7.Size = new System.Drawing.Size(40, 15);
            this.LED_7.TabIndex = 7;
            this.LED_7.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_6
            // 
            this.LED_6.BackColor = System.Drawing.Color.Gray;
            this.LED_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_6.Location = new System.Drawing.Point(32, 168);
            this.LED_6.Name = "LED_6";
            this.LED_6.Size = new System.Drawing.Size(40, 15);
            this.LED_6.TabIndex = 6;
            this.LED_6.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_5
            // 
            this.LED_5.BackColor = System.Drawing.Color.Gray;
            this.LED_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_5.Location = new System.Drawing.Point(32, 143);
            this.LED_5.Name = "LED_5";
            this.LED_5.Size = new System.Drawing.Size(40, 15);
            this.LED_5.TabIndex = 5;
            this.LED_5.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_4
            // 
            this.LED_4.BackColor = System.Drawing.Color.Gray;
            this.LED_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_4.Location = new System.Drawing.Point(32, 118);
            this.LED_4.Name = "LED_4";
            this.LED_4.Size = new System.Drawing.Size(40, 15);
            this.LED_4.TabIndex = 4;
            this.LED_4.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_3
            // 
            this.LED_3.BackColor = System.Drawing.Color.Gray;
            this.LED_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_3.Location = new System.Drawing.Point(32, 93);
            this.LED_3.Name = "LED_3";
            this.LED_3.Size = new System.Drawing.Size(40, 15);
            this.LED_3.TabIndex = 3;
            this.LED_3.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_2
            // 
            this.LED_2.BackColor = System.Drawing.Color.Gray;
            this.LED_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_2.Location = new System.Drawing.Point(32, 68);
            this.LED_2.Name = "LED_2";
            this.LED_2.Size = new System.Drawing.Size(40, 15);
            this.LED_2.TabIndex = 2;
            this.LED_2.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_1
            // 
            this.LED_1.BackColor = System.Drawing.Color.Gray;
            this.LED_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_1.Location = new System.Drawing.Point(32, 43);
            this.LED_1.Name = "LED_1";
            this.LED_1.Size = new System.Drawing.Size(40, 15);
            this.LED_1.TabIndex = 1;
            this.LED_1.Click += new System.EventHandler(this.LED_Click);
            // 
            // LED_0
            // 
            this.LED_0.BackColor = System.Drawing.Color.Gray;
            this.LED_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LED_0.Location = new System.Drawing.Point(32, 21);
            this.LED_0.Name = "LED_0";
            this.LED_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LED_0.Size = new System.Drawing.Size(40, 15);
            this.LED_0.TabIndex = 0;
            this.LED_0.Click += new System.EventHandler(this.LED_Click);
            // 
            // SwitchGroupBox
            // 
            this.SwitchGroupBox.Controls.Add(this.Switch_15);
            this.SwitchGroupBox.Controls.Add(this.Switch_14);
            this.SwitchGroupBox.Controls.Add(this.Switch_12);
            this.SwitchGroupBox.Controls.Add(this.Switch_13);
            this.SwitchGroupBox.Controls.Add(this.Switch_10);
            this.SwitchGroupBox.Controls.Add(this.Switch_9);
            this.SwitchGroupBox.Controls.Add(this.Switch_8);
            this.SwitchGroupBox.Controls.Add(this.Switch_6);
            this.SwitchGroupBox.Controls.Add(this.Switch_7);
            this.SwitchGroupBox.Controls.Add(this.Switch_4);
            this.SwitchGroupBox.Controls.Add(this.Switch_2);
            this.SwitchGroupBox.Controls.Add(this.Switch_1);
            this.SwitchGroupBox.Controls.Add(this.Switch_0);
            this.SwitchGroupBox.Controls.Add(this.Switch_5);
            this.SwitchGroupBox.Controls.Add(this.Switch_3);
            this.SwitchGroupBox.Controls.Add(this.Switch_11);
            this.SwitchGroupBox.Location = new System.Drawing.Point(56, 16);
            this.SwitchGroupBox.Name = "SwitchGroupBox";
            this.SwitchGroupBox.Size = new System.Drawing.Size(104, 422);
            this.SwitchGroupBox.TabIndex = 13;
            this.SwitchGroupBox.TabStop = false;
            this.SwitchGroupBox.Text = "Switches";
            // 
            // Switch_15
            // 
            this.Switch_15.BackColor = System.Drawing.Color.Gray;
            this.Switch_15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_15.Location = new System.Drawing.Point(33, 393);
            this.Switch_15.Name = "Switch_15";
            this.Switch_15.Size = new System.Drawing.Size(40, 15);
            this.Switch_15.TabIndex = 4;
            // 
            // Switch_14
            // 
            this.Switch_14.BackColor = System.Drawing.Color.Gray;
            this.Switch_14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_14.Location = new System.Drawing.Point(33, 368);
            this.Switch_14.Name = "Switch_14";
            this.Switch_14.Size = new System.Drawing.Size(40, 15);
            this.Switch_14.TabIndex = 3;
            // 
            // Switch_12
            // 
            this.Switch_12.BackColor = System.Drawing.Color.Gray;
            this.Switch_12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_12.Location = new System.Drawing.Point(33, 318);
            this.Switch_12.Name = "Switch_12";
            this.Switch_12.Size = new System.Drawing.Size(40, 15);
            this.Switch_12.TabIndex = 3;
            // 
            // Switch_13
            // 
            this.Switch_13.BackColor = System.Drawing.Color.Gray;
            this.Switch_13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_13.Location = new System.Drawing.Point(33, 343);
            this.Switch_13.Name = "Switch_13";
            this.Switch_13.Size = new System.Drawing.Size(40, 15);
            this.Switch_13.TabIndex = 3;
            // 
            // Switch_10
            // 
            this.Switch_10.BackColor = System.Drawing.Color.Gray;
            this.Switch_10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_10.Location = new System.Drawing.Point(33, 268);
            this.Switch_10.Name = "Switch_10";
            this.Switch_10.Size = new System.Drawing.Size(40, 15);
            this.Switch_10.TabIndex = 9;
            // 
            // Switch_9
            // 
            this.Switch_9.BackColor = System.Drawing.Color.Gray;
            this.Switch_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_9.Location = new System.Drawing.Point(33, 243);
            this.Switch_9.Name = "Switch_9";
            this.Switch_9.Size = new System.Drawing.Size(40, 15);
            this.Switch_9.TabIndex = 8;
            // 
            // Switch_8
            // 
            this.Switch_8.BackColor = System.Drawing.Color.Gray;
            this.Switch_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_8.Location = new System.Drawing.Point(33, 218);
            this.Switch_8.Name = "Switch_8";
            this.Switch_8.Size = new System.Drawing.Size(40, 15);
            this.Switch_8.TabIndex = 7;
            // 
            // Switch_6
            // 
            this.Switch_6.BackColor = System.Drawing.Color.Gray;
            this.Switch_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_6.Location = new System.Drawing.Point(33, 168);
            this.Switch_6.Name = "Switch_6";
            this.Switch_6.Size = new System.Drawing.Size(40, 15);
            this.Switch_6.TabIndex = 6;
            // 
            // Switch_7
            // 
            this.Switch_7.BackColor = System.Drawing.Color.Gray;
            this.Switch_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_7.Location = new System.Drawing.Point(33, 193);
            this.Switch_7.Name = "Switch_7";
            this.Switch_7.Size = new System.Drawing.Size(40, 15);
            this.Switch_7.TabIndex = 5;
            // 
            // Switch_4
            // 
            this.Switch_4.BackColor = System.Drawing.Color.Gray;
            this.Switch_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_4.Location = new System.Drawing.Point(33, 118);
            this.Switch_4.Name = "Switch_4";
            this.Switch_4.Size = new System.Drawing.Size(40, 15);
            this.Switch_4.TabIndex = 4;
            // 
            // Switch_2
            // 
            this.Switch_2.BackColor = System.Drawing.Color.Gray;
            this.Switch_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_2.Location = new System.Drawing.Point(33, 68);
            this.Switch_2.Name = "Switch_2";
            this.Switch_2.Size = new System.Drawing.Size(40, 15);
            this.Switch_2.TabIndex = 2;
            // 
            // Switch_1
            // 
            this.Switch_1.BackColor = System.Drawing.Color.Gray;
            this.Switch_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_1.Location = new System.Drawing.Point(33, 43);
            this.Switch_1.Name = "Switch_1";
            this.Switch_1.Size = new System.Drawing.Size(40, 15);
            this.Switch_1.TabIndex = 1;
            // 
            // Switch_0
            // 
            this.Switch_0.BackColor = System.Drawing.Color.Gray;
            this.Switch_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_0.Location = new System.Drawing.Point(33, 21);
            this.Switch_0.Name = "Switch_0";
            this.Switch_0.Size = new System.Drawing.Size(40, 15);
            this.Switch_0.TabIndex = 1;
            // 
            // Switch_5
            // 
            this.Switch_5.BackColor = System.Drawing.Color.Gray;
            this.Switch_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_5.Location = new System.Drawing.Point(33, 143);
            this.Switch_5.Name = "Switch_5";
            this.Switch_5.Size = new System.Drawing.Size(40, 15);
            this.Switch_5.TabIndex = 2;
            // 
            // Switch_3
            // 
            this.Switch_3.BackColor = System.Drawing.Color.Gray;
            this.Switch_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_3.Location = new System.Drawing.Point(33, 93);
            this.Switch_3.Name = "Switch_3";
            this.Switch_3.Size = new System.Drawing.Size(40, 15);
            this.Switch_3.TabIndex = 2;
            // 
            // Switch_11
            // 
            this.Switch_11.BackColor = System.Drawing.Color.Gray;
            this.Switch_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Switch_11.Location = new System.Drawing.Point(33, 293);
            this.Switch_11.Name = "Switch_11";
            this.Switch_11.Size = new System.Drawing.Size(40, 15);
            this.Switch_11.TabIndex = 2;
            // 
            // MHEEvents
            // 
            this.MHEEvents.Controls.Add(this.EventListBox);
            this.MHEEvents.Location = new System.Drawing.Point(4, 25);
            this.MHEEvents.Name = "MHEEvents";
            this.MHEEvents.Size = new System.Drawing.Size(688, 455);
            this.MHEEvents.TabIndex = 7;
            this.MHEEvents.Text = "Events";
            this.MHEEvents.UseVisualStyleBackColor = true;
            this.MHEEvents.Visible = false;
            // 
            // EventListBox
            // 
            this.EventListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventListBox.ItemHeight = 16;
            this.EventListBox.Location = new System.Drawing.Point(24, 24);
            this.EventListBox.Name = "EventListBox";
            this.EventListBox.Size = new System.Drawing.Size(649, 404);
            this.EventListBox.TabIndex = 10;
            // 
            // DES
            // 
            this.DES.Controls.Add(this.groupBox9);
            this.DES.Controls.Add(this.label42);
            this.DES.Controls.Add(this.label39);
            this.DES.Controls.Add(this.DESStatusTextBox);
            this.DES.Location = new System.Drawing.Point(4, 25);
            this.DES.Name = "DES";
            this.DES.Padding = new System.Windows.Forms.Padding(3);
            this.DES.Size = new System.Drawing.Size(688, 455);
            this.DES.TabIndex = 8;
            this.DES.Text = "DES";
            this.DES.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox11);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Location = new System.Drawing.Point(28, 26);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(622, 343);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "DES Security";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.newKeyTextBox);
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.ClearButton);
            this.groupBox11.Controls.Add(this.LockButton);
            this.groupBox11.Location = new System.Drawing.Point(35, 182);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(540, 94);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "PayLink";
            // 
            // newKeyTextBox
            // 
            this.newKeyTextBox.AcceptsReturn = true;
            this.newKeyTextBox.Location = new System.Drawing.Point(106, 34);
            this.newKeyTextBox.MaxLength = 16;
            this.newKeyTextBox.Name = "newKeyTextBox";
            this.newKeyTextBox.Size = new System.Drawing.Size(154, 22);
            this.newKeyTextBox.TabIndex = 3;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(34, 34);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(64, 16);
            this.label41.TabIndex = 3;
            this.label41.Text = "New Key:";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(409, 34);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(114, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Unlock PayLink";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // LockButton
            // 
            this.LockButton.Location = new System.Drawing.Point(278, 34);
            this.LockButton.Name = "LockButton";
            this.LockButton.Size = new System.Drawing.Size(114, 23);
            this.LockButton.TabIndex = 5;
            this.LockButton.Text = "Lock PayLink";
            this.LockButton.UseVisualStyleBackColor = true;
            this.LockButton.Click += new System.EventHandler(this.LockButton_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.SetButton);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.keyTextBox);
            this.groupBox10.Location = new System.Drawing.Point(35, 37);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(540, 92);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Application";
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(278, 37);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(97, 23);
            this.SetButton.TabIndex = 2;
            this.SetButton.Text = "Set Key";
            this.SetButton.UseVisualStyleBackColor = true;
            this.SetButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(34, 42);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(66, 16);
            this.label38.TabIndex = 0;
            this.label38.Text = "DES Key:";
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(106, 39);
            this.keyTextBox.MaxLength = 16;
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(154, 22);
            this.keyTextBox.TabIndex = 1;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(60, 26);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 16);
            this.label42.TabIndex = 10;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(25, 405);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(102, 16);
            this.label39.TabIndex = 3;
            this.label39.Text = "Security Status:";
            // 
            // DESStatusTextBox
            // 
            this.DESStatusTextBox.Location = new System.Drawing.Point(133, 402);
            this.DESStatusTextBox.Name = "DESStatusTextBox";
            this.DESStatusTextBox.Size = new System.Drawing.Size(517, 22);
            this.DESStatusTextBox.TabIndex = 4;
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 550);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Aardvark Embedded Solutions";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USBDriverStatus)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.General.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.EscrowGroupBox.ResumeLayout(false);
            this.EscrowGroupBox.PerformLayout();
            this.Acceptors.ResumeLayout(false);
            this.Acceptors.PerformLayout();
            this.AcceptorPanel.ResumeLayout(false);
            this.Dispensers.ResumeLayout(false);
            this.Barcodes.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Meter.ResumeLayout(false);
            this.Meter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CounterIncrementUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CounterNumberUpDown)).EndInit();
            this.SwitchesLEDs.ResumeLayout(false);
            this.LEDgroupBox.ResumeLayout(false);
            this.SwitchGroupBox.ResumeLayout(false);
            this.MHEEvents.ResumeLayout(false);
            this.DES.ResumeLayout(false);
            this.DES.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private int TotalAccepted;
		private int EscrowAtAccept;
        private MHE.Acceptor currentAcceptor;

		private AES.MHE mhe;

        //private bool[] LEDs = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};

		private void Timer_Tick(object sender, System.EventArgs e)
		{
			lock(mhe)
			{
                Timer.Enabled = false;
                try
                {
                    UpdateControls();
                }
                finally
                {
                    Timer.Enabled = true;
                }
			}
		}

        private void UpdateControls()
        {            
            UpdateMHEControls();

            UpdateUSBDriverStatus();

            UpdateEventControls();

            // update selected acceptor
            UpdateAcceptorPanel();

            // update all dispensers
            UpdateDispenserPanels();

            // update switch controls
            UpdateSwitchControls();

            // update Meter
            UpdateMeterControls();

            // update Bar Codes
            UpdateBarcodeControls();

            // update the DES controls
            UpdateDESControls();
        }

		private void Form1_Load(object sender, System.EventArgs e)
		{
			mhe = new MHE();

			int Ret = mhe.Open();
			if( Ret != 0 )
			{
				MessageBox.Show("MHE Open error " + Ret.ToString()) ;
				this.Close();
			}
			else
			{
				mhe.Enabled = true;

				// remember present current values
				TotalAccepted = mhe.CurrentValue;
				EscrowAtAccept = mhe.Escrow.Throughput;

                // initialse Escrow as enabled
				EscrowEnabledCheckBox.Checked = true;
				mhe.Escrow.Enabled = true;

                // set the curent acceptor to the first in the list
                if (mhe.Acceptors.Count > 0)
                {
                    currentAcceptor = mhe.Acceptors[0];
                }
                // bind acceptors to drop-down in form
                acceptorComboBox.DataSource = mhe.Acceptors;
                acceptorComboBox.SelectedIndex = 0;
                InitialiseAcceptorControls();

                // initialise the Dispenser Panel
                for (int i = 0; i < 16; ++i)
                {
                    MHE.Dispenser dispenser = mhe.Dispensers[i];
                    if (dispenser != null)
                    {
                        NewDispenserPanel(i, dispenser);
                    }
                }

                // initialise the meter panel
                InitialiseMeterControls();

                // initialise the LED states
                InitialiseLEDs();
                
                // show current values
                UpdateControls();

				Timer.Enabled = true ;
			}
		}

		private void UpdateBarcodeControls()
		{
			string ticketBarCode;

			// get Barcode Printer status
			this.BarcodeStatusTextBox.Text = mhe.Barcode.PrinterStatus.ToString();

			// get Stacked tickets data
            this.BarcodeTicketsStackedTextBox.Text = mhe.Barcode.TicketsStacked(out ticketBarCode).ToString();
			this.BarcodeLastTicketTextBox.Text = ticketBarCode;

			// get data on any ticket held in Escrow
            if (mhe.Barcode.TicketInEscrow(out ticketBarCode))
			{
				this.BarcodeEscrowTicketTextBox.Text = ticketBarCode;
			}
		}

		private void UpdateAcceptorPanel()
		{

            if (currentAcceptor != null)
            {
                // read the acceptor
                currentAcceptor.ReadDetails();

                // update the controls with data from the acceptor
                for (int i = 0; i < currentAcceptor.NoOfCoins; ++i)
                {
                    UpdateCoinPanel(i, currentAcceptor.Coin[i]);
                }
                this.AcceptorStatusTextBox.Text = ((MHE.AcceptorStatus)currentAcceptor.Status).ToString();
                this.AcceptorCurrencyTextBox.Text = currentAcceptor.Currency;
                this.AcceptorDefaultPathTextBox.Text = currentAcceptor.DefaultPath.ToString();
                this.AcceptorInterfaceNumberTextBox.Text = currentAcceptor.InterfaceNumber.ToString();
                this.AcceptorNoOfCoinsTextBox.Text = currentAcceptor.NoOfCoins.ToString();
                this.AcceptorDescriptionTextBox.Text = currentAcceptor.Description;
                this.AcceptorUnitAddressTextBox.Text = currentAcceptor.UnitAddress.ToString();
            }
		}

		private void UpdateMHEControls()
		{
            this.TotalAmountAcceptedTextBox.Text = String.Format("{0:0.00}",(decimal)mhe.CurrentValue/100);
            this.JustReadTextBox.Text = String.Format("{0:0.00}", ((decimal)mhe.CurrentValue - this.TotalAccepted) / 100) ;

            this.TotalAmountPaidOutTextBox.Text = String.Format("{0:0.00}", (decimal)mhe.CurrentPaid / 100);

            this.PayStatusLabel.Text = mhe.PayStatus.ToString();

			this.EscrowAmountTextBox.Text = String.Format("{0:0.00}",(decimal)(mhe.Escrow.Throughput - this.EscrowAtAccept) /100);
		}

		private void UpdateMeterControls()
		{
			this.MeterNameTextBox.Text = mhe.Meter.SerialNumber.ToString("x8");
			this.MeterStatusTextBox.Text = mhe.Meter.Status.ToString();
			UpdateCounterControls();
		}

		private void UpdateCounterControls()
		{
            MHE.Counter counter = mhe.Meter.Counter[(Byte)this.CounterNumberUpDown.Value];

			this.CounterCaptionTextBox.Text = counter.Caption;
			this.CounterCountTextBox.Text = counter.Count.ToString();

            switch (counter.DisplayMode)
            {
                case MHE.CounterMeter.CounterDisplayMode.Both:
                    this.CounterDisplayBothRadioButton.Checked = true;
                    break;
                case MHE.CounterMeter.CounterDisplayMode.CounterOnly:
                    this.CounterDisplayCountRadioButton.Checked = true;
                    break;
            }
        }

		private void UpdateSwitchControls()
		{
			foreach( System.Windows.Forms.Control control in this.SwitchGroupBox.Controls)
			{
				if( control.Name.ToLower().StartsWith("switch") )
				{
					string[] subStr = control.Name.Split(new char[]{'_'});
					int i = Convert.ToInt32(subStr[1]);

                    if (mhe.IsSwitchOpen(i))
                    {
                        ((System.Windows.Forms.Panel)control).BackColor = Color.Gray;
                    }
                    else
                    {
                        ((System.Windows.Forms.Panel)control).BackColor = Color.Red;
                    }
                }
			}
		}

        private void InitialiseLEDs()
        {
            foreach (System.Windows.Forms.Control control in this.LEDgroupBox.Controls)
            {
                if (control.Name.ToLower().StartsWith("led"))
                {
                    string[] subStr = control.Name.Split(new char[] { '_' });
                    int i = Convert.ToInt32(subStr[1]);
                    if (((System.Windows.Forms.Panel)control).BackColor == Color.Red)
                    {
                        mhe.IndicatorOn(i);
                    }
                    else
                    {
                        mhe.IndicatorOff(i);
                    }
                }
            }
        }

        private void InitialiseAcceptorControls()
        {
            this.AcceptorPanel.Controls.Clear();

            for (int i = 0; i < currentAcceptor.NoOfCoins; ++i)
            {
                NewCoinPanel(i, currentAcceptor.Coin[i]);
            }
        }

        private void InitialiseMeterControls()
        {
            this.CounterNumberUpDown.Maximum = mhe.Meter.Counter.Count;
            this.CounterNumberUpDown.Minimum = 1;

            mhe.Meter.DisplayCounter(1);
        }

		public void UpdateEventControls()
		{
			// get any events that have happend since last time
			MHE.Event eventBlock = new AES.MHE.Event();
			MHE.Event.Code eventCode = mhe.NextEvent(eventBlock) ;
            while (eventCode != MHE.Event.Code.IMHEI_NULL)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                switch (eventCode)
                {
                    case MHE.Event.Code.IMHEI_APPLICATION_START:
                        sb.Append("Application Start");
                        break;
                    case MHE.Event.Code.IMHEI_APPLICATION_EXIT:
                        sb.Append("Application Exit");
                        break;
                    case MHE.Event.Code.IMHEI_INTERFACE_START:
                        sb.Append("Interface Start");
                        break;
                    case MHE.Event.Code.IMHEI_OVERFLOW:
                        sb.Append("Overflow");
                        break;
                    case MHE.Event.Code.IMHEI_NULL:
                        sb.Append("Null");
                        break;
                }
                if (sb.Length == 0)
                {
                    // add the unit type
                    switch ((ushort)eventCode & MHE.Event.UNIT_TYPE_MASK)
                    {
                        case MHE.Event.COIN_DISPENSER_EVENT:
                            sb.Append("Coin Dispenser: ");
                            break;
                        case MHE.Event.NOTE_DISPENSER_EVENT:
                            sb.Append("Note Dispenser: ");
                            break;
                        case MHE.Event.COIN_EVENT:
                            sb.Append("Coin Acceptor: ");
                            break;
                        case MHE.Event.NOTE_EVENT:
                            sb.Append("Note Acceptor: ");
                            break;
                        default:
                            sb.Append("Device: ");
                            break;
                    }

                    // add the fault or event depending on the fault bit
                    if (((ushort)eventCode & MHE.Event.FAULT_BIT) > 0)
                    {
                        switch ((ushort)eventCode & MHE.Event.EVENT_CODE_MASK)
                        {
                            case MHE.Event.NOW_OK:
                                sb.Append("Now OK");
                                break;
                            case MHE.Event.REPORTED_FAULT:
                                sb.Append("Unit Reported Fault");
                                break;
                            case MHE.Event.UNIT_TIMEOUT:
                                sb.Append("Unit Timeout");
                                break;
                            case MHE.Event.UNIT_RESET:
                                sb.Append("Unit Reset");
                                break;
                            case MHE.Event.SELF_TEST_REFUSED:
                                sb.Append("Self Test refused");
                                break;
                            default:
                                sb.Append("Fault");
                                break;                        }
                    }
                    else
                    {
                        switch ((ushort)eventCode & MHE.Event.EVENT_CODE_MASK)
                        {
                            case MHE.Event.EVENT_OK:
                                sb.Append("OK");
                                break;
                            case MHE.Event.EVENT_BUSY:
                                sb.Append("Busy");
                                break;
                            case MHE.Event.REJECTED:
                                sb.Append("Rejected");
                                break;
                            case MHE.Event.INHIBITED:
                                sb.Append("Inhibited");
                                break;
                            case MHE.Event.MISREAD:
                                sb.Append("Misread");
                                break;
                            case MHE.Event.FRAUD:
                                sb.Append("Fraud");
                                break;
                            case MHE.Event.JAM:
                                sb.Append("Jam");
                                break;
                            case MHE.Event.JAM_FIXED:
                                sb.Append("Jam Fixed");
                                break;
                            case MHE.Event.RETURN:
                                sb.Append("Return");
                                break;
                            case MHE.Event.OUTPUT_PROBLEM:
                                sb.Append("Output Problem");
                                break;
                            case MHE.Event.OUTPUT_FIXED:
                                sb.Append("Output Fixed");
                                break;
                            case MHE.Event.INTERNAL_PROBLEM:
                                sb.Append("Internal Problem");
                                break;
                            case MHE.Event.UNKNOWN:
                                sb.Append("Unknown");
                                break;
                            case MHE.Event.DISPENSE_UPDATE:
                                sb.Append("Dispenser Update");
                                break;
                            default:
                                sb.Append("Event");
                                break;
                        }
                    }
                }

                int len = sb.Length;
                int noSpaces = 50 - len;
                for (int i = 0; i < noSpaces; ++i)
                {
                    sb.Append(" ");
                }
                sb.AppendFormat("| Raw Code: {0:x4}  Disp: {1}", eventBlock.RawEvent, eventBlock.DispenserEvent);

                this.EventListBox.Items.Add(sb.ToString());
                eventCode = mhe.NextEvent(eventBlock);
            }
		}

        private void UpdateUSBDriverStatus()
        {
            // show USB Status
            statusBar.Panels[0].Text = "USB Driver: " + mhe.USBDriverStatus.ToString();
        }

		private void UpdateDispenserPanels()
		{
			foreach( System.Windows.Forms.Control dispenserControl in this.DispenserPanel.Controls)
			{
				// get the number of the dispenser
				string[] namePart = dispenserControl.Name.Split(new char[]{'_'});
                int dispenserNumber = int.Parse(namePart[1]);

                MHE.Dispenser dispenser = mhe.Dispensers[dispenserNumber];

                dispenser.ReadDetails();

				foreach( System.Windows.Forms.Control control in dispenserControl.Controls)
				{
					namePart = control.Name.Split(new char[]{'_'});
					switch( namePart[0] )
					{
						case "DispenserTypeTextBox":
							control.Text = DispenserType(dispenser);
							break;
						case "DispenserValueTextBox":
							control.Text = dispenser.Value.ToString();
							break;
						case "DispenserAddressTextBox":
							control.Text = dispenser.UnitAddress.ToString();
							break;
						case "DispenserCoinsTextBox":
							control.Text = dispenser.Count.ToString();
							break;
						case "DispenserContentsTextBox":
                            control.Text = ((MHE.DispenserCoinStatus)dispenser.CoinCountStatus).ToString();
							break;
						case "DispenserStatusTextBox":
                            control.Text = ((MHE.DispenserPayStatus)dispenser.Status).ToString();
							break;
						case "DispenserInhibitCheckBox":
							((System.Windows.Forms.CheckBox)control).Checked = (dispenser.Inhibit != 0);
							break;
					}
				}
			}				
		}

		private string DispenserType( MHE.Dispenser Dispenser )
		{
			switch( (MHE.DeviceIdentity)Dispenser.Unit )
			{
				case MHE.DeviceIdentity.DP_AS_WH2:
					return "Asahi Seiko Escalator" ;
                case MHE.DeviceIdentity.DP_AZK_HOPPER:
					return "Azkoyen Hopper" ;
                case MHE.DeviceIdentity.DP_CC_GHOST_HOPPER:
					return "Ghost (Coin count only)" ;
                case MHE.DeviceIdentity.DP_MCL_SCH2:
					return "MCL Serial Compact Hopper" ;
                case MHE.DeviceIdentity.DP_MCL_SCH3:
					return "MCL Combi Hopper" ;
                case MHE.DeviceIdentity.DP_MCL_SUH1:
					return "MCL Serial Universal Hopper" ;
                case MHE.DeviceIdentity.DP_MDB_LEVEL_2_TUBE:
					return "MDB Tube" ;
                case MHE.DeviceIdentity.DP_MDB_TYPE_3_PAYOUT:
					return "MDB Payout System" ;
				default:
                    return Dispenser.Unit.ToString();
			}
		}

		private void UpdateCoinPanel(int Index, AESImhei.AcceptorCoin Coin)
		{
			foreach( System.Windows.Forms.Control coinControl in this.AcceptorPanel.Controls)
			{
				if( coinControl.Name == "CoinPanel" + Index.ToString())
				{
					foreach( System.Windows.Forms.Control control in coinControl.Controls)
					{
						string[] namePart = control.Name.Split(new char[]{'_'});
						switch( namePart[0] )
						{
							case "ValueTextBox":
								control.Text = Coin.Value.ToString();
								break;
                            case "DescTextBox":
                                control.Text = Coin.CoinName;
                                break;
                            case "CountTextBox":
                                control.Text = Coin.Count.ToString();
                                break;
                            case "RoutedPathTextBox":
								control.Text = Coin.Path.ToString();
								break;
							case "DefaultPathTextBox":
								control.Text = Coin.DefaultPath.ToString();
								break;
							case "NoSentTextBox":
								control.Text = Coin.PathCount.ToString();
								break;
							case "LevelTextBox":
								control.Text = Coin.PathSwitchLevel.ToString();
								break;
							case "EscrowTextBox":
								control.Text = Coin.HeldInEscrow.ToString();
								break;
							case "InhibitCheckBox":
								((System.Windows.Forms.CheckBox)control).Checked = (Coin.Inhibit != 0);
								break;
						}
					}
				}
			}
		}

        private void NewCoinPanel(int Index, AESImhei.AcceptorCoin Coin)
		{
			System.Windows.Forms.Panel coinPanel = new Panel();
			coinPanel.Location = new System.Drawing.Point(8 + 45*Index, 32);
			coinPanel.Name = "CoinPanel" + Index.ToString();
			coinPanel.Size = new System.Drawing.Size(64, 240);
			coinPanel.TabIndex = 0;
			this.AcceptorPanel.Controls.Add(coinPanel );

			// ValueTextBox
			System.Windows.Forms.TextBox valueTextBox = new TextBox();
			valueTextBox.ReadOnly  = true;
			valueTextBox.Location = new System.Drawing.Point(8, 8);
			valueTextBox.Name = "ValueTextBox_" + Index.ToString();
			valueTextBox.Size = new System.Drawing.Size(40, 22);
			valueTextBox.TabIndex = 0;
			valueTextBox.Text = Coin.Value.ToString();
			coinPanel.Controls.Add( valueTextBox );

            // DescTextBox0
            System.Windows.Forms.TextBox descTextBox = new TextBox();
            descTextBox.ReadOnly = true;
            descTextBox.Location = new System.Drawing.Point(8, 32);
            descTextBox.Name = "DescTextBox_" + Index.ToString();
            descTextBox.Size = new System.Drawing.Size(40, 22);
            descTextBox.Font = new Font("Arial", 8);
            descTextBox.TabIndex = 1;
            descTextBox.Text = Coin.Count.ToString();
            coinPanel.Controls.Add(descTextBox);

            // CountTextBox0
            System.Windows.Forms.TextBox countTextBox = new TextBox();
            countTextBox.ReadOnly = true;
            countTextBox.Location = new System.Drawing.Point(8, 56);
            countTextBox.Name = "CountTextBox_" + Index.ToString();
            countTextBox.Size = new System.Drawing.Size(40, 22);
            countTextBox.TabIndex = 2;
            countTextBox.Text = Coin.Count.ToString();
            coinPanel.Controls.Add(countTextBox);

            // RoutedPathTextBox0
			System.Windows.Forms.TextBox routedPathTextBox = new TextBox();
			routedPathTextBox.Location = new System.Drawing.Point(8, 80);
			routedPathTextBox.Name = "RoutedPathTextBox_" + Index.ToString();
			routedPathTextBox.Size = new System.Drawing.Size(40, 22);
			routedPathTextBox.TabIndex = 3;
			routedPathTextBox.Text = Coin.Path.ToString();
            routedPathTextBox.MaxLength = 1;
			routedPathTextBox.TextChanged += new System.EventHandler(this.CoinControlChanged);
			coinPanel.Controls.Add( routedPathTextBox );
			// 
			// DefaultPathTextBox0
			// 
			System.Windows.Forms.TextBox defaultPathTextBox = new TextBox();
			defaultPathTextBox.Location = new System.Drawing.Point(8, 104);
			defaultPathTextBox.Name = "DefaultPathTextBox_" + Index.ToString();
			defaultPathTextBox.Size = new System.Drawing.Size(40, 22);
			defaultPathTextBox.TabIndex = 4;
			defaultPathTextBox.Text = Coin.DefaultPath.ToString();
            defaultPathTextBox.MaxLength = 1;
			defaultPathTextBox.TextChanged += new System.EventHandler(this.CoinControlChanged);
			coinPanel.Controls.Add( defaultPathTextBox );
			// 
			// NoSentTextBox0
			// 
			System.Windows.Forms.TextBox noSentTextBox = new TextBox();
			noSentTextBox.ReadOnly  = true;
			noSentTextBox.Location = new System.Drawing.Point(8, 128);
			noSentTextBox.Name = "NoSentTextBox_" + Index.ToString();
			noSentTextBox.Size = new System.Drawing.Size(40, 22);
			noSentTextBox.TabIndex = 5;
			noSentTextBox.Text = Coin.PathCount.ToString();
			coinPanel.Controls.Add( noSentTextBox );
			// 
			// LevelTextBox0
			// 
			System.Windows.Forms.TextBox levelTextBox = new TextBox();
			levelTextBox.Location = new System.Drawing.Point(8, 152);
			levelTextBox.Name = "LevelTextBox_" + Index.ToString();
			levelTextBox.Size = new System.Drawing.Size(40, 22);
			levelTextBox.TabIndex = 6;
			levelTextBox.Text = Coin.PathSwitchLevel.ToString();
			levelTextBox.TextChanged += new System.EventHandler(this.CoinControlChanged);
			coinPanel.Controls.Add( levelTextBox );
			// 
			// EscrowTextBox0
			// 
			System.Windows.Forms.TextBox escrowTextBox = new TextBox();
			escrowTextBox.ReadOnly  = true;
			escrowTextBox.Location = new System.Drawing.Point(8, 184);
			escrowTextBox.Name = "EscrowTextBox_" + Index.ToString();
			escrowTextBox.Size = new System.Drawing.Size(40, 22);
			escrowTextBox.TabIndex = 7;
			escrowTextBox.Text = Coin.HeldInEscrow.ToString();
			coinPanel.Controls.Add( escrowTextBox );
			// 
			// InhibitCheckBox0
			// 
			System.Windows.Forms.CheckBox inhibitCheckBox = new CheckBox();
			inhibitCheckBox.Location = new System.Drawing.Point(16, 216);
			inhibitCheckBox.Name = "InhibitCheckBox_" + Index.ToString();
			inhibitCheckBox.Size = new System.Drawing.Size(16, 16);
			inhibitCheckBox.TabIndex = 8;
			inhibitCheckBox.Checked = (Coin.Inhibit != 0);
			inhibitCheckBox.CheckedChanged += new System.EventHandler(this.CoinControlChanged);
			coinPanel.Controls.Add( inhibitCheckBox );

			coinPanel.BringToFront();
		}

        private const int dispenserPanelHeight = 40;

		private void NewDispenserPanel(int Index, AES.MHE.Dispenser Dispenser)
		{
			// 
			// DispenserPanel
			// 
			System.Windows.Forms.Panel dispenserPanel = new Panel();
            dispenserPanel.Location = new System.Drawing.Point(3, dispenserPanelHeight * Index);
			dispenserPanel.Name = "DispenserPanel_" + Index.ToString();
            dispenserPanel.Size = new System.Drawing.Size(640, dispenserPanelHeight);
			dispenserPanel.TabIndex = 0;
			this.DispenserPanel.Controls.Add(dispenserPanel);
			// 
			// DispenserTypeTextBox
			// 
			System.Windows.Forms.TextBox dispenserTypeTextBox = new TextBox();
			dispenserTypeTextBox.Location = new System.Drawing.Point(8, 8);
			dispenserTypeTextBox.Name = "DispenserTypeTextBox_" + Index.ToString();
			dispenserTypeTextBox.Size = new System.Drawing.Size(202, 22);
            dispenserTypeTextBox.TextAlign = HorizontalAlignment.Center;
			dispenserTypeTextBox.TabIndex = 0;
			dispenserTypeTextBox.Text = DispenserType(Dispenser);
            dispenserTypeTextBox.ReadOnly = true;
			dispenserPanel.Controls.Add(dispenserTypeTextBox);
			// 
			// DispenserValueTextBox
			// 
			System.Windows.Forms.TextBox dispenserValueTextBox = new TextBox();
			dispenserValueTextBox.Location = new System.Drawing.Point(220, 8);
			dispenserValueTextBox.Name = "DispenserValueTextBox_" + Index.ToString();
			dispenserValueTextBox.Size = new System.Drawing.Size(30, 22);
            dispenserValueTextBox.TextAlign = HorizontalAlignment.Center;
			dispenserValueTextBox.TabIndex = 1;
			dispenserValueTextBox.Text = Dispenser.Value.ToString();
            dispenserValueTextBox.ReadOnly = true;
			dispenserPanel.Controls.Add(dispenserValueTextBox);
			// 
			// DispenserAddressTextBox
			// 
			System.Windows.Forms.TextBox dispenserAddressTextBox = new TextBox();
			dispenserAddressTextBox.Location = new System.Drawing.Point(260, 8);
			dispenserAddressTextBox.Name = "DispenserAddressTextBox_" + Index.ToString();
			dispenserAddressTextBox.Size = new System.Drawing.Size(24, 22);
            dispenserAddressTextBox.TextAlign = HorizontalAlignment.Center;
			dispenserAddressTextBox.TabIndex = 2;
			dispenserAddressTextBox.Text = Dispenser.UnitAddress.ToString();
            dispenserAddressTextBox.ReadOnly = true;
			dispenserPanel.Controls.Add(dispenserAddressTextBox);
			// 
			// DispenserCoinsTextBox
			// 
			System.Windows.Forms.TextBox dispenserCoinsTextBox = new TextBox();
			dispenserCoinsTextBox.Location = new System.Drawing.Point(320, 8);
			dispenserCoinsTextBox.Name = "DispenserCoinsTextBox_" + Index.ToString();
			dispenserCoinsTextBox.Size = new System.Drawing.Size(44, 22);
            dispenserCoinsTextBox.TextAlign = HorizontalAlignment.Center;
			dispenserCoinsTextBox.TabIndex = 3;
			dispenserCoinsTextBox.Text = Dispenser.Count.ToString();
            dispenserCoinsTextBox.ReadOnly = true;
			dispenserPanel.Controls.Add(dispenserCoinsTextBox);
			// 
			// DispenserContentsTextBox
			// 
			System.Windows.Forms.TextBox dispenserContentsTextBox = new TextBox();
			dispenserContentsTextBox.Location = new System.Drawing.Point(380, 8);
			dispenserContentsTextBox.Name = "DispenserContentsTextBox_" + Index.ToString();
			dispenserContentsTextBox.Size = new System.Drawing.Size(68, 22);
            dispenserContentsTextBox.TextAlign = HorizontalAlignment.Center;
			dispenserContentsTextBox.TabIndex = 4;
			dispenserContentsTextBox.Text = Dispenser.Count.ToString();
            dispenserContentsTextBox.ReadOnly = true;
			dispenserPanel.Controls.Add(dispenserContentsTextBox);
			// 
			// DispenserStatusTextBox
			// 
			System.Windows.Forms.TextBox dispenserStatusTextBox = new TextBox();
			dispenserStatusTextBox.Location = new System.Drawing.Point(456, 8);
			dispenserStatusTextBox.Name = "DispenserStatusTextBox_" + Index.ToString();
			dispenserStatusTextBox.Size = new System.Drawing.Size(148, 22);
            dispenserStatusTextBox.TextAlign = HorizontalAlignment.Center;
			dispenserStatusTextBox.TabIndex = 5;
			dispenserStatusTextBox.Text = ((MHE.DispenserPayStatus)Dispenser.Status).ToString();
            dispenserStatusTextBox.ReadOnly = true;
			dispenserPanel.Controls.Add(dispenserStatusTextBox);
			// 
			// DispenserInhibitCheckBox
			// 
			System.Windows.Forms.CheckBox dispenserInhibitCheckBox = new CheckBox();
			dispenserInhibitCheckBox.Location = new System.Drawing.Point(628, 8);
			dispenserInhibitCheckBox.Name = "DispenserInhibitCheckBox_" + Index.ToString();
			dispenserInhibitCheckBox.Size = new System.Drawing.Size(16, 24);
			dispenserInhibitCheckBox.TabIndex = 6;
			dispenserInhibitCheckBox.Checked = (Dispenser.Inhibit != 0);
			dispenserPanel.Controls.Add(dispenserInhibitCheckBox);

            dispenserInhibitCheckBox.Click += new EventHandler(dispenserInhibitCheckBox_Click);
            dispenserInhibitCheckBox.Tag = Index;

			dispenserPanel.BringToFront();
		}

        void dispenserInhibitCheckBox_Click(object sender, EventArgs e)
        {
            int Index = (int)((CheckBox)sender).Tag;

            MHE.Dispenser dispenser = mhe.Dispensers[Index];

            dispenser.Inhibit = ((((CheckBox)sender).Checked)?1:0);

            dispenser.WriteDetails();
        }


        private void UpdateDESControls()
        {
            DESStatusTextBox.Text = mhe.DES.Status.ToString();
        }

        private void CoinControlChanged(object sender, System.EventArgs e)
        {
            // because a timer is running keeping the fields up to date lock it out
            // whilst we do changes
            lock (mhe)
            {
                // get the coin from in the acceptor
                string[] namePart = ((System.Windows.Forms.Control)sender).Name.Split(new char[] { '_' });
                int index = Convert.ToInt32(namePart[1]);
                AESImhei.AcceptorCoin coin = currentAcceptor.Coin[index];

                // work out which field has changed and change the relevant property
                // in the coin
                switch (namePart[0])
                {
                    case "RoutedPathTextBox":
                        Int32.TryParse(((System.Windows.Forms.TextBox)sender).Text, out coin.Path);
                        break;
                    case "DefaultPathTextBox":
                        Byte.TryParse(((System.Windows.Forms.TextBox)sender).Text, out coin.DefaultPath);
                        break;
                    case "LevelTextBox":
                        Int32.TryParse(((System.Windows.Forms.TextBox)sender).Text, out coin.PathSwitchLevel);
                        break;
                    case "InhibitCheckBox":
                        coin.Inhibit = ((((System.Windows.Forms.CheckBox)sender).Checked)?1:0);
                        break;
                }

                // update the MHE
                currentAcceptor.WriteDetails();
            }
        }

		private void acceptorComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            currentAcceptor = (AES.MHE.Acceptor)this.acceptorComboBox.SelectedItem;

            InitialiseAcceptorControls();
		}

        private void acceptorComboBox_Format(object sender, ListControlConvertEventArgs e)
        {
            uint unit = (uint)((AES.MHE.Acceptor)e.Value).Unit;
            string acceptorType = ((MHE.DeviceIdentity)unit).ToString();
            if (uint.TryParse(acceptorType, out unit))
            {
                e.Value = String.Format("{0:d}.{1:d}.{2:d}.{3:d}", (unit >> 24) & 0xFF, (unit >> 16) & 0xFF, (unit >> 8) & 0xFF, (unit) & 0xFF);
            }
            else
            {
                e.Value = acceptorType;
            }
        }

        private void ToggleLEDIndicator(System.Windows.Forms.Panel indicator)
        {
            // find the LED number of the indicator
            string[] subStr = indicator.Name.Split(new char[] { '_' });
            int i = Convert.ToInt32(subStr[1]);

            // toggle to state of the LED
            if (indicator.BackColor == Color.Red)
            {
                indicator.BackColor = System.Drawing.Color.DarkGray;
                indicator.BorderStyle = BorderStyle.Fixed3D;
                mhe.IndicatorOff(i);
            }
            else
            {
                indicator.BackColor = System.Drawing.Color.Red;
                indicator.BorderStyle = BorderStyle.FixedSingle;
                mhe.IndicatorOn(i);
            }
        }

		private void LED_Click(object sender, System.EventArgs e)
		{
			ToggleLEDIndicator( (System.Windows.Forms.Panel)sender );
		}

		private void CounterNumberUpDown_ValueChanged(object sender, System.EventArgs e)
		{
            mhe.Meter.DisplayCounter((Byte)CounterNumberUpDown.Value);
        }

		private void CounterDisplayCountRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
            Byte counterNo = Convert.ToByte(this.CounterNumberUpDown.Value);
            if (((RadioButton)sender).Checked)
            {
                mhe.Meter.Counter[counterNo].DisplayMode = MHE.CounterMeter.CounterDisplayMode.CounterOnly;
                mhe.Meter.DisplayCounter(counterNo);
            }
		}

		private void CounterDisplayBothRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
            Byte counterNo = Convert.ToByte(this.CounterNumberUpDown.Value);
            mhe.Meter.Counter[counterNo].DisplayMode = MHE.CounterMeter.CounterDisplayMode.Both;
            if (((RadioButton)sender).Checked)
            {
                mhe.Meter.Counter[counterNo].DisplayMode = MHE.CounterMeter.CounterDisplayMode.Both;
                mhe.Meter.DisplayCounter(counterNo);
            }
        }

        private void CounterIncrementButton_Click(object sender, System.EventArgs e)
        {
            int increment = Convert.ToInt32(this.CounterIncrementUpDown.Value);
            Byte counterNo = Convert.ToByte(this.CounterNumberUpDown.Value);
            this.CounterCountTextBox.Text = mhe.Meter.Counter[counterNo].Increment(increment).ToString();
        }

		private void AcceptorDefaultPathTextBox_TextChanged(object sender, System.EventArgs e)
		{
			lock(mhe)
			{
				// find the displayed acceptor
				currentAcceptor.DefaultPath = Convert.ToInt32(((System.Windows.Forms.TextBox)sender).Text);
							
			}
		}

		private void PayItButton_Click(object sender, System.EventArgs e)
		{
            decimal payout;
            if (decimal.TryParse(this.PayoutTextBox.Text, out payout))
            {
                mhe.PayOut( (int)(payout * 100));
            }
		}

		private void JustReadResetButton_Click(object sender, System.EventArgs e)
		{
			this.TotalAccepted = mhe.CurrentValue;		
		}

		private void BarcodePrintButton_Click(object sender, System.EventArgs e)
		{
            MHE.BarcodeTicket barCodeTicket = new MHE.BarcodeTicket(0);
            barCodeTicket.BarcodeData = this.BarcodeReference.Text;
			barCodeTicket.AmountInWords = this.BarcodeAmountInWordsTextBox.Text;
			barCodeTicket.AmountAsNumber = this.BarcodeNumericAmountTextBox.Text;
			barCodeTicket.DatePrinted = this.BarcodeDateTextBox.Text;
			barCodeTicket.TimePrinted = this.BarcodeTimeTextBox.Text;
			barCodeTicket.MachineIdentity = this.BarcodeMachineIdTextBox.Text;
			mhe.Barcode.Print(barCodeTicket);
		}

		private void EscrowEnabledCheckBox_CheckedChanged(object sender, System.EventArgs e)
		{
			if( ((System.Windows.Forms.CheckBox)sender).Checked )
			{
				this.EscrowGroupBox.Visible = true;
				mhe.Escrow.Enabled = true;
			}
			else
			{
				this.EscrowGroupBox.Visible = false;
				mhe.Escrow.Enabled = false;
			}
		}

		private void EscrowAcceptButton_Click(object sender, System.EventArgs e)
		{
			mhe.Escrow.Accept();
			this.EscrowAtAccept = mhe.Escrow.Throughput;
		}

		private void EscrowReturnButton_Click(object sender, System.EventArgs e)
		{
			mhe.Escrow.Return();
			this.EscrowAtAccept = mhe.Escrow.Throughput;
        }

        private void CounterCaptionTextBox_TextChanged(object sender, EventArgs e)
        {
            MHE.Counter counter = mhe.Meter.Counter[(Byte)CounterNumberUpDown.Value];
            counter.Caption = ((TextBox)sender).Text;
        }

        private void BarcodeEscrowAcceptButton_Click(object sender, EventArgs e)
        {
            mhe.Barcode.TicketAccept();
        }

        private void BarcodeEscrowReturnButton_Click(object sender, EventArgs e)
        {
            mhe.Barcode.TicketReturn();
        }

        private void BarcodeReference_Validating(object sender, CancelEventArgs e)
        {
            string barcode = ((TextBox)sender).Text;

            // barcode must be 18 characters consisting of number only
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("");
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            string key = newKeyTextBox.Text;

            if (key.Length == 16)
            {
                mhe.DES.LockSet(CreateKey(key));
                DESStatusTextBox.Text = mhe.DES.Status.ToString();
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            string key = keyTextBox.Text;

            if (key.Length == 16)
            {
                mhe.DES.SetKey(CreateKey(key));
                DESStatusTextBox.Text = mhe.DES.Status.ToString();
            }
        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            mhe.DES.LockClear();
            DESStatusTextBox.Text = mhe.DES.Status.ToString();
        }

        private Byte[] CreateKey(string KeyString)
        {
            Byte[] key = new Byte[8];

            System.Text.Encoding ascii = System.Text.Encoding.ASCII;
            Byte[] encodedBytes = ascii.GetBytes(KeyString);
            for (int i = 0; i < 8; ++i)
            {
                key[i] = (Byte)(((encodedBytes[2*i] & 0x0F) << 4) | (encodedBytes[2*i+1] & 0x0F));
            }

            return key;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
	}
}
