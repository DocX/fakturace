using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using Fakturace_2009.Backbone;
using System.IO;

namespace Fakturace_2009.Portability
{

    class FakturaExporter
    {
        ZipOutputStream zip;

        ZipEntryFactory zef;

        public FakturaExporter(string filename)
        {
            zip = new ZipOutputStream( new FileStream(filename,FileMode.Create,FileAccess.ReadWrite));
            zef = new ZipEntryFactory();
            zip.SetLevel(9);
            zip.PutNextEntry(zef.MakeDirectoryEntry("faktury"));
            zip.PutNextEntry(zef.MakeDirectoryEntry("ostatni"));
        }


        public void AddFaktura(Faktura faktura)
        {
            MemoryStream ms = new MemoryStream();
            TextWriter writer = new StreamWriter(ms);

            FakturaXMLWrapper.Save(writer , faktura);

            ZipEntry ze = zef.MakeFileEntry("faktury/"+faktura.CisloFaktury.GetText() + ".xml");
            zip.PutNextEntry(ze);

            byte[] buffer = ms.GetBuffer();

            zip.Write(buffer, 0, buffer.Length);
        }

        public void Close()
        {
            zip.Finish();
            zip.Close();
        }


    }

    class FakturaImporter
    {
        ZipInputStream zip;

        public FakturaImporter(string filename)
        {
            zip = new ZipInputStream(new FileStream(filename, FileMode.Open, FileAccess.Read))
        }

        public Faktura ReadFaktura()
        {
            
        }
    }
}
