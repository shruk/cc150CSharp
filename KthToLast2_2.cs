using System;
using Xunit;

namespace cc150CSharp
{
    public class KthToLast
    {
 // 0 problem: Given a singly linked list, find the kth element to last element. 
 // 1.Listen, understand the problem, last to itself is zero.
 // 2.Example, normal small case, special case(empty string/special chars?), big enough case,
 // If empty, return null, if a-->b,  k=1 return a. k=2 return b. k=3 return a.
 
 // 3.Brute force way(naive way)...pre-compute the k%length will give us index within range.
 //4.BUD optimization. 
 //   a: look for unused info.
 //	  b: Use a fresh example. "abc" if k=0, return c. so k should be [0...n]
 //	  c: Solve it "incorretly" will provide negative result to think it over
 //	  d: Make time vs space tradeoff. More space may save more runtime. let's use hashtable
 //	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
 //	  f: Use hash table.
 //	  g: Best conceivable runtime O(n)
 //5.Walk Through the optimal solution found, not code yet...solidify my understanding of algorithm. Write code slowly and get a feel for the structure of the code. Know what the variables are and when they change.
 //6.Implement. Write beautiful code. a: Modularized code. write functions pretending the function is there, fill in details later if need to.
   //   b: Error checks.
   //.  c: Use classes/structs if necessary (e.g. returning object)
   //.  d: Good varaible name. it is OK to use abbreviation.
   //.  e: Just write beautiful code (need to practice)
 //7.Test. a: Conceptual test. reading and analyzing each line, does the code do what you think it does?
      //b:Weird looking code. Double check the line of code that is weird.
      //c:Hot spots. know wht things are likely to cause problem. recursive code. Integer division, Null nodes in binary trees. The start and end of iteration throught liked list.
      //d:Small test cases.
      //e:Special cases. Test against null or single element values, extreme cases, etc.
      //f:When finding bugs, analyze the bug and make correction in the best place. 
    public class Node<T> where T:IComparable
        {
            public T data;
            public Node<T> next;
            public Node():this(default(T))
            {}
            public Node(T dt)
            {
                data=dt;
            }
        }
    public T FindKth<T>(Node<T> head,int k) where T:IComparable
    {
        // Find the length of singly linked list
        // if len=5, k=3, then we need to find the indx 1 element i.e. (len-k-1)th(idx) element
        int Len=1;// Total Count of Elements
        Node<T> runner=head;
        while(runner.next!=null)
        { // O(n)
            runner=runner.next;
            Len++;
        }
        int idx=Len-(k%Len)-1;
        Len=0;
        while(head.next!=null)
        { // O(n)
            if (idx==Len){return head.data;}
            head=head.next;
            Len++;
        }

        return default(T);
    }

    }
    public class Test2_2
    {
        private KthToLast _o;
        public Test2_2()
        {
            _o=new KthToLast();
        }
        [Fact]
        public void TestKthToLast()
        {
            var n1=new KthToLast.Node<char>('a');
            var n2=new KthToLast.Node<char>('b');
            var n3=new KthToLast.Node<char>('c');
            var n4=new KthToLast.Node<char>('d');
            n1.next=n2;
            n2.next=n3;
            n3.next=n4;
            Assert.Equal(n2.data,_o.FindKth(n1,2));
            Assert.Equal(n3.data,_o.FindKth(n1,5));
        }
    }
}