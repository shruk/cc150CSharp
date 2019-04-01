using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using cc150CSharp.Util;

namespace cc150CSharp
{
    public class Fabonaci
    {
        private readonly ITestOutputHelper _output;

        public Fabonaci(ITestOutputHelper output)
        {
            _output=output;
        }
        public int CalculateFab(int n)
        {
            // calculate the nth element in Fabonaci sequence.
            // n=1 --> value =1; n=2 --> value=1; n=3 --> value=2;
            // n=4 --> value =3; n=5 --> value=5; n=n --> value=(n-1)+(n-2);
            int result=0;
            if (n==1 || n==2)
            {
                return result+=1;
            }
            else
            {// O(2^n) exponential time complexity.
                return result+=CalculateFab(n-1)+CalculateFab(n-2);
            }
        }

        // Print Fab sequence.
        public void PrintFab(int n)
        {
            StringBuilder sb = new StringBuilder();
            // calculate each Fab and print it outo
            for (int i=1;i<=n;i++)
            {
                sb.Append($"{CalculateFab(i)},");
            }
            _output.WriteLine(sb.ToString());
        }

    public class TestFabonaci:BaseTest
    {
        //private readonly ITestOutputHelper _output;
        private Fabonaci _o;
        public TestFabonaci(ITestOutputHelper output):base(output)
        {  
             _o=new Fabonaci(output);
        }
        [Fact]
        public void TestCalculateFab()
        {
            Assert.Equal(1,_o.CalculateFab(1));
            Assert.Equal(2,_o.CalculateFab(3));
            Assert.Equal(3,_o.CalculateFab(4));
            Assert.Equal(5,_o.CalculateFab(5));
            Assert.Equal(8,_o.CalculateFab(6));
            _o.PrintFab(6);
        }

    }
    }
}