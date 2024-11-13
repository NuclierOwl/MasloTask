using System;

class Program
{
    static void Main() // основная часть
    {
        Console.WriteLine("Введите количество элементов массива:");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        BubbleSort(array);

        Console.WriteLine("Отсортированный массив:");
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }

    static void BubbleSort(int[] arr) // сортеровка массива
    {
        int temp;
        for (int j = 0; j < arr.Length - 1; j++)
        {
            for (int i = 0; i < arr.Length - 1 - j; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
        }
    }
}