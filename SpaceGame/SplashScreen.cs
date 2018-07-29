using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{

    partial class SplashScreen : Game
    {
        static public SplashScreen sc = new SplashScreen();
        static Random rnd = new Random();
        new static BufferedGraphicsContext _context;
        new public static BufferedGraphics Buffer;

        static SplashScreen()
        {
        }
        new public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Timer timer = new Timer { Interval = 35 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Load();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        new public static void Draw()
        {

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            Buffer.Render();
        }
        new public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update();
        }

        new public static BaseObject[] _objs;

        new public static T getObj<T>(int size, int i, int pos1, int pos2, int pos3) where T : BaseObject
        {
            return (T)Activator.CreateInstance(typeof(T), new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
        }
        new public static void Load()
        {
            _objs = new BaseObject[50];
            for (int i = 0; i < _objs.Length; i++)
            {
                _objs[i] = getObj<NewForm1Obj>(10, i, i * 20, -i, 2);
            }
        }
    }
}
