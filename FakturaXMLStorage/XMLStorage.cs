using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.StorageEngines;
using Fakturace_2009.Backbone;
using Fakturace_2009.Portability;
using System.Collections;
using System.IO;

namespace FakturaXMLStorage
{
    public class FakturaXMLStorage : FakturaceStorage
    {

        #region Declaration

        private string StorageDir;

        SortedList<CisloFaktury, FakturaFingerprint> indexFaktur;
        Dictionary<CisloFaktury, Faktura> loadedFaktury;
        List<Firma> Odberatele;
        Firma Dodavatel;

        #endregion

        #region Base methods

        public FakturaXMLStorage(string[] settings)
            : base(settings)
        {
            if (settings.Length >= 1 && System.IO.Directory.Exists(Environment.ExpandEnvironmentVariables(settings[0])))
                StorageDir = Environment.ExpandEnvironmentVariables(settings[0]);
            else
                StorageDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Path.DirectorySeparatorChar + "LD Fakturace" +Path.DirectorySeparatorChar +"XMLStorage";


            this.ReloadStorage();
        }

        public override System.Windows.Forms.Form GetSettingsForm()
        {
            throw new NotImplementedException();
        }

        public override void ReloadStorage()
        {
            if (Directory.Exists(StorageDir) == false)
            {
                // create storage dir
                Directory.CreateDirectory(StorageDir);
            }

            if (Directory.Exists(StorageDir + Path.DirectorySeparatorChar + "Faktury") == false)
            {
                // create faktura storage dir
                Directory.CreateDirectory(StorageDir + Path.DirectorySeparatorChar + "Faktury");
            }

            // nacist index
            indexFaktur = FingerPrintsIndexXMLWrapper.LoadIndex(StorageDir +Path.DirectorySeparatorChar+ "index.xml", this.FakturaCisloType);

            // nacist odberatele
            Odberatele = new List<Firma>();
            try
            {
                Odberatele = FirmaXMLWrapper.Load(StorageDir + Path.DirectorySeparatorChar+"odberatele.xml");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Chyba v souboru odběratelů. Soubor bude smazán a vytvořen nový." + Environment.NewLine + ex.Message);
                this.SaveOdberatele();
            }

            // nacist dodavatele
            try
            {
                this.DodavatelGet();
            }
            catch (FirmaDontExistsException)
            {
            }

            // nacist typy

            loadedFaktury = new Dictionary<CisloFaktury, Faktura>();
        }



        #endregion

        #region Odberatele

        private void SaveOdberatele()
        {
            try
            {
                FirmaXMLWrapper.Save(StorageDir + Path.DirectorySeparatorChar + "odberatele.xml", Odberatele);
            }
            catch
            {
            }
        }

        public override Fakturace_2009.Backbone.Firma[] OdberatelGet()
        {
            Firma[] odberatele = new Firma[this.Odberatele.Count];

            for (int i = 0; i < odberatele.Length; i++)
            {
                odberatele[i] = new Firma(Odberatele[i]);
            }

            return odberatele;
        }

        public override void OdberatelSave(Fakturace_2009.Backbone.Firma odberatel)
        {
            Odberatele.Add(new Firma(odberatel));
            SaveOdberatele();
        }

        public override void OdberatelSave(Fakturace_2009.Backbone.Firma odberatel, int id)
        {
            Odberatele[id] = new Firma(odberatel);
            SaveOdberatele();
        }

        public override void OdberatelDelete(int id)
        {
            Odberatele.RemoveAt(id);
            SaveOdberatele();
        }

        #endregion

        #region Faktury

        public override List<FakturaFingerprint> FakturaGetFprints()
        {
            return FakturaGetFprints(false);
        }

        public override List<Fakturace_2009.Backbone.FakturaFingerprint> FakturaGetFprints(bool descending)
        {
            List<FakturaFingerprint> otisky = new List<FakturaFingerprint>(indexFaktur.Count);
            if (descending)
            {
                for (int i = indexFaktur.Count; i >= 0; i--)
                {
                    otisky.Add(new FakturaFingerprint(indexFaktur.Values[i]));
                }
            }
            else
            {
                for (int i = 0; i < indexFaktur.Count; i++)
                {
                    otisky.Add(new FakturaFingerprint(indexFaktur.Values[i]));
                }
            }
            return otisky;
        }

        public override bool FakturaExists(Fakturace_2009.Backbone.CisloFaktury cislo)
        {
            return indexFaktur.ContainsKey(cislo);
        }

        private string FormatFakturaFilename(CisloFaktury cislo)
        {
            return StorageDir + Path.DirectorySeparatorChar + "Faktury" + Path.DirectorySeparatorChar + cislo.GetText() + ".xml";
        }


        /// <summary>
        /// Vytvori hluboky klon faktury v ulozisti
        /// </summary>
        /// <param name="cislo"></param>
        /// <returns></returns>
        public override Fakturace_2009.Backbone.Faktura FakturaGet(Fakturace_2009.Backbone.CisloFaktury cislo)
        {
            if (!indexFaktur.ContainsKey(cislo))
                throw new Exception("Požadovaná faktura neexistuje");

            if (loadedFaktury.ContainsKey(cislo))
            {
                return new Faktura(loadedFaktury[cislo]);
            }
            else
            {
                try
                {
                    TextReader tr = new StreamReader(FormatFakturaFilename(cislo));
                    Faktura f = FakturaXMLWrapper.Load(tr, cislo.GetType());
                    tr.Close();
                    loadedFaktury.Add(cislo.Clone() as CisloFaktury, f);
                    return new Faktura(f);
                }
                catch 
                {
                    throw new Exception("Požadovaná faktura neexistuje");
                }
            }
        }

