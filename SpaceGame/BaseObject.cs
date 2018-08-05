using System;
using System.Drawing;


namespace SpaceGame
{
    public delegate void Message();

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


        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);
        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);

        public abstract void Draw();

        public abstract void Update();
    }

}
