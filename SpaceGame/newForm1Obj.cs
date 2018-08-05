using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    /// <summary>
    /// Объекты на загрузочном экране
    /// </summary>
    class NewForm1Obj : BaseObject
    {
        public NewForm1Obj(Point pos, Point dir, Size size) : base(pos, dir, size){ } //консруктор

        Image image = Image.FromFile("3.png");//спрайт

        public override void Draw() => SplashScreen.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); //отрисовка

        public override void Update() //поведение
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
        }
    }
}
