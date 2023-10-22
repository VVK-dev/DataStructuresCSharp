using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linked_Lists
{
    class SinglyLinkedList<T>
    {

        //PART A

        //A singly linked list (SLL) is one where each node has only pointer and that is to the next node.

        //The interesting thing about SSLs is that many languages don't have a built-in singly linked list class.
        //It is something that has to be user created.

        //SLLs follow some specific rules:

        //1) The first node is called the head, and the head is something that the SLL class always keeps track of
        //2) The last node is called the tail, and is always null
        //3) Each node keeps a track of what the next node is

        //In the following code, I am adhering to the given 3 rules above. However, note that these rules aren't
        //set in stone. Since an sll is a user generated class after all, we may choose to add or remove things
        //based on our needs, eg: we can choose to keep track of the tail as well as the head; this will make alot
        //of methods easier and faster.

        //go to Node.cs

        //PART B

        //SLL class

        //Note: I have used console.writeline and other shortcuts like taking in nodes as arguments in certain
        //methods. I have done this for simplicity of explanation, but in the real world code should not be written
        //like this. The methods should generally only take in the date of a given node as an argument and instead
        //of these methods printing anything to the screen in certain cases, they should throw exceptions.

        //PROPERTIES

        public int Size { get; set; } = 0; //no setter as one can't set the size

        public Node<T>? Head { get; set; } = null; //the head is null by default as the list is empty

        //CONSTRUCTOR

        public SinglyLinkedList(Node<T> NewHead) { 
        
            this.Head = NewHead;
            this.Size++;

        }

        //METHODS

        public void AppendNode(Node<T> NewNode)
        {

            NewNode.NextNode = null; //Since this new node will now be the tail, we make sure it points to null
            Node<T>? Current = this.Head;

            if(Current == null) { //If the head is null, set the new node as the head

                this.Head = NewNode;
                return;
            }

            while (Current.NextNode != null) {

                //If the current node's NextNode points to null, it's the tail 
                //If it doesn't, we set the current node to the next node and thus iterate through the linked list
                //There can be no null values in the middle of the linked list

                Current = Current.NextNode;

            }

            Current.NextNode = NewNode;

        }

        public void AddFirst(Node<T> NewNode)
        {
            NewNode.NextNode = this.Head;
            this.Head = NewNode;

        }

        public Node<T>? RemoveFirst() {

            if(this.Head == null) { return null; }

            Node<T>? temp = this.Head; //Setting head to temp to later clean out it's data and pointer

            this.Head = Head.NextNode;
            this.Size--;

            temp = null; //Cleaning old head

            return this.Head;
        
        }

        public void Remove(Node<T> RemoveNode)
        {
            Node<T>? Current = this.Head;
            Node<T>? Prev = null; //keep track of node previous to one we want to remove

            if (Current == RemoveNode)
            {
                //Case for when the node we want to remove is the head itself

                this.RemoveFirst();
                
                return;

            }

            while (Current != null)
            {

                if (Current.NextNode == RemoveNode) {

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

            if( Prev != null ) { Prev.NextNode = RemoveNode.NextNode; }

            //If previous is not null, that means we have found the node we are looking for
            
            else { 
                
                Console.WriteLine("Node not found."); 
                return; 
            
            }

            this.Size--;
            Current = null;

        }

        public void Print()
        {
            Node<T>? Current = this.Head;

            while (Current != null)
            {
                Console.WriteLine(Current);
                Current = Current.NextNode;

            }
        }

        //Go to LLMain to see these methods in action
    }
}
