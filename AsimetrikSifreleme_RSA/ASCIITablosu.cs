using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsimetrikSifreleme_RSA
{
    class ASCIITablosu
    {
        public int KodBulma(char harf)
        {
            int kod = harf;
            return kod;
        }

        public char KarakterBulma(int sayi)
        {
            char karakter = Convert.ToChar(sayi);
            return karakter;
        }
    }
}
