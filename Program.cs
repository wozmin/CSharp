using CSharpTask.Entity;
using System;

namespace CSharpTask
{
    class Program
    {
        static void Main(string[] args)
        {
            MagazineCollection collection1 = new MagazineCollection();
            MagazineCollection collection2 = new MagazineCollection();
            Listenter listener1 = new Listenter();
            Listenter listener2 = new Listenter();
            collection1.MagazineAdded += listener1.OnCollectionChanged;
            collection1.MagazineReplaced += listener1.OnCollectionChanged;
            collection1.MagazineAdded += listener2.OnCollectionChanged;
            collection1.MagazineAdded += listener1.OnCollectionChanged;
            collection1.AddDefaults();
            collection2.AddDefaults();
            Console.WriteLine("First listener output");
            Console.WriteLine(listener1.ToString());
             Console.WriteLine("Second listener output");
            Console.WriteLine(listener2.ToString());

        }
    }
}
