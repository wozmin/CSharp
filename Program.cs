using CSharpTask.Entity;
using System;

namespace CSharpTask
{
    class Program
    {
        static void Main(string[] args)
        {
            MagazineCollection collection = new MagazineCollection();
            collection.AddDefaults();
            foreach(var magazine in collection)
            {
                Console.WriteLine(magazine.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("Sorted by edition name");
            foreach (var magazine in collection.SortByEditionName())
            {
                Console.WriteLine(magazine.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("Sorted by production date");
            foreach (var magazine in collection.SortByProductionDate())
            {
                Console.WriteLine(magazine.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("Sorted by overlaying");
            foreach (var magazine in collection.SortByOverlaying())
            {
                Console.WriteLine(magazine.ToString());
                Console.WriteLine();
            }

            Console.WriteLine($"Max avg articles rating:{collection.MaxArticlesRating}");
            Console.WriteLine("Magazines with monthly frequency");
            foreach (var magazine in collection.MonthlyMagazines)
            {
                Console.WriteLine(magazine.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("Magazines with specified rating");
            foreach (var magazine in collection.RatingGroup(120))
            {
                Console.WriteLine(magazine.ToString());
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
