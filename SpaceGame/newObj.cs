using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class newObj : BaseObject
    {
        Pen[] pen = { Pens.White, Pens.Wheat, Pens.DarkKhaki };
        Random r = new Random();
        public newObj(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }        public override void Draw()
        {
            getRect(getColor(), 5);
            getRect(getColor(), 50);
        }

        public Pen getColor()
        {
            return pen[r.Next(0, pen.Length)];
        }
        public void getRect(Pen color, int otherPos)
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Red, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }


        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y + 2;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }
    }
}
