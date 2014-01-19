using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fakturace_2009.GUI
{
    public partial class LoadForm : Form
    {
        public LoadForm()
        {
            InitializeComponent();
        }

        private void LoadingLabel_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

    }
}