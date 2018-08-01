using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    class GraphEngine
    {
        static public int errorcode;
        static public Random rnd = new Random();

        public static int Width { get; set; }
        public static int Height { get; set; }

        static public void CheckScreen(int Width, int Height)
        {
            if (Width >= 1000 || Height >= 1000 || Width < 0 || Height < 0) throw new ArgumentOutOfRangeException();
        }
        /// <summary>
        /// Метод создания объекта
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="size"></param>
        /// <param name="pos1"></param>
        /// <param name="pos2"></param>
        /// <param name="pos3"></param>
        /// <returns></returns>
        public static T getObj<T>(int size, int pos1, int pos2, int pos3)where T : BaseObject
        {
            Type type = typeof(T);
            {
                if (myException.CheckException(size, pos3, ref errorcode, pos1)) throw new myException("Ошибка создания объекта", ref errorcode);
                else
                {
                    if (type == typeof(newPictureObj)) return (T)(BaseObject)new newPictureObj(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(blackHole)) return (T)(BaseObject)new blackHole(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(Star)) return (T)(BaseObject)new Star(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(SpaceObj)) return (T)(BaseObject)new SpaceObj(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(Asteroid)) return (T)(BaseObject)new Asteroid(new Point(Game.Width, rnd.Next(0, 800)), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(NewForm1Obj)) return (T)(BaseObject)new NewForm1Obj(new Point(Game.Width, rnd.Next(0, 800)), new Point(pos2, pos3), new Size(size, size));
                    else if (type == typeof(Bullet)) return (T)(BaseObject)new Bullet(new Point(0, pos1), new Point(-pos2 / 5, pos3), new Size(size, 2));
                }
                    throw new NotSupportedException();
            }
        }
    }
}
