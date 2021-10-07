using System.Text;
using KataLogic.Interfaces;

namespace KataLogic.Katas.FizzBuzz
{
    public class Kata_02_Logic : ICodingKata
    {
        // +++ fields +++
        public object m_Result;
        private int m_UpperBoundary;


        // +++ properties +++
        
        // +++ ICodingKata implementation +++
        public object Result => m_Result;

        public void SetContent(object content)
        {
             m_UpperBoundary = (int) content;
        }

        public void Execute()
        {
            var sb = new StringBuilder();

            for (int i = 1; i < m_UpperBoundary; i++)
            {
                if (!IsMultipleOf3(i) && !IsMultipleOf5(i))
                {
                    sb.AppendLine(i.ToString());
                }
                else
                {
                    if (IsMultipleOf3(i)) sb.Append("Fizz");
                    if (IsMultipleOf5(i)) sb.Append("Buzz");
                    sb.AppendLine();
                }
            }
            m_Result = sb.ToString();
        }

        // +++ member +++
        private bool IsMultipleOf3(int number)
        {
            return number % 3 == 0;
        }
        private bool IsMultipleOf5(int number)
        {
            return number % 5 == 0;
        }
    }
}
