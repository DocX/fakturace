using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakturace_2009.Backbone;
using System.Globalization;

namespace Fakturace_2009.GUI
{
    public partial class PolozkaEditor : Form
    {
        public PolozkaEditor(PolozkaFaktury polozka, Fakturace_2009.StorageEngines.FakturaceStorage storage)
        {
            InitializeComponent();

            if (polozka == null || storage == null)
                throw new NullReferenceException();

            this.storage = storage;
            editedPolozka = polozka;

            UpdateControlsFromData();

            textBoxNazev.SelectAll();
            textBoxNazev.Focus();
        }

        public PolozkaFaktury editedPolozka;
        private Color ErrBackColor = Color.FromArgb(255, 180, 180);
        private Fakturace_2009.StorageEngines.FakturaceStorage storage;

        public void SelectSpecificTyp(PolozkaFakturyTyp typ)
        {
            int index = comboBoxTyp.Items.IndexOf(typ);
            if (index >= 0)
                comboBoxTyp.SelectedIndex = index;
        }

        public void UpdateControlsFromData()
        {
            this.SuspendLayout();

            // nacist typy
            foreach (PolozkaFakturyTyp typ in storage.TypyPolozekGet())
            {
                comboBoxTyp.Items.Add(typ);
            }
            comboBoxTyp.SelectedIndex = 0;

            textBoxNazev.Text = editedPolozka.Nazev;
            textBoxMnozstvi.Text = editedPolozka.Mnozstvi.ToString("0.0");
            textBoxJednotky.Text = editedPolozka.JednotkaKusu;
            UpdateControlsCeny();

            this.ResumeLayout();
        }

        private bool TryUpdateDataNazev()
        {
            try
            {
                editedPolozka.Nazev = textBoxNazev.Text;
                textBoxNazev.BackColor = Color.FromKnownColor(KnownColor.Window);
                return true;
            }
            catch (Exception)
            {
                textBoxNazev.BackColor = ErrBackColor;
                return false;
            }
        }

        private bool TryUpdateDataMnozstvi()
        {
            try
            {
                editedPolozka.Mnozstvi = float.Parse(textBoxMnozstvi.Text);
                textBoxMnozstvi.BackColor = Color.FromKnownColor(KnownColor.Window);
                return true;
            }
            catch (Exception )
            {
                textBoxMnozstvi.BackColor = ErrBackColor;
                return false;
            }
        }

        private bool TryUpdateDataCena()
        {
            try
            {
                editedPolozka.CenaZaKus = decimal.Parse(textBoxCena.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                decimal test = editedPolozka.CenaPolozky;
                textBoxCena.BackColor = Color.FromKnownColor(KnownColor.Window);
                return true;
            }
            catch (OverflowException)
            {
                if (textBoxCena.BackColor != ErrBackColor)
                    MessageBox.Show("Hodnota je příliš velká");
                textBoxCena.BackColor = ErrBackColor;
                return false;
            }
            catch (Exception)
            {
                textBoxCena.BackColor = ErrBackColor;
                return false;
            }
        }

        private bool TryUpdateDataJednotka()
        {
            editedPolozka.JednotkaKusu = textBoxJednotky.Text;
            return true;
        }

        private void UpdateControlsCeny()
        {
            textBoxCena.Text = editedPolozka.CenaZaKus.ToString("C", CultureInfo.CurrentUICulture.NumberFormat);
            textBoxCenaCelkem.Text = editedPolozka.CenaPolozky.ToString("C", CultureInfo.CurrentUICulture.NumberFormat);
        }

        private bool TryUpdateDateFromControls()
        {
            editedPolozka.Typ = (PolozkaFakturyTyp)comboBoxTyp.SelectedItem;
            return TryUpdateDataCena() && TryUpdateDataMnozstvi() && TryUpdateDataNazev() && TryUpdateDataJednotka();
        }

        private void textBoxNazev_Validating(object sender, CancelEventArgs e)
        {
            TryUpdateDataNazev();
        }

        private void textBoxMnozstvi_Validating(object sender, CancelEventArgs e)
        {
            if (TryUpdateDataMnozstvi())
            {
                UpdateControlsCeny();
            }
        }

        private void textBoxCena_Validating(object sender, CancelEventArgs e)
        {
            if (TryUpdateDataCena())
            {
                UpdateControlsCeny();
            }
        }

        private void PolozkaEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry || this.DialogResult == DialogResult.OK)
            {
                if (TryUpdateDateFromControls() == false)
                    e.Cancel = true;
            }
        }

        private void textBoxCena_TextChanged(object sender, EventArgs e)
        {
            if (TryUpdateDataCena())
                textBoxCenaCelkem.Text = editedPolozka.CenaPolozky.ToString("C", CultureInfo.CurrentUICulture.NumberFormat);
        }

        private void textBoxMnozstvi_TextChanged(object sender, EventArgs e)
        {
            if (TryUpdateDataMnozstvi())
                UpdateControlsCeny();
        }

        private void ReturnKeyDownNext(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(sender as Control, true, true, true, false);
            }
        }

        private void textBoxJednotky_Validating(object sender, CancelEventArgs e)
        {
            TryUpdateDataJednotka();
        }

        private void PolozkaEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }


    }
}
