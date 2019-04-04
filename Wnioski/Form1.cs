using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private ArrayList _reguly;
        private ArrayList _fakty;
        private void Form1_Load(object sender, EventArgs e)
        {
            // wczytujemy fakty
            this._fakty = Repozytorium.CzytajFakty();
            // listę faktów zmieniamy na tablicę
            Fakty[] tablicaFaktow = (Fakty[])this._fakty.ToArray(typeof(Fakty));
            // wypisujemy fakty (textBox2 musi mieć własność "Multiline" = true
            for (int i = 0; i < Repozytorium.LiczbaFaktow; i++)
            {
                textBox2.Text += tablicaFaktow[i].Id.ToString() + " - ";
                textBox2.Text += tablicaFaktow[i].Fact;
                textBox2.Text += " - log: " + tablicaFaktow[i].Log + "\r\n\r\n";
            }
            // wczytujemy reguły
            this._reguly = Repozytorium.CzytajReguly();
            // wypisujemy reguły
            foreach (Reguly reg in _reguly)
            {
                textBox1.Text += "Rule:" + reg.Runo.ToString() + "\r\n" + " IF"+ "\r\n";
                for (int j = 0; j < reg.Preno; j++)
                {
                    textBox1.Text += "    " + tablicaFaktow[reg.Precondition[j]].Fact + "\r\n";
                }
                textBox1.Text += "THEN " + "\r\n    " + tablicaFaktow[reg.Conc].Fact + "\r\n\r\n";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Wnioskowanie wn = new Wnioskowanie();
            wn.ShowDialog();
        }
    }
}
