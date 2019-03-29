using System.Text;
using Xunit;
using Xunit.Abstractions;

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
            if (str==null||str.Length==0) // Null case
            { return null;}
            if (str.Length==1)  // Base case
            { return str[0].ToString().ToCharArray();}


            StringBuilder result=new StringBuilder();
            StringBuilder sb =new StringBuilder();
            for(int i=1;i<str.Length;i++)
            {
                sb.Append(str[i]);
            }
            ReverseString(sb.ToString().ToCharArray());
            result.Append(str[0]);
            return result.ToString().ToCharArray();
        }
    }

    public class TestStringReverse
    {
        private readonly ITestOutputHelper _output;
        private StringReverse _o;
        private SpeedTester _st;
        public TestStringReverse(ITestOutputHelper output)
        {
            _output=output;
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