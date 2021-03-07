using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsimetrikSifreleme_RSA
{
    class Sifreleme
    {
        private static string sifreliMetin;
        public static string SifreliMetin
        {
            get { return sifreliMetin; }
            set { sifreliMetin = value; }
        }

        ASCIITablosu tablo = new ASCIITablosu();
        public string KodMetinBul()
        {
            string metin = Form1.metin;
            string kodMetin = "";

            for (int i = 0; i < metin.Length; i++)
            {
                if (tablo.KodBulma(metin[i]) < 100)
                {
                    kodMetin += "0" + tablo.KodBulma(metin[i]);
                }
                else
                {
                    kodMetin += tablo.KodBulma(metin[i]);
                }
            }
            return kodMetin;
        }

        int LClear;
        int LCipher;
        public void LBul()
        {
            string sayi = AnahtarOlusturma.N.ToString();
            LClear = sayi.Length - 1;
            LCipher = sayi.Length;
        }


        public List<string> KodMetinParcala()
        {
            string kodMetin = KodMetinBul();
            int i = 0, j = 0, k = 0;
            string sayi = "";
            int mod = kodMetin.Length % LClear;
            List<string> sayilar = new List<string>();

            if (mod != 0)
            {
                for (int x = 0; x < LClear - mod; x++)
                {
                    kodMetin = kodMetin + "0";
                }
            }

            while (k < kodMetin.Length)
            {
                j = 0;
                while (j < LClear)
                {
                    if (i < kodMetin.Length)
                    {
                        sayi += kodMetin[i];
                        i++;
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                sayilar.Add(sayi);
                sayi = "";
                k = k + LClear;
            }
            return sayilar;
        }

        public List<string> MetinSifrele()
        {
            LBul();
            ASCIITablosu tablo = new ASCIITablosu();
            BigInteger m;
            sifreliMetin = "";
            string k;
            BigInteger c;
            List<string> sayilar2 = new List<string>();
            List<string> sayilar3 = new List<string>();

            sayilar2 = KodMetinParcala();

            foreach (var sayi in sayilar2)
            {
                m =Convert.ToInt32(sayi);
                BigInteger usSonuc =BigInteger.Pow(m,(int)AnahtarOlusturma.E);
                c = BigInteger.Remainder(usSonuc,AnahtarOlusturma.N);
                k = c.ToString();

                if (k.Length < LCipher)
                {
                    for (int i = 0; i <= LCipher - k.Length; i++)
                    {
                        k = "0" + k;
                    }
                    sayilar3.Add(k);
                    sifreliMetin = sifreliMetin + k;
                }
                else
                {
                    sayilar3.Add(k);
                    sifreliMetin = sifreliMetin + k;
                }
            }
            
            return sayilar3;
        }
    }
}
