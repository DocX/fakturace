// DetailyFaktury.cs created with MonoDevelop
// User: docx at 1:30 23.12.2008
//
// (c) Lukáš Doležal, 2005-2009

using System;
using System.Collections.Generic;

namespace Fakturace_2009.Backbone 
{
	/// <summary>
	/// Reprezentuje kontaktni informace firmy (odberatele nebo dodavatele)
	/// </summary>
    /// <remarks />
    [System.Xml.Serialization.XmlType("Firma", Namespace="fakturace2009:Backbone")]
	public class Firma
	{
        /// <summary>
        /// Nazev firmy
        /// </summary>
        /// <remarks />
        public string Nazev;

        /// <summary>
        /// Adresa sidla firmy
        /// </summary>
        /// <remarks />
        public string Adresa;

        /// <summary>
        /// Mesto adresy
        /// </summary>
        /// <remarks/>
        public string Mesto;

        /// <summary>
        /// IC firmy
        /// </summary>
        /// <remarks/>
        public string IC;
        public string DIC;

        /// <summary>
        /// Vytvori prazdnou firmu bez udaju.
        /// </summary>
        public Firma()
        {
            kontakty = new List<FirmaDetails>();
            ucty = new List<FirmaDetails>();
            this.Nazev = "";
            this.Adresa = "";
            this.Mesto = "";
            this.IC = "";
            this.DIC = "";
        }

        /// <summary>
        /// Kopirovaci konstruktor
        /// </summary>
        /// <param name="toCopy">Firma ktera se zkopiruje do nove instance</param>
        public Firma(Firma toCopy) : this(toCopy.Nazev, toCopy.Adresa, toCopy.Mesto, toCopy.IC, toCopy.DIC)
        {
            foreach (FirmaDetails item in toCopy.ucty)
            {
                this.ucty.Add(new FirmaDetails(item));   
            }
            foreach (FirmaDetails item in toCopy.kontakty )
            {
                this.kontakty.Add(new FirmaDetails(item));
            }
        }

        /// <summary>
        /// Vytvori instanci firmy podle predanych udaju
        /// </summary>
        /// <param name="nazev">
        /// Název firmy
        /// </param>
        /// <param name="adresa">
        /// Adresa firmy
        /// </param>
        /// <param name="mesto">
        /// Mesto
        /// </param>
        /// <param name="ic">
        /// IC firmy, je-li k dispozici
        /// </param>
        /// <param name="dic">
        /// DIC firmy, je-li k dispozici
        /// </param>
        public Firma(string nazev, string adresa, string mesto, string ic, string dic)
            : this()
        {
            this.Nazev = nazev;
            this.Adresa = adresa;
            this.Mesto = mesto;
            this.IC = ic;
            this.DIC = dic;
        }

        private List<FirmaDetails> kontakty; 
        private List<FirmaDetails> ucty;

        /// <summary>
        /// Seznam bankovnich spojeni, ruzne banky apod.
        /// </summary>
        public List<FirmaDetails> Ucty
        {
            get { return this.ucty; }
        }

        /// <summary>
        /// Seznam doplnujicich kontaktnich udaju jako telefony, email, www
        /// </summary>
        public List<FirmaDetails> Kontakty
        {
            get { return this.kontakty; }
        }

		/// <summary>
		/// Predstavuje dvojici popis-hodnota pro mnohonasobne udaje firmy jako ucty
		/// </summary>
	    public class FirmaDetails 
	    {
	        private string label;

            /// <summary>
            /// Popisuje vyznam obsahu Text (np. Ucet u KB, Pevny tel, Email,...)
            /// </summary>
            public string Label
            {
                get { return label; }
                set { label = value; }
            }
			
	        private string text;

            /// <summary>
            /// Hodnota (cislo uctu nebo telefon)
            /// </summary>
            public string Text
            {
                get { return text; }
                set { text = value; }
            }

            public FirmaDetails() : this("", "") { }

            public FirmaDetails(FirmaDetails f) : this(f.label, f.text) { }

            public FirmaDetails(string label, string text)
            {
                this.label = label;
                this.text = text;
            }
	    }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", this.Nazev, this.Adresa, this.Mesto);
        }

        public bool isEmpty
        {
            get { return string.IsNullOrEmpty(Nazev) && string.IsNullOrEmpty(Adresa) && string.IsNullOrEmpty(Mesto); }
        }
    }
	
	/// <summary>
	/// Reprezentuje platebni podminky pro fakturu
	/// </summary>
	public class PlatebniPodminky
	{
		/// <summary>
		/// Forma úhrady faktury (hotove, prevod, apod)
		/// </summary>
		private string forma;
		
		/// <summary>
		/// Datum splatnosti faktury
		/// </summary>
		public DateTime DatumSplatnosti;
		
		/// <summary>
		/// Datum vystavení faktury
		/// </summary>
		public DateTime DatumVystaveni;
		
		/// <summary>
		/// Datum zdanitelneho plneni, vetsinou stejne jako vystaveni
		/// </summary>
		public DateTime DatumZdPlneni;

        public string FormaUhrady
        {
            get { return this.forma; }
            set { if (value == string.Empty) throw new Exception("Nesmí být prázdný"); this.forma = value; }
        }

		/// <summary>
		/// Vytvori standartni nové podmínky, datum zd. pl. a vytv. dnes, splatnost za 14 dni, forma uhrady "Hotově" 
		/// </summary>
		public PlatebniPodminky()
		{
			this.forma = "";
			this.DatumVystaveni = DateTime.Now;
			this.DatumZdPlneni = DatumVystaveni;
			this.DatumSplatnosti = DatumVystaveni.AddDays(14);
		}

        /// <summary>
        /// Kopirovaci konstruktor
        /// </summary>
        /// <param name="p">Instance, ktera se zkopiruje</param>
        public PlatebniPodminky(PlatebniPodminky p)
        {
            this.DatumSplatnosti = p.DatumSplatnosti;
            this.DatumVystaveni = p.DatumVystaveni;
            this.DatumZdPlneni = p.DatumZdPlneni;
            this.forma = p.forma;
        }

		/// <summary>
		/// Vytvori instanci platebnich podminek dle parametru, Datum vystaveni a zd. plnenni je stejny, splatnost o 14 dni pozdeji
		/// </summary>
		/// <param name="forma">
		/// Forma platby
		/// </param>
		/// <param name="VystAZd">
		/// Toto datum nastavi jako datum vystaveni a zd. plneni, datum splatnosti bude toto + 14 dni
		/// </param>
		public PlatebniPodminky(string forma, DateTime VystAZd)
		{
			this.FormaUhrady = forma;
			this.DatumVystaveni = VystAZd;
			this.DatumZdPlneni = VystAZd;
			this.DatumSplatnosti = VystAZd.AddDays(14);
		}
		
		public PlatebniPodminky(string forma, DateTime Vystaveni, DateTime ZdPlneni, DateTime Splatnost)
		{
			this.FormaUhrady = forma;
			this.DatumVystaveni = Vystaveni;
			this.DatumZdPlneni = ZdPlneni;
			this.DatumSplatnosti = Splatnost;
		}
		
	}
}
