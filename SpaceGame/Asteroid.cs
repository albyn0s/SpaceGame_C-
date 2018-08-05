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

        public int Power { get; set; } //ХП

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
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size) => Power = rnd.Next(4,9); //создаем астеройд со случайным кол-вом жизней.

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); //То как будет выглядеть астеройд.

        public override void Update() // Поведение на сцене
        {
            Pos.X -= 10;// Скорость астеройда
            if (Pos.X < -30) getRndPos();//Если улетел за экран, генерируем новый.
        }

        public void getRndPos() //Получаем случайное значение X, Y и размеров астеройда.
        {
            Pos.X = rnd.Next(GraphEngine.Width, GraphEngine.Width + 70);
            Pos.Y = rnd.Next(0, GraphEngine.Height);
            Size.Width = rnd.Next(10, 40);
            Size.Height = Size.Width;
        }
    }
}
