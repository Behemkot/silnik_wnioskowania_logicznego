using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wnioski
{
    class Fakty
     {
        protected int _id;
        public int Id
       {
            get { return this._id; }
        }
        protected string _fact;
        public string Fact
        {
            get { return this._fact; }
       }
        protected int _log;
        public int Log
       {
            get { return this._log; }
            set { _log = value; }
       }


        public Fakty(int id, string fact, int log)
        {
            this._id = id;
            this._fact = fact;
            this._log = log;
       }
     }
}
