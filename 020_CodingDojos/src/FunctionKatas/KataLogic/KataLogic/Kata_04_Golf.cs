using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataLogic.Interfaces;

namespace KataLogic.KataLogic
{
    public class Kata_04_Golf : ICodingKata
    {
        private object result;
        private Data data;

        public object Result => result;

        public void SetContent(dynamic content)
        {
            var p = content as Dictionary<string, int>;
            data = new Data
            {
                Par = p["par"],
                Strokes = p["strokes"]
            };
        }

        public void Execute()
        {
            // Rules
            var holeInOneRule = new HoleInOneRuleChecker();
            var tripleEagleRuleChecker = new TripleEagleRuleChecker();
            var doubleEagleRuleChecker = new DoubleEagleRuleChecker();
            var eagleRuleChecker = new EagleRuleChecker();
            var birdyRuleChecker = new BirdyRuleChecker();
            var parRuleChecker = new ParRuleChecker();
            var tripleBogeyRuleChecker = new TripleBogeyRuleChecker();
            var doubleBogeyRuleChecker = new DoubleBogeyRuleChecker();
            var bogeyRuleChecker = new BogeyRuleChecker();
            var lastRuleChecker = new LastRuleChecker();

            // Rule config
            holeInOneRule.SetNextRule(tripleEagleRuleChecker);
            tripleEagleRuleChecker.SetNextRule(doubleEagleRuleChecker);
            doubleEagleRuleChecker.SetNextRule(eagleRuleChecker);
            eagleRuleChecker.SetNextRule(birdyRuleChecker);
            birdyRuleChecker.SetNextRule(parRuleChecker);
            parRuleChecker.SetNextRule(tripleBogeyRuleChecker);
            tripleBogeyRuleChecker.SetNextRule(doubleBogeyRuleChecker);
            doubleBogeyRuleChecker.SetNextRule(bogeyRuleChecker);
            bogeyRuleChecker.SetNextRule(lastRuleChecker);


            result = holeInOneRule.CheckRule(data);
        }
    }

    public class Data
    {
        public int Par { get; set; }

        public int Strokes { get; set; }
    }



    public class HoleInOneRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            if (dataToCheck.Par == 3 && dataToCheck.Strokes == 1) return "Hole In One";
            
            else return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class TripleEagleRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == -4) return "Triple Eagle";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class DoubleEagleRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == -3) return "Double Eagle";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class EagleRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == -2) return "Eagle";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class BirdyRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == -1) return "Birdy";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class ParRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == 0) return "Par";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class BogeyRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == 1) return "Bogey";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class DoubleBogeyRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == 2) return "Double Bogey";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class TripleBogeyRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            m_Data = dataToCheck;
            if (DiffStrokes == 3) return "Triple Bogey";

            return m_nextRule.CheckRule(dataToCheck);
        }
    }

    public class LastRuleChecker : RuleChecker
    {
        public override string CheckRule(Data dataToCheck)
        {
            return "Loser";
        }
    }

    public class RuleChecker
    {
        protected Data m_Data;
        protected RuleChecker m_nextRule;

        public int DiffStrokes => m_Data.Strokes - m_Data.Par;

        public void SetNextRule(RuleChecker nextRule)
        {
            m_nextRule = nextRule;
        }

        public virtual string CheckRule(Data dataToCheck)
        {
            return "unknown";
        }
    }
}
