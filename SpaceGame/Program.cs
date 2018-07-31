using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{
    class Program
    {

        static void Main()
        {
            Form1 form1 = new Form1
            {
                //Width = Screen.PrimaryScreen.Bounds.Width,
                //Height = Screen.PrimaryScreen.Bounds.Height
            };
            SplashScreen.Init(form1);
            SplashScreen.Draw();
            Application.Run(form1);
        }
    }
}