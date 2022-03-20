using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DarbasSuBylomis
{
    internal class failuKlase
    {
        public string kelias;
        public int kiek;
        private bool arteising;
        public string vieta;

        public void kurti()
        {
            DateTime now = DateTime.UtcNow;
            int year;
            int month;
            int day;
            string data;
            string naujasfailName;
            arteising = false;
            //Sukuriamas norimas katalogas, kad butu imanoma sukurti ir skaityti is jo failus
            Directory.CreateDirectory(vieta);
            for (int x = 1; x <= kiek; x++)
            {
                var rand = new Random();
                arteising = false;
                while (arteising == false)
                {
                    string failName = "a" + x + ".txt";
                    if (!File.Exists(vieta+failName))
                    {
                        string tekstas = "" + rand.Next(2);
                        File.WriteAllText(vieta+failName, tekstas);
                        arteising = true;
                    }
                    else
                    {
                        year = now.Year;
                        month = now.Month;
                        day = now.Day;
                        data = ""+year + '-' + month + '-' + day;
                        naujasfailName = "a"+ x+ "_" + data+".txt";
                        if (File.Exists(vieta+naujasfailName))
                        {
                            File.Delete(vieta+naujasfailName);
                        }
                        File.Move(vieta+failName, vieta+naujasfailName);
                        string tekstas = "" + rand.Next(2);
                        File.WriteAllText(vieta+failName, tekstas);
                        arteising = true;
                    }
                }
            }

        }
        public void ataskaita()
        {
            int Kieknuliu = 0;
            int Kiekvienetu = 0;
            string ataskaitospavadinimas = "Ataskaita.txt";
            string tekstas;
            //Surandami visi failai is norimo katalogo
            //Directory.GetFiles grazina pilna kelia ir failo pavadinima
            string[] failai = Directory.GetFiles(vieta, "*.txt");
            foreach( string i in failai)
            {
                tekstas = File.ReadAllText(i);
                if (tekstas == "1")
                {
                    Kiekvienetu++;
                }
                else
                {
                    Kieknuliu++;
                }
            }
            string rezultatas = "Ataskaitu kur yra 1 yra :" + Kiekvienetu + ", o ataskaitu kur yra 0 yra: " + Kieknuliu;
            File.WriteAllText(vieta+ataskaitospavadinimas, rezultatas);
        }

        public void trinti()
        {
            string[] failai = Directory.GetFiles(vieta, "*.txt");
            string tekstas;
            foreach (string i in failai)
            {
                tekstas = File.ReadAllText(i);
                if (tekstas == "0")
                {
                    File.Delete(i);
                }
            }
        }

        public failuKlase(int kiekKurt, string kurvieta)
        {
            vieta = kurvieta+@"\";
            kiek = kiekKurt;
        }
    }
}
