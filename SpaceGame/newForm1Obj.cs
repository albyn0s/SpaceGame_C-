using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class NewForm1Obj : BaseObject
    {
        int i = 0;
        Pen[] pen = { Pens.White, Pens.Wheat, Pens.DarkKhaki };
        Pen[] pen1 = { Pens.White, Pens.Wheat, Pens.Cyan };
        Random r = new Random();
        public NewForm1Obj(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }

        Image image = Image.FromFile("3.png");

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
            SplashScreen.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));
        }

        public override void Update()
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
