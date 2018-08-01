using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class newPictureObj : BaseObject
    {
        public newPictureObj(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw() => getRect(Pens.Red, 50);


        public void getRect(Pen color, int otherPos)
        {
            Game.Buffer.Graphics.DrawRectangle(color, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        public override void Update()
        {          
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y + 2;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }

    }

    class blackHole : BaseObject
    {
        Image image = Image.FromFile("2.png");

        public blackHole(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y;
            if (Pos.Y < -200) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < -200) Pos.X = Game.Width - Size.Width;
        }
    }
}
