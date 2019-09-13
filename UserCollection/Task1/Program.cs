using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создайте метод, который в качестве аргумента принимает массив целых чисел и возвращает
//коллекцию квадратов всех нечетных чисел массива.Для формирования коллекции
//используйте оператор yield.

namespace Task1
{
    class Program
    {
        /// <summary>
        /// Метод возвращает коллекцию квадратов нечетных чисел 
        /// </summary>
        /// <param name="arrInt">Массив целочисленных чисел</param>
        /// <returns>IEnumerable коллекция квадрат нечетных чисел</returns>
        static IEnumerable GetOddCollection(int[] arrInt)
        {
            for (int i = 0; i < arrInt.Length; i++)
            {
                if (arrInt[i] % 2 != 0)
                {
                    yield return arrInt[i] * arrInt[i];
                }
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] myCollection = new int[10];
            Console.Write("Collection before: ");
            for (int i = 0; i < myCollection.Length; i++)
            {
                myCollection[i] = random.Next(0,100);
            }
            foreach (var item in myCollection)
            {
                Console.Write(item+" ");
            }
            Console.Write("\nCollection after: ");
            foreach (var item in GetOddCollection(myCollection))
            {
                Console.Write(item+" ");
            }
            Console.WriteLine("\nНажмите любую кнопку для выхода...");
            Console.ReadKey();
        }
    }
}
