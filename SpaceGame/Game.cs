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
        static Random rnd = new Random();

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

        public static T getObj<T>(int size, int i, int pos1, int pos2, int pos3) where T : BaseObject
        {
            //Type type = typeof(T);
            //if(type == typeof(BaseObject))
            //return (T) new BaseObject(new Point(rnd.Next(0, 800), i * 20), new Point(5 - i, 15 - i), new Size(size, size));
            //return default(T);

            return (T)Activator.CreateInstance(typeof(T), new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
        }
        public static void Load()
        {
            int z = 0, r = 0, p = 0;
            _objs = new BaseObject[70];
            for (int i = 0; i < _objs.Length; i++)
            {
                if (i <= _objs.Length / 2)
                {
                    if (r % 2 == 0)
                    {
                        _objs[i] = getObj<BaseObject>(3, i, i * 20, 5 - i, 15 - i);
                        r++;
                    }
                    else
                    {
                        _objs[i] = getObj<BaseObject>(6, i, i * 20, 5 - i, 15 - i);
                        r++;
                    }
                }
                else if (i >= _objs.Length / 2 && i < _objs.Length -10)
                {
                    _objs[i] = getObj<Star>(5, i, z * 20, -z, 2);
                    z++;
                }
                else if (i >= _objs.Length -10)
                {
                    _objs[i] = getObj<newObj>(5, i, p * 100, -p, 2);
                    p++;
                }
            }




            //for (int i = _objs.Length - 5; i < _objs.Length; i++)
            //{
            //    _objs[i] = getObj<newObj>(5, i, z * 20, -z, 2);
            //    z++;
            //}
            //new Star(new Point(rnd.Next(0,800), z * 20), new Point(-z, 2), new Size(5, 5))

        }
    }
}
