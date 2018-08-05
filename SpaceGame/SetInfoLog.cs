using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    /// <summary>
    /// Вывод данных
    /// </summary>
    static class SetInfoLog // Методы записи лога
    {
        static public void logToConsole(string log) => Console.WriteLine(log); //запись в консоль

        static public void logToFile(string log) => System.IO.File.AppendAllText("log.dat",log); //запись в файл
    }
}
