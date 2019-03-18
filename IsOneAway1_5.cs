using System;
using System.Collections.Generic;
using Xunit;

namespace cc150CSharp{
    public class OneAway{
//0.Problem:three types of edits, replace,insert,remove, given 2 strings,check if they are one edit away.
//1.Listen, understand the problem
//2.Example, normal small case, special case(empty string/special chars?), big enough case,
    //"abcd" vs "aecd" is true "abcd" vs "cdab" is false so to wrap up, if there are more than 1 differences on each index of the string, then we need to return false.
//3.Brute force way(naive way)...so calculate the differences between 2 string, if the differences are less than 2, return true. else return false.
//4.BUD optimization. 
//	  a: look for unused info.
//	  b: Use a fresh example."" and "a" returns true."b" and "" returns true. 
//	  c: Solve it "incorretly" will provide negative result to think it over
//	  d: Make time vs space tradeoff. More space may save more runtime.
//	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
//	  f: Use hash table.Yes we can load one string into hashtable, then compare
//	  g: Think about the best conceivable runtime. O(a+b)
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
	  public bool IsOneAway(string a,string b){
	    //pre-compute:
	    int ldiff=Math.Abs(a.Length-b.Length);
	    if (ldiff>1) return false;
		int diff=0;
		//check if a has one more char than b
		if (a.Length>b.Length)
		{
			for(int i=0,j=0;i<a.Length;)
			{	//check if a has one more char 
				if(a[i]!=b[j]){
					//found the char,move i forward
					i++;diff++;
					if (diff>1)return false;
				}else{j++;i++;}
			}
		}else if(a.Length<b.Length){
			//check if b has one more char
			for(int i=0,j=0;i<b.Length;)
			{
				if(b[i]!=a[j]){
					//found the char,move i forward
					i++;diff++;
					if (diff>1)return false;
				}else{j++;i++;}
			}
		}else {
			//check if char gets replaced by 1
			for(int i=0,j=0;i<b.Length;)
			{
				if(b[i]!=a[j]){
					//found the char,move i forward
					i++;j++;diff++;
					if (diff>1)return false;
				}else{j++;i++;}
			}
		}
	    return diff<=1;	
	  }
  
    }

	public class TestIsOneAway{
		private OneAway _o;
		public TestIsOneAway(){
			_o=new OneAway();
		}
		[Fact]
		public void testIsOneAway(){
			string a="pale";
			string b="ple";
			Assert.Equal(true,_o.IsOneAway(a,b));
			string b1="bake";
			Assert.Equal(false,_o.IsOneAway(a,b1));
		}


	}
}