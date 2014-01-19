using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;
using System.Drawing.Printing;
using System.Drawing;

namespace Fakturace_2009.GUI
{
    class FakturaPrinter : PrintDocument
    {
        Faktura faktura;
        FontFamily font, fontPolozek;

        public FakturaPrinter(Faktura faktura) : base()
        {
            if (faktura == null)
                throw new NullReferenceException();

            this.faktura = faktura;
            this.DocumentName = "Faktura č. " + faktura.CisloFaktury.GetPrintableText();
            try
            {
                fontPolozek = font = new FontFamily("Calibri");
            }
            catch
            {
                fontPolozek = font = FontFamily.GenericSansSerif;
            }
        }

        public Faktura PrintedFaktura
        {
            get { return faktura; }
            set
            {
                if (value == null)
                    throw new NullReferenceException();

                this.faktura = value;
            }
        }

        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);

        }

        protected override void OnEndPrint(PrintEventArgs e)
        {
            base.OnEndPrint(e);

        }

        private float UnitsFromMM(float mm)
        {
            return (mm / 25.4f) * 100f;
        }

        private float DrawTextWithTitle(string title, string text, Graphics g, Brush barvaPisma, float textBoxWidth)
        {
            float top = 0;
            float odsazeni = UnitsFromMM(3);
            Font pismoFont = new Font(font, 10.5f);

            g.DrawString(title, new Font(font, 10f, FontStyle.Italic), barvaPisma, 0, top);
            top += pismoFont.GetHeight(g);

            if (text != "")
            {
                textBoxWidth -= odsazeni;
                RectangleF textRect = new RectangleF();
                textRect.Location = new PointF(odsazeni, top);
                textRect.Width = textBoxWidth;
                textRect.Height = 500f;
                g.DrawString(text, pismoFont, barvaPisma, textRect);
                top += g.MeasureString(text, pismoFont, new SizeF(textBoxWidth, float.PositiveInfinity)).Height;

                return top + UnitsFromMM(3);
            }

            return top;
        }

        private float DrawPlatPodminky(PlatebniPodminky podminky, Graphics g, Brush barvaPisma)
        {
            float odsazeni = UnitsFromMM(3);
            float top = 0;

            float vyskaRadku = pismoFont.GetHeight(g) + UnitsFromMM(1);
            float sloupec = g.MeasureString("Datum uskut. zd. plnění:.....", pismoFont).Width;
            top += DrawTextWithTitle("Platební podmínky", "", g, barvaPisma, 50f);

            g.DrawString("Datum vystavení:", pismoFont, barvaPisma, odsazeni, top);
            g.DrawString(faktura.PlatebniPodminkyFaktury.DatumVystaveni.ToShortDateString(), pismoFont, barvaPisma, odsazeni + sloupec, top);
            top += vyskaRadku;

            g.DrawString("Datum uskut. zd. plnění:", pismoFont, barvaPisma, odsazeni, top);
            g.DrawString(faktura.PlatebniPodminkyFaktury.DatumZdPlneni.ToShortDateString(), pismoFont, barvaPisma, odsazeni + sloupec, top);
            top += vyskaRadku;

            g.DrawString("Datum splatnosti:", boldFont, barvaPisma, odsazeni, top);
            g.DrawString(faktura.PlatebniPodminkyFaktury.DatumSplatnosti.ToShortDateString(), boldFont, barvaPisma, odsazeni + sloupec, top);
            top += vyskaRadku;

            g.DrawString("Způsob platby:", boldFont, barvaPisma, odsazeni, top);
            g.DrawString(faktura.PlatebniPodminkyFaktury.FormaUhrady, boldFont, barvaPisma, odsazeni + sloupec, top);
            top += vyskaRadku + UnitsFromMM(3);

            return top;

        }

        private float MeasureFirmaHeight(Firma firma, Graphics g)
        {
            float top = 0;
            float odsazeni = UnitsFromMM(3);
            Font pismoFont = new Font(font, 10.5f);

            top += pismoFont.GetHeight(g);

            float vyskaRadku = pismoFont.GetHeight(g) + UnitsFromMM(1);

            top += 3 * vyskaRadku;

            if (firma.Kontakty.Count > 0 || firma.Ucty.Count > 0)
                top += UnitsFromMM(3);

            top += (firma.Kontakty.Count + firma.Ucty.Count) * vyskaRadku + UnitsFromMM(3);


            top += (firma.DIC != "" || firma.IC != "" ? UnitsFromMM(2) : 0) + (firma.DIC != "" ? vyskaRadku : 0) + (firma.IC != "" ? vyskaRadku : 0);

            return top;
        }

        private float DrawFirma(Firma firma, Brush barvaPisma, Graphics g, String title)
        {
            float top = 0;
            float odsazeni = UnitsFromMM(3);
            
            Font pismoFont = new Font(font, 10.5f);
            Font boldFont = new Font(pismoFont, FontStyle.Bold);

            g.DrawString(title,  new Font(font,10f,FontStyle.Italic), barvaPisma, 0,top);
            top += pismoFont.GetHeight(g);
            
            float vyskaRadku = pismoFont.GetHeight(g) + UnitsFromMM(1);

            // nazev
            g.DrawString(firma.Nazev, boldFont, barvaPisma, odsazeni, top);
            top += vyskaRadku;

            // ulice
            g.DrawString(firma.Adresa, boldFont, barvaPisma, odsazeni, top);
            top += vyskaRadku;

            // mesto
            g.DrawString(firma.Mesto, boldFont, barvaPisma, odsazeni, top);
            top += vyskaRadku;

            float sloupec = g.MeasureString("ABRAKADABRA", pismoFont).Width;

            if (firma.DIC != "" || firma.IC != "")
            {
                top += UnitsFromMM(2);
            }


            // IC
            if (firma.IC != "")
            {
                g.DrawString("IČ:", pismoFont, barvaPisma, odsazeni, top);
                g.DrawString(firma.IC, pismoFont, barvaPisma, odsazeni + sloupec, top);
                top += vyskaRadku;
            }

            // DIC
            if (firma.DIC != "")
            {
                g.DrawString("DIČ:", pismoFont, barvaPisma, odsazeni, top);
                g.DrawString(firma.DIC, pismoFont, barvaPisma, odsazeni + sloupec, top);
                top += vyskaRadku;
            }

            // odsazeni
            if (firma.Kontakty.Count > 0 || firma.Ucty.Count > 0)
                top += UnitsFromMM(3);


            // kontakty
            foreach (Firma.FirmaDetails k in firma.Kontakty)
            {
                g.DrawString(k.Label, pismoFont, barvaPisma, odsazeni, top);
                g.DrawString(k.Text, pismoFont, barvaPisma, odsazeni + sloupec, top);
                top += vyskaRadku;
            }

            // ucty
            foreach (Firma.FirmaDetails k in firma.Ucty)
            {
                g.DrawString(k.Label, pismoFont, barvaPisma, odsazeni, top);
                g.DrawString(k.Text, boldFont, barvaPisma, odsazeni + sloupec, top);
                top += vyskaRadku;
            }

            return top + UnitsFromMM(3);
        }

        private void printRightBottom(string text, Font pismo, Graphics g)
        {
            SizeF vel = g.MeasureString(text, pismo);
            g.DrawString(text, pismo, Brushes.Black, - vel.Width, -vel.Height);
        }

        private void printRightTop(string text, Font pismo, Graphics g)
        {
            SizeF vel = g.MeasureString(text, pismo);
            g.DrawString(text, pismo, Brushes.Black, -vel.Width, 0);
        }

        private void DrawPolozkyHeader(Graphics g, Rectangle margin, Font polozkaPismo)
        {
            float cenaRadkuRight = margin.Width + 0f;
            float mnozstviRight = margin.Width - 130f;
            float cenaJednRight = margin.Width - 190f;
            float vyska = polozkaPismo.GetHeight(g) ;

            // nazev polozky
            string nazev = "Položka";
            float sirkaNazev = margin.Width - 320f;
            g.DrawString(nazev, polozkaPismo, Brushes.Black, 0,0);

            Pen prepazka = new Pen(ohraniceni.Brush, ohraniceni.Width*(2f/5f));


            // nahore
            g.DrawLine(prepazka, 0, -UnitsFromMM(0.5f), margin.Width, -UnitsFromMM(0.5f));

            // levy okraj
            g.DrawLine(prepazka, 0, -UnitsFromMM(0.5f), 0, vyska + UnitsFromMM(1));

            // pravy okraj
            g.DrawLine(prepazka, margin.Width, -UnitsFromMM(0.5f), margin.Width, vyska + UnitsFromMM(1));

            //ohraniceni pravo vedle nazvu
            g.DrawLine(prepazka, sirkaNazev + UnitsFromMM(0.5f), -UnitsFromMM(0.5f), sirkaNazev + UnitsFromMM(0.5f), vyska + UnitsFromMM(1));

            // ohraniceni pod
            g.DrawLine(ohraniceni, 0, vyska + UnitsFromMM(0.5f), margin.Width, vyska + UnitsFromMM(0.5f));

           // g.TranslateTransform(0, vyska);

            // cena radku
            g.TranslateTransform(cenaRadkuRight, 0);
            printRightTop("Cena řádku (Kč)", polozkaPismo, g);


            // mnozstvi
            g.TranslateTransform(mnozstviRight -cenaRadkuRight, 0);
            g.DrawLine(prepazka, UnitsFromMM(0.5f),  - UnitsFromMM(0.5f), UnitsFromMM(0.5f), vyska + UnitsFromMM(1));
            printRightTop("Množ.", polozkaPismo, g);


            // cena jednotky
            g.TranslateTransform(cenaJednRight-mnozstviRight, 0);
            g.DrawLine(prepazka, UnitsFromMM(0.5f), -UnitsFromMM(0.5f), UnitsFromMM(0.5f), vyska + UnitsFromMM(1));
            printRightTop("Jedn. cena (Kč)", polozkaPismo, g);
            g.TranslateTransform(-cenaJednRight, 0);

            g.TranslateTransform(0, vyska + UnitsFromMM(1));
        }

        private float DrawPolozkaRadek(PolozkaFaktury p, Graphics g, Rectangle margin, bool translateGraphics, bool drawTopBorder)
        {
            Font polozkaPismo = new Font(this.fontPolozek, 10f);
            //Brush pismoBrush = new SolidBrush(Color.Black);

            float cenaRadkuRight = margin.Width + 0f;
            float mnozstviRight = margin.Width - 130f;
            float cenaJednRight = margin.Width - 190f;
            float vyska;

            // nazev polozky
            string nazev = p.Typ.Zkratka + " " + p.Nazev;
            float sirkaNazev = margin.Width - 320f;
            vyska = g.MeasureString(nazev, polozkaPismo, (int)sirkaNazev).Height;


            Pen prepazka = new Pen(ohraniceni.Brush, ohraniceni.Width*(2f/5f));

            g.DrawString(nazev, polozkaPismo, Brushes.Black, new RectangleF(0, 0, sirkaNazev, 100f));

            //ohraniceni pravo vedle nazvu
            g.DrawLine(prepazka, sirkaNazev + UnitsFromMM(0.5f), 0, sirkaNazev + UnitsFromMM(0.5f), vyska + UnitsFromMM(1));
            
            // levy okraj
            g.DrawLine(ohraniceni, 0, 0, 0, vyska + UnitsFromMM(1));

            // pravy okraj
            g.DrawLine(ohraniceni, margin.Width, 0, margin.Width, vyska + UnitsFromMM(1));

            // ohraniceni nad
            if (drawTopBorder)
            {
                prepazka.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                prepazka.DashPattern = new float[] { 5f, 5f };
                g.DrawLine(prepazka, 0, UnitsFromMM(-0.5f), margin.Width, UnitsFromMM(-0.5f));
                prepazka.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }

            g.TranslateTransform(0, vyska);

            // cena radku
            g.TranslateTransform(cenaRadkuRight, 0);
            printRightBottom(p.CenaPolozky.ToString("N"), polozkaPismo, g);
            g.TranslateTransform(-cenaRadkuRight, 0);


            // mnozstvi
            g.TranslateTransform(mnozstviRight, 0);
            g.DrawLine(prepazka, UnitsFromMM(0.5f), -vyska, UnitsFromMM(0.5f), UnitsFromMM(1));
            printRightBottom(p.Mnozstvi.ToString("0.##") + (p.JednotkaKusu != "" ? " " : "") + p.JednotkaKusu, polozkaPismo, g);
            g.TranslateTransform(-mnozstviRight, 0);

            // cena jednotky
            g.TranslateTransform(cenaJednRight, 0);
            g.DrawLine(prepazka, UnitsFromMM(0.5f), -vyska, UnitsFromMM(0.5f), UnitsFromMM(1));
            printRightBottom(p.CenaZaKus.ToString("N"), polozkaPismo, g);
            g.TranslateTransform(-cenaJednRight, 0);


            if (!translateGraphics)
                g.TranslateTransform(0, -vyska);

            return vyska ;
        }

        private Font pismoFont, boldFont;

        private Pen ohraniceni;

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);

            Graphics page = e.Graphics;

            //e.PageSettings.PrintableArea 

            Font hlavickaFirma = new Font(font, 15f);
            Font hlavickaCislo = new Font(font, 14f);

            SolidBrush barvaPisma = new SolidBrush(Color.Black);
            ohraniceni = new Pen(barvaPisma, 1f);
            pismoFont = new Font(font, 10.5f);
            boldFont = new Font(pismoFont, FontStyle.Bold);


            float nextTop = e.MarginBounds.Top;

            // hlavicka nazev firmy
            page.DrawString(faktura.DodavatelFaktury.Nazev, hlavickaFirma, barvaPisma, e.MarginBounds.Left, nextTop);

            // hlavicka cislo
            string cisloText = "Faktura - Daňový doklad č.: " + faktura.CisloFaktury.GetPrintableText();
            SizeF cisloSize = page.MeasureString(cisloText, hlavickaCislo);
            page.DrawString(cisloText, hlavickaCislo, barvaPisma, e.MarginBounds.Right - cisloSize.Width, nextTop);

            nextTop += hlavickaFirma.GetHeight(page);

            // ohraniceni
            page.DrawLine(ohraniceni, e.MarginBounds.Left, nextTop, e.MarginBounds.Right, nextTop);
            nextTop += ohraniceni.Width + UnitsFromMM(5);

            float firstW, secondW;
            // dodavatel
            page.TranslateTransform(e.MarginBounds.Left, nextTop);
            firstW = DrawFirma(faktura.DodavatelFaktury, barvaPisma, page, "Dodavatel");
            page.ResetTransform();

            // oderatel
            page.TranslateTransform(e.MarginBounds.Left + e.MarginBounds.Width / 2, nextTop);
            secondW = MeasureFirmaHeight(faktura.OdberatelFaktury, page);

            RectangleF odberatelRect = new RectangleF(0f, 0f, e.MarginBounds.Width / 2, secondW - UnitsFromMM(3));
            page.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), odberatelRect);
            page.DrawRectangle(new Pen(Color.Gray), odberatelRect.Left, odberatelRect.Top, odberatelRect.Width, odberatelRect.Height);

            DrawFirma(faktura.OdberatelFaktury, barvaPisma, page, "Odběratel");

            page.ResetTransform();

            // platebni podminky
            page.TranslateTransform(e.MarginBounds.Left + e.MarginBounds.Width / 2, nextTop + secondW);
            secondW += DrawPlatPodminky(faktura.PlatebniPodminkyFaktury, page, barvaPisma);
            page.ResetTransform();

            nextTop += Math.Max(firstW, secondW);


            // ohraniceni
            //page.DrawLine(ohraniceni, e.MarginBounds.Left, nextTop, e.MarginBounds.Right, nextTop);
            nextTop += ohraniceni.Width + UnitsFromMM(1);


            // popis praci
            page.TranslateTransform(e.MarginBounds.Left, nextTop);
            firstW = DrawTextWithTitle("Popis dodávky", faktura.PopisDodavky, page, barvaPisma, e.MarginBounds.Width / 2);
            page.ResetTransform();

            // misto praci
            page.TranslateTransform(e.MarginBounds.Left + e.MarginBounds.Width / 2, nextTop);
            secondW = DrawTextWithTitle("Místo prací", faktura.MistoProvadenychPraci, page, barvaPisma, e.MarginBounds.Width / 2);

            nextTop += Math.Max(firstW, secondW);
            page.ResetTransform();

            // ohraniceni
            //page.DrawLine(ohraniceni, e.MarginBounds.Left, nextTop, e.MarginBounds.Right, nextTop);
            nextTop += ohraniceni.Width + UnitsFromMM(2);


            // polozky
            page.TranslateTransform(e.MarginBounds.Left, nextTop);
            DrawPolozkyHeader(page,e.MarginBounds,new Font(font,10f, FontStyle.Italic));

            bool sudy = false;
            foreach (PolozkaFaktury p in faktura.PolozkyNaFakture)
            {
                float vyskaPolozky = DrawPolozkaRadek(p, page, e.MarginBounds, true, sudy);
                sudy = true;
                page.TranslateTransform(0, UnitsFromMM(1));
            }

            // ohraniceni
            page.DrawLine(ohraniceni, 0, 0, e.MarginBounds.Width, 0);
            page.TranslateTransform(0, UnitsFromMM(5));

            // sumar cen
            float leftCena = e.MarginBounds.Width / 2;
            float rightCena = e.MarginBounds.Width;
            float stred =  leftCena + UnitsFromMM(1.5f);
            float right = rightCena - UnitsFromMM(1.5f);


            // celkem bez DPH
            page.DrawString("Cena celkem bez DPH " + (faktura.DPH * 100).ToString() + "%", pismoFont, barvaPisma, stred, 0);
            page.TranslateTransform(right, 0);
            printRightTop(faktura.CenaCelkem.ToString("C"), pismoFont, page);
            page.TranslateTransform(-right, pismoFont.GetHeight(page));

            // celkem DPH
            page.DrawString("DPH " + (faktura.DPH * 100).ToString() + "%", pismoFont, barvaPisma, stred, 0);
            page.TranslateTransform(right, 0);
            printRightTop(faktura.CenaDPH.ToString("C"), pismoFont, page);
            page.TranslateTransform(-right, pismoFont.GetHeight(page)+UnitsFromMM(2));

            // celkem vcetne DPH
            page.FillRectangle(new SolidBrush(Color.FromArgb(240,240,240)), leftCena, -UnitsFromMM(1), rightCena - leftCena, boldFont.GetHeight(page) + UnitsFromMM(2.5f));
            page.DrawString("Cena celkem s DPH " + (faktura.DPH * 100).ToString() + "%", boldFont, barvaPisma, stred, 0);
            page.TranslateTransform(right, 0);
            printRightTop(faktura.CenaCelkemVcetneDPH.ToString("C"), boldFont, page);
            page.TranslateTransform(-right, 0);

            // oramovani
            page.DrawRectangle(new Pen(Color.Black, 2f), leftCena, -(pismoFont.GetHeight(page) * 2 + UnitsFromMM(3.5f)), rightCena - leftCena, pismoFont.GetHeight(page) * 3 + UnitsFromMM(5));

            page.ResetTransform();

        }
    }
}
