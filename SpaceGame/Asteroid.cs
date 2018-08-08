using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{

    class Asteroid : BaseObject
    {
        Image image = Image.FromFile("4.png"); //Спрайт

        /// <summary>
        /// прочность астеройда
        /// </summary>
        public int Power { get; set; } //ХП

        /// <summary>
        /// Наносим урон астеройду с силой "damage".
        /// </summary>
        /// <param name="damage">сила урона</param>
        /// <returns></returns>
        public bool lowPower(int damage) // Наносим урон астеройды с силой "damage".
        {
            Power -= damage;
            if(Power <= 0) //Если ХП астеройда меньше или равно 0, создаем новый астеройд.
            {
                
                GetInfoLog.getLogFrom($"{Game.date} Астеройд уничтожен +10 очков"); // Логирование
                getRndPos(); //Перенос по координатам и изменение размеров
                return true;
            }
            
            return false;
        }
        /// <summary>
        /// //создаем астеройд со случайным кол-вом жизней.
        /// </summary>
        /// <param name="pos">позиция</param>
        /// <param name="dir">направление</param>
        /// <param name="size">размеры</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size) => Power = rnd.Next(4,9); //создаем астеройд со случайным кол-вом жизней.

        /// <summary>
        /// //То как будет выглядеть астеройд.
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); //То как будет выглядеть астеройд.

        /// <summary>
        ///  Поведение на сцене 
        /// </summary>
        public override void Update() // Поведение на сцене
        {
            Pos.X -= 10;// Скорость астеройда
            if (Pos.X < -30) getRndPos();//Если улетел за экран, генерируем новый.
        }

        /// <summary>
        /// //Получаем случайное значение X, Y и размеров астеройда.
        /// </summary>
        public void getRndPos() //Получаем случайное значение X, Y и размеров астеройда.
        {
            Pos.X = rnd.Next(GraphEngine.Width, GraphEngine.Width + 70);
            Pos.Y = rnd.Next(0, GraphEngine.Height);
            Size.Width = rnd.Next(10, 40);
            Size.Height = Size.Width;
        }
    }
}
