using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Fakturace_2009.GUI;
using System.Diagnostics;

namespace Fakturace_2009
{
    public class EngineNotFoundException : Exception
    {
    }

    public class ProgramInit : ApplicationContext
    {
        private LoadForm splashScreen;
        public Fakturace_2009.StorageEngines.FakturaceStorage Storage;

        public ProgramInit() : base()
        {
            // ukazet splash poikud mozno co nejdriv..
            splashScreen = new LoadForm();
            splashScreen.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            splashScreen.Show();
            splashScreen.Refresh();

            try
            {
                LoadFakturace();
               /* if (Storage.GetType() == typeof(Fakturace_2009.StorageEngines.Temporary.TemporaryStorage))
                {
                }
                */
            }
            catch (EngineNotFoundException)
            {
                SettingsForm sf = new SettingsForm(null);
                MessageBox.Show("Prosím, nastavte prvotní nastavení programu.");
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Program se nyní restartuje s novým nastavením", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProcessStartInfo pi = new ProcessStartInfo(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    pi.WindowStyle = ProcessWindowStyle.Maximized;
                    Process.Start(pi);
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    MessageBox.Show("Nevybrali jste nastavení. Program se vypne.");
                    Process.GetCurrentProcess().Kill();
                }

            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            splashScreen.LoadingLabel.Text = "Vytváření okna...";

            this.MainForm = new MainForm(Storage);
            this.MainForm.Load +=new EventHandler(MainForm_Load);
        }

        void  MainForm_Load(object sender, EventArgs e)
        {
            splashScreen.Dispose();
        }


        private void LoadFakturace()
        {
            // precist nejakou konfiguraci
            string StorageEngineName;
            

            splashScreen.LoadingLabel.Text = "Načítání konfigurace...";

            if (Properties.Settings.Default.StorageClassName == "")
            {
                Properties.Settings.Default.StorageClassName = "";
                Properties.Settings.Default.StorageStrings.Clear();
                Properties.Settings.Default.Save();
            }

            StorageEngineName = Properties.Settings.Default.StorageClassName;
            string[] StorageEngineSettings = new string[Properties.Settings.Default.StorageStrings.Count];
            Properties.Settings.Default.StorageStrings.CopyTo(StorageEngineSettings,0);

            // inicializovat storage
            splashScreen.LoadingLabel.Text = "Inicializace úložistě...";
            this.Storage = GetStorageByName(StorageEngineName, StorageEngineSettings);
        }


        private StorageEngines.FakturaceStorage GetStorageByName(string engineName, string[] engineSettings)
        {
            foreach (Type t in LoadedStorageEngines)
            {
                if (t.FullName == engineName)
                {
                    // nalezeno!
                    return (StorageEngines.FakturaceStorage)t.GetConstructor(new Type[1] { typeof(string[]) }).Invoke(new object[1] { engineSettings });
                }
            }

            throw new EngineNotFoundException();
        }

        private static Type[] storageEngines;

        public static Type[] LoadedStorageEngines
        {
            get
            {
                if (storageEngines == null)
                    storageEngines = GetStorageEngines();

                Type[] tmp = new Type[storageEngines.Length];
                storageEngines.CopyTo(tmp, 0);
                return tmp;
            }
        }

        private static Type[] GetStorageEngines()
        {
            LinkedList<Type> engines = new LinkedList<Type>();

            //engines.AddLast(typeof(Fakturace_2009.StorageEngines.Temporary.TemporaryStorage));

            System.IO.DirectoryInfo d = new System.IO.DirectoryInfo(
                System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName)
                + System.IO.Path.DirectorySeparatorChar + "storages");

            foreach (System.IO.FileInfo item in d.GetFiles("*.dll"))
            {
                Assembly asm;
                try
                {
                    asm = Assembly.LoadFrom(item.FullName);
                    
                }
                catch
                {
                    continue;
                }

                foreach (Type cls in asm.GetExportedTypes())
                {
                    if (cls == null || !(cls.IsClass && !cls.IsAbstract) || !cls.IsSubclassOf(typeof(Fakturace_2009.StorageEngines.FakturaceStorage)))
                    {
                        continue;
                    }
                    engines.AddLast(cls);
                }
            }

            Type[] engarray = new Type[engines.Count];
            engines.CopyTo(engarray, 0);
            return engarray;
        }
    }
}
