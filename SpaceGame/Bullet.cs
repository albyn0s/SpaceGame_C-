using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    class Bullet : BaseObject
    {

        Image image = Image.FromFile("5.png");

        public Bullet(Point pos, Point dir, Size size):base(pos,dir,size)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            //Game.Buffer.Graphics.DrawRectangle(Pens.Green, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
            //Game.Buffer.Graphics.FillEllipse(Brushes.Green, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X +=10;
            if (Pos.X > Game.Width) getRndPos();
        }

        public void getRndPos()
        {
            Pos.X = 0;
            Pos.Y = rnd.Next(50, Game.Height-100);
        }
    }
}
