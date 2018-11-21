using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oppg3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TEMP = 100;
            const int MIN_TEMP = 80;
            List<string> linjerFraFil = new List<string>(Commons.LesFraFil("oppg3-data.txt", 2));
            List<string> tider = new List<string>();
            List<double> verdier = new List<double>();

            foreach(string s in linjerFraFil)
            {
                string[] linje = s.Split(' ');
                string tid = linje[0];
                double verdi1 = Convert.ToDouble(linje[1]);
                double verdi2 = Convert.ToDouble(linje[2]);
                double gjennomsnitt = (verdi1 + verdi2) / 2;
                tider.Add(tid);
                verdier.Add(gjennomsnitt);

                if(verdi1>MAX_TEMP || verdi1 < MIN_TEMP)
                {
                    Console.WriteLine("Alarm fra sensor A, verdi: " + verdi1 +" klokken "+ tid);
                }
                if (verdi2 > MAX_TEMP || verdi2 < MIN_TEMP)
                {
                    Console.WriteLine("Alarm fra sensor B, verdi: " + verdi2 + " klokken " + tid);
                }
            }

            Console.WriteLine("Linjner lest: " + linjerFraFil.Count);
            Console.WriteLine("Første tid: " + tider.First<string>());
            Console.WriteLine("Siste tid: " + tider.Last<string>());

            string[] tilFil = new string[linjerFraFil.Count];
            for(int i = 0; i < linjerFraFil.Count; i++)
            {
                tilFil[i] = String.Format("{0} {1:f2}", tider[i], verdier[i]);
            }

            Commons.SkrivTilFil("oppg3-rapport.txt", tilFil);

            Console.ReadKey();
        }
    }
}
