using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Star : BaseObject
    {
        int i = 0;
        Pen[] pen = { Pens.White, Pens.Wheat, Pens.DarkKhaki };
        Pen[] pen1 = { Pens.White, Pens.Wheat, Pens.Cyan };
        Random r = new Random();
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            getStar(getColor(true), 5);
            getStar(getColor(false), 50);
            i++;
        }

        public Pen getColor(bool flag)
        {
            if (flag) return pen[r.Next(0, pen.Length)];
            return pen1[r.Next(0, pen1.Length)];
        }
        public void getStar(Pen color, int otherPos)
        {
            Game.Buffer.Graphics.DrawLine(color, Pos.X + otherPos, Pos.Y + otherPos, Pos.X + Size.Width + otherPos, Pos.Y + Size.Height + otherPos);
            Game.Buffer.Graphics.DrawLine(color, Pos.X + Size.Width + otherPos, Pos.Y + otherPos, Pos.X + otherPos, Pos.Y + Size.Height + otherPos);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y +2;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }
    }
}
