using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    class Game : GraphEngine
    {
        public static BufferedGraphics Buffer;

        static public void getGraph(Form form)
        {
            Width = form.Width;
            Height = form.Height;
            Buffer = BufferedGraphicsManager.Current.Allocate(form.CreateGraphics(), new Rectangle(0, 0, Width, Height));
        }

        public static void Init(Form form)
        {
            getGraph(form);
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
            foreach (BaseObject obj in _objs) if(obj != null)obj.Draw();
            foreach (Asteroid obj in _asteroids) if (obj != null) obj.Draw();
            if(_bullet != null)_bullet.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            CheckScreen(Width, Height);
            foreach (BaseObject obj in _objs) if (obj != null) obj.Update();
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

        static public int z = 0, p = 0;

        public static void Load()
        {
            _objs = new BaseObject[80];
            _asteroids = new Asteroid[3];
            int r = rnd.Next(100, 400);

            try
            {
                _bullet = getObj<Bullet>(30, r, -r / 5, r);

                for (int i = 0; i < _objs.Length; i += 4)
                    _objs[i] = getObj<SpaceObj>(2, i * 20, 5 - i, 15 - i);
                for (int i = 1; i < _objs.Length; i += 4)
                    _objs[i] = getObj<SpaceObj>(3, i * 20, 5 - i, 15 - i);
                for (int i = 2; i < _objs.Length; i += 4)
                {
                    _objs[i] = getObj<Star>(1, z * 20, -z, 2);
                    z++;
                }
                for (int i = 3; i < _objs.Length; i += 4)
                {
                    _objs[i] = getObj<newPictureObj>(1, p * 50, -p, 2);
                    p++;
                }
                for (var i = 0; i < _asteroids.Length; i++)
                {
                    r = rnd.Next(5, 50);
                     _asteroids[i] = getObj<Asteroid>(r, 800, -r / 5, r);
                }
                for (int i = _objs.Length - 1; i < _objs.Length; i++)
                {
                    p = 5;
                    _objs[i] = getObj<blackHole>(50, p * 50, -p, 2);
                }
            }
            catch(myException e) when (e.ErrorCode == 123456789)
            {
                MessageBox.Show($"{e.Message}{e.ErrorCode}, Заданы некорректные размеры.");
                Application.Exit();
            }
            catch (myException e) when (e.ErrorCode == 987654321)
            {
                MessageBox.Show($"{e.Message}{e.ErrorCode}, Задана некорректная скорость.");
                Application.Exit();
            }
            catch (myException e) when (e.ErrorCode == 10101010)
            {
                MessageBox.Show($"{e.Message}{e.ErrorCode}, Заданы некорректные координаты.");
                Application.Exit();
            }
            finally { }
        }
    }
}
