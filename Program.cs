using System;
using System.Threading;
using System.IO;

/**<remark>
 * Write 10 numbers and 10 strings to the same file. Numbers are written from one thread, strings from another one.
 * Запишите 10 чисел и 10 строк в один и тот же файл. Числа записываются из одного потока, строки из другого.
</remark> */

namespace _20180329_Task3_Thread
{
    internal class Program
    {
        private static readonly StreamWriter commonResource = new StreamWriter(@"CommonFile.txt", false);

        private static void FirstTread()
        {
            Console.WriteLine("Первый поток начал запись!");

            for (int i = 1; i <= 10; i++)
            {
                commonResource.WriteLine(i);
            }
            Console.WriteLine("Первый поток завершил запись!");
        }

        private static void SecondTread()
        {
            Console.WriteLine("Второй поток начал запись!");

            for (int i = 1; i <= 10; i++)
            {
                commonResource.WriteLine("Hello User!");
            }
            Console.WriteLine("Второй поток завершил запись!");
        }

        private static void Main()
        {
            Thread firstThread = new Thread(FirstTread);
            Thread secondThread = new Thread(SecondTread);

            firstThread.Start();
            secondThread.Start();

            firstThread.Join();
            secondThread.Join();

            commonResource.Close();

            Console.ReadKey();
        }
    }
}