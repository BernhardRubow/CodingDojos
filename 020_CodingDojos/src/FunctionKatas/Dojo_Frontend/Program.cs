using System.Data;
using Common;
using KataLogic.Interfaces;
using KataLogic.Kata_01_CSV;

namespace Dojo_Frontend
{
    class Program
    {

        static void Main(string[] args)
        {

            ICodingKata codingKata_01 = new CSV_Helper();
            codingKata_01.Execute();



        }
    }
}
