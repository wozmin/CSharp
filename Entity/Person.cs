using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTask
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string name,string surname)
        {
            Name = name;
            Surname = surname;
        }

        public virtual object DeepCopy()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj is Person personToCompare)
            {
                return this.Name.Equals(personToCompare.Name) && this.Surname.Equals(personToCompare.Surname);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Surname.GetHashCode();
        }
    }
}
