using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{

    class Asteroid : BaseObject, ICloneable
    {
        Image image = Image.FromFile("4.png");

        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new 
            Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height));

            asteroid.Power = Power;
            return asteroid;
        }

        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        public override void Update()
        {
            Pos.X -= 10;
            if (Pos.X < 0) getRndPos();
        }

        public void getRndPos()
        {
            Pos.X = rnd.Next(Game.Width, Game.Width + 70);
            Pos.Y = rnd.Next(0, Game.Height);
            Size.Width = rnd.Next(10, 40);
            Size.Height = Size.Width;
        }
    }
}
