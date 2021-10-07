using System.Collections.Generic;
using KataLogic.Katas.Golf;
using NUnit.Framework;

namespace KataLogic_UnitTests
{
    public class Kata_04_Golf_Tests
    {
        [Test]
        public void Test_result_is_not_null_with_given_parameters()
        {
            var logic = new Kata_04_Golf();

            var p = new Dictionary<string, int>{ {"par",3}, {"strokes",1}};

            logic.SetContent(p);

            logic.Execute();

            Assert.NotNull(logic.Result);
        }


        [Test]
        public void Test_result_is_PAR_with_given_parameters()
        {
            var logic = new Kata_04_Golf();

            var p = new Dictionary<string, int>{ {"par",3}, {"strokes",3}};

            logic.SetContent(p);

            logic.Execute();

            Assert.AreEqual("Par", logic.Result);
        }

        [Test]
        public void Test_result_is_Loser_with_given_parameters()
        {
            var logic = new Kata_04_Golf();

            var p = new Dictionary<string, int>{ {"par",3}, {"strokes",15}};

            logic.SetContent(p);

            logic.Execute();

            Assert.AreEqual("Loser", logic.Result);
        }


        [Test]
        public void Test_result_is_DoubleBogey_with_given_parameters()
        {
            var logic = new Kata_04_Golf();

            var p = new Dictionary<string, int>{ {"par",5}, {"strokes",7}};

            logic.SetContent(p);

            logic.Execute();

            Assert.AreEqual("Double Bogey", logic.Result);
        }


        [Test]
        public void Test_result_is_Birdy_with_given_parameters()
        {
            var logic = new Kata_04_Golf();

            var p = new Dictionary<string, int>{ {"par",4}, {"strokes",3}};

            logic.SetContent(p);

            logic.Execute();

            Assert.AreEqual("Birdy", logic.Result);
        }


        [Test]
        public void Test_result_is_Bogey_with_given_parameters()
        {
            var logic = new Kata_04_Golf();

            var p = new Dictionary<string, int>{ {"par",3}, {"strokes",4}};

            logic.SetContent(p);

            logic.Execute();

            Assert.AreEqual("Bogey", logic.Result);
        }
    }
}