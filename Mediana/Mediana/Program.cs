using System;
using System.Collections.Generic;

public class MedianFinder // прописаный в тз класс
{
    private List<int> nums;

    public MedianFinder() // иницилизатор
    {
        nums = new List<int>();
    }

    public void AddNum(int num) // добавление чисел
    {
        nums.Add(num);
        nums.Sort();
    }

    public double FindMedian() // поиск медиан
    {
        int count = nums.Count;
        if (count % 2 == 0)
        {
            return (nums[count / 2 - 1] + nums[count / 2]) / 2.0;
        }
        else
        {
            return nums[count / 2];
        }
    }
}

class Program
{
    static void Main(string[] args) // консолька с 2 командами
    {
        MedianFinder medianFinder = new MedianFinder();
        string commander;

        while (true)
        {
            Console.WriteLine("Введите команду (addNum <число> для добавления, findMedian для получения медианы, exit для выхода):"); // инструкция для usera
            commander = Console.ReadLine();

            if (commander.StartsWith("addNum")) // добавления номера
            {
                int num = int.Parse(commander.Split(' ')[1]);
                medianFinder.AddNum(num);
            }
            else if (commander == "findMedian") // отображение медианы
            {
                Console.WriteLine("Медиана: " + medianFinder.FindMedian());
            }
            else if (commander == "exit") // точка выхода
            {
                break;
            }
            else
            {
                Console.WriteLine("Не та команда. Давай по новой.");
            }
        }
    }
}
