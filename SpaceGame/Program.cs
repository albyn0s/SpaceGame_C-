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
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;

            SplashScreen.Init(form);
            form.Show();
            SplashScreen.Draw();

            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }

}