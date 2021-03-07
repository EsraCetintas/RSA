using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsimetrikSifreleme_RSA
{
    class Desifreleme
    {
        private string kodMetin = "";
        public static string DesifreliMetin;
        List<string> sayilar = new List<string>();


        int LClear;
        int LCipher;
        public void LBul()
        {
            string sayi = AnahtarOlusturma.N.ToString();
            LClear = sayi.Length - 1;
            LCipher = sayi.Length;
        }

        public List<string> MetinDesifrele()
        {
            ASCIITablosu tablo = new ASCIITablosu();
            int c;
            DesifreliMetin = "";
            string k;
            BigInteger m;
            Sifreleme sifreleme = new Sifreleme();
            foreach (var sayi in sifreleme.MetinSifrele())
            {
                c = Convert.ToInt32(sayi);
                BigInteger usSonuc =BigInteger.Pow(c,(int)AnahtarOlusturma.D);
                m = BigInteger.Remainder(usSonuc,AnahtarOlusturma.N);
                k = m.ToString();

                if (k.Length < LClear)
                {
                    for (int i = 0; i <= LClear - k.Length; i++)
                    {
                        k = "0" + k;
                    }
                    kodMetin = kodMetin + k;
                }
                else
                {
                    kodMetin = kodMetin + k;
                }
            }

            int x = 0, j, p = 0;
            string kod = "";
            while (x < kodMetin.Length)
            {
                j = 0;
                while (j < 3)
                {
                    if (p < kodMetin.Length)
                    {
                        kod += kodMetin[p];
                        p++;
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                sayilar.Add(kod);
                kod = "";
                x = x + 3;
            }

            Sil();

            foreach (var sayi2 in sayilar)
            {
                DesifreliMetin = DesifreliMetin + tablo.KarakterBulma(Convert.ToInt32(sayi2));
            }

            return sayilar;
        }

        public List<string> Sil()
        {
            for (int i = 0; i < sayilar.Count; i++)
            {
                if (sayilar[i].Length != 3)
                {
                    sayilar.Remove(sayilar[i]);
                }
            }
            return sayilar;
        }
    }
}
