using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTask.Interfaces
{
    public interface IRateAndCopy
    {
        double Rating { get;}
        object DeepCopy();
    }
}
