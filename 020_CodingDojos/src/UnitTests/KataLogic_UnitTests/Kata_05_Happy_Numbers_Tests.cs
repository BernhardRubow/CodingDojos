using NUnit.Framework;
using KataLogic.Katas.HappyNumbers;

namespace KataLogic_UnitTests
{
    public class Kata_05_Happy_Numbers_Tests
    {
        [Test]
        public void Test_convert_numbers_to_ziffer_list_works()
        {
            var result = 19.GetZifferList();

            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 9);


            result = 42.GetZifferList();

            Assert.AreEqual(result[0], 4);
            Assert.AreEqual(result[1], 2);
        }

        [Test]
        public void Test_IsHappyNumer_works()
        {
            int numberToTest;
            bool result;

            numberToTest = 10;
            result = Kata_05_Logic.IsHappyNumber(numberToTest);
            Assert.AreEqual(true, result);
            
            numberToTest = 11;
            result = Kata_05_Logic.IsHappyNumber(numberToTest);
            Assert.AreEqual(false, result);
        }
    }
}