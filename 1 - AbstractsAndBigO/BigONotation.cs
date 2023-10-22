using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractsAndBigO
{
    class BigONotation
    {

        //Big O is also something I have already done in 12th. However, after going through my textbook, it is
        //apparent that we were only taught the basics. Here, I will be going into alot more depth.

        //Big O notation is simply a succinct way of expressing how a particular function's execution time
        //scales as its input's size scales.

        //It's written as O(n) where n is the dominant factor in the function, i.e. the term in the function which
        //grows the most as the input grows.

        //Let's take the functions y = 2, y = 7x+3 and y = 4x^5+x+100000. 

        //The first case has constant time complexity, i.e. O(1). This is because no matter how much the input
        //scales, the output remains the exact same.

        //The second case has what's called linear time complexity. Here, the dominant term is 7x, as 3 is a
        //constant that never changes. But, the time complexity of this function is not O(7n). When writing 
        //big O, all constants are removed from all terms. So, the time complexity of this function is O(n).

        //The 3rd case has a time compelxity of O(n^5).

        //Big O always represents the worst case time complexity of a function.


        //Here's some common notations in order from fastest to slowest and examples with them:

        /*
            NOTATION                    EXAMPLE
                
            O(1)                        Array lookup given an index (list[0]), appending and removing an element 
            [aka Constant time]         from the end. Inserting, looking up and removing an element from a hashmap
                                        and hashset.
         
            O(log(n))                   Binary search.
            [aka Logorithmic time]                   


            O(n)                        Linear search with a for/while loop. Inserting and removing
            [aka Linear time]           from the middle of an array.

            O(nlog(n))                  Quicksort. Most comparison sorts, like MergeSort. 
                                        Most built-in sorting functions.

         
            O(n^2)                      A nested loop. Insertion sort.
         
            O(n!)                       Very rare, very inefficient.
         
         */
    }
}
