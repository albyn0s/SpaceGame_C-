using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Основной тип пули
    /// </summary>
    class Bullet : BaseObject
    {
        private int bulSpeed = 10; //скорость
        static public int Damage { get; set; }

        Image image = Image.FromFile("5.png");//спрайт

        public Bullet(Point pos, Point dir, Size size):base(pos,dir,size){ Damage = 1; }//Урон

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));//Отрисовка

        public override void Update() => Pos.X += bulSpeed;//Полет пули

        public void getNull() => Pos.Y = 1000; // через foreach не удалось уничтожить объект, поэтому отправляю его далеко и надолго по Y

    }
}
