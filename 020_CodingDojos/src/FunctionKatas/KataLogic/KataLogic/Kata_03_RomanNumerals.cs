﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ExtensionMethods;
using KataLogic.Interfaces;

namespace KataLogic.KataLogic
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
        }

        public void Execute()
        {
            for (int i = m_RomanNumber.Length - 1; i > 0 -1; i--)
            {
                var c = m_RomanNumber[i];
                if (m_LastIndex <= m_NumberIndices[c])
                {
                    m_Result += m_NumberValues[c];
                }
                else
                {
                    if (Math.Abs(m_LastIndex - m_NumberIndices[c]) > 2)
                    {
                        m_Result = -1;
                        break;
                    }
                    
                    m_Result -= m_NumberValues[c];
                }

                m_LastIndex = m_NumberIndices[c];
            }
        }
    }

    
}
