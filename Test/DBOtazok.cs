using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class DBOtazok
    {
        public DBOtazok()
        {
            SingleOtazka o = new SingleOtazka();
            o.Text = "kolko je 1+1?";
            o.Moznosti = new Moznost[]
            {
                new Moznost ("Vysledok je 1",false),
                new Moznost ("Vysledok je 2",true),
                new Moznost ("Vysledok je 3",false),

            };
            Otazky.Add(o);

            o = new SingleOtazka();
            o.Text = "kolko je 2+1?";
            o.Moznosti = new Moznost[]
            {
                new Moznost ("Vysledok je 1",false),
                new Moznost ("Vysledok je 2",false),
                new Moznost ("Vysledok je 3",true),

            };
            Otazky.Add(o);

            MultiOtazka m = new MultiOtazka();
            m.Text = "Ktory z nich je operacny system?";
            m.Moznosti = new Moznost[]
            {
                new Moznost ("OS X",true),
                new Moznost ("OS Z",false),
                new Moznost ("Windows",true),

            };
            Otazky.Add(o);


        }

        public ArrayList Otazky = new ArrayList();
        

    }
}
