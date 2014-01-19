namespace Fakturace_2009.GUI
{
    partial class OpenForm
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
            this.seznamBox = new System.Windows.Forms.ListBox();
            this.proupravuBtn = new System.Windows.Forms.Button();
            this.hledaniBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.celkemLab = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.popisLab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guideTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.smazatButton = new System.Windows.Forms.Button();
            this.pocetLab = new System.Windows.Forms.Label();
            this.OtevritVyber = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.proÚpravuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.jakoNovouBezPoložekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jakoNovouSPoložkamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.OtevritVyber.SuspendLayout();
            this.SuspendLayout();
            // 
            // seznamBox
            // 
            this.seznamBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.seznamBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.seznamBox.FormattingEnabled = true;
            this.seznamBox.ItemHeight = 60;
            this.seznamBox.Location = new System.Drawing.Point(14, 46);
            this.seznamBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.seznamBox.Name = "seznamBox";
            this.seznamBox.Size = new System.Drawing.Size(441, 244);
            this.seznamBox.TabIndex = 0;
            this.guideTip.SetToolTip(this.seznamBox, "...výbìr faktury, kterou chcete otevøít nebo pouze pro zobrazení bližších informa" +
                    "cí.");
            this.seznamBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.seznamBox_MouseDoubleClick);
            this.seznamBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.seznamBox.SelectedIndexChanged += new System.EventHandler(this.seznamBox_SelectedIndexChanged);
            // 
            // proupravuBtn
            // 
            this.proupravuBtn.Enabled = false;
            this.proupravuBtn.Location = new System.Drawing.Point(299, 305);
            this.proupravuBtn.Name = "proupravuBtn";
            this.proupravuBtn.Size = new System.Drawing.Size(156, 28);
            this.proupravuBtn.TabIndex = 1;
            this.proupravuBtn.Text = "Otevøít";
            this.guideTip.SetToolTip(this.proupravuBtn, "... výbìr zpùsobu otevøení.");
            this.proupravuBtn.UseVisualStyleBackColor = true;
            this.proupravuBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // hledaniBox
            // 
            this.hledaniBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.hledaniBox.Location = new System.Drawing.Point(268, 12);
            this.hledaniBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.hledaniBox.Name = "hledaniBox";
            this.hledaniBox.Size = new System.Drawing.Size(187, 24);
            this.hledaniBox.TabIndex = 2;
            this.hledaniBox.Text = "Hledání...";
            this.guideTip.SetToolTip(this.hledaniBox, "...vyhledávání ve fakturách pomocí zadání hledaného textu.\r\nHledá v èíslech, jmén" +
                    "ech odbìratelù, míst provádìní pracía popisech faktur.");
            this.hledaniBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.hledaniBox.Leave += new System.EventHandler(this.textBox1_Leave);
            this.hledaniBox.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.celkemLab);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.popisLab);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 297);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Další info:";
            // 
            // celkemLab
            // 
            this.celkemLab.Location = new System.Drawing.Point(98, 97);
            this.celkemLab.Margin = new System.Windows.Forms.Padding(3, 0, 8, 0);
            this.celkemLab.Name = "celkemLab";
            this.celkemLab.Size = new System.Drawing.Size(170, 17);
            this.celkemLab.TabIndex = 3;
            this.celkemLab.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cena celkem:";
            // 
            // popisLab
            // 
            this.popisLab.Location = new System.Drawing.Point(6, 36);
            this.popisLab.Name = "popisLab";
            this.popisLab.Size = new System.Drawing.Size(267, 57);
            this.popisLab.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Popis faktury:";
            // 
            // guideTip
            // 
            this.guideTip.AutoPopDelay = 5000;
            this.guideTip.InitialDelay = 400;
            this.guideTip.ReshowDelay = 100;
            this.guideTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.guideTip.ToolTipTitle = "Kliknìte pro...";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(299, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Zpìt";
            this.guideTip.SetToolTip(this.button1, ".. návrat na fakturu, ze které jste otevøeli toto  okno. Nebude nijak zmìnìna ani" +
                    " ztracena ;-)");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // smazatButton
            // 
            this.smazatButton.Enabled = false;
            this.smazatButton.Location = new System.Drawing.Point(299, 361);
            this.smazatButton.Name = "smazatButton";
            this.smazatButton.Size = new System.Drawing.Size(156, 28);
            this.smazatButton.TabIndex = 6;
            this.smazatButton.Text = "Smazat";
            this.guideTip.SetToolTip(this.smazatButton, ".. mazání vybrané faktury. Pokud fakturu smažete nebude možné ji obnovit.");
            this.smazatButton.UseVisualStyleBackColor = true;
            this.smazatButton.Click += new System.EventHandler(this.smazatButton_Click);
            // 
            // pocetLab
            // 
            this.pocetLab.AutoSize = true;
            this.pocetLab.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.pocetLab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pocetLab.Location = new System.Drawing.Point(12, 16);
            this.pocetLab.Name = "pocetLab";
            this.pocetLab.Size = new System.Drawing.Size(0, 16);
            this.pocetLab.TabIndex = 4;
            // 
            // OtevritVyber
            // 
            this.OtevritVyber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.OtevritVyber.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proÚpravuToolStripMenuItem,
            this.toolStripSeparator1,
            this.jakoNovouBezPoložekToolStripMenuItem,
            this.jakoNovouSPoložkamiToolStripMenuItem});
            this.OtevritVyber.Name = "OtevritVyber";
            this.OtevritVyber.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.OtevritVyber.Size = new System.Drawing.Size(239, 76);
            // 
            // proÚpravuToolStripMenuItem
            // 
            this.proÚpravuToolStripMenuItem.Name = "proÚpravuToolStripMenuItem";
            this.proÚpravuToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.proÚpravuToolStripMenuItem.Text = "Pro úpravu";
            this.proÚpravuToolStripMenuItem.ToolTipText = "Otevøe tuto fakturu pro úpravu. Uložit lze pouze jako tu samou fakturu.";
            this.proÚpravuToolStripMenuItem.Click += new System.EventHandler(this.proÚpravuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // jakoNovouBezPoložekToolStripMenuItem
            // 
            this.jakoNovouBezPoložekToolStripMenuItem.Name = "jakoNovouBezPoložekToolStripMenuItem";
            this.jakoNovouBezPoložekToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.jakoNovouBezPoložekToolStripMenuItem.Text = "Jako novou - bez položek";
            this.jakoNovouBezPoložekToolStripMenuItem.ToolTipText = "Otevøe fakturu pod novým èíslem a ponechá vše z pùvodní faktury";
            this.jakoNovouBezPoložekToolStripMenuItem.Click += new System.EventHandler(this.jakoNovouBezPoložekToolStripMenuItem_Click);
            // 
            // jakoNovouSPoložkamiToolStripMenuItem
            // 
            this.jakoNovouSPoložkamiToolStripMenuItem.Name = "jakoNovouSPoložkamiToolStripMenuItem";
            this.jakoNovouSPoložkamiToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.jakoNovouSPoložkamiToolStripMenuItem.Text = "Jako novou - s položkami";
            this.jakoNovouSPoložkamiToolStripMenuItem.ToolTipText = "Otevøe fakturu pod novým èíslem a vyprázdní položky";
            this.jakoNovouSPoložkamiToolStripMenuItem.Click += new System.EventHandler(this.jakoNovouSPoložkamiToolStripMenuItem_Click);
            // 
            // OpenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 435);
            this.Controls.Add(this.smazatButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pocetLab);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hledaniBox);
            this.Controls.Add(this.proupravuBtn);
            this.Controls.Add(this.seznamBox);
            this.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Otevøír fakturu..";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.OtevritVyber.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox seznamBox;
        private System.Windows.Forms.Button proupravuBtn;
        private System.Windows.Forms.TextBox hledaniBox;
        private System.Windows.Forms.ToolTip guideTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label pocetLab;
        private System.Windows.Forms.Label popisLab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label celkemLab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip OtevritVyber;
        private System.Windows.Forms.ToolStripMenuItem proÚpravuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem jakoNovouBezPoložekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jakoNovouSPoložkamiToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button smazatButton;
    }
}