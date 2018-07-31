using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    partial class Game
    {
        protected static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        public Game()
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
            timer.Tick += Timer_Tick1;

        }

        private static void Timer_Tick1(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (Asteroid obj in _asteroids) obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }

        static public void CheckScreen(int Width, int Height)
        {
            if(Width > 1000 || Height > 1000 || Width < 0 || Height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public static void Update()
        {
            CheckScreen(Width, Height);
            foreach (BaseObject obj in _objs) obj.Update();
            foreach (Asteroid ast in _asteroids)
            {
                ast.Update();
                if (ast.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullet.getRndPos();
                    ast.getRndPos();
                }
            }
            _bullet.Update();
        }

        private static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        static Random rnd = new Random();

        public static T getObj<T>(int size, int i, int pos1, int pos2, int pos3) where T : BaseObject
        {
            Type type = typeof(T);

            if (type == typeof(newPictureObj)) return (T)(BaseObject)new newPictureObj(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
            else if (type == typeof(blackHole)) return (T)(BaseObject)new blackHole(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
            else if (type == typeof(Star)) return (T)(BaseObject)new Star(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
            else if (type == typeof(SpaceObj)) return (T)(BaseObject)new SpaceObj(new Point(rnd.Next(0, 800), pos1), new Point(pos2, pos3), new Size(size, size));
            else if (type == typeof(Asteroid)) return (T)(BaseObject)new Asteroid(new Point(Game.Width, rnd.Next(0,800)), new Point(pos2, pos3), new Size(size, size));

            throw new NotSupportedException();
        }
        public static void Load()
        {
            _objs = new BaseObject[80];
            _asteroids = new Asteroid[3];
            int r = rnd.Next(100, 400);
            _bullet = new Bullet(new Point(0, r),new Point(-r / 5, r), new Size(40, 2));
            int z = 0, p = 0;

            for (int i = 0; i < _objs.Length; i += 4)
                _objs[i] = getObj<SpaceObj>(2, i, i * 20, 5 - i, 15 - i);
            for (int i = 1; i < _objs.Length; i += 4)
                _objs[i] = getObj<SpaceObj>(3, i, i * 20, 5 - i, 15 - i);
            for (int i = 2; i < _objs.Length; i += 4 )
            {
                _objs[i] = getObj<Star>(1, i, z * 20, -z, 2);
                z++;
            }
            for (int i = 3; i < _objs.Length; i += 4)
            {
                _objs[i] = getObj<newPictureObj>(1, i, p * 50, -p, 2);
                p++;
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                r = rnd.Next(5, 50);
                _asteroids[i] = getObj<Asteroid>(r,i, 800,-r / 5, r);
            }
            for (int i = _objs.Length-1; i < _objs.Length; i ++)
            {
                p = 5;
                _objs[i] = getObj<blackHole>(70, i, p * 50, -p, 2);
            }
        }
    }
}
