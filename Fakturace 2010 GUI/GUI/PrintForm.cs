using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Fakturace_2009.GUI
{
    public partial class PrintForm : Form
    {

        PrintDocument document;

        public PrintForm(PrintDocument fp)
        {
            InitializeComponent();

            document = fp;

            document.DefaultPageSettings.Margins.Left = (int)Math.Max(fp.DefaultPageSettings.PrintableArea.Left, 150f / 2.54f);
            document.DefaultPageSettings.Margins.Right = (int)Math.Max(fp.DefaultPageSettings.PaperSize.Width - fp.DefaultPageSettings.PrintableArea.Right, 150f / 2.54f);
            document.DefaultPageSettings.Margins.Top = (int)Math.Max(fp.DefaultPageSettings.PrintableArea.Top, 200f / 2.54f);

            printPreviewControl1.Document = document;
            printPreviewControl1.UseAntiAlias = true;
            printPreviewControl1.Zoom = 1f;

   //         printPreviewControl1.MouseWheel += new MouseEventHandler(printPreviewControl1_MouseWheel);

            this.Text = "Náhled tisku : " + fp.DocumentName;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.UseEXDialog = true;


            if (pd.ShowDialog() == DialogResult.OK)
            {
                document.PrinterSettings = pd.PrinterSettings;
                try
                {
                    document.Print();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Chyba tisku", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
