using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Quiz
    {
        private Otazka[] otazky;

        public Quiz()
        {
            otazky = new Otazka[2];
            Random r = new Random();
            DBOtazok dB = new DBOtazok();
            ArrayList vybraneCisla = new ArrayList(); 
            for (int i = 0; i < 2; i++)
            {
                int index;
                do
                {

                    index = r.Next(2);
                }

                while (vybraneCisla.Contains(index));
                otazky[i] = (Otazka)dB.Otazky[index];
                otazky[i] = (Otazka) dB.Otazky[index];


            }
            
        }
        public void SpustQuiz()
        {
            foreach(Otazka o in otazky)
            {
                string uzivOdpoved;
                int[] poleUzivIndexov;
                o.VypisOtazku();
                do
                {
                    uzivOdpoved = Console.ReadLine();

                }
                while (!skontrolujVstup(uzivOdpoved, o,out poleUzivIndexov));


            }
            Console.ReadLine();
        }
        private bool skontrolujVstup(string uzivVstup,Otazka otazka,out int[] poleIndexov)
        {
            poleIndexov = null;
            int index;
            if (otazka is SingleOtazka)
            {

                bool res = jeCisloAJevindexe(uzivVstup, otazka, out index);
                poleIndexov = new int[] { index };
                return res;

            }
            
            else
            {
                string[] poleOdpovediUziv = uzivVstup.Split(' ');
                poleIndexov = new int[poleOdpovediUziv.Length];
                for(int i=0; i < poleOdpovediUziv.Length; i++)
                
                {

                    if (!jeCisloAJevindexe(poleOdpovediUziv[i], otazka,out index)) return false;
                    poleIndexov[i] = index;        
                }
                return true;

            }

        }
        private bool jeCisloAJevindexe(string uzivatelskeCislo,Otazka otazka, out int index)
        {
            int indexOdpovedi;
            bool jeCislo = int.TryParse(uzivatelskeCislo, out index);

            if (!jeCislo)
            {
                return false;
            }
            else
            {
                return (indexOdpovedi > 0 && indexOdpovedi < otazka.Moznosti.Length);

            }
        }
            
           
    }
}
