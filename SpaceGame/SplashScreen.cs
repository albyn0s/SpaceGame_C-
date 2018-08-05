﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Начальный экран
    /// </summary>
    class SplashScreen : GraphEngine 
    {
        public static BufferedGraphics Buffer; 

        static public void getGraph(Form form) //Буфер для графики.
        {
            Width = form.Width;
            Height = form.Height;
            Buffer = BufferedGraphicsManager.Current.Allocate(form.CreateGraphics(), new Rectangle(0, 0, Width, Height));
        }

        public static void Init(Form form) //Инициализация формы.
        {
            getGraph(form);

            Timer timer = new Timer { Interval = 35 };
            timer.Start();
            timer.Tick += Timer_Tick;

            Load(); // Загрузка объектов.
        }

        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw() // Отрисовка объектов на сцене.
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) if (obj != null) obj.Draw();
            Buffer.Render();
        }
        public static void Update() // Обновление данных для каждого объекта.
        {
            CheckScreen(Width, Height); // Проверка размеров экрана.
            foreach (BaseObject obj in _objs) obj.Update();
        }

        private static BaseObject[] _objs;

        public static void Load() //Заполнение массива с объектами
        {
            _objs = new BaseObject[50];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = getObj<NewForm1Obj>(10, i * 20, -i, 2);
            }
        }
    }
}
