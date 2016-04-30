using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class ElementNode<T>
    {
        public T value { get; private set; }
        public ElementNode<T> left { get; set; }
        public ElementNode<T> right { get; set; }

        public ElementNode(T value)
        {
            this.value = value;
        }

    }
}
