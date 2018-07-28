using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    static class Game
    {
        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
        }
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 35 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Red);
            //Buffer.Graphics.DrawRectangle(Pens.Red, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
        }

        public static BaseObject[] _objs;

        public static BaseObject getObj(int pos, int size, int i)
        {
           return _objs[i] = new BaseObject(new Point(pos, i * 20), new Point(5 - i, 15 - i), new Size(size, size));
        }

        public static void Load()
        {
            int z = 0, r = 0;
            _objs = new BaseObject[100];
            for (int i = 0; i < _objs.Length / 2; i++)
            {
                if (r % 2 == 0) getObj(600, 3, i);
                else getObj(200, 6, i);
                r++;
            }

            for (int i = _objs.Length/2; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(-1, z * 10), new Point(-z, 2), new Size(5, 5));
                z++;
            }


        }
    }
}
