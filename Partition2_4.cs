using System;
using Xunit;

namespace cc150CSharp
{
// Problem:given a linked list and a value x, sort the list so that all items less than x is on the left side
// partition, if x exists, x can be anywhere on the right parition.
// 1.Listen, understand the problem,.
// 2.Example, normal small case, special case(empty string/special chars?), big enough case,
// x can be exists in the list, anything less than x should be on the left, 
// if x is small or bigger than all elements, then any order is fine.
// 3.Brute force way(naive way)...create left and right list, adding them after looping through all elements
// Merge back left and right at the end. O(n) time complexity. but Space complexity is O(n)
// 4.BUD optimization. 
//	  a: look for unused info.
//	  b: Use a fresh example. if x exists in the list, move it to the right partition.
//	  c: Solve it "incorretly" will provide negative result to think it over
//	  d: Make time vs space tradeoff. 
//	  e: Precompute information.
//	  f: Use hash table.
//	  g: Think about the best conceivable runtime.
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

    public class Partition<T>where T: IComparable
    {
        public Node<T> PartitionLinkedList(Node<T> head, T x)
        {// Recreate another 2 list and keep original link intact. 
            var left=new Node<T>();
            var leftRunner=left.next;
            var right=new Node<T>();
            var rightRunner=right.next;
            

            while(head!=null)
            {// O(n) time complexity.
                if (head.data.CompareTo(x)<0)
                {// Move this to left.
                   leftRunner=head; 
                   leftRunner=leftRunner.next;
                }else 
                {
                   rightRunner=head;
                   rightRunner=rightRunner.next;
                }
                head=head.next;
            }
            // Merge left to the right side.
            leftRunner=right.next;
            return left;
        }

    }
    public class TestPartition
    {
        private Partition<int> _o;
        public TestPartition()
        {
            _o=new Partition<int>();
        }
        [Fact]
        public void testPartitionWorks()
        {
            var head=new Node<int>(8);
            head.next=new Node<int>(9);
            head.next=new Node<int>(1);
            head.next=new Node<int>(3);
            head.next=new Node<int>(5);
            head.next=new Node<int>(7);
            
        }
    }
}