using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Черная дыра
    /// </summary>
    class blackHole : BaseObject
    {
        Image image = Image.FromFile("2.png"); //спрайт

        public blackHole(Point pos, Point dir, Size size) : base(pos, dir, size) { }//констурктор

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); //отрисовка

        public override void Update() //поведение
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < -200) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < -200) Pos.X = Game.Width - Size.Width;
        }
    }
}
