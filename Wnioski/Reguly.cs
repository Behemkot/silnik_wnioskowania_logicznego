using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wnioski
{
    public class Reguly
    {
        protected int _runo;
        public int Runo
        {
            get { return this._runo; }
        }
        protected int _preno;
        public int Preno
        {
            get { return this._preno; }
        }
        protected int[] _preco;
        public int[] Precondition
        {
            get { return this._preco; }
        }

        protected int _conc;
        public int Conc
        {
            get { return _conc; }
        }
        protected bool _ver;
        public bool Verified
        {
            get { return _ver; }
            set { _ver = value; }
        }
        public Reguly(int runo, int l_przeslane, int[] preco, int conc, bool ver)// 
        {
            this._runo = runo;
            this._preno = l_przeslane;
            this._preco = preco;
            this._conc = conc;
            this._ver = ver;
        }
     }
}
