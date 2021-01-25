using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test
            Model2.Dict<int, string> dict = new Model2.Dict<int, string>();
            dict.Add(new Model1.Item<int, string>(0, "Ноль"));
            dict.Add(new Model1.Item<int, string>(1, "Один"));
            dict.Add(new Model1.Item<int, string>(2, "Два"));
            dict.Add(new Model1.Item<int, string>(3, "Три"));
            dict.Add(new Model1.Item<int, string>(4, "Четыре"));
            dict.Add(new Model1.Item<int, string>(5, "Пять"));
            dict.Add(new Model1.Item<int, string>(6, "Шесть"));
            dict.Add(new Model1.Item<int, string>(7, "Семь"));
            dict.Add(new Model1.Item<int, string>(8, "Восемь"));
            dict.Add(new Model1.Item<int, string>(9, "Девять"));

            foreach (Model1.Item<int, string> item in dict) Console.WriteLine(item);

            Console.WriteLine();
            dict.Remove(1);

            foreach (Model1.Item<int, string> item in dict) Console.WriteLine(item);

            Console.WriteLine();
            dict.Add(new Model1.Item<int, string>(50, "Пятьдесят"));

            foreach (Model1.Item<int, string> item in dict) Console.WriteLine(item);

            Console.WriteLine();
            dict.Remove(7);

            foreach (Model1.Item<int, string> item in dict) Console.WriteLine(item);

            Console.WriteLine();
            Console.WriteLine(dict.Search(50));

            // Model2

            /*Model2.Dict<int, string> dict = new Model2.Dict<int, string>();
            dict.Add(new Model1.Item<int, string>(1, "Один"));
            dict.Add(new Model1.Item<int, string>(1, "Один"));
            dict.Add(new Model1.Item<int, string>(2, "Два"));
            dict.Add(new Model1.Item<int, string>(3, "Три"));
            dict.Add(new Model1.Item<int, string>(4, "Четыре"));
            dict.Add(new Model1.Item<int, string>(5, "Пять"));
            dict.Add(new Model1.Item<int, string>(101, "СтоОдин"));

            foreach (Model1.Item<int, string> item in dict)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(dict.Search(7) ?? "Не найдено");
            Console.WriteLine(dict.Search(3) ?? "Не найдено");
            Console.WriteLine(dict.Search(101) ?? "Не найдено");


            dict.Remove(3);
            dict.Remove(1);

            foreach (Model1.Item<int, string> item in dict)
            {
                Console.WriteLine(item);
            }*/

            // Model 1

            /*Model1.EasyMap<int, string> easyMap = new Model1.EasyMap<int, string>();
            easyMap.Add(new Model1.Item<int, string>(1, "Один"));
            easyMap.Add(new Model1.Item<int, string>(2, "Два"));
            easyMap.Add(new Model1.Item<int, string>(3, "Три"));
            easyMap.Add(new Model1.Item<int, string>(4, "Четыре"));
            easyMap.Add(new Model1.Item<int, string>(5, "Пять"));

            foreach(Model1.Item<int, string> item in easyMap)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(easyMap.Search(7) ?? "Не найдено");
            Console.WriteLine(easyMap.Search(3) ?? "Не найдено");

            Console.WriteLine(easyMap.Remove(2));
            Console.WriteLine(easyMap.Remove(7));*/

            Console.ReadLine();
        }
    }
}
