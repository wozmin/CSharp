using CSharpTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTask
{
    public class Article:IRateAndCopy
    {
        public Person Author { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }


        public Article()
        {
            Author = new Person("Andrii","Ikavetc");
            Name = "Author Article";
            Rating = 20;
        }

        public Article(Person author,string name,double rating)
        {
            Author = author;
            Name = name;
            Rating = rating;
        }

        public object DeepCopy()
        {
            Person author = new Person(this.Author.Name, this.Author.Surname);
            return new Article
            {
                Author = author,
                Name = this.Name,
                Rating = this.Rating
            };
        }

        public override string ToString()
        {
            return $"Artilce: {Name}, Author{Author.Name},Rating:{Rating}";
        }
    }
}
