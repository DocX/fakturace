using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;

namespace Fakturace_2009.UserSpecifics
{
    public class CisloPoradiRok : CisloFaktury
    {
        public CisloPoradiRok(int poradi, int rok)
        {
            Poradi = poradi;
            Rok = rok;
        }

        public CisloPoradiRok()
        {
            this.poradi = 1;
            this.rok = DateTime.Now.Year;
        }

        public CisloPoradiRok(string CisloText)
        {
            if (CisloText.Length != 8)
                throw new InvalidCastException("Číslo musí být 8 znaků dlouhé");

            string p, r;
            int pomlcka = CisloText.IndexOf("-");

            if (pomlcka < 0)
                throw new InvalidCastException("Číslo musí obsahovat pomlčku");

            p = CisloText.Substring(0, pomlcka);
            r = CisloText.Substring(pomlcka + 1, 4);

            this.poradi = int.Parse(p);

            if (poradi <= 0)
                throw new InvalidCastException("Pořadí musí být vetší jak 0");

            this.rok = int.Parse(r) ;
        }

        public int Poradi
        {
            get { return poradi; }
            set { if (value <= 0)throw new InvalidCastException("Pořadí musí být vetší jak 0"); poradi = value; }
        }

        public int Rok
        {
            get { return rok; }
            set { if (value <= 0)throw new InvalidCastException("Rok musí být vetší jak 0"); rok = value; }
        }

        
        public override string GetText()
        {
            return poradi.ToString("000") + "-" + rok.ToString("0000");
        }

        public override CisloFaktury GetNext()
        {
            int dnesniRok = DateTime.Now.Year;
            if (dnesniRok > this.rok)
            {
                return new CisloPoradiRok(1, dnesniRok);
            }
            else
            {
                return new CisloPoradiRok(this.poradi + 1, this.rok);
            }
        }

        public override string GetPrintableText()
        {
            return poradi.ToString() + "-" + rok.ToString("0000");
        }

        public static new string GetTextMask()
        {
            return "000-0000";
        }

        private int rok;
        private int poradi;

        #region IComparable Members

        /// <summary>
        /// Porovnani dvou cisel sestupne.
        /// </summary>
        /// <param name="obj">Druhe cislo</param>
        /// <returns>-1 pokud je prvni cislo mensi, 0 stejne, 1 pokud je prvni vetsi</returns>
        public override int CompareTo(CisloFaktury obj)
        {
            if (this.rok == (obj as CisloPoradiRok).rok)
            {
                return this.poradi.CompareTo((obj as CisloPoradiRok).poradi);
            }
            else
            {
                return this.rok.CompareTo((obj as CisloPoradiRok).rok);
            }
        }

        #endregion

        public override object Clone()
        {
            return new CisloPoradiRok(this.poradi, this.rok);
        }

        public override bool Equals(CisloFaktury other)
        {
            return (other.GetType() == typeof(CisloPoradiRok)) && (other as CisloPoradiRok).rok == this.rok && (other as CisloPoradiRok).poradi == this.poradi;
        }

         public override int GetHashCode()
        {
            return poradi * 1000 + rok;
        }
    }
}
