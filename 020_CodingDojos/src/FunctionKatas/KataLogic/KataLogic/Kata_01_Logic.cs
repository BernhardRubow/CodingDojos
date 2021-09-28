using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.ExtensionMethods;
using KataLogic.Interfaces;

namespace KataLogic.KataLogic
{
    public  class Kata_01_Logic : ICodingKata
    {
        // +++ fields +++
        private List<string> m_PaddedLines;
        private IEnumerable<string> m_CsvRows;
        private object m_Result;


        // +++ properties +++
        public List<string> paddedLines => m_PaddedLines;




        // +++ life cycle +++
        public Kata_01_Logic()
        {
            // Default Content
            var csv = @"
Name;Strasse;Ort;Alter
Peter Pan;Am Hang 5;12345 Einsam;42
Maria Schmitz;Kölner Straße 45;50123 Köln;43
Paul Meier;Münchener Weg 1;87654 München;65
";

            SetContent(csv);
        }




        // +++ ICodingKata Implementation +++
        public object Result => m_Result;

        public void SetContent(object content)
        {
            m_CsvRows = content
                .UnboxAs<string>()
                .SplitByString(Environment.NewLine);
        }

        public void Execute()
        {
            var lines  = Tablelize(m_CsvRows);

            m_Result = PrintLines(lines);
        }




        // +++ member +++
        /// <summary>
        /// Print the lines of an IEnumerable of String.
        /// </summary>
        /// <param name="lines">The lines to Print</param>
        private string PrintLines(IEnumerable<string> linesToPrint)
        {
            var sb = new StringBuilder();
            foreach (var line in linesToPrint)
            {
                sb.AppendLine(line);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts an IEnumerable of strings (with CSV-Content) to an IEnumerable list of pretty padded lines.
        /// </summary>
        /// <param name="csvContent">The csv lines to be padded</param>
        /// <returns>A IEnumerable of strings containing the padded content from the csv lines.</returns>
        public IEnumerable<string> Tablelize(IEnumerable<string> csvContent)
        {
            var result = BuildArrayFromCsvLines(csvContent);

            m_PaddedLines = BuildPaddedListFromArrayElements(
                result.valueArray,
                result.widthArray);

            return paddedLines;
        }

        /// <summary>
        /// Extracts a 2 dimensional value array and an array with the widths of each column.
        /// </summary>
        /// <param name="csvLines">The lines with the csv content</param>
        /// <returns>Tuple of values [0] valueArray [1] columnWidthArray</returns>
        private (string[,] valueArray, int[] widthArray) BuildArrayFromCsvLines(IEnumerable<string> csvContent)
        {
            var csvLines = csvContent.ToArray();

            string[,] colummnValues = null;
            int[] columnWidths = null;

            for (int i = 0; i < csvLines.Length; i++)
            {
                var cols = csvLines[i].SplitByString(";").ToArray();

                // create 2 dimensional array
                colummnValues ??= new string[csvLines.Length, cols.Length];
                columnWidths ??= new int[cols.Length];

                for (int j = 0; j < cols.Length; j++)
                {
                    colummnValues[i, j] = cols[j];
                    if (columnWidths[j] < cols[j].Length) columnWidths[j] = cols[j].Length;
                }
            }

            return (colummnValues, columnWidths);
        }

        private List<string> BuildPaddedListFromArrayElements(string[,] columnValues, int[] columnWidths)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < columnValues.GetLength(0); i++)
            {
                string line = "|";
                for (int j = 0; j < columnWidths.Length; j++)
                {
                    line += columnValues[i, j].PadRight(columnWidths[j]) + "|";
                }

                result.Add(line);
            }

            return result;
        }
    }
}