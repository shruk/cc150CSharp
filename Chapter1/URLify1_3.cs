using System.Collections.Generic;
using Xunit;

namespace cc150CSharp{
	public class URLify{
//Problem: Write a method to replace all spaces in a string with '%20', and string and "true" length of string is given, return the new string, need to use array of char so operation is in place.
//1.Listen: The char array has enough spaces so no need to resize. True length is length of substring that need to be processed start from index 0.
//2.Example: input "Mr John Smith    ", 13
//.          output"Mr%20John%20Smith"
//			 input "  ",1. input:"",0. input null,0
//			 output"%20".  output:"".  output null
//3.Brute Force: for each char, check if it is equal to space, if it is , try to insert "%20" else go to next char. time complexity is going to be O(n)* O (n-i-1) =>O(n^2)
//4.BUD optimization: 1.unused info, the length is given
//					2.use fresh example: " a b",4 output should be "%20a%20b"
//.                 3.solve it incorrectly could be missing the leading space
//					4.precompile information?
//					5.Hash table?
//					6.best conceivable runtime is going to be O(n)
//5.Walk through code
//6.Write beautiful code
//7.Test code: wierd code checking; sample checking: if string has 2 spaces, 
//we need to test if substring is needed, assume string input is not null.
		
		// Time Complexity O(n)
		// Space: 2n as we are using extra Dictionary.
		public char[] URLify_bf(char[] a,int len)
		{//use hash table to store what char is for each index after replacement,
		 // then loop through array char to place the value
			if (a==null)return null;
			int index=0;
			Dictionary<int,char> dict=new Dictionary<int,char>();
			//a=a.Substring(0,len);//check to see if this what the problem is looking for
			//char [] arr=a.ToCharArray();
			for(int i=0;i<len;i++)
			{//O(n) loop
				if (a[i]==' '){//replace with "%20"
					dict.Add(index++,'%');
					dict.Add(index++,'2');
					dict.Add(index++,'0');
				}else
				{
					dict.Add(index++,a[i]);	
				}
			}
		    //loop	through O(n)
			for (int i=0;i<index;i++)
			{
				
				a[i]=dict[i];
			}
			return a;
		}

		// Edit string from back to front, this way we don't need to worry about overwriting.
		// Save some space by not using additional DS
		public char[] URLify_Pro(char[] a,int len)
		{
			if (a==null)return null;
			int spCount=0;
			// Count number of space we have
			foreach(char c in a)
			{
				if (c==' ')
				{
					spCount++;
				}
			}
			// Calculate the new Length of new string
			int newLen=len+(spCount*2);
			for (int i=newLen-1,j=len;i>=0;)
			{
				if (a[j]==' '){
					a[i--]='0';
					a[i--]='2';
					a[i--]='%';
					j--;
				}
				else
				{// Any other char.
					a[i--]=a[j--];
				}
			}
			return a;
		}
	}

	public class TestURLify{
		private URLify _o;
		public TestURLify(){
			_o=new URLify();
		}

		[Fact]
		public void testURLify()
		{
			char [] a=new char[2]{'a','b'};
			Assert.Equal(a,_o.URLify_bf(a,2));
			char [] b=new char[5];
			b[0]=' ';
			b[1]='a';
			b[2]='b';
			Assert.Equal('%',_o.URLify_bf(b,3)[0]);


		}

	}
}