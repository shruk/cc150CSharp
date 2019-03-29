using System.Collections.Generic;
using System.Text;
using Xunit;

namespace cc150CSharp{
    public class StringComp{
 //0.Problem:compress string e.g. "aabcccccaaa"->"a2b1c5a3", if compressed version is more or same, then return original string
 //string should be only A-Za-z
//1.Listen, understand the problem, input string output compressed string
//2.Example, normal small case, special case(empty string/special chars?), big enough case,
//"abcd"->"a1b1c1d1" then should return original string. there is no empty string.
//3.Brute force way(naive way)...use hash table to store index and char+count, at last concatenate all. should be O(n).
//4.BUD optimization. 
//	  a: look for unused info.
//	  b: Use a fresh example. "ab" need to return original. 
//	  c: Solve it "incorretly" will provide negative result to think it over
//	  d: Make time vs space tradeoff. More space may save more runtime.
//	  e: Precompute information. Sorting/compute value upfront save time in the   long run.
//	  f: Use hash table.Yes we can load one string into hashtable, 
//	  g: Think about the best conceivable runtime. O(n)
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
    public string Compress(string a)
    {// Construct Dict for position(seqence) and its key/value pair (letter/count)
        Dictionary<int,KeyValue> dict=new Dictionary<int,KeyValue>();
        char last=default(char);
        int lastInd=0;
        for (int i=0;i<a.Length;i++)//O(n)
        {   // Compare current char with last processed char
            if (a[i]!=last)
            {//add new
            dict.Add(i,new KeyValue(a[i],1));
            last=a[i];
            lastInd=i;
            }
            else
            {
                dict[lastInd].Value++;
            }
        }
        StringBuilder sb =new StringBuilder();
        foreach(KeyValue k in dict.Values)
        { // O(n) to loop through dict values
            sb.Append(k.ToString());
        }
        string result=sb.ToString();
        if(result.Length<a.Length)return result;
        return a;
    }
    
    //Build without extra ds to help.
    public string CompressPro(string str)
    {
        StringBuilder result=new StringBuilder();
        // Var to hold number of times for Char
        int countConsecutive=0; 
        for (int i=0;i<str.Length;i++)
        {
            countConsecutive++;
            if (i+1>=str.Length||str[i]!=str[i+1])
            {// A new char
             // Reset count.
                result.Append(str[i]+countConsecutive);
                countConsecutive=0; 
            }
        }
        return result.Length>str.Length?str:result.ToString();

    }
    public class KeyValue{
        readonly char _key;
        int _value;
        public KeyValue(char key,int value){
            _key=key;_value=value;
        }
        public char Key{get{return _key;}}
        public int Value{get{return _value;}set{_value=value;}}

        public override string ToString(){
            return this.Key+this.Value.ToString();
        }

     }


    }
    public class TestStringComp{
        private StringComp _o;
        public TestStringComp(){
            _o=new StringComp();
        }
        [Fact]
        public void testStringComp(){
            string a="abc";
            Assert.Equal("abc",_o.Compress(a));
            string b="aaabbbcccaaa";
            Assert.Equal("a3b3c3a3",_o.Compress(b));
        }
    }
}