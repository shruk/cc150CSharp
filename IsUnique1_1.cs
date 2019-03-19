using System.Collections.Generic;
using Xunit;

namespace cc150CSharp
{
    public class IsUnique
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
        public bool IsUniqueBf(string s)
        {

            if (s.Length == 0) return true;

            for (int i = 0; i < s.Length; i++)
            {//O(n) 
                for (int j = i + 1; j < s.Length; j++)
                {//iteration goes :(n-1)+(n-2)+...+2+1=n(n+1)/2 -n
                    if (s[i] == s[j]) { return false; }
                }
            }
            //based on iternation total above..
            //total O(n)=O(n^2)
            return false;
        }

        public bool IsUnique(string s)
        {
            if (s.Length == 0) return true;
            HashSet<char> hs = new HashSet<char>();
            foreach (char c in s)
            {//O(n) as it loops through n elements
                if (hs.Add(c) == false) return false;
            }
            //time complexity is O(n)
            //space complexity is O(n)
            return true;
        }
    }


    public class TestIsUnique
    {
        private IsUnique _class;
        public TestIsUnique()
        {
            _class = new IsUnique();
        }

        [Fact]
        public void Test()
        {
            string s = "aertuhghza";
            Assert.False(_class.IsUnique(s));
            string s1 = "";
            Assert.True(_class.IsUnique(s1));
            Assert.False(_class.IsUnique("  "));
        }
    }
}