using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
а) для целых чисел;
б) *для обобщенной коллекции;
в) *используя Linq.*/

            Random rnd = new Random();
            
            //а) для целых чисел;
            List<int> myListA = new List<int>();
            while (myListA.Count() < 10) myListA.Add(rnd.Next(0, 10)); //заполнение массива;

            Console.Write(" List A =");
            foreach (int el in myListA) Console.Write($" {el}");

            Console.WriteLine("\n");

            for (int i = 0; i < myListA.Count(); i++)
            {
                int index = 1;//счетчик одинаковых элементов
                for (int j = 0; j < myListA.Count(); j++)
                {
                    if (myListA[i].Equals(myListA[j]))
                    {
                        if (j == i) continue; //если индекс тот же самый переходим к следующему.
                        index++; //если совпадение найдено прибавляем к счетчику.
                        myListA.RemoveAt(j); //стандартно удаляем объект
                        j = 0; //обнуляем j счетчик.
                    }
                }
                Console.WriteLine($" {myListA[i]} : {index} count");//выводим первый повторяющийся элемент
            }
            Console.WriteLine();
            foreach (int el in myListA) Console.Write($" {el}");//вывод итога

            Console.WriteLine();
            
            //б) *для обобщенной коллекции;
            MyList<double> myListB = new MyList<double>();//создан свой класс для коллекции.
            while (myListB.MyCount < 10) myListB.Add(rnd.Next(0, 4)); //заполнение

            
            sortList(myListB, "\n List B =");//нахождение элементов (метод ниже)

            Console.WriteLine("\n");
            
            //в) *используя Linq.
            List<int> myListC = new List<int>();
            while (myListC.Count < 10) myListC.Add(rnd.Next(0, 4));

            Console.Write(" List C =");
            foreach (int el in myListC) Console.Write($" {el}");

            Console.WriteLine("\n");
            Program p = new Program();

            var Mylist = from el in myListC group el by el; //получаем кол-во повт элементов и сам элемент

            foreach (var el in Mylist)
                Console.WriteLine($" {el.Key} : {el.Count()} count"); //вывод повт элементов с кол-вом

            Console.WriteLine();
            foreach (var el in Mylist) Console.Write($" {el.Key}"); //вывод

            Console.WriteLine();

            Console.ReadKey();


        }
        /// <summary>
        /// //б) *для обобщенной коллекции;
        /// </summary>
        /// <typeparam name="T">тип объекта</typeparam>
        /// <param name="myList">передаваемая коллекция</param>
        /// <param name="text">текст для вывода</param>
        public static void sortList<T>(MyList<T> myList, string text)            //б) *для обобщенной коллекции;
        {
            Console.Write(text); //вывод ListB =
            foreach (T el in myList) Console.Write($" {el}");// вывод изначальных элементов

            Console.WriteLine("\n");

            for (int i = 0; i < myList.MyCount; i++)
            {
                int index = 1;
                for (int j = 0; j < myList.MyCount; j++)
                {
                    if (myList[i].Equals(myList[j]))
                    {
                        if (j == i) continue; //если индекс тот же самый переходим к следующему.
                        myList.RemoveAt(j); // удаляем объект по логике описанной в классе
                        index++; //если совпадение найдено прибавляем к счетчику.
                        j = 0; //обнуляем j счетчик.
                    }
                }
                Console.WriteLine($" {myList[i]} : {index} count"); //вывод
            }
            Console.WriteLine();
            foreach (T el in myList) Console.Write($" {el}"); //итог
        }

    }
}
