using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fakturace_2009.Backbone;
using System.Globalization;
using Fakturace_2009.StorageEngines;

namespace Fakturace_2009.GUI
{
    public enum FakturaOpenMode
    {
        NovaSPolozkami,
        NovaBezPolozek,
        ProUpravu
    }

    public partial class MainForm : Form
    {
        public static void SetKeydownHandlerToChildern(Control parent, KeyEventHandler keh)
        {
            foreach (Control item in parent.Controls)
            {
                item.KeyDown += keh;
            }
        }
        
        private Faktura OpenedFaktura;
        private FakturaOpenMode OpenMode = FakturaOpenMode.NovaSPolozkami;
        public FakturaceStorage ActiveStorage;
        DataGridView.HitTestInfo popupGridHit;

        public MainForm(FakturaceStorage storage)
        {
            InitializeComponent();
            this.ActiveStorage = storage;
            this.CisloEdit.Mask = (String)storage.FakturaCisloType.GetMethod("GetTextMask").Invoke(null, new Object[0]);
            NovaFaktura();
        }


        private void NovaFaktura()
        {
            try
            {
                this.OpenedFaktura = new Faktura(ActiveStorage.FakturaNextNumber(), ActiveStorage.DodavatelGet());
                SetOtevreno(FakturaOpenMode.NovaSPolozkami);
                OpenedFaktura.DPH = Properties.Settings.Default.DefaultDPH / 100f;
                errorProvider.Clear();
            }
            catch (FirmaDontExistsException)
            {
                MessageBox.Show("Nejsou nastaveny informace o dodavateli. nyní se otevře formulář, kam je můžete zadat.");
                nastaveníToolStripMenuItem_Click(null, EventArgs.Empty);
                NovaFaktura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Chyba při vytváření nové faktury");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateControlsByFaktura();
        }


        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Aktualizuje soucty cen polozek na formulari
        /// </summary>
        private void PrepocitejCelkoveCeny()
        {
            celkemEd.Text = OpenedFaktura.CenaCelkem.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
            celkdphEd.Text = OpenedFaktura.CenaDPH.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
            totalEd.Text = OpenedFaktura.CenaCelkemVcetneDPH.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
        }

        private void fakturaGrid_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo mouseGridTest = fakturaGrid.HitTest(e.X, e.Y);
            
            if ((mouseGridTest.Type == DataGridViewHitTestType.Cell) && (e.Button == MouseButtons.Right))
            {
                if (mouseGridTest.RowIndex == 0)
                    posunoutNahoruToolStripMenuItem.Enabled = false;
                else
                    posunoutNahoruToolStripMenuItem.Enabled = true;

                if (mouseGridTest.RowIndex == fakturaGrid.Rows.Count - 1)
                    posunoutDoluToolStripMenuItem.Enabled = false;
                else
                    posunoutDoluToolStripMenuItem.Enabled = true;

                popupGridHit = mouseGridTest;
                polozkaEditMenu.Show((Control)sender, e.Location);
                fakturaGrid.Rows[popupGridHit.RowIndex].Selected = true;
            }

            if ((mouseGridTest.Type == DataGridViewHitTestType.Cell) && (e.Button == MouseButtons.Left))
            {
                // pripravit tazeni
            }
        }

        /// <summary>
        /// Zkopiruje odberatele, popis a misto dodavky z predane faktury
        /// </summary>
        /// <param name="from"></param>
        private void CopyMetadataToOpened(Faktura from)
        {
            OpenedFaktura.OdberatelFaktury = from.OdberatelFaktury;
            OpenedFaktura.PopisDodavky = from.PopisDodavky;
            OpenedFaktura.MistoProvadenychPraci = from.MistoProvadenychPraci;
        }

