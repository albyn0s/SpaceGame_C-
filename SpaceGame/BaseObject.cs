using System;
using System.Drawing;


namespace SpaceGame
{
    public delegate void Message();
    /// <summary>
    /// Переделанный интерфейс на столкновение объектов
    /// </summary>
    interface ICollision // Переделанный интерфейс на столкновение объектов
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }

    abstract class BaseObject : ICollision
    {
        protected static Random rnd = new Random();

        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Направление</param>
        /// <param name="size">Размеры</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);
        /// <summary>
        /// столкновение объектов
        /// </summary>
        /// <param name="obj">объект</param>
        /// <returns></returns>
        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);

        public abstract void Draw();

        public abstract void Update();
    }

}
