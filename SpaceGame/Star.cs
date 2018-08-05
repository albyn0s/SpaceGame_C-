using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    /// <summary>
    /// звезды на сцене игры
    /// </summary>
    class Star : BaseObject
    {
        Pen[] pen = { Pens.White, Pens.Wheat, Pens.DarkKhaki }; //Массив переливания цвета 1.
        Pen[] pen1 = { Pens.White, Pens.Wheat, Pens.Cyan };//Массив переливания цвета 2.
        Random r = new Random();
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { } // Конструтор

        public override void Draw() //Отрисовка
        {
            getStar(getColor(true), 5);
            getStar(getColor(false), 50);
        }

        public Pen getColor(bool flag) //Получение цвета для звезд
        {
            if (flag) return pen[r.Next(0, pen.Length)];
            return pen1[r.Next(0, pen1.Length)];
        }
        /// <summary>
        /// Отрисовка звезд
        /// </summary>
        /// <param name="color">Передаваемый цвет</param>
        /// <param name="otherPos">Сдвиг</param>
        public void getStar(Pen color, int otherPos) // вывод звезд
        {
            Game.Buffer.Graphics.DrawLine(color, Pos.X + otherPos, Pos.Y + otherPos, Pos.X + Size.Width + otherPos, Pos.Y + Size.Height + otherPos);
            Game.Buffer.Graphics.DrawLine(color, Pos.X + Size.Width + otherPos, Pos.Y + otherPos, Pos.X + otherPos, Pos.Y + Size.Height + otherPos);
        }

        public override void Update() //поведение
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y - Dir.Y +2;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
        }
    }
}
