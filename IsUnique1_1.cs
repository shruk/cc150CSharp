namespace cc150Sharp{
    public class IsUnique1_1{
        //determine if string has all unique characters..
        //brute force way... for each char, check if the same char exists in the rest of string
        public bool isUnique(string s){
        
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
    		Assert.Equals(false,s);
    	}
    }
}