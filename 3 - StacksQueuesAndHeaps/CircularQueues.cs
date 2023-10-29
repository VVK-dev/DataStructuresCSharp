using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksQueuesAndHeaps
{
    public class CircularQueues
    {

        //A circular queue is a queue that utilizes a circular array or circular linked list to keep track of items.
        //The end of the queue always points to the front of the queue.

    }

    public class CircularSLL<T>
    {

        //CIRCULAR SINGLY LINKED LIST

        //A circular SLL is one that is more like a ring than a line. As it's a linked list, every node points to
        //the next. In a circular SLL, the tail's next node is not null like usual, but instead the tail points to
        //the front of the SLL - the head.

        //eg: 1->2->3->4->5
        //    ^-----------'

        //Essentially, tail.next() == head

        //Note: I have used console.writeline and other shortcuts like taking in nodes as arguments in certain
        //methods. I have done this for simplicity of explanation, but in the real world code should not be written
        //like this. The methods should generally only take in the data of a given node as an argument, and instead
        //of these methods printing anything to the screen in certain cases, they should throw exceptions.


        //PROPERTIES

        public int Size { get; private set; } = 0; //private setter as users can't set the size
        public Node<T>? Head { get; private set; } //the head is null by default as the list is empty
        public Node<T>? Tail { get; private set; } //the tail is null by default as the list is empty

        //We don't actually need to keep track of the head as Tail.Next is always the head, but in general it is
        //better to for more readable code and for better performance (since the head is saved to a variable, you are
        //not calling the Tail.NextNode property everytime).

        //CONSTRUCTOR

        public CircularSLL(Node<T> NewHead)
        {

            this.Head = NewHead;
            this.Tail = NewHead;
            this.Tail.NextNode = this.Head;
            this.Size++;

        }

        //METHODS

        public void AppendNode(Node<T> NewNode)
        {
            if (this.Tail != null && this.Head != null)
            {
                this.Tail.NextNode = NewNode; //The old tail points to the new tail
                NewNode.NextNode = this.Head; //The new tail points to the head
            }
            else { this.Head = NewNode; } //When the list is empty, both the head and tail will be the new node
                                          //Since the new tail will always be the new node regardless of whether the
                                          //the list is empty or not, only this statement is given here
            this.Tail = NewNode;        
            this.Size++;
        }

        public void AddFirst(Node<T> NewNode)
        {
            if (this.Tail != null && this.Head != null)
            {
                this.Tail.NextNode = NewNode; //The old tail points to the new tail
                NewNode.NextNode = this.Head; //The new tail points to the head
            }
            else { this.Tail = NewNode; } //When the list is empty, both the head and tail will be the new node
                                          //Since the new head will always be the new node regardless of whether the
                                          //the list is empty or not, only this statement is given here
            this.Head = NewNode;            
            this.Size++;
        }

        public Node<T>? RemoveFirst()
        {

            if (this.Head == null) { return null; }

            Node<T>? Oldhead = this.Head; //Saving current head to Oldhead to later return it

            if(this.Size == 1) {
                
                //If there is only one node in the list, it is both the head and tail. So we set both to null
                //to remove it

                this.Head = this.Tail = null;
                return Oldhead; 
            }

            this.Head = Head.NextNode;
            this.Tail!.NextNode = this.Head;

            this.Size--;

            return Oldhead;

        }

        public void Remove(Node<T> RemoveNode)
        {

            if (this.Head == null) { Console.WriteLine("List empty."); return; }

            Node<T>? Current = this.Head;
            Node<T>? Prev = null; //keep track of node previous to the one we want to remove

            if (Current == RemoveNode)
            {
                //Case for when the node we want to remove is the head itself

                this.RemoveFirst();

                return;

            }

            if (this.Size == 1)
            {
                //When there is only 1 node in the list and it isn't the node for removal (i.e. it isn't the head)

                Console.WriteLine("Node not found.");
                return;

            }

            //Since the case for the node for removal is the head has already been checked, we can set current to the
            //next node instead.

            Current = Current.NextNode;

            while (Current != this.Head)
            {

                if (Current!.NextNode == RemoveNode)
                {

                    Prev = Current;

                    //If node after current is the one we want to remove, the current is the previous node to the
                    //one we want to remove

                    Current = Current.NextNode; //we still save the node we want to remove to a variable
                    //even though we already have it in the form of RemoveNode. This is to clean it from memory
                    //later.

                    break;

                }

                Current = Current.NextNode;
            }

            if (Prev != null) { Prev.NextNode = RemoveNode.NextNode; }

            //If previous is not null, that means we have found the node we are looking for

            else
            {

                Console.WriteLine("Node not found.");
                return;

            }

            this.Size--;

            Current = null;

        }

        public void Print()
        {

            if (this.Head == null) { Console.WriteLine("List empty."); return; }

            if (this.Size == 1)
            {
                //When there is only 1 node in the list

                Console.WriteLine(this.Head);
                return;

            }

            Node<T>? Current = this.Head;

            while (Current!.NextNode != Head)
            {
                Console.WriteLine(Current);
                Current = Current.NextNode;

            }
        }

    }
}