        private void RaiseOpenForm()
        {
            OpenForm openform = new OpenForm(ActiveStorage);
            DialogResult openResult = openform.ShowDialog();
            if (openResult == DialogResult.OK)
            {
                if (!OpenedFaktura.isEmpty && MessageBox.Show("Uložit současnou fakturu?", "Uložit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!SaveFaktura())
                    {
                        return;
                    }
                }

                try
                {
                    Faktura otevirana = ActiveStorage.FakturaGet(openform.openCislo);
                    switch (openform.openMode)
                    {
                        case FakturaOpenMode.ProUpravu:
                            OpenedFaktura = otevirana;
                            break;
                        case FakturaOpenMode.NovaBezPolozek:
                            NovaFaktura();
                            CopyMetadataToOpened(otevirana);
                            break;
                        case FakturaOpenMode.NovaSPolozkami:
                            NovaFaktura();
                            CopyMetadataToOpened(otevirana);
                            OpenedFaktura.PolozkyNaFakture.AddRange(otevirana.PolozkyNaFakture);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Chyba při otevírání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                SetOtevreno(openform.openMode);
                UpdateControlsByFaktura();
            }
        }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaiseOpenForm();
        }

        /// <summary>
        /// Nacte otevrenou fakturu do prvku formulare
        /// </summary>
        private void UpdateControlsByFaktura()
        {
            this.SuspendLayout();

            // cislo
            CisloEdit.Text = OpenedFaktura.CisloFaktury.GetText();

            // polozky a ceny
            ReloadFakturaGrid();
            PrepocitejCelkoveCeny();
            dphEdit.Text = (OpenedFaktura.DPH*100).ToString("00");

            // popis
            PopisEdit.Text = OpenedFaktura.PopisDodavky;
            textBoxMistoPraci.Text = OpenedFaktura.MistoProvadenychPraci;

            // odberatel
            /*icLab.Text = "IČ: "+OpenedFaktura.OdberatelFaktury.IC;
            dicLabel.Text = "DIČ: "+OpenedFaktura.OdberatelFaktury.DIC;
            if (OpenedFaktura.OdberatelFaktury.Kontakty.Count > 0)
                labelTel.Text = "Tel: " + OpenedFaktura.OdberatelFaktury.Kontakty[0].Text;
            else
                labelTel.Text = "";
            jmenoLab.Text = OpenedFaktura.OdberatelFaktury.Nazev + Environment.NewLine +
                OpenedFaktura.OdberatelFaktury.Adresa + Environment.NewLine +
                OpenedFaktura.OdberatelFaktury.Mesto;
            */
            firmaEditor1.EditedFirma = OpenedFaktura.OdberatelFaktury;

            // platebni podminky
            splatDate.Value = OpenedFaktura.PlatebniPodminkyFaktury.DatumSplatnosti;
            if (OpenedFaktura.PlatebniPodminkyFaktury.DatumVystaveni.Date.Equals(OpenedFaktura.PlatebniPodminkyFaktury.DatumZdPlneni.Date))
            {
                checkBoxZdVystLock.Checked = true;
                vystDate.Value = OpenedFaktura.PlatebniPodminkyFaktury.DatumVystaveni;
                dateZdan.Value = OpenedFaktura.PlatebniPodminkyFaktury.DatumZdPlneni;
            }
            comboBoxUhrada.Text = OpenedFaktura.PlatebniPodminkyFaktury.FormaUhrady;

            //vystDate.MaxDate = OpenedFaktura.PlatebniPodminkyFaktury.DatumSplatnosti;
            //dateZdan.MaxDate = OpenedFaktura.PlatebniPodminkyFaktury.DatumSplatnosti;
            //splatDate.MinDate = OpenedFaktura.PlatebniPodminkyFaktury.DatumVystaveni;

            this.ResumeLayout(); 
        }

        /// <summary>
        /// Upravi radek tabulky faktury podle predane polozky
        /// </summary>
        /// <param name="index">index radku</param>
        /// <param name="polozka">polozka ktera se vlozi</param>
        private void UpdateFakturaGridPolozka(int index, PolozkaFaktury polozka, bool ChangeSelection)
        {
            fakturaGrid.Rows[index].Cells[0].Value = polozka.Typ.Zkratka;
            fakturaGrid.Rows[index].Cells[1].Value = polozka.Nazev;
            fakturaGrid.Rows[index].Cells[2].Value = polozka.Mnozstvi.ToString("0.##" ) + " " + polozka.JednotkaKusu;;
            fakturaGrid.Rows[index].Cells[3].Value = polozka.CenaZaKus.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
            fakturaGrid.Rows[index].Cells[4].Value = polozka.CenaPolozky.ToString("C", CultureInfo.CurrentCulture.NumberFormat);
            if (ChangeSelection)
                fakturaGrid.Rows[index].Selected = true;
        }

        /// <summary>
        /// Nacte tabulku polozek faktury znovu z instance OpenedFaktura
        /// </summary>
        private void ReloadFakturaGrid()
        {
            fakturaGrid.SuspendLayout();

            fakturaGrid.Rows.Clear();
            foreach (PolozkaFaktury polozka in OpenedFaktura.PolozkyNaFakture)
            {
                int index = fakturaGrid.Rows.Add();
                UpdateFakturaGridPolozka(index, polozka, false);
            }

            if (fakturaGrid.Rows.Count > 0)
            {
                fakturaGrid.Rows[fakturaGrid.Rows.Count - 1].Selected = true;

                int halfWay = (fakturaGrid.DisplayedRowCount(false) / 2);
                if (fakturaGrid.FirstDisplayedScrollingRowIndex + halfWay > fakturaGrid.SelectedRows[0].Index ||
                    (fakturaGrid.FirstDisplayedScrollingRowIndex + fakturaGrid.DisplayedRowCount(false) - halfWay) <= fakturaGrid.SelectedRows[0].Index)
                {
                    int targetRow = fakturaGrid.SelectedRows[0].Index;

                    targetRow = Math.Max(targetRow - halfWay, 0);
                    fakturaGrid.FirstDisplayedScrollingRowIndex = targetRow;
                }
            }
            fakturaGrid.ResumeLayout();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OpenedFaktura.isEmpty)
            {
                DialogResult r = MessageBox.Show(
                    "Přejete si před ukončním programu uložit rozpracovanou fakturu?",
                    "Zavřít",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Exclamation);
                switch (r)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        e.Cancel = !SaveFaktura();
                        break;
                }
            }
         
        }

