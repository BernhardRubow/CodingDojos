using System.Collections.Generic;
using Common.ExtensionMethods;
using KataLogic.Katas;
using KataLogic.Katas.RomanNumerals;
using NUnit.Framework;

namespace KataLogic_UnitTests
{
    public class Kata_03_RomanNumbers_Tests
    {
        private Kata_03_RomanNumerals m_CodingKata;
        private Dictionary<string, int> m_TestCases;


        [SetUp]
        public void Setup()
        {
            m_CodingKata = new Kata_03_RomanNumerals();
            m_TestCases = new Dictionary<string, int>
            {
            
                {"MMDCXCVIII", 2698},
                {"I", 1},
                {"II", 2},
                {"XVI", 16},
                {"CML", 950},
            };
        }

        [Test]
        public void Test_TestCases()
        {
            foreach (var key in m_TestCases.Keys)
            {
                m_CodingKata.SetContent(key);
                m_CodingKata.Execute();
                var value = m_CodingKata.Result.UnboxAs<int>();
                Assert.AreEqual(m_TestCases[key], value);
            }
        }

        [Test]
        public void Test_Single()
        {
            m_CodingKata.SetContent("MMDCXCVIII");
            m_CodingKata.Execute();
            Assert.AreEqual(2698, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_I()
        {
            m_CodingKata.SetContent("I");
            m_CodingKata.Execute();
            Assert.AreEqual(1, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_II()
        {
            m_CodingKata.SetContent("II");
            m_CodingKata.Execute();
            Assert.AreEqual(2, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_V()
        {
            m_CodingKata.SetContent("V");
            m_CodingKata.Execute();
            Assert.AreEqual(5, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_VII()
        {
            m_CodingKata.SetContent("VII");
            m_CodingKata.Execute();
            Assert.AreEqual(7, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_IX()
        {
            m_CodingKata.SetContent("IX");
            m_CodingKata.Execute();
            Assert.AreEqual(9, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_XLII()
        {
            m_CodingKata.SetContent("XLII");
            m_CodingKata.Execute();
            Assert.AreEqual(42, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_XCIX()
        {
            m_CodingKata.SetContent("XCIX");
            m_CodingKata.Execute();
            Assert.AreEqual(99, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_MMXIII()
        {
            m_CodingKata.SetContent("MMXIII");
            m_CodingKata.Execute();
            Assert.AreEqual(2013, m_CodingKata.Result.UnboxAs<int>());
        }

        [Test]
        public void Test_IIX()
        {
            m_CodingKata.SetContent("IIX");
            m_CodingKata.Execute();
            Assert.AreEqual(-1, m_CodingKata.Result.UnboxAs<int>());
        }
    }
}