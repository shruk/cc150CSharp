namespace cc150CSharp
{
// Problem:given access to middle node that is not the first nor last node in a singly linked list,
// return the list without the middle node.
// 1.Listen, understand the problem,.
// 2.Example, normal small case, special case(empty string/special chars?), big enough case,
// this node can a->(b)->c or a->b->(c)->d, just not the start nor the end.
// 3.Brute force way(naive way)...how to access the previous node is a question
// 4.BUD optimization. 
//	  a: look for unused info.
//	  b: Use a fresh example. 
//	  c: Solve it "incorretly" will provide negative result to think it over
//	  d: Make time vs space tradeoff. More space may save more runtime.
//	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
//	  f: Use hash table.Yes we can load one string into hashtable, 
//	  g: Think about the best conceivable runtime. O(M*N)
// 5.Walk Through the optimal solution found, not code yet...solidify my understanding of algorithm. Load string a into hashtable,loop through string b, get value for each position, if it is different, increase the count. if count is greater than 1, return true. if match, then remove the char from hashtable, if hashtable has only 1 item left, return true. 
// Write code slowly and get a feel for the structure of the code. Know what the variables are and when they change.
// 6.Implement. Write beautiful code. 
//	 a: Modularized code. write functions pretending the function is there, fill in details later if need to.
//   b: Error checks.
//   c: Use classes/structs if necessary (e.g. returning object)
//   d: Good varaible name. it is OK to use abbreviation.
//   e: Just write beautiful code (need to practice)
// 7.Test. 
//	a: Conceptual test. reading and analyzing each line, does the code do what you think it does?
//	b:Weird looking code. Double check the line of code that is weird.
//	c:Hot spots. know wht things are likely to cause problem. recursive code. Integer division, Null nodes in binary trees. The start and end of iteration throught liked list.
//	d:Small test cases.
//	e:Special cases. Test against null or single element values, extreme cases, etc.
//	f:When finding bugs, analyze the bug and make correction in the best place.
    public class Node<T>where T:IComparable{
        T data;
        Node<T> next;
    }
    public class MiddleNode
    {
        public void DeleteMiddleNode(Node<T> middle){}
    }
    public class TestMiddleNode{
        private MiddleNode _o;
        public TestMiddleNode()
        {
            _o=new MiddleNode();
        }
        public void testMiddleNodeWorks()
        {}
    }
}