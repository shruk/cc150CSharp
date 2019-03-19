namespace cc150CSharp{
    public class RemoveDup{
//problem:remove duplicate from unsorted list
//1.Listen, understand the problem, try not use buffer.
//2.Example, normal small case, special case(empty string/special chars?), big enough case,
//3.Brute force way(naive way)...use hashset, it is pretty simple, just iterate through and add them into HS,then reconstruct the list.
//the author asked not to use temp buffer, meaning we need to use insertion sort(start from left)
//compare each node to its left, put smaller one on left, then go to next
//remove dup duing insertion.
//note list has no indexer to access, that is a big diff from array
//end up using 2 pointer technique, so slow runner will point to each node
//fast runner will go through the nodes to compare the slow point.
//4.BUD optimization. 
//	  a: look for unused info.
//	  b: Use a fresh example. 
//	  c: Solve it "incorretly" will provide negative result to think it over
//	  d: Make time vs space tradeoff. More space may save more runtime.
//	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
//	  f: Use hash table.this solution doesn't allow temp buffer.
//	  g: Think about the best conceivable runtime. O(M*N)
//5.Walk Through the optimal solution found, not code yet...solidify my understanding of algorithm. Load string a into hashtable,loop through string b, get value for each position, if it is different, increase the count. if count is greater than 1, return true. if match, then remove the char from hashtable, if hashtable has only 1 item left, return true. 
//Write code slowly and get a feel for the structure of the code. Know what the variables are and when they change.
//6.Implement. Write beautiful code. 
//	 a: Modularized code. write functions pretending the function is there, fill in details later if need to.
//   b: Error checks.
//.  c: Use classes/structs if necessary (e.g. returning object)
//.  d: Good varaible name. it is OK to use abbreviation.
//.  e: Just write beautiful code (need to practice)
//7.Test. 
//	a: Conceptual test. reading and analyzing each line, does the code do what you think it does?
//	b:Weird looking code. Double check the line of code that is weird.
//	c:Hot spots. know wht things are likely to cause problem. recursive code. Integer division, Null nodes in binary trees. The start and end of iteration throught liked list.
//	d:Small test cases.
//	e:Special cases. Test against null or single element values, extreme cases, etc.
//	f:When finding bugs, analyze the bug and make correction in the best place.
    public class Node<T>{
        public T data;
        public Node<T> next;
    }
    public void RemoveDuplicate<T>(Node<T> head){
            Node<T> slow=head;
            Node<T> fast=head.next;
            while(slow.next!=null)
            {
                //fast will go through the node for this slow
                while (fast.next!=null)
                {
                    if (slow==fast){//found
                    }
                    fast=fast.next;
                }

                slow=slow.next;
            }
    }
    }
}