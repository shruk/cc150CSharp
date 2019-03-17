using System.Collections.Generic;

namespace cc150CSharp{
	public class URLify1_3{
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
	}
}