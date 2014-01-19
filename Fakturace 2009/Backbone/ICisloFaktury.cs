using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fakturace_2009.Backbone
{
    /// <summary>
    /// Reprezentuje nutnou funkcnost cisla faktury
    /// </summary>
    abstract public class CisloFaktury : IComparable<CisloFaktury>, ICloneable, IEquatable<CisloFaktury>, IComparer<CisloFaktury>
    {
        /// <summary>
        /// Vytvori nove cislo
        /// </summary>
        public CisloFaktury()
        {
        }

        /// <summary>
        /// Prelozi z textove podoby do cisla faktury
        /// </summary>
        /// <param name="CisloText">
        /// A <see cref="System.String"/>
        /// </param>
        public CisloFaktury(string CisloText)
        {
        }

        /// <summary>
        /// Vrati jednoznacnou textovou podobu cisla, kompatibilni s Parse(string)
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/>
        /// </returns>
        abstract public string GetText();

        /// <summary>
        /// Vrati textovou podobu cisla, ktera se bude tisknout na fakture
        /// </summary>
        /// <returns></returns>
        abstract public string GetPrintableText();


        /// <summary>
        /// Vrati masku textu cisla pro MaskEdit kompatibilni s GetText() a Parse()
        /// </summary>
        /// <returns>Maska cisla</returns>
        public static string GetTextMask()
        {
            return "";
        }

        /// <summary>
        /// Vrátí další číslo v pořadí za číslem na kterem je trida volana. 
        /// </summary>
        /// <returns>
        /// A <see cref="ICisloFaktury"/>
        /// </returns>
        abstract public CisloFaktury GetNext();

        #region IComparable Members

        abstract public int CompareTo(CisloFaktury obj);

        #endregion

        public static CisloFaktury ParseToType(Type CisloType, string CisloText)
        {
            if (!CisloType.IsSubclassOf(typeof(CisloFaktury)))
            {
                return null;
            }

            return (CisloFaktury)CisloType.GetConstructor(new Type[1] { typeof(string) }).Invoke(new Object[1] { CisloText });
        }

        #region ICloneable Members

        abstract public object Clone();

        #endregion

        #region IEquatable<CisloFaktury> Members

        abstract public bool Equals(CisloFaktury other);
            
        #endregion

        #region IComparer<CisloFaktury> Members

        public int Compare(CisloFaktury x, CisloFaktury y)
        {
            return x.CompareTo(y);
        }

        #endregion

        #region IEqualityComparer<CisloFaktury> Members

        public bool Equals(CisloFaktury x, CisloFaktury y)
        {
            return x.Equals(y);
        }

     //   abstract public int GetHashCode(CisloFaktury obj);

        #endregion
    }
}
