using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{

    public class Haus : IEnumerable<IVerbraucher>, IEnumerator, IEnumerator<IVerbraucher>
    {
        IVerbraucher _Staubsauger;
        IVerbraucher _Fernseher;
        List<IVerbraucher> _Sonstige;

        public void serialize()
        {
            
        }

        public IVerbraucher CreateStaubsaugerFactoryMethod()
        {
            return new Verbraucher(1000);
        }

        public IEnumerator<IVerbraucher> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Haus ()
        {
            _Sonstige = new List<IVerbraucher>();
            _Sonstige.Add(new Verbraucher(-100));
            _Sonstige.Add(new Verbraucher(300));
            _Sonstige.Add(new Wasserkocher());
            _Staubsauger = new Verbraucher(1000);
            _Fernseher = new Verbraucher(200);

            

            float geld = 0;
            foreach (IVerbraucher veb in _Sonstige)
            {
                if (veb is IGeldverbraucher)
                {
                    geld += ((IGeldverbraucher)veb).Geld;
                }
            }
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

        public object Current => throw new NotImplementedException();

        IVerbraucher IEnumerator<IVerbraucher>.Current => throw new NotImplementedException();
    }

    public interface ISerializable
    {
        string serialize();
        void deserialize(string stDaten);
    }

    public interface IVerbraucher
    {
        float Strom { get; }
    }

    public interface IGeldverbraucher
    {
        float Geld { get; }
    }

    public class Wasserkocher : IVerbraucher, IGeldverbraucher
    {
        public float Strom
        {
            get
            {
                return 10;
            }
        }

        public float Geld
        {
            get
            {
                return 0;
            }
        }
    }

    public class Verbraucher : IVerbraucher
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
