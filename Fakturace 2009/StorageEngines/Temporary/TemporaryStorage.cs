using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;

#if BUILD_TEMPSTORAGE

namespace Fakturace_2009.StorageEngines.Temporary
{
    public class TemporaryStorage : FakturaceStorage
    {
        private SortedList<CisloFaktury, Faktura> Faktury;
        private List<Firma> Odberatele;

        public TemporaryStorage(string[] settings)
            : base(settings)
        {
            Faktury = new SortedList<CisloFaktury, Faktura>();
            Odberatele = new List<Firma>();
            Odberatele.Add(new Firma("My","U me","Tady", "1236", "CZ1236"));
        }


        public override List<FakturaFingerprint> FakturaGetFprints()
        {
            return FakturaGetFprints(false);
        }

        public override List<FakturaFingerprint> FakturaGetFprints(bool descending)
        {
            List<FakturaFingerprint> otisky = new List<FakturaFingerprint>(Faktury.Count);
            if (descending)
            {
                for (int i = Faktury.Count - 1; i >= 0; i--)
                {
                    otisky.Add((FakturaFingerprint)Faktury.Values[i]);
                }
            }
            else
            {
                for (int i = 0; i < Faktury.Count; i++)
                {
                    otisky.Add((FakturaFingerprint)Faktury.Values[i]);
                }
            }
            return otisky;
        }

        public override Firma[] OdberatelGet()
        {
            Firma[] odberatele = new Firma[this.Odberatele.Count];

            for (int i = 0; i < odberatele.Length; i++)
            {
                odberatele[i] = new Firma(Odberatele[i]);
            }

            return odberatele;
        }

        public override void OdberatelSave(Firma odberatel)
        {
            Odberatele.Add(new Firma(odberatel));
        }

        public override void OdberatelSave(Firma odberatel, int id)
        {
            Odberatele[id] = new Firma(odberatel);
        }

        public override void OdberatelDelete(int id)
        {
            throw new NotImplementedException();
        }

        public override Faktura FakturaGet(CisloFaktury cislo)
        {
            if (Faktury.ContainsKey(cislo))
            {
                return new Faktura(Faktury[cislo]);
            }

            return null;
        }

        public override void FakturaSave(Faktura faktura)
        {
            if (Faktury.ContainsKey(faktura.CisloFaktury))
            {
                Faktury[faktura.CisloFaktury] = new Faktura(faktura);
            }
            else
            {
                Faktury.Add((CisloFaktury)faktura.CisloFaktury.Clone(), new Faktura(faktura));
            }
        }

        public override void FakturaDelete(CisloFaktury cisloFaktury)
        {
            throw new NotImplementedException();
        }

        public override Firma DodavatelGet()
        {
            Firma f = new Firma("Plyn-Servis Doležal", "Javorová 3099", "43401 Most", "10445081", "CZ5509110981");
            f.Kontakty.Add(new Firma.FirmaDetails("Tel.:", "476 709 094"));
            f.Kontakty.Add(new Firma.FirmaDetails("Mob.:", "602 460 193"));
            f.Ucty.Add(new Firma.FirmaDetails("Učet KB:", "60748491/0100"));
            return f;
        }

        public override void DodavatelReplace(Firma dodavatel)
        {
            
        }

        public override PolozkaFakturyTyp[] TypyPolozekGet()
        {
            PolozkaFakturyTyp[] typy = new PolozkaFakturyTyp[2];
            typy[0].Nazev = "Práce"; typy[0].Zkratka = "P";
            typy[1].Nazev = "Materiál"; typy[1].Zkratka = "M";
            return typy;
        }

        public override void TypyPolozekSave(PolozkaFakturyTyp typ)
        {
            throw new NotImplementedException();
        }

        public override void TypyPolozekDelete(int index)
        {
            throw new NotImplementedException();
        }

        public override void ReloadStorage()
        {
            throw new NotImplementedException();
        }

        public override Type FakturaCisloType
        {
            get { return typeof(Fakturace_2009.UserSpecifics.CisloPoradiRok); }
        }

        public override System.Windows.Forms.Form GetSettingsForm()
        {
            throw new NotImplementedException();
        }

        public override bool FakturaExists(CisloFaktury cislo)
        {
            return Faktury.ContainsKey(cislo);
        }

        public override Faktura[] FakturaGetRange(DateTime first, DateTime last)
        {
            LinkedList<Faktura> tmp = new LinkedList<Faktura>();

            foreach (Faktura f in Faktury.Values)
            {
                if (f.PlatebniPodminkyFaktury.DatumVystaveni >= first && f.PlatebniPodminkyFaktury.DatumVystaveni <= last)
                {
                    tmp.AddLast(new Faktura(f));
                }
            }

            Faktura[] tmpf = new Faktura[tmp.Count];
            tmp.CopyTo(tmpf, 0);

            return tmpf;
        }
    }
}

#endif