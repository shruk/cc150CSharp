using System;
using Xunit;

namespace cc150CSharp{
    public class RotateMatrix{
//problem:given an image by an N*N matrix,where each pixel in the image is 4 bytes. write a
//method to rotate the image by 90 degrees. do this in place?
//1.Listen, understand the problem, 
//2.Example, normal small case, special case(empty string/special chars?), big enough case,
//3.Brute force way(naive way)...gather a collection of positions and set to zero in matrix.
//4.BUD optimization. 
//	  a: look for unused info.
//	  b: Use a fresh example. 
//	  c: Solve it "incorretly" will provide negative result to think it over
//	  d: Make time vs space tradeoff. More space may save more runtime.
//	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
//	  f: Use hash table.Yes we can load one string into hashtable, 
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
   public bool IsRotation(string s1,string s2)
   {    int i=0;
       while(i<s1.Length)//o(n^2), not a good solution but need to test
       {    
           if(s2==rotate(ref s1))return true;
           i--;
       }
       return false;

   }

   private string rotate(ref string a)
   {
       char [] arr=new char[a.Length];
       arr[0]=a[a.Length-1];
       for (int i=0;i<a.Length-1;i++)
       {
           arr[i+1]=a[i];
       }
       //trying to change string here, string internning should change the value...
       a=new string(arr);
       return a;
   }
   
    }

    public class TestRotateMatrix{
        private RotateMatrix _o;
        public TestRotateMatrix(){
            _o=new RotateMatrix();
        }
        [Fact]
        public void testRotateMatrix()
        {
        string a="test";
        string b="estt";
        //Given
        Assert.True(_o.IsRotation(a,b));
        //When
        
        //Then
        }
    }
}