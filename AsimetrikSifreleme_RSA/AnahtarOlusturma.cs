using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsimetrikSifreleme_RSA
{
    class AnahtarOlusturma
    {
        public static BigInteger p;
        public static BigInteger q;
        private static BigInteger n;
        private static BigInteger t;
        private static BigInteger e;
        private static BigInteger d;
       
        public static BigInteger N
        {
            get { return n; }
            set { n = value; }
        }

        public static BigInteger T
        {
            get { return t; }
            set { t = value; }
        }

        public static BigInteger E
        {
            get { return e; }
            set { e = value; }
        }
        public static BigInteger D
        {
            get { return d; }
            set { d = value; }
        }

        public void pUret()
        {
            Random rnd = new Random();
            Kontrol kontrol = new Kontrol();
            while (true)
            {
                p = rnd.Next(2, 1000);
                if (kontrol.AsalSayiKontrol(p))
                {
                    break;
                }
            }
        }

        public void qUret()
        {
            Random rnd = new Random();
            Kontrol kontrol = new Kontrol();
            while (true)
            {
                q = rnd.Next(2, 1000);
                if (kontrol.AsalSayiKontrol(q) && p != q)
                {
                    break;
                }
            }
        }

        public void nBulma()
        {
            n =p*q;
        }

        public void Totient()
        {
            t =(p - 1)*(q - 1);
        }

        public void eBulma()
        {
            Kontrol kontrol = new Kontrol();
            Random random = new Random();
            while (true)
            {
                e = random.Next(2, (int)t);
                if (kontrol.eKontrol(e))
                {
                    break;
                }
            }
        }

        public BigInteger dBulma()
        {
            BigInteger say;
            d = 1;
            while (true)
            {
                say = d * e;
                if (say % t == 1 && e!=d)
                {
                    break;
                }
                d++;
            }
            return d;
        }

    }
}
   