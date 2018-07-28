using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    static class SplashScreen
    {
        static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        static SplashScreen()
        {
        }
        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
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
            _objs = new BaseObject[20];
            //for (int i = 0; i < _objs.Length; i++)
            //{
            //    _objs[i] = getObj<Star>(5, i, z * 20, -z, 2);
            //    z++;
            //}
        }
    }
}
