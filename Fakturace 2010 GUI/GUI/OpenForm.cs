using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using Fakturace_2009;
using Fakturace_2009.StorageEngines;
using Fakturace_2009.Backbone;

namespace Fakturace_2009.GUI
{
    public partial class OpenForm : Form
    {
        public OpenForm(FakturaceStorage storage)
        {
            InitializeComponent();
            this.storage = storage;
            UpdateFromStorage();
        }

        private FakturaceStorage storage;

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics gr = e.Graphics;

            if (e.Index > -1)
            {
                FakturaFingerprint f = (FakturaFingerprint)seznamBox.Items[e.Index];


                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    gr.FillRectangle(new LinearGradientBrush(e.Bounds, Color.AliceBlue, Color.LightSteelBlue, 90f), e.Bounds);
                }
                else
                {
                    e.DrawBackground();
                }

                Pen pn = new Pen(Color.FromKnownColor(KnownColor.ControlDark));
                pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                gr.DrawLine(pn, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                pn.Dispose();

                /* cislo faktury */
                gr.DrawString(f.cisloFaktury.GetPrintableText(), new Font(e.Font.FontFamily, 14, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), 5, e.Bounds.Top);

                Font font = new Font(e.Font.FontFamily, 13.5f, FontStyle.Regular, GraphicsUnit.Pixel);

                /* odberatel jmeno a misto */
                gr.DrawString(f.nazevOdberatele, font, new SolidBrush(Color.SaddleBrown), 5, 18 + e.Bounds.Top);
                gr.DrawString(
                    (f.mistoPraci.Length > 55) ? f.mistoPraci.Replace(Environment.NewLine, ", ").Substring(0, 55) + "..." : f.mistoPraci.Replace(Environment.NewLine, ", "),
                    font, new SolidBrush(Color.Chocolate), 5, 37 + e.Bounds.Top);

                /* datum vystaveni */
                string datvyt = f.datumVytvoreni.ToShortDateString();
                gr.DrawString(datvyt, font, new SolidBrush(Color.DimGray), e.Bounds.Right - TextRenderer.MeasureText(datvyt, font).Width - 5, e.Bounds.Top);
            }
            else
            {
                e.DrawBackground();
                gr.DrawString("Není k dispozici žádná faktura", new Font(e.Font.FontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Black),
                    (e.Bounds.Width / 2) - TextRenderer.MeasureText("Není k dispozici žádná faktura", new Font(e.Font.FontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel)).Width / 2, e.Bounds.Height / 2 - 6);
            }
        }

        public FakturaOpenMode openMode;
        public CisloFaktury openCislo;
        private List<FakturaFingerprint> otiskyFaktur;

        private void UpdateFromStorage()
        {
            this.SuspendLayout();
            otiskyFaktur = storage.FakturaGetFprints();
            otiskyFaktur.Reverse();
            seznamBox.Items.Clear();
            foreach (var item in otiskyFaktur)
            {
                seznamBox.Items.Add(item);
            }
            this.ResumeLayout();
            hledaniBox.Text = "";
            pocetLab.Text = "Celkem " + seznamBox.Items.Count.ToString() + " faktur";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OtevritVyber.Show((Control)sender, new Point(0, 0), ToolStripDropDownDirection.AboveRight);
        }

        bool vyhledavaniAktivni = false;

        bool VyhledavanaFaktura(FakturaFingerprint f)
        {
            string s = hledaniBox.Text.ToLower();

            return (
                string.IsNullOrEmpty(s) || 
                f.nazevOdberatele.ToLower().Contains(s) ||
                f.mistoPraci.ToLower().Contains(s) ||
                f.cisloFaktury.GetText().ToLower().Contains(s) ||
                f.popisFaktury.ToLower().Contains(s)
                );
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (vyhledavaniAktivni)
            {
                seznamBox.Items.Clear();

                seznamBox.Items.AddRange(otiskyFaktur.FindAll(VyhledavanaFaktura).ToArray());

                pocetLab.Text = "Nalezeno " + seznamBox.Items.Count.ToString() + " faktur";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (vyhledavaniAktivni == false)
            {
                hledaniBox.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                hledaniBox.Text = string.Empty;
                vyhledavaniAktivni = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (vyhledavaniAktivni == true)
            {
                if (hledaniBox.Text == string.Empty)
                {
                    vyhledavaniAktivni = false;
                    hledaniBox.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
                    hledaniBox.Text = "Vyhledat...";
                    pocetLab.Text = "Celkem " + seznamBox.Items.Count.ToString() + " faktur";
                }
            }
        }

        private void seznamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            proupravuBtn.Enabled = (seznamBox.SelectedIndex >= 0);
            smazatButton.Enabled = (seznamBox.SelectedIndex >= 0);

            if (seznamBox.SelectedIndex >= 0)
            {
                // vyplnit popis apod.
                FakturaFingerprint f = (FakturaFingerprint)seznamBox.SelectedItem;
                popisLab.Text = (f.popisFaktury.Length > 55) ? f.popisFaktury.Substring(0, 55) + "..." : f.popisFaktury;
                celkemLab.Text = f.cenaCelkemSDPH.ToString("C");
            }
        }

        private void jakoNovouSPoložkamiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seznamBox.SelectedIndex >= 0)
            {
                openMode = FakturaOpenMode.NovaSPolozkami;
                openCislo = ((FakturaFingerprint)seznamBox.SelectedItem).cisloFaktury;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void jakoNovouBezPoložekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seznamBox.SelectedIndex >= 0)
            {
                openMode = FakturaOpenMode.NovaBezPolozek;
                openCislo = ((FakturaFingerprint)seznamBox.SelectedItem).cisloFaktury;
                this.DialogResult = DialogResult.OK;
            }

        }

        private void proÚpravuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seznamBox.SelectedIndex >= 0)
            {
                openMode = FakturaOpenMode.ProUpravu;
                openCislo = ((FakturaFingerprint)seznamBox.SelectedItem).cisloFaktury;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void seznamBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (seznamBox.IndexFromPoint(e.Location) >= 0))
            {
                OtevritVyber.Show((Control)sender, e.Location);
            }
        }

        private void smazatButton_Click(object sender, EventArgs e)
        {
            FakturaFingerprint f = seznamBox.SelectedItem as FakturaFingerprint;

            DialogResult r = MessageBox.Show(string.Format("Opravdu chcete smazat fakturu è. {0} ?",f.cisloFaktury.GetText()), "Potvrïte smazání", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (r == DialogResult.Yes)
            {
                try
                {
                    storage.FakturaDelete(f.cisloFaktury);
                    UpdateFromStorage();
                    MessageBox.Show("Faktura byla úspìšne smazána", "Smazáno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}