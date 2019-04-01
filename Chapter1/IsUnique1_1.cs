using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using cc150CSharp.Util;

namespace cc150CSharp
{
    public class UniqueString
    {
        //Problem Description: determine if string has all unique characters..
        //1.Listen, understand the problem
        //2.Example, normal small case, special case(empty string/special chars?), big enough case,
        //3.Brute force way(naive way)...for each char, check if the same char exists in the rest of string,check the time complexity, don't code yet since it is not final version.
        //4.BUD optimization. a: look for unused info.
        //	  b: Use a fresh example.
        //	  c: Solve it "incorretly" will provide negative result to think it over
        //	  d: Make time vs space tradeoff. More space may save more runtime.
        //	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
        //	  f: Use hash table
        //	  g: Think about the best conceivable runtime
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
        
        // Time: O(n^2)
        // Space: O(1)
        public bool IsUniqueBf(string s)
        {

            if (s.Length == 0) return true;

            for (int i = 0; i < s.Length; i++)
            {// O(n) 
                for (int j = i + 1; j < s.Length; j++)
                {// Iteration goes :(n-1)+(n-2)+...+2+1=n(n+1)/2 -n
                    if (s[i] == s[j]) { return false; }
                }
            }
            // Based on iternation total above..
            // total O(n)=O(n^2).
            return true;
        }

        // Time: O(n)
        // Space: O(n)
        public bool IsUnique(string s)
        {
            if (s.Length == 0) return true;
            HashSet<char> hs = new HashSet<char>();
            foreach (char c in s)
            {// O(n) as it loops through n elements.
                if (hs.Add(c) == false) return false;
            }
            // Time complexity is O(n).
            // Space complexity is O(n).
            return true;
        }

		// How about use List? If to use List, time complexity is still be O(n^2) as for each newly added item, would need to compare the ones in List.
		public bool IsUniqueByList(string s)
        {
            if (s.Length == 0) return true;
			var li=new List<char>();
            // Missing Load chars into list.
			foreach (char c in s)
			{
				foreach (char c1 in li)
				{// O(n^2) time compexlity.
					if (c1==c)return false;
				}
			}
			return true;

        }
        // Try to solve it with O(NlogN)?
		// Maybe recursion? 
        public bool IsUniqueTry(string s)
        {// Divide and Conquer, //divide string into substring until 1 char, then merge , check duplicate during merge...
            char [] cs=s.ToCharArray();
            return CheckUnique(cs,0,cs.Length-1);
        }

        private bool CheckUnique(char [] s, int startIdx, int endIdx)
        {
            if (startIdx>=endIdx){
                return true;// Only 1 element left , so IsUnique is true;
            }
            int midIdx=(startIdx+endIdx)/2;   
            if (!CheckUnique(s,startIdx,midIdx)) return false;
            if (!CheckUnique(s,midIdx+1,endIdx))return false;
            return Merge(s,startIdx,midIdx,endIdx);
        }

        public bool Merge(char [] s,int startIdx,int midIdx,int endIdx)
        {   
            int leftRunner=startIdx;
            int rightRunner=midIdx+1;
            int tempRunner=startIdx;
            char [] temp=new char[s.Length];
            while(leftRunner<=midIdx && rightRunner<=endIdx)
            {
                if (s[leftRunner]<s[rightRunner])
                {
                    temp[tempRunner++]=s[leftRunner++];
                }else if (s[leftRunner]>s[rightRunner])
                {
                    temp[tempRunner++]=s[rightRunner++];
                }
                else if (s[leftRunner]==s[rightRunner]) return false;
            }
            // Copy rest of left part or right part.
            while (leftRunner<=midIdx)
            {
                temp[tempRunner++]=s[leftRunner++];
            }
            while (rightRunner<=endIdx)
            {
                temp[tempRunner++]=s[rightRunner++];
            }
            for (int i1=startIdx;i1<=endIdx;i1++)
            {
                s[i1]=temp[i1];
            }


            return true;
        }


