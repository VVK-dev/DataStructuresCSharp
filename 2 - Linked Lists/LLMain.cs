using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Lists
{
    public class LLMain
    {
        public static void Main(string[] args)
        {

            //For the sake of easy explanation, the way we have coded the singly linked lists means that we have
            //to create nodes ourselves and then use them in sll functions. Normally, this would not be this way -
            //the user shouldn't have the ability to create nodes, they are just something we use in the
            //background to keep track of things. The user should just have to give in the data portion of the node
            //and that's it - we will create the node itself and work with it unbeknownst to the user.

            Node<int> n1 = new Node<int>(1, null);
            Node<int> n2 = new Node<int>(2, null);
            Node<int> n3 = new Node<int>(3, null);

            SinglyLinkedList<int> sll = new (n1);

            Console.WriteLine("Head:");
            Console.WriteLine(sll.Head);

            sll.AppendNode(n2);
            sll.AppendNode(n3);

            Console.WriteLine("Linked List:");
            sll.Print();

            Console.WriteLine("New Head:");
            Console.WriteLine(sll.RemoveFirst());

            sll.Remove(n2);
            sll.AddFirst(n1);

            Console.WriteLine("Linked List:");
            sll.Print();

            //REFER TO DOUBLYLINKEDLISTS.CS BEFORE READING FURTHER

            Console.WriteLine("Doubly Linked List:");

            LinkedList<int> dll = new LinkedList<int>();

            dll.AddFirst(1);
            dll.AddLast(2);

            foreach (var item in dll)
            {
                Console.WriteLine(item);
            }

            dll.RemoveFirst();
            dll.RemoveLast();

            Console.WriteLine("Doubly Linked List after removing first and last elements:");
            
            foreach (var item in dll)
            {
                Console.WriteLine(item);
            }

            dll.AddLast(3);
            dll.Remove(3);

            Console.WriteLine("Doubly Linked List after adding and removing 3:");
            
            foreach (var item in dll)
            {
                Console.WriteLine(item);
            }

            //Go to B in LinkedLists.cs

        }
    }
}
