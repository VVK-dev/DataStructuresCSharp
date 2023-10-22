namespace Linked_Lists
{
    class LinkedListsIntro
    {
        //A

        //Linked lists are a "data structure" which comprises of x elements (called nodes) which hold data and
        //a pointer to the next element in the chain.

        //The reason why I put data structure in quotes is because linked lists aren't like other collections - 
        //well, for one they aren't even really collections. A linked list is sort of like the pinboard with red
        //strings going from suspect to suspect in detective shows: Each node is not stored contigously in memory,
        //they are all stored randomly. The only connection between each node is the pointer from each node to the
        //other.

        //Linked lists aren't like arrays. Arrays are like a box in which you put stuff in, but linked lists aren't
        //a box or any sort of container at all. A linked list is simply the name given to the phenomenon where
        //something points to something else, which then points to something else and that in turn points to
        //something else and so on thus forming a sort of chain.

        //Linked lists come in 2 types depending the amount of pointers between 2 elements:

        //(go to A in SinglyLinkedLists.cs)

        //B

        //TIME COMPLEXITIES

        /*
         *                      Singly Linked Lists                Doubly Linked Lists          Arrays
         * 
         * Linear Search                O(n)                               O(n)                  O(n)
         * 
         * Insert at Head               O(1)                               O(1)                 [All insertion 
         *                                                                                       and deletion
         * Insert at Tail       O(1) [when keeping track of tail]          O(1)                  operations are
         *                                                                                       O(n)]
         * Remove Head                  O(1)                               O(1)
         * 
         * Remove Tail         O(n) [as no previous pointers]              O(1)
         * 
         * Remove in middle             O(n)                               O(n)
         * [using linear search
         *  where needed]
         * 
         * Modifying an element         O(n)                               O(n)                  O(1) 
         * in the middle
         * [using linear search
         *  where needed]
         * 
         */

        //In general, linked lists are preferred over arrays and even arraylists for scenarios where frequent
        //insertion and deletion of elements is required, as these operations are faster with linked lists.

        //However, linked lists have slower search times than arrays as random access is not allowed. Unlike arrays
        //where the elements can be search by index, linked lists require iteration. Hence arrays are preferred
        //when we need to access elements in the middle of the collection easily.

    }
}