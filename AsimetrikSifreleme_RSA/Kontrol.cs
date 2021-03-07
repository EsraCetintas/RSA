using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsimetrikSifreleme_RSA
{
    class Kontrol
    {
        public bool AsalSayiKontrol(BigInteger sayi)
        {
            int i = 2;
            while (i < sayi)
            {
                if (sayi%i == 0)
                {
                    return false;
                }

                i++;
            }
            return true;
        }

        public bool eKontrol(BigInteger sayi)
        {
            if (BigInteger.GreatestCommonDivisor(sayi, AnahtarOlusturma.T) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
