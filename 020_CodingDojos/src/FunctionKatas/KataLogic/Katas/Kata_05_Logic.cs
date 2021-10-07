using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ExtensionMethods;
using KataLogic.Interfaces;

namespace KataLogic.Katas.HappyNumbers
{
    /// <summary>
    /// Function Kata “Fröhliche Zahlen”
    /// Entwickle eine Funktion, die erkennt, ob eine Zahl „fröhlich“ ist oder nicht.
    ///
    /// Eine Fröhliche Zahl ist eine Zahl, bei der die Summe der Quadrate ihrer Ziffern „auf die Dauer“ 1 ergibt.Beispiel:
    /// 19 -> 1^2 + 9^2 = 82 -> 8^2 + 2^2 = 68 -> 6^2 + 8^2 = 100 -> 1^2 + 0^2 + 0^2 = 1
    ///
    /// Ermittle alle Fröhlichen Zahlen in einem Zahlenbereich, z.B. von 10 bis 20.
    /// </summary>
    public class Kata_05_Logic : ICodingKata
    {
        private object result;
        private List<int> m_NumberList;

        public object Result => result;

        public void SetContent(object content)
        {
            m_NumberList = content.UnboxAs<List<int>>();
        }

        public void Execute()
        {
            var sb = new StringBuilder();
            foreach (var number in m_NumberList)
            {
                sb.AppendLine($"{number} is as happy number: { Kata_05_Logic.IsHappyNumber(number) }");
            }

            result = sb.ToString();
        }

        /// <summary>
        /// Recursice Methode, which determins if a number is a happy number
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <returns>true or false</returns>
        public static bool IsHappyNumber(int number)
        {
            
            var zifferList = number.GetZifferList();

            int sum = 0;
            foreach (var ziffer in zifferList)
            {
                // build the sum of all quads of all digit
                // in given number 
                sum += ziffer * ziffer;
            }

            // cancelation conditions
            if (sum == 1) return true;
            if (sum < 10) return false;

            // recursive call
            return IsHappyNumber(sum);
        }
    }

    public static class Kata05Extensions
    {
        public static List<int> GetZifferList(this int number)
        {
            var zifferList = new List<int>();

            var ziffernString = number.ToString();

            for (int i = 0; i < ziffernString.Length; i++)
            {
                char z = ziffernString[i];
                zifferList.Add(z-48);
            }

            return zifferList;
        }

        
    }
}
