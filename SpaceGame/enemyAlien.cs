using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Враги на сцене (не реализовано)
    /// </summary>
    class enemyAlien : BaseObject
    {
        Image image = Image.FromFile("12.png"); //Спрайт 

        public int Power { get; set; } //ХП

        public bool lowPower(int damage) // Наносим урон с силой "damage".
        {
            Power -= damage;
            if (Power <= 0) //Если ХП меньше или равно 0, создаем новый объект.
            {

                GetInfoLog.getLogFrom($"{Game.date} Враг уничтожен +30 очков");
                getRndPos();
                return true;
            }

            return false;
        }
        public enemyAlien(Point pos, Point dir, Size size) : base(pos, dir, size) => Power = 15; //создаем объект со случайным кол-вом жизней.

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); //То как будет выглядеть объект.

        //public int getEnemyPosX() => Pos.X;
        //public int getEnemyPosY() => Pos.Y;

        public void enemyStop() => Pos.X = GraphEngine.Width/2;
        
        public override void Update()
        {
            Pos.X -= 10;// Скорость
            //if (Pos.X < GraphEngine.Width / 2) Pos.X = GraphEngine.Width / 2;
        }

    public void getRndPos() //Получаем случайное значение X, Y и размеров.
        {
            Pos.X = rnd.Next(GraphEngine.Width, GraphEngine.Width + 70);
            Pos.Y = rnd.Next(0, GraphEngine.Height);
        }
    }
}
