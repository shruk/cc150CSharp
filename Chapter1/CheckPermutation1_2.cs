using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using cc150CSharp.Util;

namespace cc150CSharp{
	public class CheckPermutation1_2{
		//problem:Given two strings, write a method to decide if one is a permutation of the other.
		//1.Listen: assume the string is not null,
		//2.Example: small case "abc"'s permutation can be "bac" or "acb"
		//			 special case can be " " permutation can be " " or with dup chars "aab","aba"
		//3.BF naive way: for each char in string1, go to string2 check if exists, mark found on that position. need to create another array to store found information. O(a*b) time complexity and O(a+b) space complexity
		//4. BUD optimization: use Hash table, the best conceivable runtime should be O(a+b),precompute length maybe helpful for runtime. string1.len==string2.len else return false;
		//5. Walk through: load string1 into HS, O(a), go through string2 O(b), check if char in b exists in HS,if exists, remove that char from HS. else, return false; at last, check HS.count ==0
		//6.Write beautiful code: using standard format.
		//7.Test
		
		// Time complexity: O(a+b+a)=>O(a+b)
		public bool IsPermutation(string a,string b)
		{// For each char in string a, load into dictionary as key=> char, value=> count
			if ((a == null)||(b==null)) return false;
			if (a.Length!=b.Length)return false;
			Dictionary<char,int> dictA=new Dictionary<char,int>();
			int outCount;
			for(int i=0;i<a.Length;i++){//O(a) operations
				if (dictA.TryGetValue(a[i],out outCount))
				{ dictA[a[i]]=outCount+1;}
				else{//value is not there , then update the value
				dictA.Add(a[i],1);	
				}
			}
			// Scan each char in string b, minus the count from dictionary,
			for(int j=0;j<b.Length;j++)
			{//O(b) operations
				if (dictA.TryGetValue(b[j],out outCount)){
					dictA[b[j]]=outCount-1;
				}
				else {return false;}
			}
			// Check count value should be zero
			foreach(int c in dictA.Values)
			{//O(a)
				if (c!=0)return false;
			}
			return true;
		}

		public bool IsPermutationArray(string a,string t)
		{
			if (a.Length!=t.Length)return false;
			// Assume we use ASCII string, hold a count on number of times each char appears
			int [] count= new int [128];
			foreach( char c in a)
			{
				count[c]++; // Increase number at index of char value.
			}
			// Perform deduction 
			foreach (char c in t)
			{
				count[c]--;
				if ((count[c])<0) //only if b has char doesn't in a or has more same char than in a.
				{
					return false;
				}
			}
			return true;
		}

		// Sort both string then compare the euqalness, sorting take n(logn) + n comparision
		// This solution is best as the code is clean and easy!
		public bool IsPermutationSort(string a, string t)
		{
			char [] arrayA=a.ToCharArray();
			char [] arrayT=t.ToCharArray();
			Array.Sort(arrayA);
			Array.Sort(arrayT);
			// String.Equals and char [] Equals are differnt. String is comparing value, while char [] is obj compare.
			return new String(arrayA).Equals(new String(arrayT));
			// arrayA.Equals(arrayT) Implements object comparision.
		}
	}
	
	public class TestCheckPermutation{
		private CheckPermutation1_2 _class;
		private SpeedTester _st;
		private readonly ITestOutputHelper _output;
		public TestCheckPermutation(ITestOutputHelper output){
		_class=new CheckPermutation1_2();
		_output=output;
		}


		[Fact]
		public void testCheckPermutation(){
			string a="";
			string b="";
			Assert.True(_class.IsPermutation(a,b));
			a=null;
			b=null;
			Assert.False(_class.IsPermutation(a,b));
			a="aab";
			b="baa";
			Assert.True(_class.IsPermutation(a,b));
			Assert.True(_class.IsPermutationSort(a,b));
			Assert.True(_class.IsPermutationArray(a,b));
			a="aabceer";
			b="baaerec";
			Assert.True(_class.IsPermutation(a,b));
		
		}

		public void methodDict()
		{
			bool b=_class.IsPermutation("aabbccdd","ddccbbaa");
		}//test 
		public void methodSort()
		{
			bool b=_class.IsPermutationSort("aabbccdd","ddccbbaa");
		}

		public void methodArray()
		{
			bool b=_class.IsPermutationArray("aabbccdd","ddccbbaa");
		}
		[Fact]
		public void testPerfDict()
		{
			MethodHandler method=new MethodHandler(methodDict);
			_st=new SpeedTester(method);
			_st.RunTest();
			_output.WriteLine($" total running minisec: {_st.TotalRunningTime}");
		}

		
		
		[Fact]
		public void testPerfSort()
		{
			MethodHandler method=new MethodHandler(methodSort);
			_st=new SpeedTester(method);
			_st.RunTest();
			_output.WriteLine($" total running minisec: {_st.TotalRunningTime}");
		}
		[Fact]
		public void testPerfArray()
		{
			MethodHandler method=new MethodHandler(methodArray);
			_st=new SpeedTester(method);
			_st.RunTest();
			_output.WriteLine($" total running minisec: {_st.TotalRunningTime}");
		}
	}
}