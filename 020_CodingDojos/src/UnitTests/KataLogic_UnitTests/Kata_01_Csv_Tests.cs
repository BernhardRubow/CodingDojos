using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataLogic.Interfaces;
using KataLogic.KataLogic;
using NUnit.Framework;

namespace KataLogic_UnitTests
{
    [TestFixture]
    public class Kata_01_Csv_Tests
    {
        private string m_TestCsvString;
        private string m_Result;

        [SetUp]
        public void Setup()
        {
            m_TestCsvString = @"
Name;Strasse;Ort;Alter
Peter Pan;Am Hang 5;12345 Einsam;42
Maria Schmitz;Kölner Straße 45;50123 Köln;43
Paul Meier;Münchener Weg 1;87654 München;65
";

            m_Result = $"|Name         |Strasse         |Ort          |Alter|\r\n" +
                       $"|Peter Pan    |Am Hang 5       |12345 Einsam |42   |\r\n" +
                       $"|Maria Schmitz|Kölner Straße 45|50123 Köln   |43   |\r\n" +
                       $"|Paul Meier   |Münchener Weg 1 |87654 München|65   |\r\n";
        }

        [Test]
        public void Test_result_with_given_content_is_not_null()
        {
            ICodingKata kata = new Kata_01_Logic();
            kata.SetContent(m_TestCsvString);
            kata.Execute();

            var result = kata.Result;

            Assert.IsNotNull(result);
        }

        [Test]
        public void Test_result_with_given_content_is_padded_correctly()
        {
            ICodingKata kata = new Kata_01_Logic();
            kata.SetContent(m_TestCsvString);
            kata.Execute();

            var result = kata.Result;

            Assert.AreEqual(m_Result,result);
        }
    }
}
