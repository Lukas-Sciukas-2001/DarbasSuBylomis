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

        public void kurti()
        {
            DateTime now = DateTime.UtcNow;
            int year;
            int month;
            int day;
            string data;
            string naujasfailName;
            arteising = false;
            for (int x = 1; x <= kiek; x++)
            {
                var rand = new Random();
                arteising = false;
                while (arteising == false)
                {
                    string failName = "a" + x + ".txt";
                    if (!File.Exists(failName))
                    {
                        string tekstas = "" + rand.Next(2);
                        File.WriteAllText(failName, tekstas);
                        arteising = true;
                    }
                    else
                    {
                        year = now.Year;
                        month = now.Month;
                        day = now.Day;
                        data = ""+year + '-' + month + '-' + day;
                        naujasfailName = "a"+ x+ "_" + data+".txt";
                        if (File.Exists(naujasfailName))
                        {
                            File.Delete(naujasfailName);
                        }
                        File.Move(failName, naujasfailName);
                        string tekstas = "" + rand.Next(2);
                        File.WriteAllText(failName, tekstas);
                        arteising = true;
                    }
                }
            }

        }
        public failuKlase(int kiekKurt)
        {
            kiek = kiekKurt;
        }
    }
}