        private void SetOtevreno(FakturaOpenMode mod)
        {
            OpenMode = mod;

            if ((mod == FakturaOpenMode.NovaBezPolozek) || (mod == FakturaOpenMode.NovaSPolozkami))
            {
                CisloEdit.Enabled = true;
            }
            else if (mod == FakturaOpenMode.ProUpravu)
            {
                CisloEdit.Enabled = false;
            }
        }

        private void statistikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*StatisticsForm sf = new StatisticsForm(Faktury);

            sf.ShowDialog();
             */
        }

        private void SmazatPolozku(int index)
        {
            OpenedFaktura.PolozkyNaFakture.RemoveAt(index);
            ReloadFakturaGrid();
            PrepocitejCelkoveCeny();
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmazatPolozku(popupGridHit.RowIndex);
        }


        private void posunoutNahoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // je uz nahore
            if (popupGridHit.RowIndex<= 0) { return; }

            int i = popupGridHit.RowIndex;
            
            PolozkaFaktury temp = OpenedFaktura.PolozkyNaFakture[i-1];
            OpenedFaktura.PolozkyNaFakture[i - 1] = OpenedFaktura.PolozkyNaFakture[i];
            OpenedFaktura.PolozkyNaFakture[i] = temp;

            ReloadFakturaGrid();

