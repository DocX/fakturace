using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fakturace_2009.Backbone;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace Fakturace_2009.Portability
{
    static public class FirmaXMLWrapper
    {

        static public List<Firma> Load(string filename)
        {
            List<Firma> firmy = new List<Firma>(); 
            
            if (File.Exists(filename) == false)
            {
                //File.Create(filename);
                Save(filename, firmy);
                return firmy;
            }

            TextReader docreader = new StreamReader(filename);
            XPathDocument doc = new XPathDocument(docreader);
            XPathNavigator nav = doc.CreateNavigator();

            XPathNodeIterator firmyI = nav.Select("//Firmy/firma");
            while (firmyI.MoveNext())
            {
                Firma f = LoadFirma(firmyI.Current);
                if (f != null)
                    firmy.Add(f);
            }

            docreader.Close();

            return firmy;
        }

        public static Firma LoadFirma(XPathNavigator firma)
        {
            XPathNavigator p;
            Firma f = new Firma();

            if ((p = firma.SelectSingleNode("nazev")) != null)
                f.Nazev = p.Value;
            else
                return null;

            if ((p = firma.SelectSingleNode("adresa")) != null)
                f.Adresa = p.Value;
            else
                return null;

            if ((p = firma.SelectSingleNode("mesto")) != null)
                f.Mesto = p.Value;
            else
                return null;

            if ((p = firma.SelectSingleNode("ic")) != null)
                f.IC = p.Value;
            else
                return null;

            if ((p = firma.SelectSingleNode("dic")) != null)
                f.DIC = p.Value;
            else
                return null;

            if ((p = firma.SelectSingleNode("kontakty")) != null)
                LoadDetail(p.Select("detail"), f.Kontakty);
            else
                return null;

            if ((p = firma.SelectSingleNode("ucty")) != null)
                LoadDetail(p.Select("detail"), f.Ucty);
            else
                return null;

            return f;
        }

        static public void Save(string filename, List<Firma> firmy)
        {
            XmlTextWriter doc = new XmlTextWriter(filename, null);
            
            doc.WriteStartDocument();
            doc.WriteStartElement("Firmy");

            // zapis otisku
            //LinkedListNode<Firma> f = firmy.First;
            foreach (Firma f in firmy)
            {
                
                doc.WriteStartElement("firma");

                WriteFirma(doc, f);

                doc.WriteEndElement();

                //f = f.Next;
            }

            doc.WriteEndDocument();
            doc.Close();
        }

        public static void WriteFirma(XmlTextWriter doc, Firma f)
        {
            doc.WriteElementString("nazev", f.Nazev);
            doc.WriteElementString("adresa", f.Adresa);
            doc.WriteElementString("mesto", f.Mesto);
            doc.WriteElementString("ic", f.IC);
            doc.WriteElementString("dic", f.DIC);

            doc.WriteStartElement("kontakty");
            WriteDetail(doc, f.Kontakty);
            doc.WriteEndElement();

            doc.WriteStartElement("ucty");
            WriteDetail(doc, f.Ucty );
            doc.WriteEndElement();
        }

        private static void WriteDetail(XmlTextWriter doc, List<Firma.FirmaDetails> f)
        {
            foreach (Firma.FirmaDetails detail in f)
            {
                doc.WriteStartElement("detail");

                doc.WriteAttributeString("label", detail.Label);
                doc.WriteValue(detail.Text);

                doc.WriteEndElement();
            }

        }

        private static void LoadDetail(XPathNodeIterator doc, List<Firma.FirmaDetails>  f)
        {
            while (doc.MoveNext())
            {
                Firma.FirmaDetails fd = new Firma.FirmaDetails();
                XPathNavigator p;

                fd.Text = doc.Current.Value;

                if ((p = doc.Current.SelectSingleNode("@label")) != null)
                   fd.Label = p.Value;
                else
                    continue;

                f.Add(fd);
            }
        }


    }
}
