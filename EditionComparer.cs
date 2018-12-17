using CSharpTask.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTask
{
    public class EditionComparer : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            return x.Overlayin.CompareTo(y.Overlayin);
        }
    }
}
