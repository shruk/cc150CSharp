using System.Text;
using Xunit;
using Xunit.Abstractions;
using cc150CSharp.Util;

namespace cc150CSharp
{
    public class RotateMatrix<T>
    {
        public T [,] RotateMatrixBf(T [,] arr)
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
                {// O(n^2)
                    arrNew[i,j]=arr[len-j-1,i];
                }
            }
            return arrNew;
        }
    }


    public class TestRotateMatrixOfT : BaseTest
    {
        private RotateMatrix<int> _o;
        public TestRotateMatrixOfT(ITestOutputHelper output):base(output)
        {
            _o=new RotateMatrix<int>();
        }

        [Fact]
        public void testMatrix()
        {
            int [,] arr=new int[2,2]{ {1,2},{ 3,4}};
            PrintArray(arr);
            PrintArray(_o.RotateMatrixBf(arr));
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