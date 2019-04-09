using System;
using System.Collections;
using System.Windows.Forms;



namespace Wnioski
{
    public partial class Wnioskowanie : Form
    {
        public Wnioskowanie()
        {
            InitializeComponent();
        }                   
        private ArrayList _reguly;
        private ArrayList _fakty;
        Fakty[] tablicaFaktow = new Fakty[0];
        private void Wnioskowanie_Load(object sender, EventArgs e)
        {
            // wczytujemy fakty
            this._fakty = Repozytorium.CzytajFakty();
            // listę faktów zmieniamy na tablicę
            // wczytujemy reguły
            this._reguly = Repozytorium.CzytajReguly();
            tablicaFaktow = (Fakty[])_fakty.ToArray(typeof(Fakty));
            Boolean nowe = true;
            // działamy póty, póki pojawiają się nowe fakty
            while (nowe)
            {
                ArrayList NoweFakty = new ArrayList();

                // w tej wersji nie będzie nowych faktów
                nowe = false;

                foreach(Reguly regula in _reguly)
                {
                    Fakty konkluzja = tablicaFaktow[regula.Conc];
                    int wniosek = 0;
                    if(konkluzja.Log != 1)
                    {
                        wniosek = Wnioskuj(regula);
                        konkluzja.Log = wniosek;
                    }

                    if(wniosek == 1)
                    {
                        nowe = true;
                        NoweFakty.Add(konkluzja);
                    }
                    tablicaFaktow[regula.Conc] = konkluzja;
                }

                wypisz_fakty(NoweFakty);
            }
        }

        private int Wnioskuj(Reguly regula)
        {
            Fakty przeslanka;
            for (int i = 0; i < regula.Preno; i++)
            {
                przeslanka = tablicaFaktow[regula.Precondition[i]];
                if (przeslanka.Log != 1)
                {
                    return 0;
                }
            }
            return 1;
        }

        private void wypisz_fakty(ArrayList lista_faktow)
        {
            log("");
            if (lista_faktow.Count == 0)
            {
                log("KONIEC WNIOSKOWANIA");
            }
            else
            {
                foreach (Fakty fakt in lista_faktow)
                {
                    log(fakt.Id.ToString() + " " + fakt.Fact + " " + fakt.Log.ToString());
                }
            }
        }

        private void wypisz_reguly(ArrayList lista_regol)
        {
            foreach (Reguly reg in lista_regol)
            {
                log("Rule: " + reg.Runo.ToString());
                log("FACT: " + tablicaFaktow[reg.Conc].Fact);
                log("BECAUSE: ");
                for (int j = 0; j < reg.Preno; j++)
                {
                    log(tablicaFaktow[reg.Precondition[j]].Fact);
                }
            }
        }


        private void log(string message)
        {
            textBox1.Text += message + "\r\n";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }    
}
