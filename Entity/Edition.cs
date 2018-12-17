using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTask.Entity
{
    public class Edition:IComparable<Edition>,IComparer<Edition>
    {
        private int _overlaying;
        private DateTime _productionDate;
        protected string editionName;

        public DateTime ProductionDate
        {   
            get => _productionDate;
            set => _productionDate = value;
        }

        public string EditionName
        {
            get => editionName;
            set => editionName = value;
        }

        public int Overlayin
        {
            get => _overlaying;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The overlaying value must be grater than zero");
                }
                else
                {
                    _overlaying = value;
                }
            }
        }

        public Edition()
        {
            Overlayin = 100;
            ProductionDate = DateTime.Now;
            EditionName = "My edition";
        }

        public Edition(int overlaying, DateTime productionDate, string name)
        {
            Overlayin = overlaying;
            ProductionDate = productionDate;
            EditionName = name;
        }

        public virtual object DeepCopy()
        {
            return new Edition
            {
                EditionName = this.EditionName,
                Overlayin = this.Overlayin,
                ProductionDate = this.ProductionDate
            };
        }

        public override bool Equals(object obj)
        {
            if(obj is Edition edition)
            {
                return this.EditionName.Equals(edition.EditionName)
                    && this.ProductionDate.Equals(edition.ProductionDate)
                    && this.Overlayin == edition.Overlayin;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return EditionName.GetHashCode();
        }

        public override string ToString()
        {
            return $"Edition:{EditionName}\n" +
                   $"Overlayin:{Overlayin}" +
                   $"Production date:{ProductionDate.ToString("dd:MM:yyyy")}";

        }

        public int CompareTo(Edition other)
        {
            return this.EditionName.CompareTo(other.EditionName);
        }

        public int Compare(Edition x, Edition y)
        {
            return x.ProductionDate.CompareTo(y.ProductionDate);
        }
    }
}
