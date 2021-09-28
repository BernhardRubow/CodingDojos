using System;
using System.Data;
using Common;
using KataLogic.Interfaces;
using KataLogic.KataLogic;

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
        }
    }
}
