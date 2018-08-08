using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    class Heal : BaseObject
    {
        Image image = Image.FromFile("6.png"); // спрайт аптечки

        public Heal(Point pos, Point dir, Size size):base(pos,dir,size) { } // констурктор

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); //отрисовка

        public override void Update() //поведение на сцене
        {
            Pos.X -= 5;
            if (Pos.X < -30) getRndPos();//Если улетел за экран, генерируем новый.
        }
        /// <summary>
        /// //Получаем случайное значение X, Y.
        /// </summary>
        public void getRndPos() //Получаем случайное значение X, Y.
        {
            Pos.X = rnd.Next(GraphEngine.Width, GraphEngine.Width + 200);
            Pos.Y = rnd.Next(0, GraphEngine.Height);
        }
    }
}
