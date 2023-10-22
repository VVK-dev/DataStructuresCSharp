using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Lists
{
    public class Node<T>
    {
        //PROPERTIES

        public T Data{ get; set; } //This is the actual element that this node holds
        public Node<T>? NextNode{ get; set; } //This is next node in the chain

        //The above statement is what's called a self-referencing property, where a property's type is that of the 
        //current class itself

        //CONSTRUCTOR

        public Node(T data, Node<T>? next)
        {
            Data = data;
            NextNode = next;
        }

        public override string? ToString()
        {
            if(this.Data == null) return null;

            return this.Data.ToString();
        }

        //go to SinglyLinkedList.cs PART B

    }
}
