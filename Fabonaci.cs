using Xunit;
using Xunit.Abstractions;

namespace cc150CSharp
{
    public class Fabonaci
    {
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
            {
                return result+=CalculateFab(n-1);
            }
        }

    public class TestFabonaci
    {
        private readonly ITestOutputHelper _output;
        private Fabonaci _o;
        private SpeedTester _st;
        public TestFabonaci(ITestOutputHelper output)
        {
            _output=output;
            _o=new Fabonaci();
        }
        [Fact]
        public void TestCalculateFab()
        {
            Assert.Equal(1,_o.CalculateFab(1));
            Assert.Equal(1,_o.CalculateFab(2));
            Assert.Equal(2,_o.CalculateFab(3));
            Assert.Equal(3,_o.CalculateFab(4));
        }

    }
    }
}