// PolozkaFaktury.cs created with MonoDevelop
// User: docx at 23:23 22.12.2008
//
// (c) Lukáš Doležal, 2005-2009

using System;

namespace Fakturace_2009.Backbone
{
	/// <summary>
	/// Představuje položku na faktuře
	/// </summary>
	public class PolozkaFaktury
	{        
        /// <value>
		/// Název položky
		/// </value>
		private string nazev;
		/// <value>
		/// Název jednotky množství
		/// </value>
		public string JednotkaKusu;
		/// <value>
		/// Cena za 1 kus
		/// </value>
		public decimal CenaZaKus;
        /// <summary>
        /// Typ položky
        /// </summary>
        public PolozkaFakturyTyp Typ;

		private float mnozstvi;

        public string Nazev
        {
            get { return this.nazev; }
            set { if (value == string.Empty) throw new Exception("Název nesmí být prázdný"); this.nazev = value; }
        }

		/// <value>
		/// Množství položky
		/// </value>
		/// <exception cref="Exception">Nesmí být 0</exception>
		public float Mnozstvi
		{
			set
			{
				if (value == 0)
				{
					throw new Exception("Množství nesmí být nulové");
				}
				
				this.mnozstvi = value;
			}
			get {return this.mnozstvi;}
		}
		
		/// <value>
		/// Celková cena položky, vypočtená z množství * cena/kus
		/// </value>
		public decimal CenaPolozky
		{
			get { return CenaZaKus * (decimal)Mnozstvi; }
		}
		
		/// <summary>
		/// Základní položka
		/// </summary>
		/// <param name="Nazev">
		/// Název položky
		/// </param>
		public PolozkaFaktury(string Nazev)
		{			
			this.mnozstvi = 1;
			this.Nazev = Nazev;
		}

        /// <summary>
        /// Kopirovaci konstruktor
        /// </summary>
        /// <param name="polozka"></param>
        public PolozkaFaktury(PolozkaFaktury polozka)
        {
            this.CenaZaKus = polozka.CenaZaKus;
            this.JednotkaKusu = polozka.JednotkaKusu;
            this.mnozstvi = polozka.mnozstvi;
            this.nazev = polozka.nazev;
            this.Typ = polozka.Typ;
        }

		/// <summary>
		/// Kompletni položka
		/// </summary>
		/// <param name="Nazev">
		/// Název položky
		/// </param>
		/// <param name="CenaZaKus">
		/// Cena za kus
		/// </param>
		/// <param name="Jednotka">
		/// Jednotka množství
		/// </param>
		/// <param name="Mnozstvi">
		/// Počet kusů
		/// </param>
		/// <exception cref="Exception">Když je množství 0</exception>
		public PolozkaFaktury(string Nazev, decimal CenaZaKus, string Jednotka, float Mnozstvi) : this(Nazev)
		{
			
			this.CenaZaKus = CenaZaKus;
			this.JednotkaKusu = Jednotka;
			this.Mnozstvi = Mnozstvi;
		}
	}

    /// <summary>
    /// Upřesnuje typ jednotky. Např. práce, materiál, cestovné..
    /// </summary>
    public struct PolozkaFakturyTyp
    {
        /// <summary>
        /// Celý název typu
        /// </summary>
        public string Nazev;
        /// <summary>
        /// Zkratka typu, umístěná na faktuře
        /// </summary>
        public string Zkratka;

        public override string ToString()
        {
            return this.Nazev;
        }
    }
}
