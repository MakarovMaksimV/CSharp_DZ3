using System;
namespace DZ3
{
	public class Task3
	{
        // Задан лабиринт в виде двумерного массива, где 1 - это стена, 0 - проход,
        // 2 - выход, напишите алгоритм определяющий наличие выходов из лабиринта и
        // координаты точки выхода, если такие имеются

        public Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        public int Count { get; set; }

        public int[,] l = new int[,]{
        {1, 1, 1, 2, 1, 1, 1 },
        {1, 0, 0, 0, 0, 0, 1 },
        {1, 0, 1, 1, 1, 0, 0 },
        {0, 0, 0, 2, 1, 0, 2 },
        {1, 1, 0, 0, 1, 1, 1 },
        {1, 1, 1, 0, 1, 1, 1 },
        {2, 1, 1, 2, 1, 1, 1 }};

        public void FindPath()
        {
            Console.Write("Введите координату x: ");
            int startI = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите координату y: ");
            int startJ = Convert.ToInt32(Console.ReadLine());
            if (startI > l.GetLength(0)
                || startJ > l.GetLength(1) || startI < 0 || startJ < 0)
            {
                Console.WriteLine("Вы ввели координаты за пределами лабиринта");
                FindPath();
            }
            if (l[startI, startJ] == 1)
            {
                Console.WriteLine("Вы ввели координаты стены");
                FindPath();
            }
            if (l[startI, startJ] == 2)
            {
                Console.WriteLine("Вы вышли из лабиринта");
                FindPath();
            }
            else
            {
                HasExit(startI, startJ, l);
            }
        }

        public void HasExit(int i, int j, int[,] l)
        {
            stack.Push(new Tuple<int, int>(i, j));

            if (l[i, j] == 0)

                while (stack.Count > 0)
                {
                    var current = stack.Pop();

                    if (l[current.Item1, current.Item2] == 2 &&
                            (current.Item1 + 1 >= l.GetLength(0)
                            || current.Item2 + 1 >= l.GetLength(1)
                            || current.Item1 - 1 < 0
                            || current.Item2 - 1 < 0))
                    {
                        Count++;
                    }

                    l[current.Item1, current.Item2] = 1;

                    if (current.Item1 + 1 < l.GetLength(0) && l[current.Item1 + 1, current.Item2] != 1)
                        stack.Push(new(current.Item1 + 1, current.Item2));

                    if (current.Item2 + 1 < l.GetLength(1) && l[current.Item1, current.Item2 + 1] != 1)
                        stack.Push(new(current.Item1, current.Item2 + 1));

                    if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] != 1)
                        stack.Push(new(current.Item1 - 1, current.Item2));

                    if (current.Item2 > 0 &&
                        l[current.Item1, current.Item2 - 1] != 1)
                        stack.Push(new(current.Item1, current.Item2 - 1));
                }
            Console.WriteLine($"Колличество выходов: {Count}");
        }
    }
}