        public override void FakturaSave(Fakturace_2009.Backbone.Faktura faktura)
        {
            if (loadedFaktury.ContainsKey(faktura.CisloFaktury))
            {
                loadedFaktury[faktura.CisloFaktury] = new Faktura(faktura);
                indexFaktur[faktura.CisloFaktury] = (FakturaFingerprint)faktura;
            }
            else
            {
                CisloFaktury c = (CisloFaktury)faktura.CisloFaktury.Clone();
                loadedFaktury.Add(c, new Faktura(faktura));
                indexFaktur.Add(c,(FakturaFingerprint)faktura);
            }
            TextWriter tw = new StreamWriter(FormatFakturaFilename(faktura.CisloFaktury));
            FakturaXMLWrapper.Save(tw, faktura);
            tw.Close();

            SaveIndexFile();
        }

        private void SaveIndexFile()
        {
            FingerPrintsIndexXMLWrapper.SaveIndex(StorageDir + Path.DirectorySeparatorChar + "index.xml", indexFaktur.Values.ToArray<FakturaFingerprint>());
        }

        /// <summary>
        /// Pokusi se odstranit fakturu z uloziste
        /// </summary>
        /// <param name="cisloFaktury">Cislo faktury ktera se ma odstranit</param>
        /// <exception cref="IO"></exception>
        public override void FakturaDelete(Fakturace_2009.Backbone.CisloFaktury cisloFaktury)
        {
            FakturaFingerprint finger = null;
            Faktura faktura = null;

            if (indexFaktur.ContainsKey(cisloFaktury))
                finger = indexFaktur[cisloFaktury];
            if (loadedFaktury.ContainsKey(cisloFaktury))
                faktura = loadedFaktury[cisloFaktury];
            
            indexFaktur.Remove(cisloFaktury);
            loadedFaktury.Remove(cisloFaktury);
            try
            {
                SaveIndexFile();
                File.Delete(FormatFakturaFilename(cisloFaktury));
            }
            catch (Exception ex)
            {
                if (finger != null)
                    indexFaktur.Add(cisloFaktury, finger);
                if (faktura != null)
                    loadedFaktury.Add(cisloFaktury, faktura);

                throw ex;
            }

        }

        public override Fakturace_2009.Backbone.Faktura[] FakturaGetRange(DateTime first, DateTime last)
        {
            List<Faktura> range = new List<Faktura>();

            foreach (FakturaFingerprint ff in this.indexFaktur.Values)
            {
                if (ff.datumVytvoreni <= last && ff.datumVytvoreni >= first)
                {
                    range.Add(this.FakturaGet(ff.cisloFaktury));
                }
            }

            return range.ToArray();
            //throw new NotImplementedException();
        }

        new public static FakturaceStorage.StorageEngineInfo GetStorageInfo()
        {
            return new StorageEngineInfo("Indexované XML úložiště", "Ukládá faktury do XML souborů", "1.0", "Lukáš Doležal");
        }

        #endregion

        #region Dodavatel

        public override Fakturace_2009.Backbone.Firma DodavatelGet()
        {
            if (Dodavatel == null)
            {
                try
                {
                    List<Firma> dodavatel = FirmaXMLWrapper.Load(StorageDir + Path.DirectorySeparatorChar + "dodavatel.xml");
                    if (dodavatel.Count == 0)
                        throw new FirmaDontExistsException("V úložisti není nastaven dodavatel");
                    else
                        Dodavatel = dodavatel[0];
                }
                catch
                {
                    throw new FirmaDontExistsException("Nepodařilo se načíst dodavatele");
                }
            }

            return new Firma(Dodavatel);
        }

        public override void DodavatelReplace(Fakturace_2009.Backbone.Firma dodavatel)
        {
            if (dodavatel == null)
                return;

            List<Firma> newDodavatel = new List<Firma>(1);
            newDodavatel.Add(dodavatel);
            try
            {
                FirmaXMLWrapper.Save(StorageDir +  Path.DirectorySeparatorChar + "dodavatel.xml", newDodavatel);
                this.Dodavatel = new Firma(dodavatel);
            }
            catch
            {
                throw new Exception("Nepodařilo se uložit dodavatele");
            }
        }

        #endregion

        #region TypyPolozek

        public override Fakturace_2009.Backbone.PolozkaFakturyTyp[] TypyPolozekGet()
        {
            PolozkaFakturyTyp[] typy = new PolozkaFakturyTyp[2];
            typy[0].Nazev = "Práce"; typy[0].Zkratka = "P";
            typy[1].Nazev = "Materiál"; typy[1].Zkratka = "M";
            return typy;
        }

        public override void TypyPolozekSave(Fakturace_2009.Backbone.PolozkaFakturyTyp typ)
        {
            throw new NotImplementedException();
        }

        public override void TypyPolozekDelete(int index)
        {
            throw new NotImplementedException();
        }

        #endregion

        public override Type FakturaCisloType
        {
            get { return typeof(Fakturace_2009.UserSpecifics.CisloPoradiRok); }
        }

    }
}
