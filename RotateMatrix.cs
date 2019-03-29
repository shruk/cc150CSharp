using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace cc150CSharp
{
    public class RotateMatrix<T>
    {
        public void RotateMatrixBf(T [,] arr)
        {
            //Basically re-create another matrix and reassign the matrix by access the given matrix
            // How to get the dimension of the matrix?
            // Get first dimension Length.
            int len=arr.GetLength(0);
            // Get second dimension Length.
            int len2=arr.GetLength(1);

            T [,] arrNew=new T [len,len2];
            // len should be equal to len2
            for (int i=0;i<len;i++)
            {
                for (int j=0;j<len;j++)
                {
                    arrNew[i,j]=arr[len-j,i];
                }
            }
            arr=arrNew;
        }
    }


    public class TestRotateMatrixOfT{
        
        private readonly ITestOutputHelper _output;
        private RotateMatrix<int> _o;
        private SpeedTester _st;

        public TestRotateMatrixOfT(ITestOutputHelper output)
        {
            _output=output;
            _o=new RotateMatrix<int>();
        }

        [Fact]
        public void testMatrix()
        {
            int [,] arr=new int[2,2]{ {1,2},{ 3,4}};
            PrintArray(arr);
            _o.RotateMatrixBf(arr);
        }

        private void PrintArray(int [,] arr)
        {
             
            for (int i=0;i<arr.GetLength(0);i++)
            {StringBuilder sb=new StringBuilder();
                for (int j=0;j<arr.GetLength(1);j++)
                {
                    sb.Append(arr[i,j]);
                }
                 _output.WriteLine(sb.ToString());
            }
        }
    }
}