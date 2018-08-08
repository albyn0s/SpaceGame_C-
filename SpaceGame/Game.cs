using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

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

        /// <summary>
        /// буфер для графики
        /// </summary>
        /// <param name="form"></param>
        static public void getGraph(Form form)
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
            string text = $"    Игра окончена" + "\n" +  $"{Count} уровень "+ $"{_ship.Point} очков."; //сообщение в конце игры
            Buffer.Graphics.DrawString(text, new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold), Brushes.Yellow, Width / 2 - 145, Height / 2 - 80); //вывод сообщения
            Buffer.Render();
        }

        /// <summary>
        /// инициализация формы
        /// </summary>
        /// <param name="form">передаваемая форма</param>
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
        /// <summary>
        /// Номер уровня
        /// </summary>
        public static int Count = 1;

        /// <summary>
        /// отрисовка формы
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black); // Задний фон

            drawObjects(); // отрисовка всех объектов

            Buffer?.Graphics.DrawString("Энергия:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 20, 40); // Интерфейс вывода энергии
            Buffer?.Graphics.DrawString("Очки:" + _ship.Point, SystemFonts.DefaultFont, Brushes.White, 100, 40); // Интерфейс вывода очков
            Buffer?.Graphics.DrawString("Осталось астеройдов:" + _asteroids.Count, SystemFonts.DefaultFont, Brushes.White, 160, 40); // Интерфейс вывода очков
            Buffer?.Graphics.DrawString("Уровень:" + Count, SystemFonts.DefaultFont, Brushes.White, 300, 40); //интерфейс текущего уровня

            Buffer.Render();
        }
        static public int i = 0;
        public static int p = 1;

        /// <summary>
        /// обновление данных по объектам
        /// </summary>
        public static void Update()
        {
            date = DateTime.Now.ToString("HH:mm:ss"); // Дата для логирования
            CheckScreen(Width, Height); // проверка на размеры экрана

            foreach (BaseObject obj in _objs) obj?.Update();
            //foreach (Bullet bul in _bullet) bul?.Update();
            for(int j = 0; j<_bullet.Count; j++)
            {
                _bullet[j]?.Update();
                if (_bullet[j] != null && _bullet[j].getNull()) _bullet[j] = null;
            }
            _heal?.Update();


            if (_ship.Collision(_heal)) getHeal(); // проверка на взятие аптечки

            foreach (Asteroid ast in _asteroids) // Проверка на столкновение с астеройдом
            {
                ast?.Update();
                if (!_ship.Collision(ast)) continue;
                getDamageFrom(ast); // Урон от астеройда
            }
            
            getDamageFromBul(); // проверка всех пуль и всех астеройдов на столкновение
        }

        /// <summary>
        /// создание астеройдов
        /// </summary>
        /// <param name="ast">счетчик</param>
        public static void createAsteroids(ref int ast)
        {
            r = rnd.Next(5, 50);
            _asteroids.Add(getObj<Asteroid>(r, 800, -r / 5, r));//создание объекта со случайными параметрами
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

        /// <summary>
        /// объекты
        /// </summary>
        public static BaseObject[] _objs;
        /// <summary>
        /// астеройды
        /// </summary>
        public static List<Asteroid> _asteroids;
        /// <summary>
        /// пули
        /// </summary>
        public static List<Bullet> _bullet = new List<Bullet>();
        /// <summary>
        /// аптечка
        /// </summary>
        public static Heal _heal;
        /// <summary>
        /// корабль
        /// </summary>
        public static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(20, 20));

        public static int Listpos = 10;

        #region Заполнение объектов
        /// <summary>
        /// загрузка/заполнение объектов
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[100];
            _asteroids = new List<Asteroid>(Listpos);
            _heal = getObj<Heal>(15, 800, -10, 2);
            try
            {
                for (int i = 0, ast = 0, z = 0, p = 0; i < _objs.Length; i++)
                {
                    if (i <= _objs.Length / 2 / 2) _objs[i] = getObj<SpaceObj>(2, i * 20, 5 - i, 15 - i);
                    else if ((i > _objs.Length / 2 / 2) && (i <= _objs.Length / 2))
                    {
                        _objs[i] = getObj<Star>(1, z * 20, -z, 2); //создание объекта со случайными параметрами
                        z++;//счетчик для star
                    }
                    else if ((i > _objs.Length / 2) && (i <= _objs.Length / 2 + 10))
                    {
                        _objs[i] = getObj<newPictureObj>(1, p * 50, -p, 2);//создание объекта со случайными параметрами
                        p++;//счетчик для newPictureObj
                    }
                    else if ((i > _objs.Length / 2 + 10) && (i <= _objs.Length / 2 + 20))
                    {
                        createAsteroids(ref ast);
                    }
                    else if ((i > _objs.Length / 2 + 20) && (i <= _objs.Length - 2))
                    {
                        _objs[i] = getObj<Star>(1, z * 20, -z, 2);//создание объекта со случайными параметрами
                        z++;//счетчик для star
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
