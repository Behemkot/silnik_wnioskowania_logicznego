using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

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
                // w tej wersji nie będzie nowych faktów
                nowe = false;


                /*      DEFINICJE
                 * fakt okreslony       -   fakt którego wartość logiczna to albo prawda albo fałsz (fakt.Log == 1 lub 2)
                 * fakt nieokreslony    -   fakt którego wartość logiczna nie jest sprecyzowana. 
                 *                          Nie wiemy czy fakt jest prawdziwy czy fałszywy (fakt.Log == 0)
                 * reguła aktywna       -   reguła której wszystkie przesłanki są faktami określonymi.
                 *                          Innymi słowy, to reguła z której możemy coś wywnioskować. 
                 */

                ArrayList F = new ArrayList();              // zbiór faktów prawdziwych
                ArrayList S = _reguly;                      // zbiór regół
                ArrayList Aktywne_Reguly = new ArrayList(); // zbiór aktywnych regół
                ArrayList Fakty_Okreslone = new ArrayList();
                ArrayList Fakty_Nieokreslone = new ArrayList();

                // dziele fakty na dwa zbiory faktów
                foreach (Fakty fakt in _fakty)
                {
                    if (fakt.Log == 0)
                    {
                        Fakty_Nieokreslone.Add(fakt);
                    }
                    else
                    {
                        Fakty_Okreslone.Add(fakt);
                    }
                }

                int breaker = 0; // taka zmienna zabezpieczająca przed zapętleniem w nieskończoność
                int iteracja = 0;

                while (breaker < 10)
                {
                    log("-----------------------------------------------------------------------");
                    textBox1.Text += "\r\n> iteracja " + ++iteracja + "\r\n";
                    ArrayList nowe_Fakty = new ArrayList();

                    log("FAKTY OKRESLONE");
                    wypisz_fakty(Fakty_Okreslone);
                    log("FAKTY NIEOKRESLONE");
                    wypisz_fakty(Fakty_Nieokreslone);

                    log("> szukam aktywnych regul");

                    // szukam nowych konkluzji (na podstawie faktow okreslonych) w zbiorze regul
                    foreach (Reguly regula in S)
                    {
                        // dla każdej przesłanki w regule sprawdzamy czy możemy coś wywnioskować 
                        List<int> list = new List<int>();
                        foreach (int id_faktu in regula.Precondition)
                        {
                            list.Add(tablicaFaktow[id_faktu].Log);
                        }

                        // jeśli choć jedna przesłanka jest nieokreślona nie możemy nic wywnioskować
                        if (!list.Contains(0))
                        { 
                            regula.Verified = true;
                            Aktywne_Reguly.Add(regula);
                        }
                    }

                    if(Aktywne_Reguly.Count == 0)
                    {
                        log("> brak aktywnych regul");
                        log("> koncze petle na iteracji = " + iteracja);
                        break;
                    } 

                    log("AKTYWNE REGULY");
                    wypisz_reguly(Aktywne_Reguly);


                    log("> na podstawie aktywnych regul tworze nowe fakty");

                    foreach(Reguly regula in Aktywne_Reguly)
                    {
                        log("ID Reguly " + regula.Runo);
                        bool wniosek = true;
                        // sprawdzam wszystkie przesłanki w regule
                        for(int i = 0; i < regula.Preno; i++)
                        {
                            // jeśli choć jedna przesłanka ma wartość logiczną 2 (fałsz) to wnioskiem jest fałsz
                            Fakty fakt = tablicaFaktow[regula.Precondition[i]];
                            if (fakt.Log == 2)
                            {
                                wniosek = false;
                            }
                            textBox1.Text += fakt.Id + " : " + fakt.Log + "\r\n";
                        }

                        Fakty konkluzja = tablicaFaktow[regula.Conc];

                        textBox1.Text += "Wniosek: \r\n" + konkluzja.Id + " : " + wniosek + "\r\n";
                        // jeżeli konkluzja jest prawdziwa oraz
                        if (wniosek && Fakty_Nieokreslone.Contains(konkluzja))
                        {
                            konkluzja.Log = 1;
                            Fakty_Nieokreslone.Remove(konkluzja);
                            Fakty_Okreslone.Add(konkluzja);
                            nowe_Fakty.Add(konkluzja);
                        }
                    }

                    log("NOWE FAKTY");
                    wypisz_fakty(nowe_Fakty);

                    log("> usuwam aktywne reguly ze zbioru regul");

                    foreach (Reguly regula in Aktywne_Reguly)
                    {
                        S.Remove(regula);
                    }

                    log("> czyszcze zbior aktywnych regul");
                    Aktywne_Reguly.Clear();

                    log("NOWY ZBIOR REGUL");

                    wypisz_reguly(S);
                    breaker++;
                }
            }
        }

        private void wypisz_fakty(ArrayList lista_faktow)
        {
            textBox1.Text += "\r\n";
            if (lista_faktow.Count == 0)
            {
                textBox1.Text += "NULL";
            }
            else
            {
                foreach (Fakty fakt in lista_faktow)
                {
                    textBox1.Text += fakt.Id.ToString() + " " + fakt.Fact + " " + fakt.Log.ToString() + "\r\n";
                }
            }
        }

        private void wypisz_reguly(ArrayList lista_regol)
        {
            textBox1.Text += "\r\n";
            foreach (Reguly reg in lista_regol)
            {
                textBox1.Text += "Rule: " + reg.Runo.ToString() + "\r\n";
                /*
                textBox1.Text += "FACT: " + tablicaFaktow[reg.Conc].Fact + "\r\n";
                textBox1.Text += "BECAUSE: " + "\r\n";
                for (int j = 0; j < reg.Preno; j++)
                {
                    textBox1.Text += tablicaFaktow[reg.Precondition[j]].Fact + "\r\n";
                }
                textBox1.Text += "\r\n";
                */
            }
        }


        private void log(string message)
        {
            textBox1.Text += "\r\n" + message + "\r\n";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }    
}
