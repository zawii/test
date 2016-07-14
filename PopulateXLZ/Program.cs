using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;


namespace PopulateXLZ
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //if (Registry.ClassesRoot.GetValue("HKEY_CLASSES_ROOT\\batfile\\shell\\PopulateFoldersWithXLZ\\command", null) == null)
                if (Registry.GetValue("HKEY_CLASSES_ROOT\\ZippedXliff\\shell\\PopulateFoldersWithXLZ\\command", "", null) == null)
                {
                    Registry.SetValue("HKEY_CLASSES_ROOT\\ZippedXliff\\shell\\PopulateFoldersWithXLZ\\command", "", System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + " \"%1\"");
                    MessageBox.Show("Script added to XLZ file context menu!", "Script Added!");
                }
                else
                {
                    MessageBox.Show("Script already installed!", "Script detected!");
                }

            }
            else
            {
                //string dir = args[0].Substring(0,args[0].LastIndexOf('\\'));

                //string filename = args[0].Substring(args[0].LastIndexOf('\\') + 1);

                string dir = Path.GetDirectoryName(args[0]);

                string filename = Path.GetFileName(args[0]);


                // Console.WriteLine("Sciezka w ktorej szukam folderow jezykowych: {0}", dir);
                //  Console.WriteLine("Plik: {0}", filename);


                DirectoryInfo file_dir = new DirectoryInfo(dir);

                DirectoryInfo[] dirInfos = file_dir.GetDirectories("*.*");

                foreach (DirectoryInfo d in dirInfos)
                {
                    DirectoryInfo[] TranslatedirInfos = d.GetDirectories("translate");

                    foreach (DirectoryInfo dd in TranslatedirInfos)
                    {
                        //Console.WriteLine(dd.FullName);
                        File.Copy(args[0], dd.FullName + '\\' + filename, true);
                    }


                }


                // Console.ReadKey();

            }

        }
    }
}
