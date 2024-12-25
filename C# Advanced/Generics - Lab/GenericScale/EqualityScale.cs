using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    internal class EqualityScale<T>
    {
        public EqualityScale(T left, T right)
        {
            this._left = left;
            this._right = right;
        }

        public T _left;
        public T _right;

        public bool AreEqual()
        {
            return _left.Equals(_right);
        }
    }
}
