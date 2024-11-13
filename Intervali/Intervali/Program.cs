using System;
using System.Collections.Generic;

public class SummaRenga
{
    private SortedSet<int> numbers;
    public SummaRenga()
    {
        numbers = new SortedSet<int>();
    }
    public void addNum(int val) // добавление номеров
    {
        numbers.Add(val);
    }

    public int[][] getInter() // поиск нужного интервала
    {
        List<int[]> intervals = new List<int[]>();
        if (numbers.Count == 0) return intervals.ToArray();

        int start = -1, end = -1;

        foreach (var num in numbers)
        {
            if (start == -1)
            {
                start = num;
                end = num;
            }
            else if (num == end + 1)
            {
                end = num;
            }
            else
            {
                intervals.Add(new int[] { start, end });
                start = num;
                end = num;
            }
        }

        intervals.Add(new int[] { start, end });
        return intervals.ToArray();
    }
}

class Programka
{
    static void Main(string[] args)
    {
        SummaRenga summa = new SummaRenga();
        string commanda;

        while (true)
        {
            Console.WriteLine("Введите команду (addNum <число>  или getIntervals для получения интервалов):"); // инструкция для косоли
            commanda = Console.ReadLine();

            if (commanda.StartsWith("addNum")) // красивай способ добавлять номера
            {
                int value = int.Parse(commanda.Split(' ')[1]);
                summa.addNum(value);
                Console.WriteLine("Число добавлено.");
            }
            else if (commanda == "getIntervals") // красивый способ отображать номера
            {
                var inters = summa.getInter();
                Console.WriteLine("Интервалы:");
                Console.WriteLine("| Начало | Конец |");
                Console.WriteLine("|--------|-------|");
                foreach (var inter in inters)
                {
                    Console.WriteLine($"| {inter[0]}      | {inter[1]}    |");
                }
            }
            else
            {
                Console.WriteLine("Неверная команда. Попробуйте снова.");
            }
        }
    }
}
