// Faktura.cs created with MonoDevelop
// User: docx at 1:44 23.12.2008
//
// (c) Lukáš Doležal, 2005-2009

using System;
using System.Collections.Generic;
using System.Text;

namespace Fakturace_2009.Backbone
{
	/// <summary>
	/// Zapouzdřuje jednu fakturu
	/// </summary>

    public class Faktura
    {
		private Faktura()
		{
            this.odberatel = new Firma();
            this.PopisDodavky = string.Empty;
            this.MistoProvadenychPraci = string.Empty;
            this.dph = 0;
            this.polozky = new List<PolozkaFaktury>();
			this.platba = new PlatebniPodminky();
		}

        public Faktura(Faktura f)
        {
            this.cislo = (CisloFaktury)f.cislo.Clone();
            this.odberatel = new Firma(f.odberatel);
            this.dodavatel = new Firma(f.dodavatel);
            this.dph = f.dph;
            this.MistoProvadenychPraci = f.MistoProvadenychPraci;
            this.PopisDodavky = f.PopisDodavky;
            this.polozky = new List<PolozkaFaktury>();
            for (int i = 0; i < f.polozky.Count; i++)
            {
                this.polozky.Add(new PolozkaFaktury(f.polozky[i]));
            }
            this.platba  = new PlatebniPodminky(f.PlatebniPodminkyFaktury);
        }

        public Faktura(CisloFaktury cislo, Firma dodavatel) : this()
        {
            if (cislo == null || dodavatel == null)
                throw new ArgumentNullException();

            this.cislo = cislo;
			this.dodavatel = dodavatel;
        }

		public Faktura(CisloFaktury cislo, Firma dodavatel, Firma odberatel, PlatebniPodminky platebni, int dph) : this(cislo,dodavatel)
		{
            if (odberatel == null || platebni == null)
                throw new ArgumentNullException(); 
            
            this.odberatel = odberatel;
			this.platba = platebni;
			this.DPH = dph;
		}

        private Firma dodavatel;
		private Firma odberatel;
        private CisloFaktury cislo;
        private float dph;
        private List<PolozkaFaktury> polozky;
		private PlatebniPodminky platba;

        public static bool allowNegativeTax = true;

        /// <summary>
        /// Popis dodávky
        /// </summary>
        /// <remarks />
		public string PopisDodavky;
        /// <summary>
        /// Misto praci
        /// </summary>
        /// <remarks/>
		public string MistoProvadenychPraci;
		
        /// <summary>
        /// Nastavene DPH pro fakturu, v desetinném číslo (100% = 1.0, 19% = 0.19, ...)
        /// </summary>
        /// <remarks />
        public float DPH
        {
            get { return dph; }
            set
			{
				if (value < 0)
					throw new Exception("DPH nesmí být záporné");
				this.dph = value;
			}
        }

		public Firma DodavatelFaktury
		{
			get { return this.dodavatel; }
            set { if (value == null) throw new NullReferenceException(); this.dodavatel = value; }
        }

        /// <summary>
        /// Odberatel faktury
        /// </summary>
		public Firma OdberatelFaktury
		{
			get { return this.odberatel ; }
            set { if (value == null) throw new NullReferenceException(); this.odberatel = value; }
		}

        public List<PolozkaFaktury> PolozkyNaFakture
		{
			get { return this.polozky; }
		}

		public CisloFaktury CisloFaktury
		{
			get { return this.cislo; }
            set { if (value == null) throw new NullReferenceException(); this.cislo = value; }
		}

        public PlatebniPodminky PlatebniPodminkyFaktury
        {
            get { return this.platba; }
        }

		/// <summary>
		/// Celkova cena faktury bez DPH
		/// </summary>
		/// <returns>
		/// Soucet cen vsech polozek faktury
		/// </returns>
        public decimal CenaCelkem
        {
            get
            {
                decimal celkem = 0;
                PolozkaFaktury[] ps = this.polozky.ToArray();

                for (int i = 0; i < ps.Length; i++)
                {
                    celkem += ps[i].CenaPolozky;
                }

                return celkem;
            }
        }

        public decimal CenaDPH
        {
            get
            {
                decimal d = this.CenaCelkem * (decimal)this.dph;
                if (!allowNegativeTax && d < 0m)
                {
                    return 0m;
                }
                return d;
            }
        }

        /// <summary>
        /// Celkova cena faktury vcetne DPH
        /// </summary>
        /// <returns></returns>
        public decimal CenaCelkemVcetneDPH
        {
            get
            {
                return CenaCelkem + CenaDPH;
            }
        }

        /// <summary>
        /// Vrati sumu polozek urciteho typu
        /// </summary>
        /// <param name="typPolozky">Pozadovany typ polozek</param>
        /// <returns></returns>
        public decimal CenaCelkemTypu(string typPolozky)
        {
            decimal celkem = 0;
            PolozkaFaktury[] ps = this.polozky.ToArray();

            for (int i = 0; i < ps.Length; i++)
            {
                if (ps[i].Typ.Nazev != typPolozky)
                    continue;
                celkem += ps[i].CenaPolozky;
            }

            return celkem;
        }

        /// <summary>
        /// Je faktura prázdná - jako nová. Není opak requiredFilled
        /// </summary>
        public bool isEmpty
        {
            get
            {
                return
                    string.IsNullOrEmpty(MistoProvadenychPraci) &&
                    string.IsNullOrEmpty(PopisDodavky) &&
                    polozky.Count == 0 &&
                    odberatel.isEmpty;
            }
        }

        /// <summary>
        /// Vše potřebné i nepovinné je vyplněno
        /// </summary>
        public bool FullFilled
        {
            get {
                return !this.isEmpty && !this.dodavatel.isEmpty;
            }
        }

        /// <summary>
        /// Vše potřebné je vyplněno, nepovinné nemusí
        /// </summary>
        public bool RequiredFilled
        {
            get
            {
                return !odberatel.isEmpty && !string.IsNullOrEmpty(platba.FormaUhrady) && !dodavatel.isEmpty;                    
            }
        }

        /// <summary>
        /// Vymaze polozky z faktury
        /// </summary>
        public void ClearPolozky()
        {
            this.polozky = new List<PolozkaFaktury>();
        }

        /// <summary>
        /// Vytvori otisk faktury
        /// </summary>
        /// <returns></returns>
        public static explicit operator FakturaFingerprint(Faktura f)
        {
            FakturaFingerprint tempFinger = new FakturaFingerprint();
            tempFinger.cisloFaktury = f.cislo;
            tempFinger.cenaCelkemSDPH = f.CenaCelkemVcetneDPH;
            tempFinger.datumVytvoreni = f.platba.DatumVystaveni;
            tempFinger.mistoPraci = f.MistoProvadenychPraci;
            tempFinger.nazevOdberatele = f.odberatel.Nazev;
            tempFinger.popisFaktury = f.PopisDodavky;

            return tempFinger;
        }

    }
}
