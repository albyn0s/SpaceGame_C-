using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Тип пули 3
    /// </summary>
    class BlueBullet : Bullet
    {
        private int bulSpeed = 15; // Скорость
        new static public int Damage { get; set; }

        Image image = Image.FromFile("10.png"); // спрайт 

        public BlueBullet(Point pos, Point dir, Size size) : base(pos, dir, size) => Damage = 1;  // Урон и контруктор

        public override void Draw() // Отрисовка пули
        {
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y+3, Size.Width, Size.Height));
            Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y-3, Size.Width, Size.Height));
        }

        public override void Update() => Pos.X += bulSpeed; //Полет пули
    }
}
