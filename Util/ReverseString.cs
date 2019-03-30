using System.Text;
using Xunit;
using Xunit.Abstractions;
using cc150CSharp.Util;

namespace cc150CSharp
{
    public class StringReverse
    {
        // Using recursion to solve this problem
        public char [] ReverseString(char [] str)
        {
            // Reduce the problem-> ReverseString(n)-->ReverseString(n-1) + Append str[0]
            // --> ReverseString(n-2)+Append str[1] + Append str[0]
            // --> ReverseString(n-3)+Append str[2] + Append str[1] +Append str[0]
            // Appsend str[0] is easy as StringBuilder.Append(str[0]);
            // Always remember to stop at the base case.
            StringBuilder result=new StringBuilder();
            
            if (str==null||str.Length==0) // Null case
            { return null;}
            if (str.Length==1)  // Base case
            { return str[0].ToString().ToCharArray();}


            
            StringBuilder sb =new StringBuilder();
            for(int i=1;i<str.Length;i++)
            {
                sb.Append(str[i]);
            }
            result.Append(ReverseString(sb.ToString().ToCharArray()));
            result.Append(str[0]);
            return result.ToString().ToCharArray();
        }

        public void ReverseStringPartition(char [] str)
        {
            // Try to solve the problem via Paritioning
            // partition the first and last element as one part
            // partition the rest elements as one part

        }
    }

    public class TestStringReverse:BaseTest
    {
        private StringReverse _o;
        public TestStringReverse(ITestOutputHelper output):base(output)
        {
            _o=new StringReverse();
        }
        [Fact]
        public void TestReverseString()
        {
            string a="abcdefg";
            string b=new string(_o.ReverseString(a.ToCharArray()));
            _output.WriteLine(b);
        }

    }
}