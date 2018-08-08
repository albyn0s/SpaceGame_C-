using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{
    /// <summary>
    /// Взаимодействие объектов на сцене и их механика.
    /// </summary>
    class Mechanic : GraphEngine
    {
        public static int numOfbullet = 20; // кол-во пуль.
        private static Timer reload = new Timer(); // Таймер перезарядки
        private static bool flag = true; // Флаг для стрельбы
        public static int r = rnd.Next(100, 400);//рандомное число
        private static int count = 0; //счетчик


        #region Контроллер корабля
        public static void Form_KeyDown(object sender, KeyEventArgs e) //Управление корабля.
        {
            Game._ship.Control(e.KeyCode); // Перемещение.

            if (e.KeyCode == Keys.Space) FireBullet<Bullet>(500); //Стрельба тип 1 с перезарядкой 500.
            if (e.KeyCode == Keys.Q) FireBullet<YellowBullet>(1500); //Стрельба тип 2 с перезарядкой 1500.
            if (e.KeyCode == Keys.E) FireBullet<BlueBullet>(200); //Стрельба тип 3 с перезарядкой 200.
        }
        #endregion

        #region Стрельба
        /// <summary>
        /// Стрельба с параметром перезарядки
        /// </summary>
        /// <typeparam name="T">Тип передаваемой пули</typeparam>
        /// <param name="timeReload">Время перезарядки</param>
        private static void FireBullet<T>(int timeReload) where T : Bullet
        {
            if (IcanFire(timeReload)) // проверка на возможность стрельбы.
            {
                Game._bullet.Add(getObj<T>(20, Game._ship.getShipPos(), 10, 50)); // создаем пулю.
                count++;
                if(count == 10)
                {
                    GC.Collect();//очистка
                    count = 0;//сброс счетчика
                }
            }
        }


        #region урон от пули
        /// <summary>
        /// Получение урона от пули
        /// </summary>
        /// <param name="ast">Астеройд</param>
        /// <param name="bul">Тип пули</param>
        /// <param name="damage">Урон от типа пули</param>
        public static void getDamageFromBul()
        {
            for (int j = 0; j < Game._bullet.Count; j++)//проверка всех пуль и астеройдов
                for (int i = 0; i < Game._asteroids.Count; i++)
                    if (Game._bullet[j] != null && Game._bullet[j].Collision(Game._asteroids[i]) && Game._asteroids[i] != null) // Проверка на столкновение пули и астеройда.
                    {
                        int damage = damageValue(Game._bullet[j]);//узнаем урон по типу пули
                        Game._bullet[j] = null; //при столкновении уничтоженаем пулю.
                        GetInfoLog.getLogFrom($"{Game.date} объект {Game._bullet[j]} нанес {damage} урона, {Game._asteroids[i]}"); //логирование.
                        if (Game._asteroids[i].lowPower(damage))
                        {
                            Game._ship.getPoint(); // Если вернулся "true", значит астеройд уничтожен и записываем очки для корабля.
                            Game._asteroids.Remove(Game._asteroids[i]); //удаляем этот астеройд из списка
                            
                            GetInfoLog.getLogFrom($"{Game.date} Осталось {Game._asteroids.Count} астеройдов"); //логирование.
                            if (Game._asteroids.Count == 0) //если астеройдов осталось 0
                            {
                                GetInfoLog.getLogFrom($"{Game.date} инициализация"); //логирование.
                                Game.Listpos++;//увеличиваем коллекцию на 1
                                Game._asteroids = new List<Asteroid>(Game.Listpos);//создаем новую коллекцию.
                                Game.Count++;
                                for (int e = 0; e < Game.Listpos; e++)
                                {
                                    GetInfoLog.getLogFrom($"{Game.date} создан объект {e}"); //логирование.
                                    Game.createAsteroids(ref e);//создаем астеройды
                                }
                            }
                        }
                    }
        }
        /// <summary>
        /// определяем урон от типа пули
        /// </summary>
        /// <param name="bul">Тип передаваемой пули</param>
        /// <returns></returns>
        public static int damageValue(object bul)//вычисляем урон для типа пули
        {
            if (bul?.GetType() == typeof(YellowBullet)) return YellowBullet.Damage; 
            else if (bul?.GetType() == typeof(BlueBullet)) return BlueBullet.Damage;
            else return Bullet.Damage;
        }
        #endregion


        #region Перезарядка корабля
        /// <summary>
        /// Проверка на возможность стрельбы
        /// </summary>
        /// <param name="timeReload">Время перезарядки</param>
        /// <returns></returns>
        private static bool IcanFire(int timeReload)
        {
            if (flag)//если флаг true можем стрелять иначе false
            {
                flag = false;
                reload = new Timer { Interval = timeReload }; //Таймер перезарядки (перезарядка общая)
                reload.Start();
                reload.Tick += Reload_Tick;
                return true;
            }
            return false;

        }

        private static void Reload_Tick(object sender, EventArgs e) // 1 тик = перезарядка (время задается в timeReload)
        {
                reload.Stop();
                flag = true;
        }
        #endregion
        #endregion

        #region Лечение и получение урона 
        /// <summary>
        /// Лечение корабля
        /// </summary>
        public static void getHeal() // Получение энергии для корабля.
        {
            Game._ship.EnergyGet(10); // фиксировано по 10 энергии получаем.
            GetInfoLog.getLogFrom($"{Game.date} объект {Game._ship} получил {10} энергии,"); //логирование.
            Game._heal.getRndPos(); // Как только получили лечение, генерируем новые координаты для хила.
        }
        
        /// <summary>
        /// получение урона от астеройда
        /// </summary>
        /// <param name="ast">Астеройд</param>
        public static void getDamageFrom(Asteroid ast)
        {
            r = rnd.Next(1, 10); //Урон динамический
            GetInfoLog.getLogFrom($"{Game.date} объект {ast} нанес {r} урона, {Game._ship}"); //логирование.
            Game._ship?.EnergyLow(r); //Наносим урон в кол-ве "r".
            if (Game._ship.Energy <= 0) // если энергии нет, игра окончена.
            {
                GetInfoLog.getLogFrom($"{Game.date} игра окончена"); // логирование
                Game._ship?.Die();//корабль взорван
            }
        }
        #endregion
    }
}