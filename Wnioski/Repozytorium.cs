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
    public class Repozytorium
    {
        // tu należy wstawić aktualny namiar na arkusz z danymi

        // Dobre dane
        private static string strfile = "C:\\Users\\behem\\OneDrive\\Dokumenty\\WnStudenci\\DaneWzor2.xls";
        // Błędne dane
        //private static string strfile = "C:\\Users\\behem\\OneDrive\\Dokumenty\\WnStudenci\\SilnikC#1.xls";


        
        //****
        private static string ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strfile + ";Extended Properties=Excel 5.0";  
        public static DataSet ds = new DataSet();
        public static int LiczbaFaktow;
        
        // wczytywanie reguł z arkusza
        public static ArrayList CzytajReguly()
        {
            // połączenie z arkuszem i pobranie danych do "DataSet" - ds
            OleDbConnection objConn = new OleDbConnection(ConnectionString);
            ds.Clear();
            objConn.Open();
            String strConString = "SELECT * from [Arkusz1$]";
            OleDbCommand objCmdSelect = new OleDbCommand(strConString, objConn);
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
            objAdapter1.SelectCommand = objCmdSelect;
            objAdapter1.Fill(ds, "Reguly");
            objConn.Close();
            // przepisanie danych z "DataSet" - ds do ArrayList listaRegul
            ArrayList listaRegul = new ArrayList();
            int k = 0;
            // pierwsza reguła
            int numer = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][0]);
            int l_przeslanek = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][1]);
            int konkl = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][3]);
            int[] przeslanki = new int[10];
            przeslanki[0] = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][2]);
            k++;
            for (int j = 1; j < l_przeslanek; j++)
            {
                przeslanki[j] = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][2]);
                k++;
            }
            bool ver = false;
            Reguly regula = new Reguly(numer, l_przeslanek, przeslanki, konkl, ver);
            listaRegul.Add(regula);
            // kolejne reguły
            int l = 1;
            while (k < ds.Tables["Reguly"].Rows.Count)

            {
                numer = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][0]);
                l_przeslanek = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][1]);
                konkl = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][3]);
                int[] przeslanki1 = new int[10];
                przeslanki1[0] = Convert.ToInt32(ds.Tables["Reguly"].Rows[k][2]);
                int gg = k + l_przeslanek;
                k++;
                l= 1;
                for (int j = k; j < gg; j++)
                {
                    przeslanki1[l] = Convert.ToInt32(ds.Tables["Reguly"].Rows[j][2]);
                    l++;
                    k++;
                }
                Reguly regula1 = new Reguly(numer, l_przeslanek, przeslanki1, konkl, ver);
                listaRegul.Add(regula1);
            }
            return listaRegul;
        }

        // wczytywanie faktów z arkusza
        public static ArrayList CzytajFakty()
        {
            // połączenie z arkuszem i pobranie danych do "DataSet" - ds
            ArrayList listaFaktow = new ArrayList();
            OleDbConnection objConn = new OleDbConnection(ConnectionString);
            ds.Clear();
            objConn.Open();
            string strConString = "SELECT * from [Arkusz2$]";
            OleDbCommand objCmdSelect2 = new OleDbCommand(strConString, objConn);
            OleDbDataAdapter objAdapter2 = new OleDbDataAdapter();
            objAdapter2.SelectCommand = objCmdSelect2;
            objAdapter2.Fill(ds, "_fakt");
            objConn.Close();

            // przepisanie danych z "DataSet" - ds do ArrayList listaFaktow
            for (int i = 1; i <= ds.Tables["_fakt"].Rows.Count; i++)
            {
                int _id = Convert.ToInt32(ds.Tables["_fakt"].Rows[i - 1][0]);
                string _fact = ds.Tables["_fakt"].Rows[i - 1][1].ToString();
                int _log = Convert.ToInt32(ds.Tables["_fakt"].Rows[i - 1][2]);
                Fakty fakt = new Fakty(_id, _fact, _log);
                listaFaktow.Add(fakt);
            }
            LiczbaFaktow = ds.Tables["_fakt"].Rows.Count;
            return listaFaktow;
        }

        // zapisanie nowej wartości logicznej faktu o kluczu w kolumnie fact_id = id
        public static void Zapisz(int id, int log)
        {
            OleDbConnection objConn = new OleDbConnection(ConnectionString);
            string strConString = "Update [Arkusz2$] set logic = @logic where fact_id=@id";
            OleDbCommand objCmdUpdate = new OleDbCommand(strConString, objConn);
            OleDbDataAdapter objAdapter = new OleDbDataAdapter();
            // wstawienie odpowiednich danych w miejsce parametrów
            objCmdUpdate.Parameters.AddWithValue("@logic", log);
            objCmdUpdate.Parameters.AddWithValue("@id", id);
            objConn.Open();
            objCmdUpdate.ExecuteNonQuery();
            objConn.Close();
        }
    }
}
