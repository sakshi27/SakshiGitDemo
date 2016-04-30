using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularLoop
{
    public class CountMinSteps
    {
        public int countMinSteps(int[] targetArray)
        {
            if (targetArray.Length == 0)
                return 0;
            int[] inputArray = new int[targetArray.Length];
            for (int i = 0; i < targetArray.Length; i++)
                inputArray[i] = 0;
            return count(inputArray, targetArray);
        }

        private int count(int[] inputArray, int[] targetArray)
        {
            int steps = 0;
            for(int i = 0; i < targetArray.Length; i++)
            {
                while (targetArray[i] != 0)
                {
                    if (even(targetArray[i]))
                    {
                        if (targetArray[i] != 0)
                        {
                            targetArray[i] = DivideByTwo(targetArray[i]);
                            steps++;
                        }
                    }
                    else
                    {
                        if (targetArray[i] != 0)
                        {
                            targetArray[i] = Subtract(targetArray[i]);
                            steps++;
                        }
                    }
                }
            }
            return steps;
        }

        private int Subtract(int v)
        {
            return v - 1;
        }

        private int DivideByTwo(int v)
        {
            return v / 2;
        }

        private bool even(int v)
        {
            if (v % 2 == 0)
                return true;
            else
                return false;
        }

        public int CountMinSteps2(int[] targetArray)
        {
            if (targetArray.Length == 0)
                return 0;
            int hops = 0;
            int[] inputArray = new int[targetArray.Length];
            for (int i = 0; i < targetArray.Length; i++)
                inputArray[i] = 0;
            while (!AllElementsZero(targetArray))
            {
                int steps = makeArrayEven(targetArray);
                hops += steps;
                if (!AllElementsZero(targetArray))
                {
                    targetArray= DivideArrayByTwo(targetArray);
                    hops++;
                }
            }
            return hops;
        }

        private int[] DivideArrayByTwo(int[] targetArray)
        {
            for (int i = 0; i < targetArray.Length; i++)
            {
                targetArray[i] /= 2;
            }
            return targetArray;
        }

        private int makeArrayEven(int[] targetArray)
        {
            int steps = 0;
            for (int i=0; i< targetArray.Length ;i++)
            {
                if (!even(targetArray[i]))
                {
                    targetArray[i] = Subtract(targetArray[i]);
                    steps++;
                }
            }
            return steps;
        }

        private bool AllElementsZero(int[] targetArray)
        {
            foreach(int i in targetArray)
            {
                if (i != 0)
                    return false;
            }
            return true;
        }
    }
}
