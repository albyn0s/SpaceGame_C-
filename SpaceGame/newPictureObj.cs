using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    /// <summary>
    /// Объекты на сцене игры
    /// </summary>
    class newPictureObj : BaseObject
    {
        public newPictureObj(Point pos, Point dir, Size size) : base(pos, dir, size){ } //конструтор

        public override void Draw() => Game.Buffer.Graphics.DrawRectangle(Pens.Red, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));// Отрисовка

        public override void Update() //Поведение
        {          
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y + 2;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }

    }
}
