namespace StacksQueuesAndHeaps
{
    //I already know what stacks and queues are, and have done extensive work implementing them in the past.
    //I am writing here simply for the sake of having notes for future reference and as such, I will not go
    //into much detail. However heaps and priority queues are new to me, and so I will focus on them mainly.

    public class StacksAndQueuesIntro
    {

        //STACKS

        //Stacks are literally just that - stacks. A stack is a tower of items wherein each item is stacked on top
        //of the other.

        //Like in a real world stack (eg: a stack of plates), items can only be removed from and added to the top of
        //the stack. We cannot modify the bottom of the stack unless we remove all the elements above it.

        //Stacks are known as Last-In-First-Out (LIFO) data structures. This is because the last (most recent)
        //element added is the first one to be removed.

        //The action of adding an element to a stack is called pushing, whiling removing an element is called 
        //popping.

        //Stacks have to be user generated in some languages, while others have a built in stack class.
        //C# has a built in stack class.

        public void StacksShowcase()
        {
            Stack<int> s = new Stack<int>();
            
            s.Push(1); //This is at the top of the stack - the Head. Since there are no other elements this is also
            //at the bottom.
            s.Push(2); //This is the new head. 1 is now the bottom of the stack.
            s.Push(3); //This is the new head. 2 is now in the middle and 1 is still athe the bottom.

            s.Pop(); //This removes and returns the topmost element from the stack. Here, it will return 1.
                     //Now 2 is at the top of the stack and has become the head again.
        }

        //We can also make a stack class ourselves using either an SLL, a DLL or simply an array to keep track of
        //elements.

    }

    public class Queues
    {

        //QUEUES

        //A queue is, like a stack, exactly as the name suggests. It is collection in which items are stored
        //in a line, one after another.

        //Like in a real world queue (eg: a ticket line for a movie), when an item is added to a queue it is sent
        //to the back of the line, and when an item is removed from a queue it is taken out from the front of the
        //line.

        //Queues are known as First-In-First-Out (FIFO) data structures. This is because the first (oldest) element
        //added is the first one to be removed.

        //The action of adding an element to a queue is called enqueueing, whiling removing an element is called 
        //dequeueing.

        //Queues, like stacks, have to be user generated in some languages, while others have a built in queue class.
        //C# has a built in queue class.

        public void QueueShowcase()
        {
            Queue<int> q = new Queue<int>();
            
            q.Enqueue(1); //This is at the front of the queue - the first one to get in line to get its ticket.
                          //Since it is the only element in the queue, it is also at the end of the line. It is
                          //both the head and the tail.
            
            q.Enqueue(2); //This is now at the end of the queue; it is the new tail. 1 is now the head only.

            q.Enqueue(3); //This is the new tail. 2 is in the middle of the queue while 1 is still the head.

            q.Dequeue(); //This removes and returns the element at the satrt of the queue - the head. Here, it will
                         //return 1. 2 is now the new head.

        }    
        
    }

}