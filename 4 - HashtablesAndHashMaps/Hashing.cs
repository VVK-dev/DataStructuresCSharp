namespace HashtablesAndHashMaps
{
    class Hashing
    {

        //In the 12th Chapter (Optimization) of Advanced World C#, I went over hashsets at a very basic level. I 
        //mentioned hashing and hashcodes but did not go into it. Here, I will be taking a deep dive into the
        //process of hashing plus going over hashtables and hashmaps.

        //HASHTABLES - PART 1

        //A hashtable is a data structure that maps some values to some other values using a method called hashing.
        //The first set of values is called keys, and the second set is simply called values. Keys must all be 
        //unique and immutable, no such restriction exists on values.

        //Generally, how a hash table works is that given a key-value pair, a hash value y is found using the key.
        //The key value pair is then added at the index y.

        //Before we can move with hastables, we must explore hashing.

        //I will continue with HashTables in another file later on.

        //HASHING

        //Hashing is simply a process by which some x is mapped to a whole number in a fixed range.

        //The way this is done is by use of a hash function. A hash funtion is a function that maps a key to a
        //number in some fixed range. 

        //Eg: H(x) = (x^2 - 6x + 9) % 10 maps all entered integer keys to a numebr in the range [0,9]

        //H(4) => (16 - 24 + 9) % 10 = 1, H(-7) => (49 - 42 + 9) % 10 = 0, H(0) => (0 - 0 + 9) % 10 = 9

        //There is no one set way to do a hash function; all hash functions don't have to only deal integers or
        //can only return values in a fixed range that all computer scientists have to follow.

        //Eg:

        /*      NAME            AGE     SEX     HASH
        
                William          21      M      
                Kate             19      F
                Bishma           24      M
                Jun              27      O
         */

        //Suppose we want to create a hash value for every element in the above table. How can we go about this?

        //Well, there are infinite ways to do so. We can check the length of every persons name and add it their age
        //or we can convert their name and sex to ascii values and add them all up, or etc, etc.
        //There is no one single way to solve this problem, there are literally an infinte amount of possible hash
        //functions one can create here that will all work.

        //Here's one such way to do it:

        /*
         public static void Hash(Person p){
            int hash = person.age;
            hash += person.name.length;
            if(person.sex == "M"){
                hash++;
            }
            
            return hash % 6;
         */

        //Using the above hash function we get the following table:

        /*      NAME            AGE     SEX     HASH
         
                William          21      M       5      
                Kate             19      F       5
                Bishma           24      M       1
                Jun              27      O       0
        */

        //Properties of Hash Functions

        //1) Hash Value Equality rule

        //If, using some hash funtion H(x), the hash value of x equals the hash value of y, then x MAY equal y. But,
        //if the hash value of x doesn't equal y, then they are certainly not equal.
        //i.e. if H(x) == H(y), then x maybe equal to y; but if H(x) != H(y), then x != y.

        //This rule is particularly useful when trying to do something like compare files. Rather than going through
        //and checking each and every byte of 2 files to see if they are the same, if we have already precomputed
        //their hash values we can simply check those to see if they are the same. If they are the same then we do
        //have to go through the entirety of both files, but if their hash codes aren't the same we can simply say
        //that both files are different.

        //The hash funtions used in such cases like file checking are much more sphisticated than those used in
        //hashtables and are called cryptographic hash functions or checksums.

        //2) Determinism

        //Hash functions must absolutely always be deterministic. This means that if H(x) produces y, then H(x) must
        //always produce the same y and never another value for x.

        //Hash collisons

        //Hash collisions are when for 2 different values x and y, H(x) = H(y). We try to avoid creating hash
        //collisions as much as possible when creating a hash function.

        //Hashability

        //A key of type T is said to be hashable if we have a hash function H(x) defined for all keys x that are 
        //of type T AND if x is immutable.

        //As we need our hash functions to be deterministic, the keys we use must be immutable. If we have a mutable
        //key, then when the key's value is changed the hash value will also change, violating the 2nd rule of
        //determinism and leading to a high risk of hash collision.

        //This is why most languages enforce immutable keys.

    }
}