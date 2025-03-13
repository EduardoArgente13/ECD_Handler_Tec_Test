using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ECD_Handler
{
    class Program
    {
        static void print_msgs(string[]? txt_msgs = null, string sep = "\n", string end = "\n")
        {
            if (txt_msgs is null)
            {
                return;
            }

            foreach (string txt in txt_msgs.Take(txt_msgs.Length - 1))
            {
                Console.Write(txt + sep);
            }
            Console.Write(txt_msgs[txt_msgs.Length - 1] + end);

            return;
        }

        static string get_home_dir()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        static void process_files_dir(string[] files)
        {
            string[] file_msg_aux = { "", "", new String('-', 30) };
            decimal totalGeneral = 0;

            foreach (string file in files)
            {
                file_msg_aux[0] = file.Split('\\')[file.Split('\\').Length - 1];
                print_msgs(txt_msgs: file_msg_aux, end: "\n\n");

                try
                {
                    XDocument xmlDoc = XDocument.Load(file);

                    var montos = xmlDoc.Descendants("liquidacion")
                                       .Where(l => l.Attribute("num_liq")?.Value == "0")
                                       .Descendants("monto_total")
                                       .Select(m => decimal.Parse(m.Value));

                    // Sum the montos
                    decimal total = montos.Sum();
                    totalGeneral += total; 

                    Console.WriteLine($"El total de la factura en {file_msg_aux[0]} es: {total}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al procesar el archivo {file_msg_aux[0]}: {ex.Message}");
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"El total general de todas las facturas es: {totalGeneral}");
            Console.WriteLine(new string('=', 50));
        }

        static void Main(string[] args)
        {
            string work_dir = Path.Combine(Directory.GetCurrentDirectory(), "XML_files");

            if (!Directory.Exists(work_dir))
            {
                Console.WriteLine("La carpeta XML_files no existe.");
                return;
            }

            string[] files = Directory.GetFiles(work_dir, "*.xml");
            string[] welcome_msg = { "   # Programa ECD Handler"
                                , " # The files are going to be selected from " + work_dir};

            print_msgs(txt_msgs: welcome_msg, sep: new string('\n', 2));

            process_files_dir(files);
        }
    }
}