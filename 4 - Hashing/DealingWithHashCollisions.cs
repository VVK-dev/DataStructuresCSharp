using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashtablesAndHashMaps
{
    class DealingWithHashCollisions
    {

        //Considering the problem of hash collisions, immutable keys is generally not enough to solve it. So, there
        //exist several other ways to prevent them from occuring.

        //NOTE: The load factor of a hash table is (number of items in table / size of table). It is essentaily a 
        //scale of how empty/full a hashtable is.

        //-SEPARATE CHAINING-

        //In this method, we store every key value pair element as part of a collection (usually
        //either a linked list or an array) and if we encounter a hash collision where 2 keys have the same hash,
        //they are added to the same collection.

        //eg: Suppose we have the following key value pairs - "Rai":25, "Ryan":56, "Rick":61, "Will":21, "Finn":21
        //and that we have a hash function that gives             1   ,     1    ,      2   ,    3     ,    3
        //as their respective hash codes.

        //It is already possible to see that we have some hash collisions, let us see how we can handle them using 
        //the separate chaining method with a array:

        /*
                INDEX           Key:Value
         
                  0             {}
                  1             {"Rai":25, "Ryan":56}
                  2             {"Rick":61}
                  3             {"Will":21, "Finn":21}
                  4             {}

        */

        //And here is the same method depicted with a linked list:
        /*
                INDEX           Key:Value
         
                  0              
                  1             "Rai":25 -> "Ryan":56
                  2             "Rick":61 -> 
                  3             "Will":21 -> "Finn":21
                  4              

        */

        //Every key-value pair is stored as an element of a collection. If we have a hash collision, we simply
        //append that key-value pair to the collection for that given index and thus hash value. 

        //Suppose now we want to find the value for the string "Ryan". First we hash it and check if there are
        //any elements at that index. If there are none then it is not a key and not in the hashtable. Here, we get
        //a hash value of 1. At index 1, we have a list of 2 elements, so we iterate through the list and search for
        //it.

        //The time complexity of separate chaining increases linearly with increased load factor.

        //-OPEN ADDRESSING-

        //In this method, when a hash collision occurs, we offset the hash value of the element we
        //are trying to insert by a set amount using a function called a probing function/sequence P(x).
        //If that slot is also full, we use the probing sequence again to get a new index.

        //The most important thing to manage in a hashtable when using open addressing is the hashtable's load factor.

        //With higher load factors (0.8 and above) , open addressing gets exponentially worse. For low load factors,
        //open addressing is very, very quick and much faster than separate chaining. However, for high load factors
        //separate chaining is significantly quicker than open addressing.

        //i.e. the more full a hashtable is, the worse open addressing is, and the more empty a hashtable is, the 
        //better open addressing is.

        //The general way to implement open addressing is as follows:

        /*
            int numofiterations = 1;
            int hash = HashFunction(Key);
            int index = hash;
            
            while (Hashtable[index] != null) {
                
                index = (hash + ProbingFunction(Key, numofiterations)) % Size of Hashtable;
                numofiterations += 1;
                
                //The reason we do % Size of Hashtable at the end is to make sure whatever the end result is is in 
                //bounds of the HashTable's indices.

            }
         
            Hashtable.insert(Key, Value) at index; 

         */

        //Before we head onto implementing probing functions, we must first take note of an issue that plagues them:
        //cycles. Alot of probing sequences % (Size of Hashtable) will produce a cycle, where only a few of the open
        //available spots in the hashtable keep getting checked infinitely and the others are ignored.

        //Eg: Let's assume we have the following hashtable:

        /*
         * 
         * {k1:v1, empty, empty, k2:v2, k3:v3, k4:v4, empty, empty, k5:v5, empty, empty, empty}
              0      1      2      3      4      5      6      7      8      9     10      11

            Assume we use the probing sequence P(x) = 4x where x = number of iterations of probing sequence
            Now suppose we want to insert a key-value pair into the table and get H(key) = 8
            
            //

            index = H(key) = 8 
            But index 8 is full, so we try again and increment x.
            index = (H(key) + P(1)) % Size = (8 + 4) % 12 = 0
            But index 0 is full, so we try again and increment x.
            index = (H(key) + P(2)) % Size = (8 + 8) % 12 = 4
            But index 4 is full, so we try again and increment x.
            index = (H(key) + P(3)) % Size = (8 + 12) % 12 = 8
            But index 8 is full, so we try again and increment x.
            ...

            We end right back where we started and continue infintely on, creating an endless cycle.

        */

        //Essentially, what we want to do when we create a probing sequence is to create a function that produces 
        //a cycle of order N, where N is the size of the hashtable, so that every index in the hashtable is searched
        //for an open slot.


        //There are many ways to implement a probing function for open addressing, and they each have their own solutions
        //to producing a cycle of order N and thus avoiding infinite cycles. The main implementations of probing
        //sequences are:

        //1)Linear Probing

        //Linear probing is when a probing sequence adheres to a linear formula, i.e. P(x) = ax + b where a,b are
        //constants and a != 0.

        //In order to avoid an infinite cycle, the constant a and the size of the hashtable N must be relatively prime.
        //2 numbers are realtively prime when their Highest Common Factor (HCF) = 1; i.e. a and N must have only 1
        //as their only common factor.

        //Because of this, a common choice for a is simply 1 itself, since the HCF of N and 1 is always 1.

        //2)Quadratic Probing

        //Quadratic probing is when a probing sequence adheres to a quadratic formula, i.e. P(x) = ax^2 + bx + c where
        //a,b,c are constants and a != 0.

        //There are many ways to avoid an infinite cycle using quadratic probing, the 2 most common ways are:

        //1 - Let P(x) = x^2, maintain a table size equal to a prime number >3 and keep the load factor <= 1/2 
        //2 - Let P(x) = (x^2 + x)/2 and maintain a table size equal to a power of 2

        //3)Double Hashing

        //Double Hashing is when a probing sequence is simply another hashing function, i.e. P(x) = x * H2(key) where
        //H2 is a second hashing function.

        //Note that since both hashing functions H1 (the original hashing fucntion) and H2 are hashing the same key,
        //they must be able to hash keys of the same type.

        //In order to avoid an infinite cycle, we have to do something a little complicated. Instead of using H2 in our
        //implementation of our probing sequence, we use & (imagine this is delta), where & = H2(key) % N, where N is
        //the size of the table.

        //Now, our probing function becomes:

        /*
            int numofiterations = 1;
            int hash1 = HashFunction1(Key);
            int hash2 = HashFunction2(Key);
            
            int index = hash1;
            int & = hash2 % Size of Hashtable;    

            while (Hashtable[index] != null) {
                
                index = (hash + numofiterations * &) % Size of Hashtable;
                numofiterations += 1;
                
            }
         
            Hashtable.insert(Key, Value) at index; 

        */

        //The reason we use & instead of the second hash function on its own is because & gives us some very important
        //info. If & is ever 0, we are guaranteed to be in an infinite cycle. Consider the following:

        //We try to insert an element by getting its hash value from a hash function, but then encounter a hash
        //collision as another key-value pair already occupies that position. So, we try to get the hash value of the 
        //the key again using another hash function. Now we also find &... and uh oh! & = 0, so if we try to continue,
        //we will get stuck in an infinite cycle. Now what?

        //Well the way to solve such situations is very simple, we just set & = 1 and continue. This will avoid an
        //infinite cycle. How? Well, by looking closely at our code above we can see that essentially, we are simply
        //using a linear probing sequence where a = & and b = 0! Thus, if we want to avoid an infinte cycle, we have
        //to use the same method for doing so in a linear probing sequence, i.e., a must be relatively prime to N.
        //Since a = &, if we set & = 1, a and N will automatically be relatively prime, as 1 is relatively prime to
        //all numbers.

        //Thus, we avoid an infinite cycle using double hashing.

        // - Removing elements using probing sequences -

        //Let's say we have an empty hashtable: {null, null, null, null, null, null, null, null} and some hashing
        //function H(key) and we are using a linear probing sequence for dealing with hash collisons.

        //Now, we insert k1:v1 into it. We get a hash value of 1 for it. Since that spot is empty, no need to probe 
        //and we can directly insert it. The hashtable is now: {null, k1:v1 , null, null, null, null, null, null}

        //Now we try to insert k2:v2 into it. We get the same hash value of 1 for it. We probe once and get a new index
        //of 2. We now insert it at index 2. The hashtable is now: {null, k1:v1 , k2:v2, null, null, null, null, null}

        //Now we try to insert k3:v3 into it. We get the same hash value of 1 for it. We probe once and get a new index
        //of 2. But that space is also occupied, so we probe again and get an index of 3. That spot is empty so we
        //insert it at index 3. The hashtable is now: {null, k1:v1 , k2:v2, k3:v3, null, null, null, null}

        //Now we remove k2:v2. The hashtable is now: {null, k1:v1 , null, k3:v3, null, null, null, null}

        //Now let's say we want to get the value of k3. First, we hash k3 - this gives us a hash value of 1. But k1 is
        //at 1 and k1 != k3. So we probe it once and get a hash value of 2. But, at index 2 there is a null space.
        //Since we hit a null space before we hit k3, we conclude that k3 doesn't exist in the hashtable.

        //To solve this issue of removal in hashtables, we use something called tombstones. When we remove an element
        //from the hashtable, instead of leaving that index as null, we place a tombstone there. A tombstone is simply
        //a marker that indicates that this particualr index should be skipped when doing a search. As this is a hashtable
        //, the tombstone is something that is the same type as the given key type for the hashtable, but is also
        //unique from all other possible keys. For example, if we have a hashtable that takes keys of type string
        //and values of type string as well, we can have the tombstones be soemthing like "--TOMBSTONE--": null

        //Let's say we place a tombstone at index 2 after removing k2:v2 in the previous example. Now the hashtable is:
        //{null, k1:v1 , TOMBSTONE, k3:v3, null, null, null, null}

        //Now let's say we want to get the value of k3 again. First, we hash k3 - this gives us a hash value of 1.
        //But k1 is at 1 and k1 != k3. So we probe it once and get a hash value of 2. But, at index 2 there is a
        //tombstone. So, we ignore it and probe again and get a hash value of 3. Now, we've founf k3 and can return its
        //value.

        //Along with this normal usage, we must also use an optimization to make future searches faster.

        //Let's say we add k4:v4 and k5:v5 into the hashtable. k4:v4 and k5:v5 both hash to 1 and so we follow the same
        //processes as aobve to place them at index 4 and 5 respectively. Now, we also remove k3:v3, leaving a
        //tombstone at its index.

        //The hashtable is now: {null, k1:v1 , TOMBSTONE, TOMBSTONE, k4:v4, k5:v5, null, null}

        //Now we search for k5:v5. We hash k5 and follow the same process as above to probe 4 times and get the value
        //of k5. But this time, we store the value of the first tombstone we encountered when searching. Once we've
        //found the element, we replace that first tombstone with k5:v5 and set the index where k5:v5 orginally was to
        //null. We can do this since k5:v5 and the first tombstone are part of the same probing cycle, so this won't
        //interfere with future searches but instead help them. This way, we can clear clutter with the tombstones and
        //thus reduce the load factor of the hashtable.

        //One small anecdote: this is actually only possible if we are searching for the latest element added.
        //If we try to do this when searching for another element in the probing cycle like k4:v4 for example, we will
        //place a null element where it originally was making k5:v5 inaccessible. One way we can check if the element
        //we are searching for is the msot recent element added is to first find the element, then run the probing
        //sequence once more and check that index. If that index is empty, the element we found is the last element.
        //If that index isn't empty, then the element we found is not at the end of the probing cycle.

        //NOTE: Now after discussing all of this, remember that open addressing only makes sense with low load factors,
        //so be sure to resize the hashtable once you hit a certain load factor limit you set!!!

    }
}
