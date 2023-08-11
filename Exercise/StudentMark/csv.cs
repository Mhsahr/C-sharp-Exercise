using CSV.Models;
using LINQtoCSV;
using System.Collections.Generic;
using StudentMark.App;


//Install LINQtoCSV

namespace CSV
{
    class Csv
    {

        public static void WriteCsvFile()
        {
            var learner = new Table();


            var countryList = new List<Student>
            {
                new Student{ID =learner.Id, Firstname = learner.fname, Lastname=learner.lname, Score= learner.score},

            };



            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',
            };

            var csvContext = new CsvContext();
            csvContext.Write(countryList, "scorelist.csv", csvFileDescription);
            System.Console.WriteLine("CSV File Created");

        }

        public static void ReadCsvFile()
        {
            var csvFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                SeparatorChar = ',',
                UseFieldIndexForReadingData = false,
            };

            var csvContext = new CsvContext();
            var school = csvContext.Read<Student>("marklist.csv", csvFileDescription);

            foreach (var item in school)
            {
                System.Console.WriteLine($"{item.ID}| {item.Firstname}| {item.Lastname}| {item.Score}");

            }
        }
    }
}
