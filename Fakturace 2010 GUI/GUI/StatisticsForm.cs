using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fakturace_2009.StorageEngines;
using Fakturace_2009.Backbone;

namespace Fakturace_2009.GUI
{
    public partial class StatisticsForm : Form
    {
        FakturaceStorage Storage;

        private bool loaded = false;

        public StatisticsForm(FakturaceStorage storage)
        {
            InitializeComponent();
            Storage = storage;

            List<FakturaFingerprint> faktury = Storage.FakturaGetFprints();
            if (faktury.Count > 0)
            {
                DateTime first = DateTime.Now;
                DateTime last = DateTime.Now;

                foreach (FakturaFingerprint f in faktury)
                {
                    if (f.datumVytvoreni.CompareTo(first) < 0)
                        first = f.datumVytvoreni;
                    if (f.datumVytvoreni.CompareTo(last) > 0)
                        last = f.datumVytvoreni;
                }


                PocatekDate.MinDate = first;
                PocatekDate.Value = first;
                KonecDate.MaxDate = last;
                KonecDate.Value = last;

                loaded = true;

                labelPocet.Text = faktury.Count.ToString();

            }
            else
            {
                PocatekDate.Enabled = false;
                KonecDate.Enabled = false;
            }

            foreach (PolozkaFakturyTyp t in Storage.TypyPolozekGet())
            {
                comboBoxTyp.Items.Add(t.Nazev); 
            }
        }

        Faktura[] vybraneFaktury;

        private bool UpdateVybraneFaktury()
        {
            try
            {
                vybraneFaktury = Storage.FakturaGetRange(PocatekDate.Value, KonecDate.Value);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Chyba pøi získávání statistik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ResumeLayout();
                this.Cursor = Cursors.Default;
                return false;
            }
        }

        private void VypocitatZaObdobi()
        {
            if (vybraneFaktury == null) return;

            decimal celkem = 0, celkemDPH = 0, celkemTyp = 0;
            int pocetFaktur = 0, pocetPolozek = 0;

            this.Cursor = Cursors.WaitCursor;
            this.SuspendLayout();

            foreach (Faktura f in vybraneFaktury)
            {
                celkem += f.CenaCelkem;
                celkemDPH += f.CenaDPH;
                pocetPolozek += f.PolozkyNaFakture.Count;

                if (comboBoxTyp.Text != "")
                {
                    celkemTyp += f.CenaCelkemTypu(comboBoxTyp.Text );
                }
            }

            pocetFaktur = vybraneFaktury.Length;

            this.ResumeLayout();
            this.Cursor = Cursors.Default;

            labelCelkDPH.Text = celkemDPH.ToString("C");
            labelCelkSDPH.Text = (celkem + celkemDPH).ToString("C");
            labelPolCelk.Text = celkem.ToString("C");
            labelPocet.Text = pocetFaktur.ToString();
            labelPolozek.Text = pocetPolozek.ToString();
            labelAvgFak.Text = ((celkem + celkemDPH) / pocetFaktur).ToString("C");
            labelAvgPol.Text = (celkem / pocetPolozek).ToString("C");
            labelCelkemTyp.Text = celkemTyp.ToString("C");
        }

        private void PocatekDate_ValueChanged(object sender, EventArgs e)
        {
            if (!loaded) return;
            //KonecDate.MinDate = PocatekDate.Value;
            if (UpdateVybraneFaktury())
                VypocitatZaObdobi();
        }

        private void KonecDate_ValueChanged(object sender, EventArgs e)
        {
            if (!loaded) return;
            //PocatekDate.MaxDate = KonecDate.Value;
            if (UpdateVybraneFaktury())
                VypocitatZaObdobi();
        }


        private void comboBoxTyp_TextUpdate(object sender, EventArgs e)
        {
            VypocitatZaObdobi();
        }

        private void buttonRecomp_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            UpdateVybraneFaktury();

            VypocitatZaObdobi();

            this.Cursor = Cursors.Arrow;
        }

        private void comboBoxTyp_SelectedValueChanged(object sender, EventArgs e)
        {
            VypocitatZaObdobi();
        }

        private void StatisticsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

    }
}