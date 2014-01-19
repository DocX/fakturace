using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FakturaXMLStorage;
using System.IO;

namespace Converter2006to2010
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Zadejte cestu k adresari s fakturami programu Faktura 2006 jako parametr.");
                return;
            }

            string f2006dir = args[0];
            string f2010dir = ".";

            if (!Directory.Exists(f2006dir))
            {
                Console.WriteLine("Zdrojovy adresar neexistuje");
                return;
            }

            Fakturace_2009.StorageEngines.FakturaceStorage storage
                = new FakturaXMLStorage.FakturaXMLStorage(new string[1] {f2010dir});

            foreach (string soubor in Directory.GetFiles(f2006dir, "*.xml"))
            {
                Console.Write(soubor + "... ");
                Fakturace_2006.faktura f = new Fakturace_2006.faktura();
                try
                {
                    f.NacistZXML(soubor);

                    // konvertovat dodavatele
                    Fakturace_2009.Backbone.Firma dodavatel = new Fakturace_2009.Backbone.Firma();
                    dodavatel.Adresa = f.dodavatel.adresa;
                    dodavatel.DIC = f.dodavatel.dic;
                    dodavatel.IC = f.dodavatel.ic;
                    dodavatel.Mesto = f.dodavatel.mesto;
                    dodavatel.Nazev = f.dodavatel.nazev;
                    foreach (Fakturace_2006.DodavatelDetails ucet in f.dodavatel.ucty)
                    {
                        dodavatel.Ucty.Add(new Fakturace_2009.Backbone.Firma.FirmaDetails(ucet.Label, ucet.Text));
                    }
                    foreach (Fakturace_2006.DodavatelDetails kontakt in f.dodavatel.kontaky)
                    {
                        dodavatel.Kontakty.Add(new Fakturace_2009.Backbone.Firma.FirmaDetails(kontakt.Label, kontakt.Text));
                    }
                    
                    // konvertovat cislo
                    Fakturace_2009.UserSpecifics.CisloPoradiRok cislo
                        = new Fakturace_2009.UserSpecifics.CisloPoradiRok(f.cislo.Poradi, f.cislo.Rok);

                    Fakturace_2009.Backbone.Faktura newF 
                        = new Fakturace_2009.Backbone.Faktura(cislo, dodavatel);

                    // odberatel
                    newF.OdberatelFaktury.Adresa = f.Odberatel.Adresa;
                    newF.OdberatelFaktury.DIC = f.Odberatel.Dic;
                    newF.OdberatelFaktury.IC = f.Odberatel.Ic;
                    newF.OdberatelFaktury.Mesto = f.Odberatel.Mesto;
                    newF.OdberatelFaktury.Nazev = f.Odberatel.Jmeno;

                    // misto a popis
                    newF.MistoProvadenychPraci = f.Odberatel.Misto;
                    newF.PopisDodavky = f.PopisFaktury;
                    
                    // platebni podminky
                    newF.DPH = f.Dph / 100f;
                    newF.PlatebniPodminkyFaktury.DatumSplatnosti = f.Splatnost;
                    newF.PlatebniPodminkyFaktury.DatumVystaveni = f.Vystaveni;
                    newF.PlatebniPodminkyFaktury.DatumZdPlneni = f.Vystaveni;
                    newF.PlatebniPodminkyFaktury.FormaUhrady = f.FormaPlatby;

                    foreach (var item in f.Polozky)
                    {
                        if (item.NazevPolozky == "")
                            continue;

                        Fakturace_2009.Backbone.PolozkaFaktury polozka = new Fakturace_2009.Backbone.PolozkaFaktury(item.NazevPolozky);
                        polozka.CenaZaKus = (decimal)item.CenaJedn;
                        polozka.JednotkaKusu = "";
                        polozka.Mnozstvi = item.Mnozstvi;
                        polozka.Typ.Nazev = item.TypPolozky;
                        polozka.Typ.Zkratka = item.TypPolozky.Length > 0 ? item.TypPolozky[0].ToString() : "";

                        newF.PolozkyNaFakture.Add(polozka);
                    }

                    if (newF.CenaCelkem != (decimal)f.CenaCelkem())
                    {
                        throw new Exception("Celkove ceny se neshoduji");
                    }

                    storage.FakturaSave(newF);
                    Console.WriteLine("OK");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FAIL: " + ex.Message);
                }
            }


        }
    }
}
