using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _21Tsk
{
    class Program
    {
        /*   Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
         *   Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
         *   Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
         *   Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
         *   Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. 
         *   Садовники должны работать параллельно. Создать многопоточное приложение, моделирующее работу садовников.
         * */
        //Задаем аргументы
        static int wid;
        static int len;
        static int[,] arGard;
        //Задаем метод 1
        static void garWorker1()
        {
            for (int i = 0; i < wid; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (arGard[i, j] == 0) 
                    {
                        arGard[i, j] = 7;
                    }
                    Thread.Sleep(2);
                }
            }
        }
        //Задаем метод 2
        static void garWorker2()
        {
            for (int i =  wid - 1; i > 0; i--)
            {
                for (int j = len - 1; j > 0; j--)
                {
                    if (arGard[j, i] == 0) 
                    {
                        arGard[j, i] = 1;
                    }
                    Thread.Sleep(2);
                }
            }
        }
        static void Main(string[] args)
        {
            //Ввод исходных данных
            Console.WriteLine("Введите размеры участка");
            Console.WriteLine("Введите длину участка");
            wid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите ширину учстка");
            len = Convert.ToInt32(Console.ReadLine());
            arGard = new int[wid, len];
            //Создание потоков
            Thread Gar1 = new Thread(garWorker1);
            Thread Gar2 = new Thread(garWorker2);
            //Старт потоков
            Gar1.Start();
            Gar2.Start();
            //блокировка выполнения потока 
            Gar1.Join();
            Gar2.Join();
            //Вывод полученного массива
            for (int i = 0; i < wid; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.Write(arGard[i,j]  + "  ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
