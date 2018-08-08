using System;
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


        /// <summary>
        /// буфер для графики
        /// </summary>
        /// <param name="form">передаваемая форма</param>
        static public void getGraph(Form form) //Буфер для графики.
        {
            Width = form.Width;
            Height = form.Height;
            Buffer = BufferedGraphicsManager.Current.Allocate(form.CreateGraphics(), new Rectangle(0, 0, Width, Height));
        }

        /// <summary>
        /// Инициализация формы.
        /// </summary>
        /// <param name="form">передаваемая форма</param>
        public static void Init(Form form) //Инициализация формы.
        {
            getGraph(form);

            Timer timer = new Timer { Interval = 35 };//fps
            timer.Start();
            timer.Tick += Timer_Tick;

            Load(); // Загрузка объектов.
        }

        /// <summary>
        /// таймер отработки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();//отрисовка объектов
            Update();// Обновление данных для каждого объекта.
        }

        /// <summary>
        /// Отрисовка объектов на сцене.
        /// </summary>
        public static void Draw() // Отрисовка объектов на сцене.
        {
            Buffer.Graphics.Clear(Color.Black);//заливаем черным цветом
            foreach (BaseObject obj in _objs) if (obj != null) obj.Draw();//отрисовка объектов.
            Buffer.Render();//рендер
        }
        /// <summary>
        /// обновление данных
        /// </summary>
        public static void Update() // Обновление данных для каждого объекта.
        {
            CheckScreen(Width, Height); // Проверка размеров экрана.
            foreach (BaseObject obj in _objs) obj.Update();
        }

        private static BaseObject[] _objs;

        /// <summary>
        /// загрузка/заполнение объектов
        /// </summary>
        public static void Load() //Заполнение массива с объектами
        {
            _objs = new BaseObject[50];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = getObj<NewForm1Obj>(10, i * 20, -i, 2);//заполнение массива объектов 
            }
        }
    }
}
