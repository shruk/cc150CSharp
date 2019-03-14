using System.Collections.Generic;
using Xunit;

namespace cc150Sharp{
	public class CheckPermutation1_2{
		//problem:Given two strings, write a method to decide if one is a permutation of the other.
		//1.Listen: assume the string is not null,
		//2.Example: small case "abc"'s permutation can be "bac" or "acb"
		//			 special case can be " " permutation can be " " or with dup chars "aab","aba"
		//3.BF naive way: for each char in string1, go to string2 check if exists, mark found on that position. need to create another array to store found information. O(a*b) time complexity and O(a+b) space complexity
		//4. BUD optimization: use Hash table, the best conceivable runtime should be O(a+b),precompute length maybe helpful for runtime. string1.len==string2.len else return false;
		//5. Walk through: load string1 into HS, O(a), go through string2 O(b), check if char in b exists in HS,if exists, remove that char from HS. else, return false; at last, check HS.count ==0
		//6.Write beautiful code: using standard format
		//7.Test
		public bool IsPermutation(string a,string b)
		{
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
			for(int j=0;j<b.Length;j++)
			{//O(b) operations
				if (dictA.TryGetValue(b[j],out outCount)){
					dictA[b[j]]=outCount-1;
				}
				else {return false;}
			}
			//check count value
			foreach(int c in dictA.Values)
			{//O(a)
				if (c!=0)return false;
			}
			return true;
		}
	}
	
	public class TestCheckPermutation{
		private CheckPermutation1_2 _class;
		public TestCheckPermutation(){
		_class=new CheckPermutation1_2();
		}
		[Fact]
		public void testCheckPermutation(){
			string a="";
			string b="";
			Assert.Equal(true,_class.IsPermutation(a,b));
			a=null;
			b=null;
			Assert.Equal(false,_class.IsPermutation(a,b));
			a="aab";
			b="baa";
			Assert.Equal(true,_class.IsPermutation(a,b));
			a="aabceer";
			b="baaerec";
			Assert.Equal(true,_class.IsPermutation(a,b));
		
		}
	}
}