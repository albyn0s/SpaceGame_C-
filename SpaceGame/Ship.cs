﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SpaceGame
{
    class Ship : BaseObject
    {
        public static event Message MessageDie; // Событие сообщения Die

        Image image = Image.FromFile("8.png"); //спрайт

        private int _energy = 100; //Энергия
        private int _point = 0; //Очки
        public int Energy => _energy;
        public int Point => _point;

        public void EnergyLow(int n) => _energy -= n; //Метод отнимания энергии
        public void EnergyGet(int n)// Метод получения энергии
        {
            if (Energy < 100) _energy += n;
            if (Energy >= 100) _energy = 100;
        }

        public void getPoint() => _point += 10; //Метод получения очков

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size) { } //констуктор для корабля

        public override void Draw() => Game.Buffer.Graphics.DrawImage(image, new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height)); // отрисовка корабля

        public override void Update() { }

        public int getShipPos() => Pos.Y+7; //Получение позиции корабля для пули

        //public int getShipPosY() => Pos.Y; координата для врага (не реализовано)
        //public int getShipPosX() => Pos.X;

        public void Control(Keys key) //Управление корабля
        {
            if (key == Keys.W || key == Keys.Up) Pos.Y -= Dir.Y;
            if (key == Keys.S || key == Keys.Down) Pos.Y += Dir.Y;
        }

        public void Die() => MessageDie();
    }
}
