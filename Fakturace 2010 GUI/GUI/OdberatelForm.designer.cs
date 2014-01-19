namespace Fakturace_2009.GUI
{
    partial class OdberatelForm
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
            this.ulozitBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.zpetBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.infoTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDel = new System.Windows.Forms.Button();
            this.odberateleBox = new System.Windows.Forms.ListBox();
            this.firmaEditor1 = new Fakturace_2009.GUI.FirmaEditor();
            this.SuspendLayout();
            // 
            // ulozitBtn
            // 
            this.ulozitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ulozitBtn.Location = new System.Drawing.Point(12, 297);
            this.ulozitBtn.Name = "ulozitBtn";
            this.ulozitBtn.Size = new System.Drawing.Size(90, 26);
            this.ulozitBtn.TabIndex = 2;
            this.ulozitBtn.Text = "Uložit nový";
            this.infoTip.SetToolTip(this.ulozitBtn, "Uložení právì zadaných informací o odbìrateli\r\ndo pøeddefinovaných odbìratelù.\r\nP" +
                    "okud máte vybraného již uloženého odbìratel,\r\nbudete dotázáni zda jej chcete pøe" +
                    "psat");
            this.ulozitBtn.UseVisualStyleBackColor = true;
            this.ulozitBtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Control_HelpRequested);
            this.ulozitBtn.Click += new System.EventHandler(this.ulozitBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.BackColor = System.Drawing.SystemColors.Control;
            this.okBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.okBtn.Location = new System.Drawing.Point(593, 297);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(114, 26);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "OK";
            this.infoTip.SetToolTip(this.okBtn, "Nastavení vámi zadaného odbìratele do faktury.\r\nPoté jej mùžete kdykoliv zmìnit.");
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Control_HelpRequested);
            // 
            // zpetBtn
            // 
            this.zpetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zpetBtn.BackColor = System.Drawing.SystemColors.Control;
            this.zpetBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.zpetBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.zpetBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.zpetBtn.Location = new System.Drawing.Point(498, 297);
            this.zpetBtn.Name = "zpetBtn";
            this.zpetBtn.Size = new System.Drawing.Size(91, 26);
            this.zpetBtn.TabIndex = 9;
            this.zpetBtn.Text = "Zpìt";
            this.infoTip.SetToolTip(this.zpetBtn, "Návrat na fakturu. Odbìratel se nebude mìnit.");
            this.zpetBtn.UseVisualStyleBackColor = true;
            this.zpetBtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Control_HelpRequested);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(221, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 26);
            this.button1.TabIndex = 10;
            this.button1.Text = "Vyèistit";
            this.infoTip.SetToolTip(this.button1, "Vymazání všech políèek pro zadávání.\r\nÚdaje na faktuøe nebo uložení odbìratelé ne" +
                    "budou dotèeny.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.Control_HelpRequested);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infoTip
            // 
            this.infoTip.AutoPopDelay = 5000;
            this.infoTip.InitialDelay = 500;
            this.infoTip.ReshowDelay = 100;
            this.infoTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.infoTip.ToolTipTitle = "Kliknìte pro...";
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDel.Location = new System.Drawing.Point(125, 297);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(90, 26);
            this.buttonDel.TabIndex = 13;
            this.buttonDel.Text = "Smazat";
            this.infoTip.SetToolTip(this.buttonDel, "Smaže uloženou šablonu odbìratele");
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // odberateleBox
            // 
            this.odberateleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.odberateleBox.FormattingEnabled = true;
            this.odberateleBox.IntegralHeight = false;
            this.odberateleBox.ItemHeight = 16;
            this.odberateleBox.Location = new System.Drawing.Point(12, 12);
            this.odberateleBox.Name = "odberateleBox";
            this.odberateleBox.Size = new System.Drawing.Size(203, 279);
            this.odberateleBox.TabIndex = 11;
            this.odberateleBox.SelectedIndexChanged += new System.EventHandler(this.odberateleBox_SelectedIndexChanged);
            this.odberateleBox.DoubleClick += new System.EventHandler(this.odberateleBox_DoubleClick);
            // 
            // firmaEditor1
            // 
            this.firmaEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.firmaEditor1.EditedFirma = firma1;
            this.firmaEditor1.Location = new System.Drawing.Point(221, 13);
            this.firmaEditor1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firmaEditor1.Name = "firmaEditor1";
            this.firmaEditor1.Size = new System.Drawing.Size(486, 277);
            this.firmaEditor1.TabIndex = 14;
            // 
            // OdberatelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 330);
            this.Controls.Add(this.firmaEditor1);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.ulozitBtn);
            this.Controls.Add(this.odberateleBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zpetBtn);
            this.Controls.Add(this.okBtn);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OdberatelForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Výbìr nebo úprava odbìratele";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OdberatelForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OdberatelForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ulozitBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button zpetBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip infoTip;
        private System.Windows.Forms.ListBox odberateleBox;
        private System.Windows.Forms.Button buttonDel;
        private FirmaEditor firmaEditor1;
    }
}