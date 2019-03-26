using System;
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

		public bool IsPalinPemuBit(string a)
		{
			int bitVector = createBitVector(a);
			return bitVector==0||checkExactlyOneBitSet(bitVector);
			
		}

        private bool checkExactlyOneBitSet(int bitVector)
        {// 00010000 -1 = 00001111  ==>> 00010000 & 00001111 =0
           return (bitVector & (bitVector -1))== 0;
        }

        private int createBitVector(string a)
        {
            int bitVector=0;
						foreach (char c in a.ToLower().ToCharArray())
						{
							int x=getCharNumber(c);
							bitVector=toggle(bitVector,x);
						}
						return bitVector;
        }

        private int toggle(int bitVector, int x)
        {
            if (x <0)return bitVector;
						int mask =1<<x;
						if ((bitVector & mask)==0) // there is no duplicate char, then zero, if duplicate, then go to else
						{// No duplicate char, flip from 0 to 1.
							bitVector|=mask;// Flip to 1 add to existing bitVector.
						}
						else
						{// Duplicate char in bitVector and mask, ~mask&bitVector will flip the dup only
						 // flip from 1 to 0 in event of duplicate.
							bitVector&= ~mask;
						}
						return bitVector;
        }

        // Need to add a logic to ignore all non-letter characters
        // Time complexity is the same as original solution but better case handling.
        public bool IsPalinPemuPro(string a)
		{
			// Build hash table to store string character's frequency.
			int [] table =buildCharFrequencyTable(a);
			return checkMaxOneOdd(table);
		}

    private bool checkMaxOneOdd(int[] table)
        { bool oddFound=false;
						foreach (int i in table)
						{
								if (i%2!=0)
								{
									if (oddFound)
									{
										return false;
									}
									oddFound=true;
								}
						}
						return true;
        }

    private int getCharNumber(Char c)
			{
				if (c>='a' && c<='z' )
				{// Return only the value differences
					return c-'a';
				}
				else
				{
					return -1;
				}
			}
		private int[] buildCharFrequencyTable(string a)
			{
				// Create array to hold all lower case letters
					int [] table=new int['z'-'a'+1]; 
					foreach (char c in a.ToLower().ToCharArray())
					{
						 if (getCharNumber(c)!=-1)
							table[getCharNumber(c)]++;
					}
					return table;
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
			 Assert.Equal(true,_this.IsPalinPemuBit("Tact Coa"));
			 Assert.Equal(false,_this.IsPalinPemu("Tact 1Coa"));
     }	
    }
}