using System;

class Program
{
    static void Main() // основная часть
    {
        Console.WriteLine("Нужны элементы массива: ");
        var n = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries); //сюда вводят значения игнорируя " ", ",", ";"
        var array = new int[n.Length];
        for (int i = 0; i < n.Length; i++)
        {
            array[i] = Convert.ToInt32(n[i]);
        }
        MerSort(array, 0, n.Length - 1);
        Console.WriteLine("Отсортированный:");
        PrintArray(array);
    }


    static void MerSort(int[] array, int left, int right) // сама счортировка 
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MerSort(array, left, middle);
            MerSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }


    static void Merge(int[] array, int left, int middle, int right) // слияние левого и правого массива
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;
        int[] Levo = new int[n1];
        int[] Pravo = new int[n2];
        for (int b = 0; b < n1; b++)  // заполнение левого массива
        {
            Levo[b] = array[left + b];
        }
        for (int v = 0; v < n2; v++) // заполнение правого массива
        {
            Pravo[v] = array[middle + 1 + v];
        }
        int k = left;
        int i = 0, j = 0;
        while (i < n1 && j < n2) // сравнение значений в массивах
        {
            if (Levo[i] <= Pravo[j])
            {
                array[k] = Levo[i];
                i++;
            }
            else
            {
                array[k] = Pravo[j];
                j++;
            }
            k++;
        }
        while (i < n1) // перегонка значений из левого в изначайный массив
        {
            array[k] = Levo[i];
            i++;
            k++;
        }
        while (j < n2) // перегонка значений из правого в изначайный массив
        {
            array[k] = Pravo[j];
            j++;
            k++;
        }
    }

    static void PrintArray(int[] array) // отображение массива
    {
        foreach (int value in array)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }
}