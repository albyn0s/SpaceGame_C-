using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Пуля для врагов (не реализовано)
    /// </summary>
    class enemyBullet : Bullet
    {

        private int bulSpeed = 5; //скорость пули
        new static public int Damage { get; set; }

        Image image = Image.FromFile("11.png"); // спрайт

        public enemyBullet(Point pos, Point dir, Size size) : base(pos, dir, size) => Damage = 2; //констурктор с заданным уроном

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height));

        public override void Update()
        {
            Pos.X += bulSpeed;
        }
    }
}
