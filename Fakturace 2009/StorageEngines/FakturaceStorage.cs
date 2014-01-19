using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;


namespace Fakturace_2009.StorageEngines
{
    /// <summary>
    /// Pokud při načítání z úložiště neexistuje dodavatel
    /// </summary>
    public class FirmaDontExistsException : Exception
    {
        public FirmaDontExistsException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Chyba v natavení úložistě
    /// </summary>
    public class StorageSeetingsIncorectException : Exception
    {
        public StorageSeetingsIncorectException(string message)
            : base(message)
        {
        }
    }
    

    /// <summary>
    /// Zapouzdruje uloziste fakturace. Obsahuje spravu faktur, odberatelu, dodavatele atd.
    /// </summary>
    public abstract class FakturaceStorage
    {
        /// <summary>
        /// Vytvoři instanci uložiště faktur, melo by zaridit vse nutne pro inicializaci.
        /// </summary>
        /// <param name="settings">Objekt nastaveni storage, nacteny z hlavniho konfiguracniho souboru fakturace</param>
        public FakturaceStorage(string[] Settings)
        {
            this.settings = Settings;
        }

        private string[] settings;

        /// <summary>
        /// Nastaveni storage
        /// </summary>
        public string[] Settings
        {
            get 
            {
                return settings;
            }
        }

        /// <summary>
        /// Vrati referenci na okno s nastavenim. Mel by napojit udalost uzavreni okna na ulozeni nastaveni apod.
        /// </summary>
        /// <returns></returns>
        abstract public System.Windows.Forms.Form GetSettingsForm();

        /// <summary>
        /// Vrati pole s otiskama faktur serazene od nejstarsi faktury. Melo by se nejak kesovat, vola se pri kazdem otevreni open dialogu apod.
        /// </summary>
        /// <returns></returns>
        abstract public List<FakturaFingerprint> FakturaGetFprints();

        /// <summary>
        /// Vrati pole s otiskama faktur. Melo by se nejak kesovat, vola se pri kazdem otevreni open dialogu apod.
        /// </summary>
        /// <param name="descending">Urcuje poradi faktur. TRUE od nejnovejsi, FALSE od nejstarsi</param>
        /// <returns></returns>
        abstract public List<FakturaFingerprint> FakturaGetFprints(bool descending);
        
        /// <summary>
        /// Existuje faktura s danym cislem?
        /// </summary>
        /// <param name="cislo">Cislo faktury podle ktereho se zjisti existence faktury</param>
        /// <returns></returns>
        abstract public bool FakturaExists(CisloFaktury cislo);

        /// <summary>
        /// Zjisti posledni cislo faktury z otisku faktur
        /// </summary>
        /// <returns></returns>
        public CisloFaktury FakturaNextNumber()
        {
            List<FakturaFingerprint> otisky = this.FakturaGetFprints();
            if (otisky.Count > 0)
            {
                return otisky[otisky.Count - 1].cisloFaktury.GetNext();
            }
            else
            {
                Type cislo = this.FakturaCisloType;
                return (CisloFaktury)cislo.GetConstructor(new Type[0]).Invoke(new Object[0]);
            }
            
        }

        /// <summary>
        /// Vrati seznam ulozenych odberatelu
        /// </summary>
        /// <returns></returns>
        abstract public Firma[] OdberatelGet();

        /// <summary>
        /// Ulozi odberatele do seznamu odberatelu
        /// </summary>
        /// <param name="odberatel">Odberatel k ulozeni</param>
        abstract public void OdberatelSave(Firma odberatel);

        /// <summary>
        /// Prepise urciteho odberatele
        /// </summary>
        /// <param name="odberatel">Odberatel k ulozeni</param>
        /// <param name="id">ID v poli podle GetOdberatele</param>
        abstract public void OdberatelSave(Firma odberatel, int id);

        /// <summary>
        /// Odstrani odberatele z uloziste
        /// </summary>
        /// <param name="id"></param>
        abstract public void OdberatelDelete(int id);

        /// <summary>
        /// Nacte fakturu
        /// </summary>
        /// <param name="cislo">Cislo faktury</param>
        /// <returns></returns>
        abstract public Faktura FakturaGet(CisloFaktury cislo);

        /// <summary>
        /// Ulozi novou nebo upravenou fakturu
        /// </summary>
        /// <param name="faktura">Faktura na ulozeni</param>
        abstract public void FakturaSave(Faktura faktura);

        /// <summary>
        /// Odstrani fakturu podle jejiho cisla
        /// </summary>
        /// <param name="otiskFaktury">Cislo faktury, ktera se ma odstranit</param>
        abstract public void FakturaDelete(CisloFaktury cisloFaktury);

        /// <summary>
        /// Vrati pole faktur ohranicene datumy vystaveni
        /// </summary>
        /// <param name="first">Datum vystaveni prvni faktury</param>
        /// <param name="last">Datum vystaveni druhe faktury</param>
        /// <returns></returns>
        abstract public Faktura[] FakturaGetRange(DateTime first, DateTime last);

        /// <summary>
        /// Precte nastaveni dodavatele pro faktury
        /// </summary>
        /// <returns></returns>
        abstract public Firma DodavatelGet();

        /// <summary>
        /// Ulozi nove nastaveni dodavatele.
        /// </summary>
        /// <param name="dodavatel">Dodavatel k ulozeni</param>
        abstract public void DodavatelReplace(Firma dodavatel);

        /// <summary>
        /// Nacte prednastavene typy polozek
        /// </summary>
        /// <returns></returns>
        abstract public PolozkaFakturyTyp[] TypyPolozekGet();

        /// <summary>
        /// Ulozi novy typ
        /// </summary>
        /// <param name="typ">Typ polozky k ulozeni</param>
        abstract public void TypyPolozekSave(PolozkaFakturyTyp typ);

        /// <summary>
        /// Smaze typ na indexu z podle GetTypyPolozek()
        /// </summary>
        /// <param name="index">index ke smazani</param>
        abstract public void TypyPolozekDelete(int index);

        /// <summary>
        /// Vrati typ cisla faktury pouzity pro toto uloziste
        /// </summary>
        /// <returns></returns>
        abstract public Type FakturaCisloType
        {
            get;
        }


        /// <summary>
        /// Znovu nacte vse a zahodi zmeny
        /// </summary>
        abstract public void ReloadStorage();

        public struct StorageEngineInfo
        {
            public string Name;
            public string Description;
            public string Version;
            public string Author;

            public StorageEngineInfo(string name, string description, string version, string author)
            {
                Name = name;
                Description = description;
                Version = version;
                Author = author;
            }

            public bool IsEmpty
            {
                get { return Name == "" && Description == "" && Version == "" && Author == ""; }
            }
        }

        public static  StorageEngineInfo GetStorageInfo()
        {
            return new StorageEngineInfo();
        }
    }
}
