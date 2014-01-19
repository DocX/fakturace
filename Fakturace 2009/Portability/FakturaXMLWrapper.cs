using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;
using System.IO;
using System.Xml.XPath;
using System.Xml;

namespace Fakturace_2009.Portability
{
    static public class FakturaXMLWrapper
    {

        public static Faktura Load(TextReader docreader, Type cislotype)
        {

            //TextReader docreader = new StreamReader(filename);
            XPathDocument doc = new XPathDocument(docreader);
            XPathNavigator nav = doc.CreateNavigator();

            XPathNavigator fnode = nav.SelectSingleNode("//Faktura");

            if (fnode != null)
            {
                CisloFaktury cislo;

                cislo = CisloFaktury.ParseToType(cislotype, fnode.SelectSingleNode("@cislo").Value);
                if (cislo == null)
                    throw new Exception("Chybny formát čísla faktury");

                Faktura f = new Faktura(cislo, new Firma());

                f.DodavatelFaktury = FirmaXMLWrapper.LoadFirma(fnode.SelectSingleNode("dodavatel"));
                f.OdberatelFaktury = FirmaXMLWrapper.LoadFirma(fnode.SelectSingleNode("odberatel"));

                f.MistoProvadenychPraci = fnode.SelectSingleNode("misto").Value;
                f.PopisDodavky = fnode.SelectSingleNode("popis").Value;

                f.PlatebniPodminkyFaktury.DatumSplatnosti = fnode.SelectSingleNode("splatnost").ValueAsDateTime;
                f.PlatebniPodminkyFaktury.DatumVystaveni = fnode.SelectSingleNode("vystaveni").ValueAsDateTime;
                f.PlatebniPodminkyFaktury.DatumZdPlneni = fnode.SelectSingleNode("zdplneni").ValueAsDateTime;
                f.PlatebniPodminkyFaktury.FormaUhrady = fnode.SelectSingleNode("forma-uhrady").Value;

                f.DPH = (float)fnode.SelectSingleNode("polozky/@dph").ValueAsDouble;

                XPathNodeIterator polozky = fnode.Select("polozky/polozka");
                while (polozky.MoveNext())
                {
                    PolozkaFaktury p = new PolozkaFaktury(polozky.Current.SelectSingleNode("nazev").Value);

                    p.CenaZaKus = (decimal)polozky.Current.SelectSingleNode("cena").ValueAs(typeof(decimal));
                    p.Mnozstvi = (float)polozky.Current.SelectSingleNode("mnozstvi").ValueAsDouble;
                    p.JednotkaKusu = polozky.Current.SelectSingleNode("mnozstvi/@jednotka").Value;
                    p.Typ.Nazev = polozky.Current.SelectSingleNode("typ").Value;
                    p.Typ.Zkratka = polozky.Current.SelectSingleNode("typ/@zkratka").Value;

                    f.PolozkyNaFakture.Add(p);
                }

                return f;
            }
            else
            {
                throw new Exception("Soubor s fakturou je zřejmě poškozen");
            }
        }

        public static void Save(TextWriter twriter, Faktura f)
        {
            
            XmlTextWriter doc = new XmlTextWriter(twriter);
            doc.WriteStartDocument();

            doc.WriteStartElement("Faktura");
            doc.WriteAttributeString("cislo", f.CisloFaktury.GetText());

            doc.WriteElementString("misto", f.MistoProvadenychPraci);
            doc.WriteElementString("popis", f.PopisDodavky);

            doc.WriteStartElement("splatnost");
            doc.WriteValue(f.PlatebniPodminkyFaktury.DatumSplatnosti);
            doc.WriteEndElement();
            doc.WriteStartElement("zdplneni");
            doc.WriteValue(f.PlatebniPodminkyFaktury.DatumZdPlneni);
            doc.WriteEndElement();
            doc.WriteStartElement("vystaveni");
            doc.WriteValue(f.PlatebniPodminkyFaktury.DatumVystaveni);
            doc.WriteEndElement();

            doc.WriteElementString("forma-uhrady", f.PlatebniPodminkyFaktury.FormaUhrady);

            // odberatel
            doc.WriteStartElement("odberatel");
            FirmaXMLWrapper.WriteFirma(doc, f.OdberatelFaktury);
            doc.WriteEndElement();

            // dodavatel
            doc.WriteStartElement("dodavatel");
            FirmaXMLWrapper.WriteFirma(doc, f.DodavatelFaktury);
            doc.WriteEndElement();

            // polozky
            doc.WriteStartElement("polozky");
            doc.WriteStartAttribute("dph");
            doc.WriteValue(f.DPH);
            doc.WriteEndAttribute();

            foreach (PolozkaFaktury p in f.PolozkyNaFakture)
            {
                doc.WriteStartElement("polozka");
                
                // typ
                doc.WriteStartElement("typ");
                doc.WriteAttributeString("zkratka", p.Typ.Zkratka);
                doc.WriteValue(p.Typ.Nazev);
                doc.WriteEndElement();

                // mnozstvi
                doc.WriteStartElement("mnozstvi");
                doc.WriteAttributeString("jednotka", p.JednotkaKusu);
                doc.WriteValue(p.Mnozstvi);
                doc.WriteEndElement();

                // cena
                doc.WriteStartElement("cena");
                doc.WriteValue(p.CenaZaKus);
                doc.WriteEndElement();

                // nazev
                doc.WriteElementString("nazev", p.Nazev);

                doc.WriteEndElement();
            }

            doc.WriteEndElement();

            doc.WriteEndDocument();

            doc.Flush();
        }

    }
}
