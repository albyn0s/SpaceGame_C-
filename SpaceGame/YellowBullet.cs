using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Тип пули 2
    /// </summary>
    class YellowBullet : Bullet
    {
        private int bulSpeed = 20; // задаем скррость
        new static public int Damage { get; set; }

        Image image = Image.FromFile("9.png"); // Спрайт

        public YellowBullet(Point pos, Point dir, Size size) : base(pos, dir, size) { Damage = 10; } // Урон и конструктор

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); // отрисовка пули

        public override void Update() => Pos.X += bulSpeed; //Полет пули
    }
}
