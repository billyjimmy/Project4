using System;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                RunTest(500, 1000);
                RunTest(1000, 1000);
                RunTest(2000, 1000);
                RunTest(3000, 1000);
                RunTest(4000, 1000);
                RunTest(5000, 1000);
                RunTest(7500, 1000);
                RunTest(10000, 1000);
                RunTest(15000, 1000);

                Console.WriteLine("\nRun Again?");
                if (Console.ReadLine() != "y")
                {
                    loop = false;
                }
            }

        }


        static void BubbleSort(ref int[] data)
        {
            int size = data.Length;
            int temp;
            bool noSwap = false;

            while (noSwap == false) //While the array is not sorted
            {
                noSwap = true;
                for (int i = 0; i < size - 1; i++) //Make a pass
                {
                    if (data[i] > data[i+1]) //If not in ascending order, swap them
                    {
                        temp = data[i];
                        data[i] = data[i+1];
                        data[i+1] = temp;
                        noSwap = false;
                    }
                }
            }
        }


        static void Quicksort(ref int[] data, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(ref data, low, high);
                Quicksort(ref data, low, partitionIndex - 1);
                Quicksort(ref data, partitionIndex + 1, high);                
            }
        }
        static int Partition(ref int[] data, int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (data[j] < pivot)
                {
                    i++;
                    Swap(ref data, i, j);
                }
            }
            Swap(ref data, i + 1, high);
            return i + 1;
        }
        static void Swap(ref int[] data, int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        static int[] GenerateDataset(int size, int range)
        {
            Random random = new Random();
            int[] dataset = new int[size];
            for (int i = 0; i < size - 1; i++)
            {
                dataset[i] = random.Next(0, range);
            }
            return dataset;
        }

        static void printArray(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine(i + ": " + data[i] + "\n");
            }
        }

        static void RunTest(int size, int range)
        {
            int[] array1 = GenerateDataset(size, range);
            int[] array2 = array1;

            DateTime start;
            DateTime end;
            long duration;

            Console.WriteLine("Array size: " + size + "\nRange: " + range);

            start = DateTime.Now;
            BubbleSort(ref array1);
            end = DateTime.Now;
            duration = (long)(end - start).TotalMilliseconds;
            Console.WriteLine("Bubble sort: " + duration + " milliseconds");

            start = DateTime.Now;
            Quicksort(ref array2, 0, array2.Length - 1);
            end = DateTime.Now;
            duration = (long)(end - start).TotalMilliseconds;
            Console.WriteLine("Quicksort: " + duration + " milliseconds\n");
        }
    }
}