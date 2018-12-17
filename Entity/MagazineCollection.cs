using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTask.Entity
{

    public class MagazineCollection:IEnumerable
   {
        public delegate void MagazineListHandler (object source, MagazineListHandlerEventArgs args);
        public event  MagazineListHandler MagazineAdded;
        public event  MagazineListHandler MagazineReplaced;
        private List<Magazine> _magazines;

        public MagazineCollection()
        {
            _magazines = new List<Magazine>();
        }

        public IEnumerable<Magazine> MonthlyMagazines
        {
            get
            {
                return _magazines.Where(m => m.Frequency.Equals(Frequency.Monthly));
            }
        }

        public double MaxArticlesRating
        {
            get
            {
                return _magazines.Max(m => m.AvgArticlesRating);
            }
        }

        public string CollectionName {get;set;}

        public Magazine this[int index] {
            get => _magazines[index];
            set  {
                _magazines[index] = value;
                 MagazineAdded(this,new MagazineListHandlerEventArgs (
                "Magazines",
                "Replace",
                index
            ));
            }
        }
        
        public void AddDefaults()
        {
            _magazines.Add(new Magazine
            {
                Name = "My Magazine",
                Circulation = 2,
                Date = DateTime.Now,
                Frequency = Frequency.Yearly,
                Overlayin = 200,
                ProductionDate = DateTime.Now.Subtract(TimeSpan.FromDays(3)),
                Articles = new List<Article>
                {
                    new Article
                    {
                        Author = new Person("Andrii","Ikavetc"),
                        Name = "My article",
                        Rating = 200
                    }
                },
                Editors = new List<Person>
                {
                    new Person("Taras","Sheketa"),
                    new Person ("Olexandr","Vetoshkin")
                },
                EditionName = "My Edition"
            });
            if(MagazineAdded !=null){
                 MagazineAdded(this,new MagazineListHandlerEventArgs (
                     "Magazines",
                     "Add",
                     _magazines.Count
                ));
            }
            _magazines.Add(new Magazine
            {
                Name = "Your Magazine",
                Circulation = 6,
                Date = DateTime.Now,
                Frequency = Frequency.Monthly,
                Overlayin = 100,
                ProductionDate = DateTime.Now.Subtract(TimeSpan.FromDays(6)),
                Articles = new List<Article>
                {
                    new Article
                    {
                        Author = new Person("Andrii","Ikavetc"),
                        Name = "Your article",
                        Rating = 100
                    }
                },
                Editors = new List<Person>
                {
                    new Person("Taras","Sheketa"),
                    new Person ("Olexandr","Vetoshkin")
                },
                EditionName = "Your Edition"
            });
            if(MagazineAdded !=null){
                 MagazineAdded(this,new MagazineListHandlerEventArgs (
                     "Magazines",
                     "Add",
                     _magazines.Count
                ));
            }
        }

        public List<Magazine> SortByEditionName()
        {
            var sortedMagazines = _magazines;
            sortedMagazines.Sort(new Edition());
            return sortedMagazines;
        }

        public List<Magazine> SortByProductionDate()
        {
            return _magazines.OrderBy(x => x.ProductionDate).ToList();
        }

        public List<Magazine> SortByOverlaying()
        {
            return _magazines.OrderBy(x => x.Overlayin).ToList();
        }




        public List<Magazine> RatingGroup(double value)
        {
            return _magazines.Where(m => m.AvgArticlesRating >= value).ToList();
        }

        public bool Replace(int index,Magazine magazine){
            Magazine item = _magazines.ElementAtOrDefault(index);
            if(item is null){
                return false;
            }
            _magazines[index] = magazine;
             MagazineAdded(this,new MagazineListHandlerEventArgs (
                "Magazines",
                "Replace",
                index
            ));
            return true;
        }



        public virtual string ToShortString()
        {
            string magazinesInfo = "";
            foreach (var magazine in _magazines)
            {
                magazinesInfo += magazine.ToShortString() + "\n";
            }
            return magazinesInfo;
        }

        public override string ToString()
        {
            string magazinesInfo="";
            foreach(var magazine in _magazines)
            {
                magazinesInfo += magazine.ToString() + "\n";
            }
            return magazinesInfo;
        }

        public IEnumerator GetEnumerator()
        {
            return _magazines.GetEnumerator();
        }
    }
}
