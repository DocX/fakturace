using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fakturace_2009.Backbone;
using Fakturace_2009.StorageEngines;

namespace Fakturace_2009.GUI
{
    public partial class OdberatelForm : Form
    {
        public OdberatelForm(Firma odberatel, FakturaceStorage storage)
        {
            InitializeComponent();

            if (odberatel == null || storage == null)
                throw new NullReferenceException();

            //EditedOdberatel = odberatel;
            this.storage = storage;

            firmaEditor1.EditedFirma = odberatel;
            UpdateSavedAccounts();

            MainForm.SetKeydownHandlerToChildern(this, new KeyEventHandler(OdberatelForm_KeyDown));
        }



        private FakturaceStorage storage;
        public Firma EditedOdberatel
        {
            get
            {
                return firmaEditor1.EditedFirma;
            }
        }

        private void SelectNextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Znovu nacte ulozene odberatele z uloziste
        /// </summary>
        private void UpdateSavedAccounts()
        {
            this.SuspendLayout();
            odberateleBox.Items.Clear();
            odberateleBox.Items.AddRange(storage.OdberatelGet());
            odberateleBox.SelectedIndex = odberateleBox.Items.Add("( Nový )");
            this.ResumeLayout();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            firmaEditor1.EditedFirma = new Firma();
        }

        private void OdberatelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                //UpdateDataFromControls();

                if (firmaEditor1.EditedFirma.isEmpty)
                {
                    if (MessageBox.Show("Zadali jste prázdného odbìratele. Opravdu uložit do faktury?","",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void odberateleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (odberateleBox.SelectedIndex == odberateleBox.Items.Count - 1)
            {
                ulozitBtn.Text = "Uložit nový";
            }

            if (odberateleBox.SelectedItem is Firma)
            {
                firmaEditor1.EditedFirma = new Firma((Firma)odberateleBox.SelectedItem);
                ulozitBtn.Text = "Pøepsat";
                //UpdateControlsFromData();
            }
        }

        private void ulozitBtn_Click(object sender, EventArgs e)
        {
            if (odberateleBox.SelectedIndex == odberateleBox.Items.Count - 1 || odberateleBox.SelectedIndex < 0)
            {
                // Ulozit jako novy
                //UpdateDataFromControls();
                storage.OdberatelSave(new Firma(firmaEditor1.EditedFirma));
                UpdateSavedAccounts();
                odberateleBox.SelectedIndex = odberateleBox.Items.Count - 2;
            }
            else if (odberateleBox.SelectedItem is Firma)
            {
                if (MessageBox.Show("Pøepsan uloženého odbìratele " + odberateleBox.SelectedItem.ToString() + "?",
                        "Pøepsat?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //UpdateDataFromControls();
                    int id = odberateleBox.SelectedIndex;
                    storage.OdberatelSave(new Firma(firmaEditor1.EditedFirma), id);
                    UpdateSavedAccounts();
                    odberateleBox.SelectedIndex = id;
                }
            }
        }

        private void Control_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            infoTip.Show(infoTip.GetToolTip(sender as Control), sender as Control);
        }

        private void OdberatelForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            // je vybrana firma
            if (odberateleBox.SelectedItem is Firma)
            {
                if (MessageBox.Show("Opravdu chcete nenávratnì smazat pøeddefinovaného odbìratele " + 
                    (odberateleBox.SelectedItem as Firma).Nazev + "?", "Smazat?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        storage.OdberatelDelete(odberateleBox.SelectedIndex);
                        UpdateSavedAccounts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Chyba");
                    }
                }
            }
        }

        private void odberateleBox_DoubleClick(object sender, EventArgs e)
        {
            if (odberateleBox.SelectedItem is Firma)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}