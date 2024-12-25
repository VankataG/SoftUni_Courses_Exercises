using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> list = new Stack<T>();
        public int Count
        {
            get { return this.list.Count; }
        }

        public void Add(T element)
        {
                this.list.Push(element);
            
        }

        public T Remove()
        {
            return this.list.Pop();
        }
    }
}
