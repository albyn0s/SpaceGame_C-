using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    /// <summary>
    /// метод получения данных
    /// </summary>
     static public class GetInfoLog
    {
        static public void getLogFrom(string log) //берем строку log и отправляем в метод logToFile, logToConsole.
        {
            goTO(log + "\n", SetInfoLog.logToFile);
            goTO(log, SetInfoLog.logToConsole);
        }

        static public void goTO(string log, Action<string> Method) => Method(log); // метод, который принимает строку и принимает способ отправки информации
    }
}
