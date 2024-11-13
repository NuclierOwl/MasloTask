using System;

class Program
{
    static Random random = new Random();
   static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    static void MonkeySort(int[] array, Random random) //сортировка обезьяной
    {
        while (IsSorting(array))
        for (int i = 0; i < array.Length; i++)
        {
            int j = random.Next(array.Length);
            Swap(array, i, j);
            
        }

    }
    static bool IsSorting(int[] array) // определитель отсортированости
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i-1])
                return true;
        }
        return false;
    }

    static void Main(string[] args) 
    {
        Console.Write("Нужны элементы массива: ");
        var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries); //сюда вводят значения игнорируя " ", ",", ";"
        var array = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            
            array[i] = Convert.ToInt32(parts[i]);
        }
        MonkeySort(array, random);
        Console.WriteLine(string.Join(", ", array));

        Console.ReadLine();
    }
}