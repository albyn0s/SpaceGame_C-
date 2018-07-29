using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{
    class Program : Form
    {
        static Form1 form1 = new Form1();

        static void Main()
        {

            SplashScreen.Init(form1);
            SplashScreen.Draw();
            Application.Run(form1);

        }
    }
}