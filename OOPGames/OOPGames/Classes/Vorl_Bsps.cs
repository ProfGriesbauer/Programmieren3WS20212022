using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class Haus
    {
        Verbraucher _Staubsauger;
        Verbraucher _Fernseher;
        List<Verbraucher> _Sonstige;

        public Haus ()
        {
            _Sonstige = new List<Verbraucher>();
            _Sonstige.Add(new Verbraucher(100));
            _Sonstige.Add(new Verbraucher(300));
            _Staubsauger = new Verbraucher(1000);
            _Fernseher = new Verbraucher(200);
        }

        public float Gesamtstrom
        {
            get
            {
                float ret = 0;
                foreach (Verbraucher verb in _Sonstige)
                {
                    ret += verb.Strom;
                }
                return ret + _Staubsauger.Strom + _Fernseher.Strom;
            }
        }
    }
    public class Verbraucher
    {
        float _Wider;
        float _Span;

        static string STOHM = "R=U/I";

        public static string OhmschesGesetz ()
        {
            return STOHM;
        }

        public Verbraucher (float wider)
        {
            _Wider = wider;
        }

        public float Spannung
        {
            get
            {
                return _Span;
            }
            set
            {
                _Span = value;
            }
        }

        public float Strom
        {
            get
            {
                return _Span / _Wider;
            }
        }
    }
}
