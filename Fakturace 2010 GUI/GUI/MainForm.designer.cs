namespace Fakturace_2009.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Fakturace_2009.Backbone.Firma firma1 = new Fakturace_2009.Backbone.Firma();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CisloEdit = new System.Windows.Forms.MaskedTextBox();
            this.PopisGrp = new System.Windows.Forms.GroupBox();
            this.PopisEdit = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxUhrada = new System.Windows.Forms.ComboBox();
            this.checkBoxZdVystLock = new System.Windows.Forms.CheckBox();
            this.dateZdan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.splatDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.vystDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.odberatelButton = new System.Windows.Forms.Button();
            this.firmaEditor1 = new Fakturace_2009.GUI.FirmaEditor();
            this.GuideTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoTip = new System.Windows.Forms.ToolTip(this.components);
            this.dphEdit = new System.Windows.Forms.MaskedTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonChangePolozka = new System.Windows.Forms.Button();
            this.buttonDeletePolozka = new System.Windows.Forms.Button();
            this.ButtonAddPolozka = new System.Windows.Forms.Button();
            this.totalEd = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.celkdphEd = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.celkemEd = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.fakturaGrid = new System.Windows.Forms.DataGridView();
            this.typCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazevCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnozCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cenajCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celcenCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polozkaEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.posunoutNahoruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posunoutDoluToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.změnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smazatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.nástrojeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.statistikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NovyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.otevřítToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tisknoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uložitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxMistoPraci = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.PopisGrp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fakturaGrid)).BeginInit();
            this.polozkaEditMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.CisloEdit);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox1.Size = new System.Drawing.Size(280, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Číslo faktury";
            // 
            // CisloEdit
            // 
            this.CisloEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CisloEdit.BackColor = System.Drawing.SystemColors.Window;
            this.CisloEdit.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CisloEdit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CisloEdit.Location = new System.Drawing.Point(6, 23);
            this.CisloEdit.Margin = new System.Windows.Forms.Padding(3, 6, 20, 6);
            this.CisloEdit.Name = "CisloEdit";
            this.CisloEdit.Size = new System.Drawing.Size(251, 24);
            this.CisloEdit.TabIndex = 1;
            this.CisloEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CisloEdit.Validating += new System.ComponentModel.CancelEventHandler(this.CisloEdit_Validating);
            // 
            // PopisGrp
            // 
            this.PopisGrp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PopisGrp.BackColor = System.Drawing.Color.Transparent;
            this.PopisGrp.Controls.Add(this.PopisEdit);
            this.PopisGrp.Location = new System.Drawing.Point(3, 3);
            this.PopisGrp.Name = "PopisGrp";
            this.PopisGrp.Size = new System.Drawing.Size(564, 121);
            this.PopisGrp.TabIndex = 2;
            this.PopisGrp.TabStop = false;
            this.PopisGrp.Text = "Popis dodávky";
            // 
            // PopisEdit
            // 
            this.PopisEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PopisEdit.BackColor = System.Drawing.SystemColors.Window;
            this.PopisEdit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PopisEdit.Location = new System.Drawing.Point(6, 23);
            this.PopisEdit.Multiline = true;
            this.PopisEdit.Name = "PopisEdit";
            this.PopisEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PopisEdit.Size = new System.Drawing.Size(535, 92);
            this.PopisEdit.TabIndex = 4;
            this.PopisEdit.WordWrap = false;
            this.PopisEdit.Validating += new System.ComponentModel.CancelEventHandler(this.PopisEdit_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxUhrada);
            this.groupBox2.Controls.Add(this.checkBoxZdVystLock);
            this.groupBox2.Controls.Add(this.dateZdan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.splatDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.vystDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(280, 207);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Platební podmínky";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(9, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Forma úhrady";
            // 
            // comboBoxUhrada
            // 
            this.comboBoxUhrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxUhrada.FormattingEnabled = true;
            this.comboBoxUhrada.Items.AddRange(new object[] {
            "Platba v hotovosti",
            "Bankovní převod"});
            this.comboBoxUhrada.Location = new System.Drawing.Point(9, 171);
            this.comboBoxUhrada.Name = "comboBoxUhrada";
            this.comboBoxUhrada.Size = new System.Drawing.Size(248, 25);
            this.comboBoxUhrada.TabIndex = 11;
            this.comboBoxUhrada.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxUhrada_Validating);
            // 
            // checkBoxZdVystLock
            // 
            this.checkBoxZdVystLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxZdVystLock.AutoSize = true;
            this.checkBoxZdVystLock.Location = new System.Drawing.Point(263, 89);
            this.checkBoxZdVystLock.Name = "checkBoxZdVystLock";
            this.checkBoxZdVystLock.Size = new System.Drawing.Size(15, 14);
            this.checkBoxZdVystLock.TabIndex = 10;
            this.GuideTip.SetToolTip(this.checkBoxZdVystLock, "Zaškrtnutím svážete datum zd. plnění s datem vystavení");
            this.checkBoxZdVystLock.UseVisualStyleBackColor = true;
            this.checkBoxZdVystLock.CheckedChanged += new System.EventHandler(this.checkBoxZdVystLock_CheckedChanged);
            // 
            // dateZdan
            // 
            this.dateZdan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateZdan.CalendarFont = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateZdan.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateZdan.Location = new System.Drawing.Point(9, 83);
            this.dateZdan.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateZdan.Name = "dateZdan";
            this.dateZdan.Size = new System.Drawing.Size(248, 24);
            this.dateZdan.TabIndex = 9;
            this.dateZdan.Value = new System.DateTime(2006, 8, 1, 0, 0, 0, 0);
            this.dateZdan.ValueChanged += new System.EventHandler(this.dateZdan_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(9, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Datum zd. plnění";
            // 
            // splatDate
            // 
            this.splatDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splatDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.splatDate.Location = new System.Drawing.Point(9, 127);
            this.splatDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.splatDate.Name = "splatDate";
            this.splatDate.Size = new System.Drawing.Size(248, 24);
            this.splatDate.TabIndex = 7;
            this.splatDate.ValueChanged += new System.EventHandler(this.splatDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datum splatnosti";
            // 
            // vystDate
            // 
            this.vystDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vystDate.CalendarFont = new System.Drawing.Font("Tahoma", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.vystDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.vystDate.Location = new System.Drawing.Point(9, 39);
            this.vystDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.vystDate.Name = "vystDate";
            this.vystDate.Size = new System.Drawing.Size(248, 24);
            this.vystDate.TabIndex = 6;
            this.vystDate.Value = new System.DateTime(2006, 8, 1, 0, 0, 0, 0);
            this.vystDate.ValueChanged += new System.EventHandler(this.vystDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum vystavení";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.odberatelButton);
            this.groupBox3.Controls.Add(this.firmaEditor1);
            this.groupBox3.Location = new System.Drawing.Point(3, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(280, 240);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Odběratel";
            // 
            // odberatelButton
            // 
            this.odberatelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.odberatelButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.odberatelButton.Image = global::Fakturace_2009.Properties.Resources.page_edit;
            this.odberatelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.odberatelButton.Location = new System.Drawing.Point(12, 201);
            this.odberatelButton.Name = "odberatelButton";
            this.odberatelButton.Size = new System.Drawing.Size(248, 30);
            this.odberatelButton.TabIndex = 5;
            this.odberatelButton.Text = "Vybrat z uložených";
            this.odberatelButton.UseVisualStyleBackColor = true;
            this.odberatelButton.Click += new System.EventHandler(this.odberatelButton_Click);
            // 
            // firmaEditor1
            // 
            this.firmaEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.firmaEditor1.EditedFirma = firma1;
            this.firmaEditor1.Location = new System.Drawing.Point(9, 20);
            this.firmaEditor1.Margin = new System.Windows.Forms.Padding(4);
            this.firmaEditor1.Name = "firmaEditor1";
            this.firmaEditor1.Size = new System.Drawing.Size(251, 177);
            this.firmaEditor1.TabIndex = 5;
            // 
            // GuideTip
            // 
            this.GuideTip.AutoPopDelay = 1000;
            this.GuideTip.InitialDelay = 120;
            this.GuideTip.IsBalloon = true;
            this.GuideTip.ReshowDelay = 100;
            // 
            // infoTip
            // 
            this.infoTip.AutoPopDelay = 5000;
            this.infoTip.InitialDelay = 150;
            this.infoTip.IsBalloon = true;
            this.infoTip.ReshowDelay = 100;
            // 
            // dphEdit
            // 
            this.dphEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dphEdit.BackColor = System.Drawing.SystemColors.Window;
            this.dphEdit.BeepOnError = true;
            this.dphEdit.Location = new System.Drawing.Point(623, 446);
            this.dphEdit.Mask = "99%";
            this.dphEdit.Name = "dphEdit";
            this.dphEdit.Size = new System.Drawing.Size(54, 24);
            this.dphEdit.TabIndex = 17;
            this.dphEdit.Text = "19";
            this.infoTip.SetToolTip(this.dphEdit, "DPH použité pro celkový součet všech položek.");
            this.dphEdit.TextChanged += new System.EventHandler(this.dphEdit_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.buttonChangePolozka);
            this.groupBox4.Controls.Add(this.buttonDeletePolozka);
            this.groupBox4.Controls.Add(this.ButtonAddPolozka);
            this.groupBox4.Controls.Add(this.totalEd);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.celkdphEd);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.celkemEd);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.dphEdit);
            this.groupBox4.Controls.Add(this.fakturaGrid);
            this.groupBox4.Location = new System.Drawing.Point(6, 133);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.groupBox4.Size = new System.Drawing.Size(948, 517);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Faktura";
            // 
            // buttonChangePolozka
            // 
            this.buttonChangePolozka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChangePolozka.Enabled = false;
            this.buttonChangePolozka.Image = ((System.Drawing.Image)(resources.GetObject("buttonChangePolozka.Image")));
            this.buttonChangePolozka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangePolozka.Location = new System.Drawing.Point(9, 447);
            this.buttonChangePolozka.Name = "buttonChangePolozka";
            this.buttonChangePolozka.Size = new System.Drawing.Size(159, 25);
            this.buttonChangePolozka.TabIndex = 27;
            this.buttonChangePolozka.Text = "Změnit položku";
            this.buttonChangePolozka.UseVisualStyleBackColor = true;
            this.buttonChangePolozka.Click += new System.EventHandler(this.buttonChangePolozka_Click);
            // 
            // buttonDeletePolozka
            // 
            this.buttonDeletePolozka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeletePolozka.Enabled = false;
            this.buttonDeletePolozka.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeletePolozka.Image")));
            this.buttonDeletePolozka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeletePolozka.Location = new System.Drawing.Point(9, 483);
            this.buttonDeletePolozka.Name = "buttonDeletePolozka";
            this.buttonDeletePolozka.Size = new System.Drawing.Size(159, 25);
            this.buttonDeletePolozka.TabIndex = 26;
            this.buttonDeletePolozka.Text = "Smazat položku";
            this.buttonDeletePolozka.UseVisualStyleBackColor = true;
            this.buttonDeletePolozka.Click += new System.EventHandler(this.buttonDeletePolozka_Click);
            // 
            // ButtonAddPolozka
            // 
            this.ButtonAddPolozka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddPolozka.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddPolozka.Image")));
            this.ButtonAddPolozka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAddPolozka.Location = new System.Drawing.Point(9, 416);
            this.ButtonAddPolozka.Name = "ButtonAddPolozka";
            this.ButtonAddPolozka.Size = new System.Drawing.Size(159, 25);
            this.ButtonAddPolozka.TabIndex = 25;
            this.ButtonAddPolozka.Text = "Vložit položky";
            this.ButtonAddPolozka.UseVisualStyleBackColor = true;
            this.ButtonAddPolozka.Click += new System.EventHandler(this.ButtonAddPolozka_Click);
            // 
            // totalEd
            // 
            this.totalEd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalEd.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalEd.Location = new System.Drawing.Point(701, 483);
            this.totalEd.Name = "totalEd";
            this.totalEd.ReadOnly = true;
            this.totalEd.Size = new System.Drawing.Size(241, 25);
            this.totalEd.TabIndex = 23;
            this.totalEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(582, 487);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 17);
            this.label16.TabIndex = 22;
            this.label16.Text = "Celkem s DPH:";
            // 
            // celkdphEd
            // 
            this.celkdphEd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.celkdphEd.Location = new System.Drawing.Point(701, 446);
            this.celkdphEd.Name = "celkdphEd";
            this.celkdphEd.ReadOnly = true;
            this.celkdphEd.Size = new System.Drawing.Size(241, 24);
            this.celkdphEd.TabIndex = 21;
            this.celkdphEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(582, 449);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 20;
            this.label15.Text = "DPH";
            // 
            // celkemEd
            // 
            this.celkemEd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.celkemEd.Location = new System.Drawing.Point(701, 416);
            this.celkemEd.Name = "celkemEd";
            this.celkemEd.ReadOnly = true;
            this.celkemEd.Size = new System.Drawing.Size(241, 24);
            this.celkemEd.TabIndex = 19;
            this.celkemEd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(582, 419);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 17);
            this.label14.TabIndex = 18;
            this.label14.Text = "Celkem bez DPH:";
            // 
            // fakturaGrid
            // 
            this.fakturaGrid.AllowUserToAddRows = false;
            this.fakturaGrid.AllowUserToDeleteRows = false;
            this.fakturaGrid.AllowUserToResizeColumns = false;
            this.fakturaGrid.AllowUserToResizeRows = false;
            this.fakturaGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fakturaGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fakturaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fakturaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typCol,
            this.nazevCol,
            this.mnozCol,
            this.cenajCol,
            this.celcenCol});
            this.fakturaGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fakturaGrid.Location = new System.Drawing.Point(9, 26);
            this.fakturaGrid.MultiSelect = false;
            this.fakturaGrid.Name = "fakturaGrid";
            this.fakturaGrid.RowHeadersVisible = false;
            this.fakturaGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.fakturaGrid.RowTemplate.Height = 30;
            this.fakturaGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fakturaGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fakturaGrid.Size = new System.Drawing.Size(933, 384);
            this.fakturaGrid.TabIndex = 0;
            this.fakturaGrid.TabStop = false;
            this.fakturaGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fakturaGrid_CellDoubleClick);
            this.fakturaGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fakturaGrid_MouseClick);
            this.fakturaGrid.SelectionChanged += new System.EventHandler(this.fakturaGrid_SelectionChanged);
            // 
            // typCol
            // 
            this.typCol.HeaderText = "Typ";
            this.typCol.Name = "typCol";
            this.typCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.typCol.Width = 50;
            // 
            // nazevCol
            // 
            this.nazevCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nazevCol.HeaderText = "Název";
            this.nazevCol.MaxInputLength = 100;
            this.nazevCol.Name = "nazevCol";
            this.nazevCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // mnozCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.mnozCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.mnozCol.HeaderText = "Množ.";
            this.mnozCol.MaxInputLength = 3;
            this.mnozCol.Name = "mnozCol";
            this.mnozCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mnozCol.Width = 50;
            // 
            // cenajCol
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cenajCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.cenajCol.HeaderText = "Jednotková cena";
            this.cenajCol.MaxInputLength = 18;
            this.cenajCol.Name = "cenajCol";
            this.cenajCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cenajCol.Width = 125;
            // 
            // celcenCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.NullValue = null;
            this.celcenCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.celcenCol.HeaderText = "Cena řádku";
            this.celcenCol.Name = "celcenCol";
            this.celcenCol.ReadOnly = true;
            this.celcenCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.celcenCol.Width = 140;
            // 
            // polozkaEditMenu
            // 
            this.polozkaEditMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.polozkaEditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posunoutNahoruToolStripMenuItem,
            this.posunoutDoluToolStripMenuItem,
            this.toolStripMenuItem1,
            this.změnitToolStripMenuItem,
            this.smazatToolStripMenuItem});
            this.polozkaEditMenu.Name = "polozkaEditMenu";
            this.polozkaEditMenu.Size = new System.Drawing.Size(177, 98);
            // 
            // posunoutNahoruToolStripMenuItem
            // 
            this.posunoutNahoruToolStripMenuItem.Name = "posunoutNahoruToolStripMenuItem";
            this.posunoutNahoruToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.posunoutNahoruToolStripMenuItem.Text = "Posunout nahoru";
            this.posunoutNahoruToolStripMenuItem.Click += new System.EventHandler(this.posunoutNahoruToolStripMenuItem_Click);
            // 
            // posunoutDoluToolStripMenuItem
            // 
            this.posunoutDoluToolStripMenuItem.Name = "posunoutDoluToolStripMenuItem";
            this.posunoutDoluToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.posunoutDoluToolStripMenuItem.Text = "Posunout dolu";
            this.posunoutDoluToolStripMenuItem.Click += new System.EventHandler(this.posunoutDoluToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // změnitToolStripMenuItem
            // 
            this.změnitToolStripMenuItem.Image = global::Fakturace_2009.Properties.Resources.page_edit;
            this.změnitToolStripMenuItem.Name = "změnitToolStripMenuItem";
            this.změnitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.změnitToolStripMenuItem.Text = "Změnit";
            this.změnitToolStripMenuItem.Click += new System.EventHandler(this.změnitToolStripMenuItem_Click);
            // 
            // smazatToolStripMenuItem
            // 
            this.smazatToolStripMenuItem.Image = global::Fakturace_2009.Properties.Resources.delete;
            this.smazatToolStripMenuItem.Name = "smazatToolStripMenuItem";
            this.smazatToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.smazatToolStripMenuItem.Text = "Smazat";
            this.smazatToolStripMenuItem.Click += new System.EventHandler(this.smazatToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.konecToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.nástrojeToolStripMenuItem,
            this.souborToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1265, 30);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::Fakturace_2009.Properties.Resources.new_icon;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(76, 26);
            this.toolStripMenuItem3.Text = "Nový";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // konecToolStripMenuItem1
            // 
            this.konecToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.konecToolStripMenuItem1.Name = "konecToolStripMenuItem1";
            this.konecToolStripMenuItem1.Size = new System.Drawing.Size(63, 26);
            this.konecToolStripMenuItem1.Text = "Konec";
            this.konecToolStripMenuItem1.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Fakturace_2009.Properties.Resources.open;
            this.toolStripMenuItem2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(85, 26);
            this.toolStripMenuItem2.Text = "Otevřít";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.otevřítToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::Fakturace_2009.Properties.Resources.ti;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(99, 26);
            this.toolStripMenuItem4.Text = "Tisknout";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // nástrojeToolStripMenuItem
            // 
            this.nástrojeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.nástrojeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportovatToolStripMenuItem,
            this.importovatToolStripMenuItem,
            this.toolStripMenuItem6,
            this.statistikaToolStripMenuItem,
            this.nastaveníToolStripMenuItem});
            this.nástrojeToolStripMenuItem.Name = "nástrojeToolStripMenuItem";
            this.nástrojeToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.nástrojeToolStripMenuItem.Text = "Nástroje";
            // 
            // exportovatToolStripMenuItem
            // 
            this.exportovatToolStripMenuItem.Name = "exportovatToolStripMenuItem";
            this.exportovatToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportovatToolStripMenuItem.Text = "Exportovat";
            this.exportovatToolStripMenuItem.Visible = false;
            this.exportovatToolStripMenuItem.Click += new System.EventHandler(this.exportovatToolStripMenuItem_Click);
            // 
            // importovatToolStripMenuItem
            // 
            this.importovatToolStripMenuItem.Name = "importovatToolStripMenuItem";
            this.importovatToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.importovatToolStripMenuItem.Text = "Importovat";
            this.importovatToolStripMenuItem.Visible = false;
            this.importovatToolStripMenuItem.Click += new System.EventHandler(this.importovatToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(144, 6);
            this.toolStripMenuItem6.Visible = false;
            // 
            // statistikaToolStripMenuItem
            // 
            this.statistikaToolStripMenuItem.Name = "statistikaToolStripMenuItem";
            this.statistikaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.statistikaToolStripMenuItem.Text = "Statistika";
            this.statistikaToolStripMenuItem.Click += new System.EventHandler(this.statistikaToolStripMenuItem_Click_1);
            // 
            // nastaveníToolStripMenuItem
            // 
            this.nastaveníToolStripMenuItem.Name = "nastaveníToolStripMenuItem";
            this.nastaveníToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.nastaveníToolStripMenuItem.Text = "Nastavení";
            this.nastaveníToolStripMenuItem.Click += new System.EventHandler(this.nastaveníToolStripMenuItem_Click);
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NovyMenu,
            this.toolStripSeparator2,
            this.otevřítToolStripMenuItem,
            this.uložitToolStripMenuItem1,
            this.toolStripSeparator1,
            this.tisknoutToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(69, 26);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // NovyMenu
            // 
            this.NovyMenu.Image = global::Fakturace_2009.Properties.Resources.new_icon;
            this.NovyMenu.Name = "NovyMenu";
            this.NovyMenu.Size = new System.Drawing.Size(139, 28);
            this.NovyMenu.Text = "Nový";
            this.NovyMenu.Click += new System.EventHandler(this.NovyMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // otevřítToolStripMenuItem
            // 
            this.otevřítToolStripMenuItem.Image = global::Fakturace_2009.Properties.Resources.open;
            this.otevřítToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.otevřítToolStripMenuItem.Name = "otevřítToolStripMenuItem";
            this.otevřítToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.otevřítToolStripMenuItem.Text = "Otevřít";
            this.otevřítToolStripMenuItem.Click += new System.EventHandler(this.otevřítToolStripMenuItem_Click);
            // 
            // uložitToolStripMenuItem1
            // 
            this.uložitToolStripMenuItem1.Image = global::Fakturace_2009.Properties.Resources.save;
            this.uložitToolStripMenuItem1.Name = "uložitToolStripMenuItem1";
            this.uložitToolStripMenuItem1.Size = new System.Drawing.Size(139, 28);
            this.uložitToolStripMenuItem1.Text = "Uložit";
            this.uložitToolStripMenuItem1.Click += new System.EventHandler(this.uložitToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // tisknoutToolStripMenuItem
            // 
            this.tisknoutToolStripMenuItem.Image = global::Fakturace_2009.Properties.Resources.ti;
            this.tisknoutToolStripMenuItem.Name = "tisknoutToolStripMenuItem";
            this.tisknoutToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.tisknoutToolStripMenuItem.Text = "Tisknout";
            this.tisknoutToolStripMenuItem.Click += new System.EventHandler(this.tisknoutToolStripMenuItem_Click);
            // 
            // uložitToolStripMenuItem
            // 
            this.uložitToolStripMenuItem.Name = "uložitToolStripMenuItem";
            this.uložitToolStripMenuItem.Size = new System.Drawing.Size(56, 23);
            this.uložitToolStripMenuItem.Text = "Uložit";
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(58, 23);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(1265, 653);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.PopisGrp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(951, 127);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBoxMistoPraci);
            this.groupBox5.Location = new System.Drawing.Point(573, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(375, 121);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Místo prací";
            // 
            // textBoxMistoPraci
            // 
            this.textBoxMistoPraci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMistoPraci.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMistoPraci.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxMistoPraci.Location = new System.Drawing.Point(6, 23);
            this.textBoxMistoPraci.Multiline = true;
            this.textBoxMistoPraci.Name = "textBoxMistoPraci";
            this.textBoxMistoPraci.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMistoPraci.Size = new System.Drawing.Size(346, 92);
            this.textBoxMistoPraci.TabIndex = 5;
            this.textBoxMistoPraci.WordWrap = false;
            this.textBoxMistoPraci.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMistoPraci_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1265, 683);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = global::Fakturace_2009.Properties.Resources.icon;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Fakturace 2010";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PopisGrp.ResumeLayout(false);
            this.PopisGrp.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fakturaGrid)).EndInit();
            this.polozkaEditMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox CisloEdit;
        private System.Windows.Forms.GroupBox PopisGrp;
        private System.Windows.Forms.TextBox PopisEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker vystDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker splatDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip GuideTip;
        private System.Windows.Forms.Button odberatelButton;
        private System.Windows.Forms.ToolTip infoTip;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView fakturaGrid;
        private System.Windows.Forms.MaskedTextBox dphEdit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox celkemEd;
        private System.Windows.Forms.TextBox totalEd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox celkdphEd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ContextMenuStrip polozkaEditMenu;
        private System.Windows.Forms.ToolStripMenuItem posunoutNahoruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posunoutDoluToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smazatToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem souborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otevřítToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem uložitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tisknoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NovyMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button ButtonAddPolozka;
        private System.Windows.Forms.Button buttonChangePolozka;
        private System.Windows.Forms.Button buttonDeletePolozka;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxMistoPraci;
        private System.Windows.Forms.ToolStripMenuItem nástrojeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem statistikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveníToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripMenuItem změnitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn typCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazevCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnozCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cenajCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn celcenCol;
        private System.Windows.Forms.DateTimePicker dateZdan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxZdVystLock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxUhrada;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FirmaEditor firmaEditor1;

    }
}

