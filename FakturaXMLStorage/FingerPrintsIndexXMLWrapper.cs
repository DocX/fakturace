using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace FakturaXMLStorage
{
    static class FingerPrintsIndexXMLWrapper
    {

        static internal SortedList<CisloFaktury, FakturaFingerprint> LoadIndex(string filename, Type cislotype)
        {
            SortedList<CisloFaktury, FakturaFingerprint> indexFaktur;

            TextReader file;
            XPathNavigator navigator;
            XPathNodeIterator dom_iter;
            try
            {
                file = new StreamReader(filename);
                navigator = new XPathDocument(file).CreateNavigator();
                dom_iter = navigator.Select("//FakturyIndex/faktura");
                indexFaktur = new SortedList<CisloFaktury, FakturaFingerprint>(dom_iter.Count);
            }
            catch (System.IO.FileNotFoundException)
            {
                return CreateNewIndex(filename);
            }
            catch (NullReferenceException)
            {
                return CreateNewIndex(filename);
            }
            catch(Exception ex)
            {
                throw new Exception("Nelze načíst index", ex);
            }


            while (dom_iter.MoveNext())
            {
                FakturaFingerprint f = new FakturaFingerprint();
                try
                {
                    f.cisloFaktury = CisloFaktury.ParseToType(cislotype, dom_iter.Current.SelectSingleNode("@cislo").Value);
                    f.popisFaktury = dom_iter.Current.SelectSingleNode("popis").Value;
                    f.nazevOdberatele = dom_iter.Current.SelectSingleNode("odberatel").Value;
                    f.mistoPraci = dom_iter.Current.SelectSingleNode("misto").Value;
                    f.datumVytvoreni = dom_iter.Current.SelectSingleNode("vytvoreno").ValueAsDateTime;
                    f.datumSplaceni = dom_iter.Current.SelectSingleNode("splaceno").ValueAsDateTime;
                    f.cenaCelkemSDPH = (decimal)dom_iter.Current.SelectSingleNode("cena").ValueAs(typeof(decimal));
                }
                catch
                {
                    continue;
                }

                indexFaktur.Add(f.cisloFaktury,f);
            }

            file.Close();

            return indexFaktur;
        }

        private static SortedList<CisloFaktury, FakturaFingerprint> CreateNewIndex(string filename)
        {
            SaveIndex(filename, new FakturaFingerprint[0]);
            return new SortedList<CisloFaktury, FakturaFingerprint>(0);
        }

        static internal void SaveIndex(string filename, FakturaFingerprint[] index)
        {
            XmlTextWriter doc = new XmlTextWriter(filename, null);
            
            doc.WriteStartDocument();
            doc.WriteStartElement("FakturyIndex");

            // zapis otisku
            foreach (FakturaFingerprint f in index)
            {
                doc.WriteStartElement("faktura");
                doc.WriteAttributeString("cislo", f.cisloFaktury.GetText());

                doc.WriteElementString("odberatel", f.nazevOdberatele);
                doc.WriteElementString("popis", f.popisFaktury);
                doc.WriteElementString("misto", f.mistoPraci);
                
                doc.WriteStartElement("vytvoreno");
                doc.WriteValue(f.datumVytvoreni);
                doc.WriteEndElement();

                doc.WriteStartElement("cena");
                doc.WriteValue(f.cenaCelkemSDPH);
                doc.WriteEndElement();

                if (f.datumSplaceni != null)
                {
                    doc.WriteStartElement("splaceno");
                    doc.WriteValue(f.datumSplaceni);
                    doc.WriteEndElement();
                }
                doc.WriteEndElement();

            }

            doc.WriteEndDocument();
            doc.Close();
        }

    }
}
