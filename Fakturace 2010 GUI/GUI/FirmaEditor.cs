using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fakturace_2009.Backbone;
using Fakturace_2009.StorageEngines;

namespace Fakturace_2009.GUI
{
    public partial class FirmaEditor : UserControl
    {
        #region FirmaDetail BindingSource
        private class FirmaDetailBinding : BindingSource
        {
            #region FirmaDetailPropertyDescriptor
            private class FirmaDetailPropertyDescriptor : PropertyDescriptor
            {
                private PropertyDescriptor encapsulatedDesriptor;

                public FirmaDetailPropertyDescriptor(PropertyDescriptor d)
                    : base(d)
                {
                    encapsulatedDesriptor = d;

                }


                public override bool CanResetValue(object component)
                {
                    return encapsulatedDesriptor.CanResetValue(component);
                }

                public override Type ComponentType
                {
                    get { return encapsulatedDesriptor.ComponentType; }
                }

                public override object GetValue(object component)
                {
                    return encapsulatedDesriptor.GetValue(component);
                }

                public override bool IsReadOnly
                {
                    get { return encapsulatedDesriptor.IsReadOnly; }
                }

                public override Type PropertyType
                {
                    get { return encapsulatedDesriptor.PropertyType; }
                }

                public override void ResetValue(object component)
                {
                    encapsulatedDesriptor.ResetValue(component);
                }

                public override void SetValue(object component, object value)
                {
                    encapsulatedDesriptor.SetValue(component, value);
                }

                public override bool ShouldSerializeValue(object component)
                {
                    return encapsulatedDesriptor.ShouldSerializeValue(component);
                }

                public override string DisplayName
                {
                    get
                    {
                        switch (base.Name)
                        {
                            case "Label":
                                return "Popisek";
                            case "Text":
                                return "Hodnota";
                            default:
                                return base.DisplayName;
                        }
                    }
                }
            }
            #endregion

            public FirmaDetailBinding(List<Firma.FirmaDetails> detaily)
            {
                //this.detaily = detaily;
                this.DataSource = detaily;
                //this.AllowEdit = true;
                this.AllowNew = true;
                //this.AllowRemove = true;

            }

            public override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
            {
                PropertyDescriptorCollection pdc = base.GetItemProperties(listAccessors);
                PropertyDescriptorCollection pdcn = new PropertyDescriptorCollection(null);

                for (int i = 0; i < pdc.Count; i++)
                {
                    pdcn.Add(new FirmaDetailPropertyDescriptor(pdc[i]));
                }

                return pdcn;
            }
        }
        #endregion


        public FirmaEditor()
        {
            InitializeComponent();

            EditedFirma = new Firma();
        }

        private Firma EditedOdberatel;

        public Firma EditedFirma
        {
            get
            {
                UpdateDataFromControls();
                return EditedOdberatel;
            }
            set
            {
                EditedOdberatel = value;
                UpdateControlsFromData();
            }
        }

        private void SelectNextKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.SelectNextControl((Control)sender, true, true, true, false);
                e.SuppressKeyPress = true;
            }
        }
        private void UpdateControlsFromData()
        {
            this.SuspendLayout();

            jmenoEdit.Text = EditedOdberatel.Nazev;
            adresaEdit.Text = EditedOdberatel.Adresa;
            mestoEdit.Text = EditedOdberatel.Mesto;
            icEdit.Text = EditedOdberatel.IC;
            dicEdit.Text = EditedOdberatel.DIC;

            kontaktyGrid.DataSource = new FirmaDetailBinding(EditedOdberatel.Kontakty);
            uctyGrid.DataSource = new FirmaDetailBinding(EditedOdberatel.Ucty);

            this.ResumeLayout();
        }

        private void UpdateDataFromControls()
        {
            EditedOdberatel.Nazev = jmenoEdit.Text;
            EditedOdberatel.Adresa = adresaEdit.Text;
            EditedOdberatel.Mesto = mestoEdit.Text;
            EditedOdberatel.IC = icEdit.Text;
            EditedOdberatel.DIC = dicEdit.Text;
        }

    }
}