		// Time: O(nlogn)
        // Space: merge sort space requirement
        public bool IsUniqueBySort(string s)
        {// Divide and Conquer, Sort array first, then check each.
            // MergeSort(s);// O(nlogn) time complexity.
            for (int i=0;i<s.Length-1;i++)
        {
            if(s[i]==s[i+1])
            {
                return true;
            }
        }
        return false;
        }

        // Time: O(n)
        // Space: O(128)
        public bool IsUniqueASCII(string s)
        {// Assume char set is ASCII set for 128 elements
            bool [] checker=new bool[128];
            for(int i=0;i<=s.Length;i++)
            {// O(n) time complexity
                int val=(int)s[i];
                if (checker[val])
                {
                    return false;
                }
                else 
                {
                    checker[val]=true;
                }
            }
            return true;
        }

        // assume only letters of a-z due to nature of ACSII
        // Time complexity: T(n)
        public bool IsUniqueBit(string s)
        {//
            int checker=0;
            for (int i=0;i<s.Length;i++)
            {
                int val=s[i]-'a';
                if((checker & (1<<val))>0) // Left shift bit and perform Bitwise AND 
                {
                    return false;
                }
                checker |=(1<<val); //Bitwise OR will assign 1 to checker where there is a letter.
            }
            return true;
        }
    }


    public class TestIsUnique:BaseTest

    {
        private UniqueString _class;
        public TestIsUnique(ITestOutputHelper output):base(output)
        {
            _class = new UniqueString();
        }

        

        [Fact]
        public void Test()
        {
            string s = "aertuhghza";
            Assert.False(_class.IsUnique(s));
            Assert.False(_class.IsUniqueBf(s));
            string s1 = "";
            Assert.True(_class.IsUnique(s1));
            Assert.True(_class.IsUniqueBf(s1));
            Assert.False(_class.IsUnique("  "));
            Assert.False(_class.IsUniqueTry("  "));
            Assert.False(_class.IsUniqueTry("abcdefghijkk"));
            Assert.False(_class.IsUniqueBit("abcdefghijkk"));
            Assert.True(_class.IsUniqueTry("abcdefghijk"));
            Assert.False(_class.IsUniqueTry("abicdhijk"));
        }

        public void methodASCII()
        {
            bool b=_class.IsUniqueASCII("bcdefghijklmnopqrstuvwxyz1234567890-=][';/.,ZXCVBNMKLJHGFDSQWERTYUIOPaa");
        }

        public void methodBf()
        {
            bool b=_class.IsUniqueBf("bcdefghijklmnopqrstuvwxyz1234567890-=][';/.,ZXCVBNMKLJHGFDSQWERTYUIOPaa");
        }

        public void methodBit()
        {
            bool b=_class.IsUniqueBit("bcdefghijklmnopqrstuvwxyz1234567890-=][';/.,ZXCVBNMKLJHGFDSQWERTYUIOPaa");
           
        }

        public void methodTry()
        {
            bool b=_class.IsUniqueTry("bcdefghijklmnopqrstuvwxyz1234567890-=][';/.,ZXCVBNMKLJHGFDSQWERTYUIOPaa");
           
        }

        [Fact]
        public void TestPerfASCII()
        {
            _st=new SpeedTester(new MethodHandler(methodASCII));
            _st.RunTest();
            _output.WriteLine($"total milisec: {_st.TotalRunningTime.ToString()}");

        }


        [Fact]
        public void TestPerfBf()
        { // Bf method requires O(n^2) in avarage case.
            _st=new SpeedTester(new MethodHandler(methodBf));
            _st.RunTest();
            _output.WriteLine($"total milisec: {_st.TotalRunningTime.ToString()}");
        }

        
        [Fact]
        public void TestPerfBit()
        { // Bit method should be very fast due to bit operation
            _st=new SpeedTester(new MethodHandler(methodBit));
            _st.RunTest();
            _output.WriteLine($"total milisec: {_st.TotalRunningTime.ToString()}");
        }
        
        [Fact]
        public void TestPerfTry()
        { // Bit method should be very fast due to bit operation
            _st=new SpeedTester(new MethodHandler(methodTry));
            _st.RunTest();
            _output.WriteLine($"total milisec: {_st.TotalRunningTime.ToString()}");
        }
    }
}