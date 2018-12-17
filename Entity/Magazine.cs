using CSharpTask.Entity;
using CSharpTask.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpTask
{
    public class Magazine : Edition, IRateAndCopy
    {

        public Magazine()
        {
            _name = "Magazine";
            _frequency = Frequency.Weekly;
            _date = DateTime.Now;
            _circulation = 4;
        }

        public Magazine(string name, Frequency frequency, DateTime date, int circulation)
        {
            Name = name;
            Frequency = frequency;
            Date = date;
            Circulation = circulation;
        }


        private string _name;
        private Frequency _frequency;
        private DateTime _date;
        private int _circulation;
        private List<Article> _articles;
        private List<Person> _editors;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Frequency Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public int Circulation
        {
            get { return _circulation; }
            set { _circulation = value; }
        }

        public List<Article> Articles
        {
            get { return _articles ?? (new List<Article>()); }
            set { _articles = value; }
        }

        public List<Person> Editors {
            get { return _editors ?? (new List<Person>()); }
            set { _editors = value; }
        }


        public double AvgArticlesRating
        {
            get
            {
                double sum = 0;
                foreach (Article article in Articles)
                {
                    sum += article.Rating;
                }
                return sum / Articles.Count;
            }
        }

        public double Rating {
            get => AvgArticlesRating;
        }

        public Edition Edition
        {
            get => new Edition(base.Overlayin, base.ProductionDate, base.EditionName);
            set
            {
                base.EditionName = value.EditionName;
                base.Overlayin = value.Overlayin;
                base.ProductionDate = value.ProductionDate;
            }
        }

        public bool this[Frequency index]
        {
            get
            {
                return this.Frequency == index;
            }
        }

        public void AddArticles(params Article[] articles)
        {
            foreach(Article article in articles)
            {
                Articles.Add(article);
            }
        }

        public void AddEditors(params Person[] people)
        {
            foreach(Person person in people)
            {
                Editors.Add(person);
            }
        }

        public IEnumerable GetArticlesByRating(double rating)
        {
            foreach(Article article in Articles)
            {
                if(article.Rating > rating)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetArticlesByName(string name)
        {
            foreach (Article article in Articles)
            {
                if (article.Name.Contains(name))
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetArticlesWithAuthorsEditors()
        {
            foreach(Article article in Articles)
            {
                if (Editors.Contains(article.Author))
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetEditorsWithoutArticles()
        {
            foreach(Person editor in Editors)
            {
                foreach(Article article in Articles)
                {
                    if (article.Author.Equals(editor))
                    {
                        yield return editor;
                        yield break;
                    }
                }
            }
        }

        public override object DeepCopy()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            string info =  $"Magazine name:{Name}\n" +
                   $"Magazine frequency:{Frequency}\n" +
                   $"Production data:{Date.ToString("dd-MM-yyyy")}\n" +
                   $"Circulation:{Circulation}\n" +
                   $"Average articles rating:{AvgArticlesRating}\n" +
                   $"Overlayin:{Overlayin}\n" +
                   $"Edition:{EditionName}";
            return info;
        }

        public string ToShortString()
        {
            return $"Magazine name:{Name}\n" +
                   $"Magazine frequency:{Frequency}\n" +
                   $"Production data:{Date.ToString("dd:MM:yyyy")}\n" +
                   $"Circulation:{Circulation}\n" +
                   $"Average articles rating:{AvgArticlesRating}";
        }
    }
}
