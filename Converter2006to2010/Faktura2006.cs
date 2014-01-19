using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Fakturace_2006
{
    public class faktura
    {
        public faktura()
        {
            this.cislo = new Cislo();
            this.Odberatel = new odberatel("","","","","","","");
            this.vystaveni = DateTime.Now;
            this.splat = DateTime.Now;
            this.forma = string.Empty;
            this.popis = string.Empty;
            this.dph = 19;
            this.Polozky = new List<polozka>();
            this.Soubor = string.Empty;
            this.dodavatel = new Dodavatel();
        }
        public faktura(faktura f)
        {
            this.cislo.Poradi = f.cislo.Poradi;
            this.cislo.Rok = f.cislo.Rok;
            this.Odberatel = f.Odberatel;
            this.vystaveni = f.vystaveni;
            this.splat = f.splat;
            this.forma = f.forma;
            this.popis = f.popis;
            this.dph = f.dph;
            this.Polozky = new List<polozka>(f.Polozky);
            this.Soubor = f.Soubor;
            this.dodavatel = f.dodavatel;
        }

        public Dodavatel dodavatel;
        
        public string Soubor;

        public Cislo cislo;
        
        private DateTime vystaveni;
        private DateTime splat;

        public DateTime Vystaveni
        {
            get { return vystaveni; }
            set { vystaveni = value; }
        }

        public DateTime Splatnost
        {
            get { return splat; }
            set { splat = value; }
        }

        private string forma;

        public string FormaPlatby
        {
            get { return forma; }
            set { forma = value; }
        }

        private string popis;

        public string PopisFaktury
        {
            get { return popis; }
            set { popis = value; }
        }

        private int dph;

        public int Dph
        {
            get { return dph; }
            set { dph = value; }
        }

        public odberatel Odberatel;

        public List<polozka> Polozky;

        public void UlozitXML(string soubor)
        {
            XmlTextWriter xtw = new XmlTextWriter(new StreamWriter(soubor));

            try
            {

                xtw.WriteStartDocument();

                xtw.WriteStartElement("Faktura");
                xtw.WriteAttributeString("cislo", this.cislo.Text);
                //xtw.WriteAttributeString("verze", this.verze);

                /*Zapsat popis */
                xtw.WriteStartElement("Popis");
                xtw.WriteValue(this.PopisFaktury);
                xtw.WriteEndElement();

                /*Zacit Dodavatel*/
                xtw.WriteStartElement("Dodavatel");

                xtw.WriteStartAttribute("NazevHlavicka");
                xtw.WriteValue(this.dodavatel.hlavickatisk);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Nazev");
                xtw.WriteValue(this.dodavatel.nazev);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Adresa");
                xtw.WriteValue(this.dodavatel.adresa);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Mesto");
                xtw.WriteValue(this.dodavatel.mesto);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Ic");
                xtw.WriteValue(this.dodavatel.ic);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Dic");
                xtw.WriteValue(this.dodavatel.dic);
                xtw.WriteEndAttribute();

                xtw.WriteStartElement("Kontakty");
                foreach (DodavatelDetails kontakts in this.dodavatel.kontaky.ToArray())
                {
                    xtw.WriteStartElement("Kontakt");
                    
                    xtw.WriteStartAttribute("label");
                    xtw.WriteValue(kontakts.Label);
                    xtw.WriteEndAttribute();
                    
                    xtw.WriteValue(kontakts.Text);
                    
                    xtw.WriteEndElement();
                }
                xtw.WriteEndElement();

                xtw.WriteStartElement("Ucty");
                foreach (DodavatelDetails uctys in this.dodavatel.ucty.ToArray())
                {
                    xtw.WriteStartElement("Ucet");

                    xtw.WriteStartAttribute("label");
                    xtw.WriteValue(uctys.Label);
                    xtw.WriteEndAttribute();

                    xtw.WriteValue(uctys.Text);

                    xtw.WriteEndElement();
                }
                xtw.WriteEndElement();

                /*Ukoncit Dodavatel*/
                xtw.WriteEndElement();

                
                /*Zacit Odberatel*/
                xtw.WriteStartElement("Odberatel");

                xtw.WriteStartAttribute("Jmeno");
                xtw.WriteValue(this.Odberatel.Jmeno);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Adresa");
                xtw.WriteValue(this.Odberatel.Adresa);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Mesto");
                xtw.WriteValue(this.Odberatel.Mesto);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Ic");
                xtw.WriteValue(this.Odberatel.Ic);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Dic");
                xtw.WriteValue(this.Odberatel.Dic);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Telefon");
                xtw.WriteValue(this.Odberatel.Telefon);
                xtw.WriteEndAttribute();
                xtw.WriteStartElement("Misto");
                xtw.WriteValue(this.Odberatel.Misto);
                xtw.WriteEndElement();

                /*Ukoncit Odberatel*/
                xtw.WriteEndElement();

                /*Zacit Forma*/
                xtw.WriteStartElement("Forma");

                xtw.WriteStartAttribute("Vystaveni");
                xtw.WriteValue(this.Vystaveni);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Splatnost");
                xtw.WriteValue(this.Splatnost);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Platba");
                xtw.WriteValue(this.FormaPlatby);
                xtw.WriteEndAttribute();
                xtw.WriteStartAttribute("Dph");
                xtw.WriteValue(this.Dph);
                xtw.WriteEndAttribute();

                /*Ukoncit Forma*/
                xtw.WriteEndElement();

                /*Zacit Polozky*/
                xtw.WriteStartElement("Polozky");
                //xtw.WriteAttributeString("celkemcena", );

                foreach (polozka Polozka in this.Polozky.ToArray())
                {
                    xtw.WriteStartElement("polozka");

                    xtw.WriteStartAttribute("typ");
                    xtw.WriteValue(Polozka.TypPolozky);
                    xtw.WriteEndAttribute();

                    xtw.WriteStartAttribute("nazev");
                    xtw.WriteValue(Polozka.NazevPolozky);
                    xtw.WriteEndAttribute();

                    xtw.WriteStartAttribute("mnozstvi");
                    xtw.WriteValue(Polozka.Mnozstvi);
                    xtw.WriteEndAttribute();

                    xtw.WriteStartAttribute("cena");
                    xtw.WriteValue(Polozka.CenaJedn);
                    xtw.WriteEndAttribute();

                    xtw.WriteEndElement();
                }

                /* Konec Polozky*/
                xtw.WriteEndElement();

                /* Konec Faktura */
                xtw.WriteEndElement();
            }
            finally
            {
                xtw.Close();
            }
        }

        public void NacistZXML(string soubor)
        {
            this.cislo = new Cislo();
            this.Odberatel = new odberatel("", "", "", "", "", "", "");
            this.vystaveni = DateTime.Now;
            this.splat = DateTime.Now;
            this.forma = string.Empty;
            this.popis = string.Empty;
            this.dph = 19;
            this.Polozky = new List<polozka>();
            this.Soubor = string.Empty;
            this.dodavatel = new Dodavatel();

            XmlReader xtr = new XmlTextReader(soubor);
            try
            {
                while (xtr.Read())
                {
                    if (xtr.NodeType == XmlNodeType.Element)
                    {
                        if (xtr.Name == "Faktura")
                        {
                            this.cislo.FromText(xtr.GetAttribute("cislo"));
                        }
                        
                        if (xtr.Name == "Popis")
                        {
                            this.PopisFaktury = xtr.ReadElementString().Replace("\r\n", Environment.NewLine);
                        }
                        
                        if (xtr.Name == "Odberatel")
                        {
                            this.Odberatel.Jmeno = xtr.GetAttribute("Jmeno");
                            this.Odberatel.Adresa = xtr.GetAttribute("Adresa");
                            this.Odberatel.Mesto = xtr.GetAttribute("Mesto");
                            this.Odberatel.Ic = xtr.GetAttribute("Ic");
                            this.Odberatel.Dic = xtr.GetAttribute("Dic");
                            this.Odberatel.Telefon = xtr.GetAttribute("Telefon");

                            while (xtr.Read())
                            {
                                if ((xtr.Name == "Misto") && (xtr.NodeType == XmlNodeType.Element))
                                {
                                    this.Odberatel.Misto = xtr.ReadElementString().Replace("\r\n", Environment.NewLine);
                                    break;
                                }
                            }
                        }

                        if (xtr.Name == "Dodavatel")
                        {
                            this.dodavatel.hlavickatisk = xtr.GetAttribute("NazevHlavicka");
                            this.dodavatel.nazev = xtr.GetAttribute("Nazev");
                            this.dodavatel.mesto = xtr.GetAttribute("Mesto");
                            this.dodavatel.adresa = xtr.GetAttribute("Adresa");
                            this.dodavatel.ic = xtr.GetAttribute("Ic");
                            this.dodavatel.dic = xtr.GetAttribute("Dic");
                            
                            while (xtr.Read())
                            {
                                if (xtr.NodeType == XmlNodeType.Element)
                                {
                                    if (xtr.Name == "Kontakty")
                                    {
                                        while (xtr.Read())
                                        {
                                            if ((xtr.Name == "Kontakt") && (xtr.NodeType == XmlNodeType.Element))
                                            {
                                                DodavatelDetails k;
                                                xtr.MoveToAttribute("label");
                                                k.Label = xtr.Value;
                                                xtr.MoveToElement();
                                                k.Text = xtr.ReadString();

                                                this.dodavatel.kontaky.Add(k);
                                            }
                                            if ((xtr.Name == "Kontakty") && (xtr.NodeType == XmlNodeType.EndElement))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    if (xtr.Name == "Ucty")
                                    {
                                        while (xtr.Read())
                                        {
                                            if ((xtr.Name == "Ucet") && (xtr.NodeType == XmlNodeType.Element))
                                            {
                                                DodavatelDetails k;
                                                xtr.MoveToAttribute("label");
                                                k.Label = xtr.Value;
                                                xtr.MoveToElement();
                                                k.Text = xtr.ReadString();

                                                this.dodavatel.ucty.Add(k);
                                            }
                                            if ((xtr.Name == "Ucty") && (xtr.NodeType == XmlNodeType.EndElement))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                if ((xtr.Name == "Dodavatel") && (xtr.NodeType == XmlNodeType.EndElement))
                                {
                                    break;
                                }
                            }
                        }
                        
                        if (xtr.Name == "Forma")
                        {
                            this.Splatnost = XmlConvert.ToDateTime(xtr["Splatnost"],XmlDateTimeSerializationMode.Utc);
                            this.Vystaveni = XmlConvert.ToDateTime(xtr["Vystaveni"], XmlDateTimeSerializationMode.Utc);
                            this.Dph = XmlConvert.ToInt32(xtr["Dph"]);
                            this.FormaPlatby = xtr["Platba"];
                        }
                        
                        if ((xtr.Name == "Polozky") && (xtr.NodeType == XmlNodeType.Element) && (!xtr.IsEmptyElement))
                        {
                            while (xtr.Read())
                            {
                                if (xtr.Name == "polozka")
                                {
                                    string typ, nazev;
                                    int mnoz;
                                    double cena;

                                    xtr.MoveToAttribute("typ");
                                    typ = xtr.ReadContentAsString();
                                    xtr.MoveToAttribute("nazev");
                                    nazev = xtr.ReadContentAsString();
                                    xtr.MoveToAttribute("mnozstvi");
                                    mnoz = xtr.ReadContentAsInt();
                                    xtr.MoveToAttribute("cena");
                                    cena = xtr.ReadContentAsDouble();
                                    xtr.MoveToElement();

                                    this.Polozky.Add(new polozka(typ, nazev,mnoz,cena));
                                }
                                if ((xtr.Name == "Polozky") && (xtr.NodeType == XmlNodeType.EndElement))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    
                }
            }
            finally
            {
                xtr.Close();
                this.Soubor = soubor;
            }
        }

        public double CenaCelkem()
        {
            double celkem = 0;
            polozka[] ps = this.Polozky.ToArray();

            foreach (polozka p in ps)
            {
                celkem += p.CenaCelk;
            }

            return celkem;
        }

        public string GenerovatHTML()
        {
            string h;

            h = "";
            
            h += "<?xml version=\"1.0\"?>";
            h += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">";
            h += "<html xmlns=\"http://www.w3.org/1999/xhtml\">";
            h += "<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />";
            h += "<title>Faktura èíslo ";
            
            /*cislo titulek*/
            h += this.cislo.Poradi.ToString() + "-" + this.cislo.Rok.ToString("0000");
            h += " - tisk</title>";

            h += "<style type=\"text/css\" media=\"all\"> /* <![CDATA[ */" + Environment.NewLine;
            h += "body { background:#ffffff; } #maintable { width: 100%; background: #ffffff; margin:0; margin-left:auto; margin-right:auto; padding:0; padding-left:2mm; padding-right: 2mm; font-family: 'Arial CE', 'Helvetica CE', Arial, helvetica, sans-serif; font-size: 10pt; } #formatable { width: 100%; background: #ffffff; margin:0; margin-left:auto; margin-right:auto; padding:0; padding-left:2mm; padding-right: 2mm; padding-top:2mm; font-family: 'Arial CE', 'Helvetica CE', Arial, helvetica, sans-serif; font-size: 10pt; } tr.hlavicka { width: 100%; height: 1mm; padding:0; margin:0; font-size: 15pt; vertical-align: bottom; } td.nazev { margin:0; width:50%; } td.cislo { margin:0; width:50%; text-align: right; font-size: 13.5pt; color: #555555; } td.podtrh { border-bottom: 1pt #000000 solid; } tr.titulky { margin:0; padding:0; font-size: 10pt; font-style: italic; } tr.titulky td { margin:0; padding:0; vertical-align: bottom; height:8mm; } tr.detail { margin:0; padding:0; height:1mm; font-size:10.1pt; } tr.detail td { padding:0; margin:0; line-height: 1.5em; vertical-align: top; padding-left:4mm; } table.kontakty { width:100%; margin:0; margin-top:3mm; padding:0; text-align:left; font-size:10.1pt; } table.kontakty td { margin:0; padding:0; text-align:left; height:1.5em; vertical-align: bottom; } tr.detail td.pravys { vertical-align: top; margin:0; padding:0; } table.pravy { width:100%; margin:0; padding:0; } table.pravy tr.titulky { margin:0; padding:0; font-size: 10pt; font-style: italic; } table.pravy tr.titulky td { margin:0; padding:0; vertical-align: bottom; height:8mm; } #polozkytable { width: 100%; background: #ffffff; margin:0; margin-left:auto; margin-right:auto; padding:0; padding-left:2mm; padding-right: 2mm; margin-top:2mm; font-family: 'Arial CE', 'Helvetica CE', Arial, helvetica, sans-serif; font-size: 10pt; } #polozkytable tr.polhlav { width:100%; margin:0; padding:0; } #polozkytable tr.polhlav td { margin:0; padding:0; padding-bottom:2mm; height: 5mm; font-style: italic; font-weight:bold; vertical-align: bottom; text-align:right; font-size:9pt; } #polozkytable tr.polozka { margin:0; padding:0; margin_bottom: 2mm; line-height:normal; text-align:right; font-family:'Courier New', courier, monospace; font-size:11pt; vertical-align:bottom; } #total { width: 100%; background: #ffffff; margin:0; margin-left:auto; margin-right:auto; padding:0; padding-left:2mm; padding-right: 2mm; padding-top:3mm; font-family: 'Arial CE', 'Helvetica CE', Arial, helvetica, sans-serif; font-size: 10pt; } #total tr td { margin:0; padding:0; height: 1.8em; text-align:right; vertical-align: bottom; } #total tr td.tot { font-size:11pt; font-weight:bold; } td.formtit { width:50%; border-top:0.75pt #666666 solid; height:6mm; }";
            h += Environment.NewLine + "/* ]]> */</style>";
            
            h += "</head><body><table id=\"maintable\" cellspacing=\"0\" cellpadding=\"0\"><tr class=\"hlavicka\">";

            h += "<td class=\"nazev podtrh\">";
            h += this.dodavatel.hlavickatisk;
            h += "</td><td class=\"cislo podtrh\">Faktura - Daòový doklad è. ";
            h += this.cislo.Poradi.ToString() + "-" + this.cislo.Rok.ToString("0000");
            h += "</td></tr><tr class=\"titulky\"><td>Dodavatel</td><td>Místo provádìných prací</td></tr>";
            
            /*dodavatel*/
            h += "<tr class=\"detail\"> <td> <strong>";
            h += this.dodavatel.nazev;
            h += "</strong><br /><strong>";
            h += this.dodavatel.adresa;
            h += "</strong><br /><strong>";
            h += this.dodavatel.mesto;
            h += "</strong>";

            h += "<table class=\"kontakty\" cellspacing=\"0\"><tr><td>IÈ:</td><td>";
            h += this.dodavatel.ic;
            h += "</td></tr><tr><td>DIÈ:</td><td>";
            h += this.dodavatel.dic;
            h += "</td></tr>";

            /* kontatky */
            foreach (DodavatelDetails d in this.dodavatel.kontaky.ToArray())
            {
                h += "<tr><td>";
                h += d.Label;
                h += "</td><td>";
                h += d.Text;
                h += "</td></tr>";
            }

            /* ucty */ 
            h += "<tr><td>Èíslo úètu</td><td><strong>";
            foreach (DodavatelDetails d in this.dodavatel.ucty.ToArray())
            {
                h += d.Text;
                h += "<br />";
            }
            h += "</strong></td></tr>";


            h += "</table></td><td rowspan=\"3\" cellspacing=\"0\" cellpadding=\"0\" class=\"pravys\"><table class=\"pravy\"><tr class=\"detail\"><td>";
            h += this.Odberatel.Misto.Replace(Environment.NewLine, "<br />");
            h += "</td></tr><tr class=\"titulky\"><td>Odbìratel</td></tr><tr class=\"detail\"><td><strong>";
            
            /* odberatel */
            h += this.Odberatel.Jmeno + "<br />";
            h += this.Odberatel.Adresa + "<br />";
            h += this.Odberatel.Mesto;
            h += "</strong>";

            if ((this.Odberatel.Ic != string.Empty) || (this.Odberatel.Dic != string.Empty) || (this.Odberatel.Telefon != string.Empty))
            {
                h += "<table class=\"kontakty\" cellspacing=\"0\">";
                
                if (this.Odberatel.Ic != string.Empty)
                {
                    h += "<tr><td>IÈ:</td><td>";
                    h += this.Odberatel.Ic;
                    h += "</td></tr>";
                }
                if (this.Odberatel.Dic != string.Empty)
                {
                    h += "<tr><td>DIÈ:</td><td>";
                    h += this.Odberatel.Dic;
                    h += "</td></tr>";
                }
                if (this.Odberatel.Telefon != string.Empty)
                {
                    h += "<tr><td>Kontakt:</td><td>";
                    h += this.Odberatel.Telefon;
                    h += "</td></tr>";
                }

                h += "</table>";
            }

            h += "</td></tr></table></td></tr></table><table id=\"formatable\" cellspacing=\"0\" cellpadding=\"0\"><tr class=\"titulky\"><td class=\"formtit\">Popis dodávky</td><td class=\"formtit\">Platové podmínky</td></tr><tr class=\"detail\"><td>";
            
            /* popis */
            h += this.PopisFaktury.Replace(Environment.NewLine, "<br />");

            h += "</td><td><table class=\"kontakty\" cellspacing=\"0\" style=\"margin:0\"><tr><td>Datum vystavení:</td><td>";
            /* datum vystaveni */
            h += this.Vystaveni.ToShortDateString();
            h += "</td></tr><tr> <td>Datum uskut. zd. plnìní:</td><td>";
            /* datum zdaneni */
            h += this.Vystaveni.ToShortDateString();
            h += "</td></tr><tr><td><strong>Datum splatnosti:</strong></td> <td><strong>";
            /* datum spatnosti */
            h += this.Splatnost.ToShortDateString();

            h += "</strong></td></tr><tr><td><strong>Zpùsob platby:</strong></td><td><strong>";
            h += this.FormaPlatby;

            h += "</strong></td></tr></table></td></tr></table><table id=\"polozkytable\" cellspacing=\"0\" cellpadding=\"0\" style=\"border-top:0.75pt #666666 solid\"><tr class=\"polhlav\"> <td style=\"text-align:left; width:58%;\">Název položky</td> <td style=\"width:15%\">Jedn. cena</td> <td style=\"width:9%\">Množ.</td> <td style=\"width:18%\">Cena øádku</td></tr>";

            /* polozky */
            foreach (polozka p in this.Polozky.ToArray())
            {
                h += "<tr class=\"polozka\"><td style=\"text-align:left\">";
                h += (p.TypPolozky == "Práce") ? "P " : "M ";
                h += p.NazevPolozky;
                h += "</td><td>";
                h += p.CenaJedn.ToString("C", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                h += "</td><td>";
                h += p.Mnozstvi.ToString();
                h += "</td><td>";
                h += p.CenaCelk.ToString("C", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                h += "</td></tr>";
            }

            double tc = this.CenaCelkem();
            double td;
            td = tc * this.Dph;
            td /= 100;
            
            /* konecne ceny */
            h += "</table><table id=\"total\"  cellspacing=\"0\" cellpadding=\"0\"><tr> <td style=\"width:30%; border-top:1pt #000000 solid;\"> Cena celkem bez DPH ";
            /* dph */
            h += this.Dph.ToString();
            h += "%:</td><td style=\"width:20%; border-top:1pt #000000 solid;\">";
            /* cena b dph */
            h += tc.ToString("C", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            h += "</td> <td rowspan=\"2\" class=\"tot\" style=\"width:30%; border-top:1pt #000000 solid;\"> Celková cena s DPH:</td> <td rowspan=\"2\" class=\"tot\" style=\"border-top:1pt #000000 solid;\">";
            /* celkova cena s dph */
            h += ((double)(tc + td)).ToString("C", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            h += "</td></tr><tr><td>";
            h += "DPH " + this.Dph.ToString() + "%:</td><td>";
            h += td.ToString("C", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);

            h += "</td></tr></table></body>";
            h += "<script language=\"Javascript1.2\">window.print()</script>";
            h += "</html>";


            return h;
        }
    }

    public struct Cislo
    {
        public Cislo(int p, int r)
        {
            this.iPoradi = p;
            this.iRok = r;
        }

        private int iRok;
        public int Rok
        {
            get { return iRok; }
            set { iRok = value; }
        }

        private int iPoradi;
        public int Poradi
        {
            get { return iPoradi; }
            set { iPoradi = (value < 1) ? 1 : value; }
        }


        public string Text
        {
            get { return iPoradi.ToString("000") + "-" + iRok.ToString("0000"); }
        }

        public void FromText(string text)
        {
            string p, r;

            p = text.Substring(0, text.IndexOf("-"));
            r = text.Substring(text.IndexOf("-") + 1, 4);

            iPoradi = Convert.ToInt32(p);
            iRok = Convert.ToInt32(r);
        }

        public int CompareTo(Cislo value)
        {
            if (this.Rok == value.Rok)
            {
                return this.Poradi.CompareTo(value.Poradi);
            }
            else
            {
                return this.Rok.CompareTo(value.Rok);
            }
        }
    }


    public struct odberatel
    {
        public odberatel(string jmeno, string adresa, string mesto, string dic, string ic, string telefon, string misto)
        {
            this.jmeno = jmeno;
            this.adresa = adresa;
            this.mesto = mesto;
            this.dic = dic;
            this.ic = ic;
            this.telefon = telefon;
            this.misto = misto;
        }
        

        private string jmeno;
        private string adresa;
        private string mesto;

        private string dic;
        private string ic;
        private string telefon;

        private string misto;

        public string Jmeno
        {
            get { return jmeno; }
            set { jmeno = value; }
        }
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        public string Mesto
        {
            get { return mesto; }
            set { mesto = value; }
        }

        public string Dic
        {
            get { return dic; }
            set { dic = value; }
        }

        public string Ic
        {
            get { return ic; }
            set { ic = value; }
        }
        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }
        public string Misto
        {
            get { return misto; }
            set { misto = value; }
        }

        public static bool IsEmpty(odberatel test)
        {
            return object.Equals(test, new odberatel("", "", "", "", "", "", ""));
        }
    }

    public struct polozka
    {
        public polozka(string t, string naz, int mnoz, double cen)
        {
            this.typ = t;
            this.nazev = naz;
            this.mnozstvi = mnoz;
            this.cena = cen;
        }
        
        private string typ;

        public string TypPolozky
        {
            get { return typ; }
            set { typ = value; }
        }

        private string nazev;

        public string NazevPolozky
        {
            get { return nazev; }
            set { nazev = value; }
        }

        private int mnozstvi;

        public int Mnozstvi
        {
            get { return mnozstvi; }
            set { mnozstvi = value; }
        }

        private double cena;

        public double CenaJedn
        {
            get { return cena; }
            set { cena = value; }
        }

        public double CenaCelk
        {
            get { return (double)(mnozstvi * cena); }
        }
    }


    public class OdberatelList
    {
        
        
        public OdberatelList()
        {
            this.Odberatele = new List<odberatel>();
        }

        public OdberatelList(string soubor)
        {
            this.Odberatele = new List<odberatel>();

            if (File.Exists(soubor))
            {
                this.NacistzXML(soubor);
            }
            else
            {
                FileStream f = File.Create(soubor);
                f.Close();
                f.Dispose();
                this.UlozitXML(soubor);
            }
        }
        
        public List<odberatel> Odberatele = new List<odberatel>();

        private int aktual;

        public int AktualIndex
        {
            get { return aktual; }
            set { aktual = value; }
        }

        public odberatel AktualOdb()
        {
            if (aktual > -1)
            {
                return this.Odberatele[this.aktual];
            }
            else
            {
                return new odberatel("","","","","","","");
            }
        }

        public void UlozitXML(string soubor)
        {
            XmlTextWriter xtw= new XmlTextWriter(new StreamWriter(soubor));
            try
            {
               
                xtw.WriteStartDocument();
                xtw.WriteStartElement("Odberatele");

                foreach (odberatel odb in this.Odberatele.ToArray())
                {
                    xtw.WriteStartElement("Odberatel");

                    xtw.WriteStartAttribute("Jmeno");
                    xtw.WriteValue(odb.Jmeno);
                    xtw.WriteEndAttribute();
                    xtw.WriteStartAttribute("Adresa");
                    xtw.WriteValue(odb.Adresa);
                    xtw.WriteEndAttribute();
                    xtw.WriteStartAttribute("Mesto");
                    xtw.WriteValue(odb.Mesto);
                    xtw.WriteEndAttribute();
                    xtw.WriteStartAttribute("Ic");
                    xtw.WriteValue(odb.Ic);
                    xtw.WriteEndAttribute();
                    xtw.WriteStartAttribute("Dic");
                    xtw.WriteValue(odb.Dic);
                    xtw.WriteEndAttribute();
                    xtw.WriteStartAttribute("Telefon");
                    xtw.WriteValue(odb.Telefon);
                    xtw.WriteEndAttribute();

                    xtw.WriteStartElement("Misto");
                    xtw.WriteValue(odb.Misto);
                    xtw.WriteEndElement();

                    xtw.WriteEndElement();
                }

                xtw.WriteEndElement();
            }
            finally
            {
                xtw.Close();
            }
            
        }

        public void NacistzXML(string soubor)
        {
            XmlReader xtr = new XmlTextReader(soubor);

            while (xtr.Read())
            {
                if ((xtr.Name == "Odberatel") &&(xtr.NodeType == XmlNodeType.Element))
                {
                    this.Odberatele.Add(new odberatel(xtr["Jmeno"], xtr["Adresa"], xtr["Mesto"], xtr["Dic"], xtr["Ic"],xtr["Telefon"], ""));
                }
                if ((xtr.Name == "Misto") && (xtr.NodeType == XmlNodeType.Element))
                {
                    odberatel ob = this.Odberatele[this.Odberatele.Count - 1];
                    ob.Misto = xtr.ReadElementString();
                    this.Odberatele[this.Odberatele.Count - 1] = ob;
                }
            }
        }
    }


    public class FakturySeznam
    {
        public List<faktura> faktury = new List<faktura>();
        public List<Cislo> cisla = new List<Cislo>();

        public FakturySeznam(string cesta)
        {
            NacistFaktury(cesta);
            this.OpenIndex = -1;
        }


        public void Seradit()
        {
            this.faktury.Sort(fCompareByCislo);
            this.cisla.Sort(cCompareByCislo);
        }

        public void NacistFaktury(string cesta)
        {
            if (Directory.Exists(cesta))
            {
                string[] files = Directory.GetFiles(cesta, "*.xml");

                foreach (string fn in files)
                {
                    faktura f = new faktura();

                    f.NacistZXML(fn);
                    this.faktury.Add(f);
                    this.cisla.Add(f.cislo);
                }
            }
            else
            {
                Directory.CreateDirectory(cesta);
            }

        }

        public static int fCompareByCislo(faktura a, faktura b)
        {
            /* a je vetsi nez b = 1
             * a je mensi nez b = -1
             * oba jsou stejny = 0 */


            if (a.cislo.Rok == b.cislo.Rok)
            /* rok je stejny, zjisti jaky je mensi a vetsi v poradi */
            {
                return -a.cislo.Poradi.CompareTo(b.cislo.Poradi);
            }
            else
            {
                return -a.cislo.Rok.CompareTo(b.cislo.Rok);
            }
        }

        public static int fCompareByDatum(faktura a, faktura b)
        {
            /* a je vetsi nez b = 1
             * a je mensi nez b = -1
             * oba jsou stejny = 0 */


            return a.Vystaveni.CompareTo(b.Vystaveni);
        }
        
        private static int cCompareByCislo(Cislo a, Cislo b)
        {
            /* a je vetsi nez b = 1
             * a je mensi nez b = -1
             * oba jsou stejny = 0 */


            if (a.Rok == b.Rok)
            /* rok je stejny, zjisti jaky je mensi a vetsi v poradi */
            {
                return -a.Poradi.CompareTo(b.Poradi);
            }
            else
            {
                return -a.Rok.CompareTo(b.Rok);
            }

        }

        public int OpenIndex;
        
    }

    public enum OpenMode
    {
        NovaBezPolozek,
        NovaSPolozkami,
        ProUpravu
    }

    public class Dodavatel
    {
        public string nazev;
        public string hlavickatisk;
        public string adresa;
        public string mesto;
        public string ic;
        public string dic;

        public List<DodavatelDetails> kontaky = new List<DodavatelDetails>();
        public List<DodavatelDetails> ucty = new List<DodavatelDetails>();

        static public Dodavatel NacistzXML(string soubor)
        {
            XmlTextReader xtr = new XmlTextReader(soubor);

            Dodavatel res = new Dodavatel();

            while (xtr.Read())
            {
                if (xtr.Name == "Dodavatel")
                {
                    res.hlavickatisk = xtr.GetAttribute("NazevHlavicka");
                    res.nazev = xtr.GetAttribute("Nazev");
                    res.mesto = xtr.GetAttribute("Mesto");
                    res.adresa = xtr.GetAttribute("Adresa");
                    res.ic = xtr.GetAttribute("Ic");
                    res.dic = xtr.GetAttribute("Dic");

                    while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Element)
                        {
                            if (xtr.Name == "Kontakty")
                            {
                                while (xtr.Read())
                                {
                                    if ((xtr.Name == "Kontakt") && (xtr.NodeType == XmlNodeType.Element))
                                    {
                                        DodavatelDetails k;
                                        xtr.MoveToAttribute("label");
                                        k.Label = xtr.Value;
                                        xtr.MoveToElement();
                                        k.Text = xtr.ReadString();

                                        res.kontaky.Add(k);
                                    }
                                    if ((xtr.Name == "Kontakty") && (xtr.NodeType == XmlNodeType.EndElement))
                                    {
                                        break;
                                    }
                                }
                            }
                            if (xtr.Name == "Ucty")
                            {
                                while (xtr.Read())
                                {
                                    if ((xtr.Name == "Ucet") && (xtr.NodeType == XmlNodeType.Element))
                                    {
                                        DodavatelDetails k;
                                        xtr.MoveToAttribute("label");
                                        k.Label = xtr.Value;
                                        xtr.MoveToElement();
                                        k.Text = xtr.ReadString();

                                        res.ucty.Add(k);
                                    }
                                    if ((xtr.Name == "Ucty") && (xtr.NodeType == XmlNodeType.EndElement))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        
                        if ((xtr.Name == "Dodavatel") && (xtr.NodeType == XmlNodeType.EndElement))
                        {
                            break;
                        }
                    }
                }
            }

            xtr.Close();

            return res;
        }
    }

    public struct DodavatelDetails
    {
        public string Label;
        public string Text;
    }

    
}
