// Writer Alireza Rakhodapour



using System;

namespace homework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[10];
            Console.WriteLine("Original array:");
            for (int i=0; i<array.Length;i++)
            {
                array[i]=int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write(i+", ");
            }
            Console.WriteLine();
            array = mergeSort(array);
            Console.WriteLine("Sorted array:");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }

        public static int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];

            if (array.Length <= 1)
                return array;

            int middle = array.Length / 2;
            left = new int[middle];

            if (array.Length % 2 == 0)
                right = new int[middle];
            else
                right = new int[middle + 1];

            for (int i = 0; i < middle; i++)
                left[i] = array[i];

            int x = 0;
            for (int i = middle; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            left = mergeSort(left);
            right = mergeSort(right);
            result = Add(left, right);

            return result;
        }

        public static int[] Add(int[] l, int[] r)
        {
            int resultLength = r.Length + l.Length;
            int[] result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;

            while (indexLeft < l.Length || indexRight < r.Length)
            {
                if (indexLeft < l.Length && indexRight < r.Length)
                {
                    if (l[indexLeft] <= r[indexRight])
                    {
                        result[indexResult] = l[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = r[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < l.Length)
                {
                    result[indexResult] = l[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < r.Length)
                {
                    result[indexResult] = r[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
    }
}
