using System;
using System.Collections.Generic;
using System.Data;
using Common;
using KataLogic.Interfaces;
using KataLogic.Katas.CSV;
using KataLogic.Katas.FizzBuzz;
using KataLogic.Katas.HappyNumbers;

namespace Dojo_Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            ICodingKata codingKata_01 = new Kata_01_Logic();
            codingKata_01.Execute();
            Console.WriteLine(codingKata_01.Result);
            
            ICodingKata codingKata_02 = new Kata_02_Logic();
            codingKata_02.SetContent(17);
            codingKata_02.Execute();
            Console.WriteLine(codingKata_02.Result);


            ICodingKata codingKata_05 = new Kata_05_Logic();
            codingKata_05.SetContent(new List<int>{10,11,12,13,14,15,16,17,18,19,20});
            codingKata_05.Execute();
            Console.WriteLine(codingKata_05.Result);
        }
    }
}
