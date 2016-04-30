using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLoop
{
    public class MergeSort
    {
        public int[] Divide(int[] array)
        {
            if (null== array || array.Length < 2)
                return array;

            int lastIndex = array.Length - 1;
            int half = (array.Length / 2) ;

            int[] lefthalf = subArray(array, 0, half);
            int[] righthalf = subArray(array, half, array.Length) ;
            
            lefthalf= Divide(lefthalf);
            righthalf= Divide(righthalf);
            int[] sortArary= merge(lefthalf, righthalf);
            return sortArary;
        }

        private int[] subArray(int[] array, int startIndex, int lastIndex)
        {
            Console.WriteLine("Creating subarray of Array {0}, startIndex: {1}, lastIndex{2}", array, startIndex, lastIndex);
            int index = 0;
            int[] result = new int[lastIndex - startIndex];
            for(int i=startIndex;i< lastIndex; i++)
            {
                result[index++] = array[i];
            }
            return result;
        }

        private int[] merge(int[] lefthalf, int[] righthalf)
        {
            int sortArrayLength = lefthalf.Length + righthalf.Length;
            int[] sortArray = new int[sortArrayLength];

            int leftIndex=0, rightIndex = 0, index=0;
            while(leftIndex < lefthalf.Length && rightIndex < righthalf.Length)
            {
                if(lefthalf[leftIndex] >= righthalf[rightIndex])
                {
                    sortArray[index] = righthalf[rightIndex];
                    rightIndex++;
                }
                else
                {
                    sortArray[index] = lefthalf[leftIndex];
                    leftIndex++;
                }
                index++;
            }
            while (leftIndex < lefthalf.Length)
            {
                sortArray[index++] = lefthalf[leftIndex++];
            }
            while(rightIndex < righthalf.Length)
            {
                sortArray[index++] = righthalf[rightIndex++];
            }
            return sortArray;
        }
    }
}
