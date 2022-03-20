using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarbasSuBylomis
{
    internal class failuKlase
    {
        public string kelias;
        public int kiek;
        private bool arteising;

        public void kurti()
        {
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
