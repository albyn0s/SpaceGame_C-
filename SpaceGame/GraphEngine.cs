using System;
using System.Drawing;

namespace SpaceGame
{
    class GraphEngine
    {
        static int errorcode; // Код ошибки
        static public Random rnd = new Random(); 

        public static int Width { get; set; }
        public static int Height { get; set; }

        static public void CheckScreen(int Width, int Height) // проверка размеров экрана.
        {
            if (Width >= 1000 || Height >= 1000 || Width < 0 || Height < 0) throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Метод создания объекта
        /// </summary>
        /// <typeparam name="T">Передаваемый класс объекта</typeparam>
        /// <param name="size">Размер объекта</param>
        /// <param name="pos1">Позиция по Y</param>
        /// <param name="pos2">Направление X</param>
        /// <param name="pos3">Направление Y</param>
        /// <returns></returns>
        public static T getObj<T>(int size, int pos1, int pos2, int pos3)where T : BaseObject
        {
            Type type = typeof(T);
            {
                if (myException.CheckException(size, pos3, ref errorcode, pos1)) throw new myException("Ошибка создания объекта", ref errorcode); // проверка на исключительную ситуацию
                else
                {
                    if (type == typeof(newPictureObj)) return (T)(BaseObject)new newPictureObj(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(blackHole)) return (T)(BaseObject)new blackHole(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(Star)) return (T)(BaseObject)new Star(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(SpaceObj)) return (T)(BaseObject)new SpaceObj(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(Asteroid)) return (T)(BaseObject)new Asteroid(new Point(rnd.Next(Game.Width, Game.Width + 70), rnd.Next(0, 800)), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(NewForm1Obj)) return (T)(BaseObject)new NewForm1Obj(new Point(Game.Width, rnd.Next(0, 800)), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(Bullet)) return (T)(BaseObject)new Bullet(new Point(20, pos1), new Point(-pos2 / 5, pos3), new Size(size, 4));
                    else if (type == typeof(Heal)) return (T)(BaseObject)new Heal(new Point(rnd.Next(Game.Width, Game.Width + 70), rnd.Next(0, 800)), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(YellowBullet)) return (T)(BaseObject)new YellowBullet(new Point(20, pos1), new Point(-pos2 / 5, pos3), new Size(size, 4));
                    else if (type == typeof(BlueBullet)) return (T)(BaseObject)new BlueBullet(new Point(20, pos1), new Point(-pos2 / 5, pos3), new Size(size, 4));
                    //else if (type == typeof(enemyBullet)) return (T)(BaseObject)new enemyBullet(new Point(Game._enemy.getEnemyPosX(), Game._enemy.getEnemyPosY()+10), new Point(0, 0), new Size(size, size));
                }
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// отрисовка всех объектов
        /// </summary>
        static public void drawObjects()
        {
            foreach (BaseObject obj in Game._objs) obj?.Draw();
            foreach (Asteroid ast in Game._asteroids) ast?.Draw();
            foreach (Bullet bul in Game._bullet) bul?.Draw();
            Game._heal?.Draw();
            Game._ship?.Draw();
            //Game._enemy?.Draw();
            //Game._enemyBul?.Draw();
        }
    }
}
