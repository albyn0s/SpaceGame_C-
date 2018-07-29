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
        static Form form = new Form();
        static Form1 form1 = new Form1();
        static Form2 form2 = new Form2();
        //static Form2 form1 = new Form2();

        static void Main()
        {
            form.Width = 800;
            form.Height = 600;

            SplashScreen.Init(form1);
            SplashScreen.Draw();
            Application.Run(form1);

        }

        static public void b1_click(object sender, EventArgs e)
        {
            Game.Init(form2);
            form1.Show();
            Game.Draw();
        }
        //static public void key_Down(object sender, KeyEventArgs e)
        //{
        //    int currentKey = e.KeyValue;
        //    switch (currentKey)
        //    {
        //        case 113:
        //            SpaceGame.SplashScreen.Init(form);
        //            form.Show();
        //            SpaceGame.SplashScreen.Draw();
        //            break;
        //        case 112:
        //            Game.Init(form);
        //            form.Show();
        //            Game.Draw();
        //            break;
        //    }
        //}
    }
}