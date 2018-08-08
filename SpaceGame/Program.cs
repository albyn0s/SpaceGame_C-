using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{
    class Program
    {
        static void Main()
        {
            System.IO.File.Create("log.dat").Close(); //создаем файл для лога и закрываем его.

            Form1 form1 = new Form1(); // создаем форму.

            SplashScreen.Init(form1); // Заполняем форму для начального экрана.
            SplashScreen.Draw(); // Отрисовываем форму.

            Application.Run(form1); // Запускаем приложение.
        }
    }
}