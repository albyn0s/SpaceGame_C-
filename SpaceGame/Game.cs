using System;
using System.Windows.Forms;
using System.Drawing;

namespace SpaceGame
{
    /// <summary>
    /// Создание игровой сцены и объектов
    /// </summary>
    class Game : Mechanic
    {

        public static BufferedGraphics Buffer;
        public static Timer timer = new Timer { Interval = 35 }; //fps
        public static string date; // Фиксация времени для лога

        static public void getGraph(Form form) //Буфер для графики
        {
            Width = form.Width;
            Height = form.Height;
            Buffer = BufferedGraphicsManager.Current.Allocate(form.CreateGraphics(), new Rectangle(0, 0, Width, Height));
        }

        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            string text = "Игра окончена";
            Buffer.Graphics.DrawString(text, new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold), Brushes.Yellow, Width / 2 - 150, Height / 2 - 80);
            Buffer.Render();
        }

        public static void Init(Form form)
        {
            Ship.MessageDie += Finish; //Сообщение конца игры

            getGraph(form); // Буфер для графики.
            Load(); // заполнение массивов с объектами.

            timer.Start();
            timer.Tick += Timer_Tick1;

            form.KeyDown += Form_KeyDown; // отслеживание клавиш на клавиатуре
        }

        private static void Timer_Tick1(object sender, EventArgs e)
        {
            Draw(); // отрисовка объектов
            Update(); //  поведение объектов 
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black); // Задний фон

            drawObjects(); // отрисовка всех объектов

            Buffer?.Graphics.DrawString("Энергия:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 20, 40); // Интерфейс вывода энергии
            Buffer?.Graphics.DrawString("Очки:" + _ship.Point, SystemFonts.DefaultFont, Brushes.White, 100, 40); // Интерфейс вывода очков

            Buffer.Render();
        }
        static public int i = 0;

        public static void Update()
        {
            date = DateTime.Now.ToString("HH:mm:ss"); // Дата для логирования
            CheckScreen(Width, Height); // проверка на размеры экрана

            foreach (BaseObject obj in _objs) obj?.Update();
            foreach (Bullet bul in _bullet) bul?.Update();
            _heal?.Update();


            if (_ship.Collision(_heal)) getHeal(); // проверка на взятие аптечки

            foreach (Asteroid ast in _asteroids) // Проверка на столкновение с астеройдом
            {
                ast?.Update();
                if (!_ship.Collision(ast)) continue;
                getDamageFrom(ast); // Урон от астеройда
            }
            
            
            foreach (Bullet bul in _bullet) 
                foreach (Asteroid ast in _asteroids)
                    getDamageFromBul(ast, bul,damageValue(bul)); // проверка всех пуль и всех астеройдов на столкновение
        }

        #region Появление врагов(не реализовано)
        //shootEnemy();

        //_enemy?.Update();
        //_enemyBul?.Update();

        //public static void shootEnemy()
        //{
        //    if (_enemy.getEnemyPosX() == Game.Width / 2)
        //    {
        //        _enemy.enemyStop();
        //        _enemyBul = getObj<enemyBullet>(10, _enemy.getEnemyPosX(), _enemy.getEnemyPosY()+5, 0);
        //    }
        //}

        //public static enemyBullet _enemyBul;


        //public static enemyAlien _enemy = new enemyAlien(new Point(Game.Width, rnd.Next(100,300)), new Point(5, 5), new Size(50, 50));
        #endregion // не успел доделать

        public static BaseObject[] _objs;
        public static Asteroid[] _asteroids;
        public static Bullet[] _bullet;
        public static Heal _heal;

        public static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(20, 20)); 

        #region Заполнение объектов
        public static void Load()
        {
            _objs = new BaseObject[100];
            _asteroids = new Asteroid[10];
            _bullet = new Bullet[numOfbullet];

            _heal = getObj<Heal>(15, 800, -10, 2);
            try
            {
                for (int i = 0, ast = 0, z = 0, p = 0; i < _objs.Length; i++)
                {
                    if (i <= _objs.Length / 2 / 2) _objs[i] = getObj<SpaceObj>(2, i * 20, 5 - i, 15 - i);
                    else if ((i > _objs.Length / 2 / 2) && (i <= _objs.Length / 2))
                    {
                        _objs[i] = getObj<Star>(1, z * 20, -z, 2);
                        z++;
                    }
                    else if ((i > _objs.Length / 2) && (i <= _objs.Length / 2 + 10))
                    {
                        _objs[i] = getObj<newPictureObj>(1, p * 50, -p, 2);
                        p++;
                    }
                    else if ((i > _objs.Length / 2 + 10) && (i <= _objs.Length / 2 + 20))
                    {
                        r = rnd.Next(5, 50);
                        _asteroids[ast] = getObj<Asteroid>(r, 800, -r / 5, r);
                        ast++;
                    }
                    else if ((i > _objs.Length / 2 + 20) && (i <= _objs.Length - 2))
                    {
                        _objs[i] = getObj<Star>(1, z * 20, -z, 2);
                        z++;
                    }
                    else if (i == _objs.Length - 1)
                    {
                        p = 5;
                        _objs[i] = getObj<blackHole>(50, p * 50, -p, 2);
                    }
                }
            }
            catch (myException e) when (e.ErrorCode == 123456789)
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
        #endregion
    }
}
