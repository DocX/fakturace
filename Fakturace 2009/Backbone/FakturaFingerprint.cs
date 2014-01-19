using System;
using System.Collections.Generic;
using System.Text;

namespace Fakturace_2009.Backbone
{
    /// <summary>
    /// Souhrné informace o faktuře, použití pro seznam a index faktur
    /// </summary>
    public class FakturaFingerprint : IComparable<FakturaFingerprint>
    {
        public CisloFaktury cisloFaktury;
        public decimal cenaCelkemSDPH;
        public string nazevOdberatele;
        public string mistoPraci;
        public string popisFaktury;
        public DateTime datumVytvoreni;
        public DateTime datumSplaceni;

        public FakturaFingerprint()
        {
            this.mistoPraci = "";
            this.popisFaktury = "";
        }

        public FakturaFingerprint(FakturaFingerprint f) : this()
        {
            this.cisloFaktury = f.cisloFaktury.Clone() as CisloFaktury;
            this.cenaCelkemSDPH = f.cenaCelkemSDPH;
            this.datumVytvoreni = f.datumVytvoreni;
            this.mistoPraci = f.mistoPraci;
            this.popisFaktury = f.popisFaktury;
            this.nazevOdberatele = f.nazevOdberatele;
            this.datumSplaceni = f.datumSplaceni;
        }

        #region IComparable<FakturaFingerprint> Members

        public int CompareTo(FakturaFingerprint other)
        {
            return this.cisloFaktury.CompareTo(other.cisloFaktury);
        }

        #endregion

    }
}