            fakturaGrid.Rows[i - 1].Selected = true;
        }

        private void posunoutDoluToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (popupGridHit.RowIndex >= (fakturaGrid.Rows.Count-1)) { return; }

            int i = popupGridHit.RowIndex;

            PolozkaFaktury temp = OpenedFaktura.PolozkyNaFakture[i + 1];
            OpenedFaktura.PolozkyNaFakture[i + 1] = OpenedFaktura.PolozkyNaFakture[i];
            OpenedFaktura.PolozkyNaFakture[i] = temp;

            ReloadFakturaGrid();

            fakturaGrid.Rows[i + 1].Selected = true;
        }

        PolozkaFakturyTyp TypPoslednePridanePolozky;
        Point PozicePoslednihoOtevreniAddOkna;

        private void ButtonAddPolozka_Click(object sender, EventArgs e)
        {
            PolozkaEditor pe = new PolozkaEditor(new PolozkaFaktury("Nová položka"), this.ActiveStorage);
            pe.SelectSpecificTyp(TypPoslednePridanePolozky);
            if (PozicePoslednihoOtevreniAddOkna.IsEmpty == false)
            {
                pe.StartPosition = FormStartPosition.Manual;
                pe.Location = PozicePoslednihoOtevreniAddOkna;
            }
            DialogResult peres = pe.ShowDialog();

            if (peres == DialogResult.OK || peres == DialogResult.Retry)
            {
                OpenedFaktura.PolozkyNaFakture.Add(pe.editedPolozka);
                TypPoslednePridanePolozky = pe.editedPolozka.Typ;
                PozicePoslednihoOtevreniAddOkna = pe.Location;

                ReloadFakturaGrid();
                PrepocitejCelkoveCeny();

                if (peres == DialogResult.Retry)
                {
                    this.ButtonAddPolozka.PerformClick();
                }
            }
        }

        private void fakturaGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (fakturaGrid.SelectedRows.Count > 0)
            {
                buttonChangePolozka.Enabled = true;
                buttonDeletePolozka.Enabled = true;
            }
            else
            {
                buttonChangePolozka.Enabled = false;
                buttonDeletePolozka.Enabled = false;
            }

        }

        private bool TryUpdateDataCislo()
        {
            if (OpenMode == FakturaOpenMode.ProUpravu)
            {
                CisloEdit.Text = OpenedFaktura.CisloFaktury.GetText();
                return true;
            }

            try
            {
                CisloFaktury c = CisloFaktury.ParseToType(ActiveStorage.FakturaCisloType, CisloEdit.Text);
                if (ActiveStorage.FakturaExists(c))
                {
                    throw new Exception("Faktura s tímto číslem již exituje. Pokud ji chcete nahradit, nejprve ji otevřete pro úpravu");
                }
                OpenedFaktura.CisloFaktury = c;
                errorProvider.SetError(CisloEdit, "");
                return true;
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                if (ex.InnerException != null)
                    errorProvider.SetError(CisloEdit, ex.InnerException.Message);
                else
                    errorProvider.SetError(CisloEdit, ex.Message);
            }
            catch (Exception ex)
            {
                errorProvider.SetError(CisloEdit, ex.Message);
            }
            return false;
        }

        private void CisloEdit_Validating(object sender, CancelEventArgs e)
        {
            TryUpdateDataCislo();
        }

        private void buttonDeletePolozka_Click(object sender, EventArgs e)
        {
            if (fakturaGrid.SelectedRows.Count > 0)
            {
                SmazatPolozku(fakturaGrid.SelectedRows[0].Index);
            }
        }

        private void buttonChangePolozka_Click(object sender, EventArgs e)
        {
            if (fakturaGrid.SelectedRows.Count <= 0)
                return;

            int indexPolozky = fakturaGrid.SelectedRows[0].Index;
        }

        private void RaiseChangePolozka(int indexPolozky)
        {
            PolozkaEditor pe = new PolozkaEditor(new PolozkaFaktury(OpenedFaktura.PolozkyNaFakture[indexPolozky]), this.ActiveStorage);
            pe.buttonAddAndAgain.Visible = false;
            pe.buttonAddAndAgain.Enabled = false;
            pe.SelectSpecificTyp(TypPoslednePridanePolozky);

            DialogResult peResult = pe.ShowDialog();

            if (peResult == DialogResult.OK || peResult == DialogResult.Retry)
            {
                OpenedFaktura.PolozkyNaFakture[indexPolozky] = pe.editedPolozka;
                ReloadFakturaGrid();
                PrepocitejCelkoveCeny();
            }

        }

        private void dphEdit_TextChanged(object sender, EventArgs e)
        {
            if (dphEdit.MaskFull)
            {
                dphEdit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                OpenedFaktura.DPH = float.Parse(dphEdit.Text) / 100;
                PrepocitejCelkoveCeny();
            }
        }

        private void změnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RaiseChangePolozka(popupGridHit.RowIndex);
        }

        private bool TryUpdateDataDates()
        {
            OpenedFaktura.PlatebniPodminkyFaktury.DatumZdPlneni = dateZdan.Value;
            OpenedFaktura.PlatebniPodminkyFaktury.DatumVystaveni = vystDate.Value;
            OpenedFaktura.PlatebniPodminkyFaktury.DatumSplatnosti = splatDate.Value;

            if (OpenedFaktura.PlatebniPodminkyFaktury.DatumSplatnosti < OpenedFaktura.PlatebniPodminkyFaktury.DatumVystaveni)
            {
                errorProvider.SetError(splatDate, "Datum splatnosti nesmí být dříve jak datum vystavení");
                return false;
            }
            return true;
        }

        private bool TryUpdateDataPopis()
        {
            OpenedFaktura.PopisDodavky = PopisEdit.Text;
            return true;
        }

        private void PopisEdit_Validating(object sender, CancelEventArgs e)
        {
            TryUpdateDataPopis();
        }

        private bool TryUpdateDataMisto()
        {
            OpenedFaktura.MistoProvadenychPraci = textBoxMistoPraci.Text;
            return true;
        }

        private void textBoxMistoPraci_Validating(object sender, CancelEventArgs e)
        {
            TryUpdateDataMisto();
        }

        private void checkBoxZdVystLock_CheckedChanged(object sender, EventArgs e)
        {
                dateZdan.Enabled = ! checkBoxZdVystLock.Checked;
        }

        private void vystDate_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxZdVystLock.Checked)
            {
                // nastavit zd. pln jako vystaveni
                dateZdan.Value = vystDate.Value;
            }

            OpenedFaktura.PlatebniPodminkyFaktury.DatumVystaveni = vystDate.Value;

            //splatDate.MinDate = vystDate.Value;
        }

        private void dateZdan_ValueChanged(object sender, EventArgs e)
        {
            OpenedFaktura.PlatebniPodminkyFaktury.DatumZdPlneni = dateZdan.Value;
        }

        private void fakturaGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RaiseChangePolozka(e.RowIndex);
        }

        private bool TryUpdateDataUhrada()
        {
            try
            {
                OpenedFaktura.PlatebniPodminkyFaktury.FormaUhrady = comboBoxUhrada.Text;
                errorProvider.SetError(comboBoxUhrada, "");
                return true;
            }
            catch (Exception ex)
            {
                errorProvider.SetError(comboBoxUhrada, ex.Message);
                return false;
            }
        }

        private void comboBoxUhrada_Validating(object sender, CancelEventArgs e)
        {
            TryUpdateDataUhrada();
        }

        /// <summary>
        /// Zkontroluje spravnost dat na formulari a ulozi do faktury
        /// </summary>
        /// <returns></returns>
        private bool UpdateAndValidateOpenFaktura()
        {
            bool ok = true;
            ok = TryUpdateDataCislo() && ok;
            ok = TryUpdateDataDates() && ok;
            ok = TryUpdateDataMisto() && ok;
            ok = TryUpdateDataPopis() && ok;
            ok = TryUpdateDataUhrada() && ok;
            OpenedFaktura.OdberatelFaktury = firmaEditor1.EditedFirma;
            if (OpenedFaktura.OdberatelFaktury.isEmpty)
            {
                errorProvider.SetError(odberatelButton, "Musíte zadat odběratele.");
                ok = false;
            }
            else
            {
                errorProvider.SetError(odberatelButton, "");
            }
            ok = !OpenedFaktura.DodavatelFaktury.isEmpty && ok;

            return ok;
        }

        private bool AllOptionalFilled()
        {
            bool filled = true;
            filled = (OpenedFaktura.MistoProvadenychPraci != string.Empty) && filled;
            filled = (OpenedFaktura.PopisDodavky != string.Empty) && filled;
            filled = (OpenedFaktura.PolozkyNaFakture.Count > 0) && filled;

            return filled;
        }

        /// <summary>
        /// Ulozi data z formulare do Faktury a zkontroluje spravnost
        /// </summary>
        /// <returns></returns>
        private bool UpdateAndUserCheckFaktura()
        {
            if (UpdateAndValidateOpenFaktura())
            {
                if (AllOptionalFilled() == false)
                {
                    if (MessageBox.Show("Nejsou vyplněny některé nepovinné položky (popis, místo, apod.). Přesto chcete pokračovat?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                MessageBox.Show("Zadejte všechny požadované položky, které jsou označené vykřičníkem.", "Neúplné zadání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Ulozi fakturu do StorageEngine
        /// </summary>
        /// <returns>True pri uspechu, False pokud se nepodarilo ulozit</returns>
        private bool SaveFaktura()
        {
            if (UpdateAndUserCheckFaktura())
            {
                try
                {
                    ActiveStorage.FakturaSave(OpenedFaktura);
                    SetOtevreno(FakturaOpenMode.ProUpravu);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Chyba při ukládání", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return false;
        }

        private void uložitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFaktura();
        }

        private void odberatelButton_Click(object sender, EventArgs e)
        {
            OdberatelForm of = new OdberatelForm(new Firma(OpenedFaktura.OdberatelFaktury), this.ActiveStorage);
            DialogResult ofResult = of.ShowDialog();

            if (ofResult == DialogResult.OK)
            {
                OpenedFaktura.OdberatelFaktury = of.EditedOdberatel;
                UpdateControlsByFaktura();
            }
        }

        private void splatDate_ValueChanged(object sender, EventArgs e)
        {
            OpenedFaktura.PlatebniPodminkyFaktury.DatumSplatnosti = splatDate.Value;
            //vystDate.MaxDate = splatDate.Value;
            //dateZdan.MaxDate = splatDate.Value;
        }

        private void HandleNovaFaktura()
        {
            if (!OpenedFaktura.isEmpty && MessageBox.Show("Uložit současnou fakturu?", "Uložit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!SaveFaktura())
                {
                    return;
                }
            }

            NovaFaktura();
            UpdateControlsByFaktura();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            HandleNovaFaktura();
        }

        private void NovyMenu_Click(object sender, EventArgs e)
        {
            HandleNovaFaktura();
        }

        private void statistikaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StatisticsForm statistika = new StatisticsForm(ActiveStorage);
            statistika.ShowDialog();
        }

        private void exportovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if (!DEVEL)
            throw new NotImplementedException();
#else

            SaveFileDialog od = new SaveFileDialog();

            if (od.ShowDialog() == DialogResult.OK)
            {
                Fakturace_2009.Portability.FakturaExporter exporter = new Fakturace_2009.Portability.FakturaExporter(od.FileName);
                exporter.AddFaktura(this.OpenedFaktura);
                exporter.Close();
            }
#endif
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            PrintFaktura();
        }

        private void PrintFaktura()
        {
            if (UpdateAndUserCheckFaktura())
            {
                FakturaPrinter fp = new FakturaPrinter(OpenedFaktura);
                PrintForm f = new PrintForm(fp);
                f.ShowDialog();
            }
        }

        private void tisknoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintFaktura();
        }

        private void nastaveníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(ActiveStorage);
            sf.ShowDialog();
        }

        private void importovatToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if (!DEVEL)
            throw new NotImplementedException();
#endif
        }
   
    }
}