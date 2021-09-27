using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dojo_01_CSV
{
    class Program
    {
        private static string[,] colummnValues = null;
        private static int[] columnWidths = null;

        static void Main(string[] args)
        {
            var CSV_zeilen = @"
Name;Strasse;Ort;Alter
Peter Pan;Am Hang 5;12345 Einsam;42
Maria Schmitz;Kölner Straße 45;50123 Köln;43
Paul Meier;Münchener Weg 1;87654 München;65
".SplitByString(Environment.NewLine);

            var result = Tabelliere(CSV_zeilen);

            foreach (var row in result)
            {
                Console.WriteLine(row);
            }

            
        }

        public static IEnumerable<string> Tabelliere(IEnumerable<string> CSV_zeilen)
        {
            var rows = CSV_zeilen.ToArray();
            
            for (int i = 0; i < rows.Length; i++)
            {
                var cols = rows[i].SplitByString(";").ToArray();

                colummnValues ??= new string[rows.Length, cols.Length];
                columnWidths ??= new int[cols.Length];

                for (int j = 0; j < cols.Length; j++)
                {
                    colummnValues[i, j] = cols[j];
                    if (columnWidths[j] < cols[j].Length) columnWidths[j] = cols[j].Length;
                }
            }

            List<string> result = new List<string>();
            for (int i = 0; i < rows.Length; i++)
            {
                string line = "|";
                for (int j = 0; j < columnWidths.Length; j++)
                {
                    line += colummnValues[i, j].PadRight(columnWidths[j]) + "|";
                }
                result.Add(line);
            }



            return result;
        }



    }

    public static class ExtensionMethods
    {
        public static IEnumerable<string> SplitByString(this string s, string splitString)
        {
            string[] values = s.Split(new[] { splitString }, StringSplitOptions.RemoveEmptyEntries);

            return values.ToList();
        }
    }
}
