using Common.ExtensionMethods;
using KataLogic.Interfaces;
using KataLogic.KataLogic;
using NUnit.Framework;

namespace KataLogic_UnitTests
{
    public class Kata_02_FizzBuzz_Tests
    {
        private string m_Result;

        [SetUp]
        public void Setup()
        {
             m_Result = @"1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
16
";
        }

        [Test]
        public void Test1_result_is_not_null_with_given_content()
        {
            ICodingKata Kata_02_Logic = new Kata_02_Logic();
            Kata_02_Logic.Execute();

            Assert.NotNull(Kata_02_Logic.Result);
        }

        [Test]
        public void Test1_returns_valid_string_for_first_16_numbers()
        {
            ICodingKata Kata_02_Logic = new Kata_02_Logic();
            Kata_02_Logic.SetContent(17);
            Kata_02_Logic.Execute();

            var result = Kata_02_Logic.Result;
            Assert.AreEqual(m_Result, result.UnboxAs<string>());
        }
    }
}