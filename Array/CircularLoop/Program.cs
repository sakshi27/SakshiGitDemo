using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLoop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int maxSize = 12;
            int StartPosition = 0, EndPosition = maxSize - 1;
            int[] arrayElements = new int[maxSize];
            int position = CircularLoop(arrayElements, StartPosition, EndPosition);
        }

        public static int CircularPosition(int[] arr)
        {
            if (arr.Length == 0)
                return 0;

            if (isCircular(arr))
                return CircularLoop(arr, 0, arr.Length - 1);
            else
                return 0;
        }

        private static bool isCircular(int[] array)
        {
            if (array[array.Length - 1] > array[0])
                return false;
            else
                return true;
        }

        private static int CircularLoop(int[] array, int start, int end)
        {
            if (end <= start)
                return end;
            decimal diff = end - start;
            decimal mid = Math.Floor((diff) / 2) + start;
            if (array[start] > array[int.Parse(mid.ToString())])
            {
                //Traverse to Left array 
                end = int.Parse(mid.ToString()) - 1;
            }
            else
            {
                start = int.Parse(mid.ToString()) + 1;
            }
            return CircularLoop(array, start, end);

        }

        public static List<Point> findSumOccurance(int[] array, int sum)
        {
            int firstIndex = 0;
            List<Point> result = new List<Point>();
            int lastIndex = array.Length - 1;

            int sumValue = array[firstIndex] + array[lastIndex];
            while (lastIndex > firstIndex)
            {
                if (sumValue > sum)
                {
                    lastIndex--;
                    sumValue = array[firstIndex] + array[lastIndex];
                }else if( sumValue < sum)
                {
                    firstIndex++;
                    sumValue = array[firstIndex] + array[lastIndex];
                }
                else
                {
                    Console.WriteLine("First and Last Indexes {0} and {1}", firstIndex,lastIndex);
                    result.Add(new Point(firstIndex, lastIndex));
                    lastIndex--;
                    sumValue = array[firstIndex] + array[lastIndex];
                }

            }
            return result;
            
        }

        public class Note
        {
            public int Currency { get; private set; }

            public int Count { get; set; }
            public Note(int currency, int count)
            {
                Currency = currency;
                Count = count;
            }
        }
        public  static List<Note> CountCurrency(int value)
        {
            if (value < 0)
            {
                return null;
            }
            List<Note> result = new List<Note>();
            int[] arr = new int[] { 1000, 500, 100, 50, 20, 10 };
            int remainder=100;
            int quotient = 0,i=0;
            do
            {
                remainder = value % arr[i];
                quotient = value / arr[i];
                result.Add(new Note(arr[i], quotient));
                i++;
                value = remainder;

            } while (remainder > 0 && i < arr.Length);
            return result;
        }




    }
}
