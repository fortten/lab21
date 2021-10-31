using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab21
{
    /* Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
     * Эту задачу выполняют два садовника-мизантропа. Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо,
     * сделав ряд, он спускается вниз. Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
     * Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники работают параллельно. Создать многопоточное приложение, моделирующее работу садовников.*/
    class Program
    {
        static int[,] garden;
        static int a;
        static int b;

        static void Main(string[] args)
        {
            Console.Write("Введите длину участка: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину участка: ");
            b = Convert.ToInt32(Console.ReadLine());
            garden = new int[a, b];
            ThreadStart threadStart1 = new ThreadStart(Gardener1);
            Thread thread1 = new Thread(threadStart1);
            ThreadStart threadStart2 = new ThreadStart(Gardener2);
            Thread thread2 = new Thread(threadStart2);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {                    
                    Console.Write($"{garden[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i,j] == 0)
                    {
                        garden[i, j] = 1;
                        Thread.Sleep(1);
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int i = a-1; i > 0; i--)
            {
                for (int j = b-1; j > 0; j--)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 2;
                        Thread.Sleep(1);
                    }
                }
            }
        }
    }
}
