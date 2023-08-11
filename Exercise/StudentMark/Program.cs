using StudentMark.App;
using System;

namespace StudentMark
{
    class Program
    {
        static void Run(string[] args)
        {
            Table.MakeTable();
            
            CSV.Csv.ReadCsvFile();
            Console.ReadKey();
            CSV.Csv.WriteCsvFile();
            Table.InitEmployee();
        }
    }
}
