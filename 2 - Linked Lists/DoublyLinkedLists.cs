using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linked_Lists
{
    public class DoublyLinkedLists<T>
    {
        //A doubly linked list (DLL) is a linked list where each node has 2 pointers: one to node prior and one
        //to the next node.

        //Unlike SLLs, DLLs are generally present in most languages and generally simply called LinkedList<T>.
        //This is the same with C#:

        LinkedList<T> values = new LinkedList<T>();

        //DLLs follow some specific rules:

        //1) The first node is called the head, and the head is something that the DLL class always keeps track of
        //2) The last node is called the tail, and the tail is also kept track of by the DLL. Unlike with SLLs,
        //the tail is never null, BUT always points to null as the next element.
        //3) Each node keeps a track of what the next node is and waht the previous node is.

        //Since DLLs are a built in class, I won't be actually be using this class I created for showcasing
        //operations in main. But, I will be going over a lot of the  main concepts and methods here.

        //NOTE: Since the nodes in DLLs have 2 pointers, I have created a new Node class called DLLNode with 2
        //pointers below this class.

        //Note: I have used console.writeline and other shortcuts like taking in nodes as arguments in certain
        //methods. I have done this for simplicity of explanation, but in the real world code should not be written
        //like this. The methods should generally only take in the date of a given node as an argument and instead
        //of these methods printing anything to the screen in certain cases, they should throw exceptions.


        //PROPERTIES

        public DLLNode<T>? Head { get; set; } = null;
        public DLLNode<T>? Tail { get; set; } = null; //the head and tail are null by default as the list is empty
        public int Size { get; set; } = 0;

        //METHODS

        public void Append(DLLNode<T> NewNode)
        {
            NewNode.NextNode = null;
            NewNode.PrevNode = this.Tail;

            if (this.Head == null)
            {
                //If the head is empty, the list is empty, so the appended node will be both the head and the tail
                this.Head = this.Tail = NewNode;
            }
            else
            {
                this.Tail.NextNode = NewNode; //The possible null reference won't actually ever happen here,
                                               //as if the head is null, then only the tail will also be null,
                                               //i.e the list will be empty in that case
                this.Tail = NewNode;
                
            }

            this.Size++;
        }

        public void AddFirst(DLLNode<T> NewNode)
        {
            
            if(this.Head == null) { this.Head = this.Tail = NewNode; }

            else {

                NewNode.NextNode = this.Head;
                this.Head.PrevNode = NewNode;
                this.Head = NewNode;

            }
            
            this.Size++;

        }

        public DLLNode<T>? RemoveFirst()
        {
            if (this.Head == null) { return null; } // Can't remove data from an empty list

            DLLNode<T> prevhead = this.Head;

            this.Head = this.Head.NextNode;
            this.Size--;

            // If after removing the head the list is empty, set the tail to null
            if (this.Head == null) { this.Tail = null; }

            // If the new head is not null, i.e. the list is not empty, set the previous node to null
            else { this.Head.PrevNode = null; }

            return prevhead;
        }

        // TODO: RemoveLast() and Remove()

        public DLLNode<T>? RemoveLast()
        {
            if(this.Tail == null) { return null; } //If list empty, return null

            DLLNode<T> prevtail = this.Tail;
            
            this.Tail = this.Tail.PrevNode;
            this.Size--;

            if(this.Size == 0) { this.Head = null; } //If after removing the tail the list is empty, set the head
                                                     //to null

            else { this.Tail.NextNode = null; } //Given that the list is not empty and so the new tail is not null,
                                                //set the tail's next node to null

            return prevtail;

        }

        public DLLNode<T>? Remove(DLLNode<T> RemoveMe)
        {
            if(RemoveMe == null) { return null; }
            if (this.Size == 0) { return null; }
            if (this.Head == RemoveMe) { return this.RemoveFirst(); }
            if (this.Tail == RemoveMe) { return this.RemoveLast(); }

            //Make RemoveMe's prev node point to it's next, and RemoveMe's next point to it's prev, essentially
            //skipping over RemoveMe and thus getting it out of the chain

            (RemoveMe.NextNode!).PrevNode = RemoveMe.PrevNode; //The only cases in which the next and prev nodes of
            (RemoveMe.PrevNode!).NextNode = RemoveMe.NextNode; //RemoveMe will be null is when it's either the tail
                                                              //or the head, which has already been checked for
                                                              //above, so we can ignore these null dereference
                                                              //warnings using the ! postfix

            RemoveMe.PrevNode = RemoveMe.NextNode = null;
            this.Size--;

            return RemoveMe;
        }

    }

    public class DLLNode<T>
    {
        //PROPERTIES

        public T Data { get; set; } //This is the actual element that this node holds
        public DLLNode<T>? NextNode { get; set; } //This is next node in the chain
        public DLLNode<T>? PrevNode { get; set; } //This is previous node in the chain

        //CONSTRUCTOR

        public DLLNode(T data, DLLNode<T>? next, DLLNode<T>? prevNode)
        {
            Data = data;
            NextNode = next;
            PrevNode = prevNode;
        }

        public override string? ToString()
        {
            if (this.Data == null) return null;

            return this.Data.ToString();
        }

        //go to SinglyLinkedList.cs PART B

    }
}
