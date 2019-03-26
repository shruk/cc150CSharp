using System.Collections.Generic;
using Xunit;

namespace cc150CSharp{
    public class PalinPemu{
 //0 problem: Given a string, check if it is a permutation of a palindrome
 //1.Listen, understand the problem, looks like space in between is ignored
 //2.Example, normal small case, special case(empty string/special chars?), big enough case,
 //if empty string, return true, speical chars should be processed normally
 
 //3.Brute force way(naive way)...pre-compute the string to remove all the spaces in between 
 //for each char, see if the number of occurrances, if it not even number, mark it unique.
 //if there are more than one unique charactor, return false; time complexity there are going to be O(n) for pre-compute and process, don't code yet since it is not final version.
 //4.BUD optimization. 
 //   a: look for unused info.
 //	  b: Use a fresh example. "aaabbb" return false;
 //	  c: Solve it "incorretly" will provide negative result to think it over
 //	  d: Make time vs space tradeoff. More space may save more runtime. let's use hashtable
 //	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
 //	  f: Use hash table, yes
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
		public bool IsPalinPemu(string a)
		{	
			//Check for case-insensitive cases
			char []b=a.ToLower().ToCharArray();
			//build a hashtable to process
			Dictionary<char,int> dict=new Dictionary<char,int>();
			foreach( char c in b)
			{//O(n)
				if (c!=' '){
					if (dict.TryGetValue(c,out int value)){
						dict[c]+=1;
					}else{
						dict.Add(c,1);
					}
				}
			}
			int oddCount=0;
			//odd can only be 0 or 1
			foreach (char k in dict.Keys)
			{//O(n)
				if (dict[k]%2!=0)oddCount++;
			}
			if (oddCount>1)return false;
			return true;
		}
    }
    
    public class TestPalinPemu{
     private PalinPemu _this;
     public TestPalinPemu(){
     	_this=new PalinPemu();
     	}

     [Fact]
     public void testPalinPemu(){
     	string a="";
     	Assert.Equal(true,_this.IsPalinPemu(a));
			 Assert.Equal(true,_this.IsPalinPemu("Tact Coa"));
     }	
    }
}