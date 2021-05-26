using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{

    public class ValidationOthers
    {
        public static bool ValidCard(string cardNumber)
        {
            if (cardNumber.Length != 16) return false;
            int say = 0;
            for (int i = 0; i < cardNumber.Length; i++)
            {
                int tasi = int.Parse(cardNumber.Substring(i, 1));
                if (i % 2 == 0)
                {
                    tasi *= 2;
                    if (tasi > 9)
                    {
                        string tasima = tasi.ToString();
                        tasi = int.Parse(tasima.ToString().Substring(0, 1)) + int.Parse(tasima.ToString().Substring(1, 1));
                    }

                }
                say += tasi;

            }
            if (say % 10 == 0) return true; else return false;
        }
    }
}
