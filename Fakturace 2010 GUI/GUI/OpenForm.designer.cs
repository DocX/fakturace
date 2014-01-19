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
            this.pro�pravuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.jakoNovouBezPolo�ekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jakoNovouSPolo�kamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.guideTip.SetToolTip(this.seznamBox, "...v�b�r faktury, kterou chcete otev��t nebo pouze pro zobrazen� bli���ch informa" +
                    "c�.");
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
            this.proupravuBtn.Text = "Otev��t";
            this.guideTip.SetToolTip(this.proupravuBtn, "... v�b�r zp�sobu otev�en�.");
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
            this.hledaniBox.Text = "Hled�n�...";
            this.guideTip.SetToolTip(this.hledaniBox, "...vyhled�v�n� ve faktur�ch pomoc� zad�n� hledan�ho textu.\r\nHled� v ��slech, jm�n" +
                    "ech odb�ratel�, m�st prov�d�n� prac�a popisech faktur.");
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
            this.groupBox1.Text = "Dal�� info:";
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
            this.guideTip.ToolTipTitle = "Klikn�te pro...";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(299, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Zp�t";
            this.guideTip.SetToolTip(this.button1, ".. n�vrat na fakturu, ze kter� jste otev�eli toto  okno. Nebude nijak zm�n�na ani" +
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
            this.guideTip.SetToolTip(this.smazatButton, ".. maz�n� vybran� faktury. Pokud fakturu sma�ete nebude mo�n� ji obnovit.");
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
            this.pro�pravuToolStripMenuItem,
            this.toolStripSeparator1,
            this.jakoNovouBezPolo�ekToolStripMenuItem,
            this.jakoNovouSPolo�kamiToolStripMenuItem});
            this.OtevritVyber.Name = "OtevritVyber";
            this.OtevritVyber.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.OtevritVyber.Size = new System.Drawing.Size(239, 76);
            // 
            // pro�pravuToolStripMenuItem
            // 
            this.pro�pravuToolStripMenuItem.Name = "pro�pravuToolStripMenuItem";
            this.pro�pravuToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.pro�pravuToolStripMenuItem.Text = "Pro �pravu";
            this.pro�pravuToolStripMenuItem.ToolTipText = "Otev�e tuto fakturu pro �pravu. Ulo�it lze pouze jako tu samou fakturu.";
            this.pro�pravuToolStripMenuItem.Click += new System.EventHandler(this.pro�pravuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            // 
            // jakoNovouBezPolo�ekToolStripMenuItem
            // 
            this.jakoNovouBezPolo�ekToolStripMenuItem.Name = "jakoNovouBezPolo�ekToolStripMenuItem";
            this.jakoNovouBezPolo�ekToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.jakoNovouBezPolo�ekToolStripMenuItem.Text = "Jako novou - bez polo�ek";
            this.jakoNovouBezPolo�ekToolStripMenuItem.ToolTipText = "Otev�e fakturu pod nov�m ��slem a ponech� v�e z p�vodn� faktury";
            this.jakoNovouBezPolo�ekToolStripMenuItem.Click += new System.EventHandler(this.jakoNovouBezPolo�ekToolStripMenuItem_Click);
            // 
            // jakoNovouSPolo�kamiToolStripMenuItem
            // 
            this.jakoNovouSPolo�kamiToolStripMenuItem.Name = "jakoNovouSPolo�kamiToolStripMenuItem";
            this.jakoNovouSPolo�kamiToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.jakoNovouSPolo�kamiToolStripMenuItem.Text = "Jako novou - s polo�kami";
            this.jakoNovouSPolo�kamiToolStripMenuItem.ToolTipText = "Otev�e fakturu pod nov�m ��slem a vypr�zdn� polo�ky";
            this.jakoNovouSPolo�kamiToolStripMenuItem.Click += new System.EventHandler(this.jakoNovouSPolo�kamiToolStripMenuItem_Click);
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
            this.Text = "Otev��r fakturu..";
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
        private System.Windows.Forms.ToolStripMenuItem pro�pravuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem jakoNovouBezPolo�ekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jakoNovouSPolo�kamiToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button smazatButton;
    }
}