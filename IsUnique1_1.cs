namespace cc150Sharp{
    public class IsUnique1_1{
        //Problem Description: determine if string has all unique characters..
        //1.Listen, understand the problem
        //2.Example, normal small case, special case(empty string/special chars?), big enough case,
        //3.Brute force way(naive way)...for each char, check if the same char exists in the rest of string,check the time complexity, don't code yet since it is not final version.
        //BUD optimization: a. look for unused info.
        				//	b. Use a fresh example.
        				//. c. Solve it "incorretly"
        public bool isUnique(string s){
        
        if (s.Length==0)return true;
        
        for (int i=0;i<s.Length;i++)
        {//O(n) 
        	for (int j=i+1;j<s.Length;j++)
        	{//iteration goes :(n-1)+(n-2)+...+2+1=n(n+1)/2 -n
        		if (s[i]==s[j]){return false;}
        	}
        }
        //based on iternation total above
        //total O(n)=O(n^2)
        return false;
        }
    }
    
    
    public class TestIsUnique{
    	[Fact]
    	public void testIsUnique{
    		string s="aertuhghza";
    		Assert.Equals(false,isUnique(s));
    		string s1="";
    		Assert.Equals(true,isUnique(s1));
    		Assert.Equals(false,isUnique(" "));
    	}
    }
}