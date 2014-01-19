using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakturace_2009.StorageEngines;

namespace Fakturace_2009.GUI
{
    public partial class SettingsForm : Form
    {
        FakturaceStorage storage;

        FakturaceStorage activeStorage;

        private class StorageType
        {
            public Type type;

            public FakturaceStorage.StorageEngineInfo info;

            public StorageType(Type type)
            {
                this.type = type;

                info = new FakturaceStorage.StorageEngineInfo();

                System.Reflection.MethodInfo method = type.GetMethod("GetStorageInfo");
                if (method != null)
                {
                    info = (FakturaceStorage.StorageEngineInfo)method.Invoke(null, new object[] { });
                }       
            }

            public override string ToString()
            {
                if (!String.IsNullOrEmpty(info.Name))
                    return info.Name;

                return type.ToString();
            }
        }

        public SettingsForm(FakturaceStorage storage)
        {
            InitializeComponent();

            this.storage = storage;
            activeStorage = storage;

            foreach (Type t in Fakturace_2009.ProgramInit.LoadedStorageEngines)
            {
               comboBox1.Items.Add(new StorageType(t));
            }

            if (storage != null)
            {
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if ((comboBox1.Items[i] as StorageType).type == storage.GetType())
                    {
                        comboBox1.SelectedIndex = i;
                        labelActiveStorage.Text = "Současný aktivní systém: " + comboBox1.Items[i].ToString();
                        break;
                    }
                }
            }

            try
            {
                if (storage == null)
                    throw new FirmaDontExistsException("");

                firmaEditor1.EditedFirma = storage.DodavatelGet();
            }
            catch (FirmaDontExistsException)
            {
                firmaEditor1.EditedFirma = new Fakturace_2009.Backbone.Firma();
            }

            textBoxDPH.Text = Properties.Settings.Default.DefaultDPH.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fakturace_2009.Properties.Settings.Default.StorageClassName =
                (comboBox1.SelectedItem as StorageType ).type.FullName;
            Fakturace_2009.Properties.Settings.Default.StorageStrings.Clear();

            Properties.Settings.Default.Save();

            activeStorage = (comboBox1.SelectedItem as StorageType).type.GetConstructor(new Type[1] { typeof(string[]) }).Invoke(new object[1] { new string[1] {""} }) as StorageEngines.FakturaceStorage;

            MessageBox.Show("Nastavení uloženo. Změny se projeví až po restartu programu.");
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                try
                {

                    textBoxDPH.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    Properties.Settings.Default.DefaultDPH = int.Parse(textBoxDPH.Text);
                    Properties.Settings.Default.Save();
                }
                catch
                {
                    MessageBox.Show("DPH není číslo");
                    e.Cancel = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeStorage == null)
            {
                MessageBox.Show("Nastavte nejprve úložný systém","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                this.DialogResult = DialogResult.None;
                tabControl1.SelectTab(tabPage3);
                //this.tabPage3.Focus();
                
                return;
            }
            if (activeStorage != null)
            {
                if (firmaEditor1.EditedFirma.isEmpty)
                {
                    MessageBox.Show("Zadejte informace o dodavateli", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = DialogResult.None;
                    tabControl1.SelectTab(tabPage1);
                    return;
                }

                activeStorage.DodavatelReplace(firmaEditor1.EditedFirma);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(comboBox1.SelectedItem is StorageType))
                return;
                   
            StorageType st = (StorageType) comboBox1.SelectedItem;
            labelStorageAuthor.Text = "Autor: " + (st.info.Author == "" ? "N/A" : st.info.Author);
            labelStorageDescription.Text = "Popis: " + (st.info.Description == "" ? "N/A" : st.info.Description);
            labelStorageVersion.Text = "Verze: " + (st.info.Version == "" ? "N/A" : st.info.Version);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
