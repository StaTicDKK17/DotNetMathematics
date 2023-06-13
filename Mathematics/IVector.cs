using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    public interface IVector
    {
        float[] ToArray();
        float Item(int i);
        void SetItem(int i, float value);

        int Size { get; }
    }
}
