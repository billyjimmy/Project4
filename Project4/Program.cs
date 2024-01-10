using System;
using System.Drawing;
using System.Text;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DEMO_SIZE = 10;
            bool loop = true;
            int[] demoData = new int[DEMO_SIZE];
            int input;
            while (loop)
            {
                demoData = GenerateDataset(DEMO_SIZE, 10);
                Console.WriteLine("\n1. Run Bubble Sort Test\n2. Run Quicksort Test\n3. Run Comparison Test\n4. Quit");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1: //Demonstrate Bubble Sort
                        BubbleSort(ref demoData, true);
                        break;
                    case 2: //Demonstrate Quicksort
                        Quicksort(ref demoData, 0, DEMO_SIZE - 1, true);
                        break;
                    case 3: //Run comparison test
                        ComparisonTest(500, 1000);
                        ComparisonTest(1000, 1000);
                        ComparisonTest(2000, 1000);
                        ComparisonTest(3000, 1000);
                        ComparisonTest(4000, 1000);
                        ComparisonTest(5000, 1000);
                        ComparisonTest(7500, 1000);
                        ComparisonTest(10000, 1000);
                        ComparisonTest(15000, 1000);
                        break;
                    case 4: //Quit
                        loop = false;
                        break;
                
                }
            }
        }


        static void BubbleSort(ref int[] data, bool demo = false)
        {
            int size = data.Length;
            int temp;
            bool noSwap = false;

            while (noSwap == false) //While the array is not sorted
            {
                if (demo) { printArray(data);}
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
            if (demo) { printArray(data); }
        }


        static void Quicksort(ref int[] data, int low, int high, bool demo = false)
        {
            if (low < high)
            {
                
                int partitionIndex = Partition(ref data, low, high);
                Quicksort(ref data, low, partitionIndex - 1);                
                Quicksort(ref data, partitionIndex + 1, high);
                if (demo) { printArray(data); }
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
            string output = data[0].ToString();
            for (int i = 1; i < data.Length; i++)
            {
                output += ", " + data[i];                
            }
            Console.WriteLine("Data: " + output);
        }

        static void ComparisonTest(int size, int range)
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