using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLinkedList.Internal
{
    class ElementNode<T>
    {
        public T Value { get; private set; }

        public ElementNode<T> next { get; set; }

        public ElementNode(T value)
        {
            this.Value = value;
        }
    }
}
