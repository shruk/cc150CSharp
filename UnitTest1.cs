using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cc150CSharp
{
    [TestClass]
    public class InsertionSort
    {
        public static void NormalInsertionSort(int [] arr)
        {
             for(int i=1 ; i<=arr.Length-1 ;++i)
                {
                    int val=arr[i];
                    int j=i-1;

                    while(j>=0 && arr[j]>val)
                    {
                        arr[j+1]=arr[j];
                        j--;
                    }
                    arr[j+1]=val;

                }


        }


        [TestMethod]
        public void TestMethod1()
        {
                int [] arr=new int[7] {7,1,2,3,4,5,6};
                NormalInsertionSort(arr);

                foreach (int i in arr)
                {
                    Console.Write(i);

                }

        }
    }
}
