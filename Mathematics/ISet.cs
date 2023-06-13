using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    internal interface ISet<T>
    {
        Set<T> Intersection(Set<T> other);
        Set<T> Union(Set<T> other);
        bool Contains(T element);
        Set<T> Minus(Set<T> other);
        void AddElement(T element);
        Set<T> SymmetricDifference(Set<T> other);
    }
}
