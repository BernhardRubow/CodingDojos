using System;
using System.Collections.Generic;
using Common.ExtensionMethods;
using KataLogic.Interfaces;

namespace KataLogic.Katas.RomanNumerals
{
    public class Kata_03_RomanNumerals : ICodingKata
    {
        // +++ fields +++
        private int m_Result;
        public string m_RomanNumber;
        public Dictionary<char, int> m_NumberIndices;
        public Action<char> m_ProcessState;
        public Dictionary<char, int> m_NumberValues;
        public int m_LastIndex = -1;
        public int? m_LastSubtractedIndex;



        // +++ life cycle +++
        public Kata_03_RomanNumerals()
        {
            m_NumberValues = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };

            m_NumberIndices = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 2},
                {'X', 3},
                {'L', 4},
                {'C', 5},
                {'D', 6},
                {'M', 7},
            };
        }


        // +++ ICodingKata +++
        public object Result => m_Result;

        public void SetContent(object content)
        {
            m_RomanNumber = content.UnboxAs<string>();
            m_Result = 0;
            m_LastIndex = -1;
        }

        public void Execute()
        {
            for (int i = m_RomanNumber.Length - 1; i > 0 -1; i--)
            {
                var c = m_RomanNumber[i];
                if (m_LastIndex <= m_NumberIndices[c])
                {
                    if (m_LastSubtractedIndex.HasValue && m_LastSubtractedIndex == m_NumberIndices[c])
                    {
                        m_Result = -1;
                        break;
                    }

                    m_Result += m_NumberValues[c];
                    m_LastSubtractedIndex = null;
                }
                else
                {
                    if (Math.Abs(m_LastIndex - m_NumberIndices[c]) > 2)
                    {
                        m_Result = -1;
                        break;
                    }

                    m_Result -= m_NumberValues[c];
                    m_LastSubtractedIndex = m_NumberIndices[c];
                }

                m_LastIndex = m_NumberIndices[c];
            }
        }
    }

    
}
