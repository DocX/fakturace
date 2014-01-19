namespace Fakturace_2009.GUI
{
    partial class PolozkaEditor
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
            this.buttonAddAndAgain = new System.Windows.Forms.Button();
            this.buttonAddAndClose = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxNazev = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTyp = new System.Windows.Forms.ComboBox();
            this.textBoxMnozstvi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxJednotky = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCena = new System.Windows.Forms.TextBox();
            this.textBoxCenaCelkem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddAndAgain
            // 
            this.buttonAddAndAgain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAndAgain.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.buttonAddAndAgain.Location = new System.Drawing.Point(441, 219);
            this.buttonAddAndAgain.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddAndAgain.Name = "buttonAddAndAgain";
            this.buttonAddAndAgain.Size = new System.Drawing.Size(149, 28);
            this.buttonAddAndAgain.TabIndex = 5;
            this.buttonAddAndAgain.Text = "Uložit a vložit další";
            this.toolTip1.SetToolTip(this.buttonAddAndAgain, "... uložení nové položky a návratu znovu do tohoto okna s novou položkou.");
            this.buttonAddAndAgain.UseVisualStyleBackColor = true;
            // 
            // buttonAddAndClose
            // 
            this.buttonAddAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddAndClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAddAndClose.Location = new System.Drawing.Point(441, 255);
            this.buttonAddAndClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddAndClose.Name = "buttonAddAndClose";
            this.buttonAddAndClose.Size = new System.Drawing.Size(149, 28);
            this.buttonAddAndClose.TabIndex = 6;
            this.buttonAddAndClose.Text = "Uložit a vrátit";
            this.toolTip1.SetToolTip(this.buttonAddAndClose, "... uložení nové položky a návratu na fakturu.");
            this.buttonAddAndClose.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(13, 255);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(149, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Zrušit";
            this.toolTip1.SetToolTip(this.buttonCancel, "... návrat na fakturu bez uložení změn položky.");
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxNazev
            // 
            this.textBoxNazev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNazev.Location = new System.Drawing.Point(12, 77);
            this.textBoxNazev.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNazev.Multiline = true;
            this.textBoxNazev.Name = "textBoxNazev";
            this.textBoxNazev.Size = new System.Drawing.Size(578, 78);
            this.textBoxNazev.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxNazev, "... napsání názvu položky, kterou fakturujete.");
            this.textBoxNazev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReturnKeyDownNext);
            this.textBoxNazev.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNazev_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Název položky";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Druh položky";
            // 
            // comboBoxTyp
            // 
            this.comboBoxTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTyp.FormattingEnabled = true;
            this.comboBoxTyp.Location = new System.Drawing.Point(12, 29);
            this.comboBoxTyp.Name = "comboBoxTyp";
            this.comboBoxTyp.Size = new System.Drawing.Size(168, 24);
            this.comboBoxTyp.TabIndex = 8;
            this.toolTip1.SetToolTip(this.comboBoxTyp, "... vybrání typu položky. Pokud zde není to, co hledáte, klikněte na tlačítko \".." +
                    ".\" vedle.");
            // 
            // textBoxMnozstvi
            // 
            this.textBoxMnozstvi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMnozstvi.Location = new System.Drawing.Point(12, 182);
            this.textBoxMnozstvi.Name = "textBoxMnozstvi";
            this.textBoxMnozstvi.Size = new System.Drawing.Size(100, 23);
            this.textBoxMnozstvi.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxMnozstvi, "... zadání množství. Může být desetinné číslo, ne však 0.");
            this.textBoxMnozstvi.TextChanged += new System.EventHandler(this.textBoxMnozstvi_TextChanged);
            this.textBoxMnozstvi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReturnKeyDownNext);
            this.textBoxMnozstvi.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxMnozstvi_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Množství";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Jednotky";
            // 
            // textBoxJednotky
            // 
            this.textBoxJednotky.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxJednotky.Location = new System.Drawing.Point(118, 182);
            this.textBoxJednotky.Name = "textBoxJednotky";
            this.textBoxJednotky.Size = new System.Drawing.Size(62, 23);
            this.textBoxJednotky.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxJednotky, "... napsání jednotky množství. Pokud položka žádnou jednotku nemá, ponechte toto " +
                    "pole prázdné.");
            this.textBoxJednotky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReturnKeyDownNext);
            this.textBoxJednotky.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxJednotky_Validating);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxCena, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCenaCelkem, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(187, 162);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(404, 50);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Celkem";
            // 
            // textBoxCena
            // 
            this.textBoxCena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCena.Location = new System.Drawing.Point(3, 20);
            this.textBoxCena.Name = "textBoxCena";
            this.textBoxCena.Size = new System.Drawing.Size(196, 23);
            this.textBoxCena.TabIndex = 1;
            this.textBoxCena.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.textBoxCena, "... zadání jednotkové ceny položky. Při zadávání ihned uvidíte celkovou cenu.");
            this.textBoxCena.TextChanged += new System.EventHandler(this.textBoxCena_TextChanged);
            this.textBoxCena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReturnKeyDownNext);
            this.textBoxCena.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCena_Validating);
            // 
            // textBoxCenaCelkem
            // 
            this.textBoxCenaCelkem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCenaCelkem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxCenaCelkem.Location = new System.Drawing.Point(205, 20);
            this.textBoxCenaCelkem.Name = "textBoxCenaCelkem";
            this.textBoxCenaCelkem.ReadOnly = true;
            this.textBoxCenaCelkem.Size = new System.Drawing.Size(196, 23);
            this.textBoxCenaCelkem.TabIndex = 3;
            this.textBoxCenaCelkem.TabStop = false;
            this.textBoxCenaCelkem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cena/jedn.";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 800;
            this.toolTip1.AutoPopDelay = 8000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 160;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Klikněte pro...";
            // 
            // PolozkaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(603, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBoxJednotky);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMnozstvi);
            this.Controls.Add(this.comboBoxTyp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNazev);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAddAndClose);
            this.Controls.Add(this.buttonAddAndAgain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PolozkaEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editor položky";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PolozkaEditor_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PolozkaEditor_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddAndClose;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxNazev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTyp;
        private System.Windows.Forms.TextBox textBoxMnozstvi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxJednotky;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCena;
        private System.Windows.Forms.TextBox textBoxCenaCelkem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Button buttonAddAndAgain;
    }
}