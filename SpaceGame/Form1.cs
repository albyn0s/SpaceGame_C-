using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{

    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow(); //Консоль для логирования

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        public Form1()
        {
            InitializeComponent();
            ShowWindow(GetConsoleWindow(), 0); // Как запустили форму скрываем консоль
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Выход
        }

        private void стартToolStripMenuItem_Click_2(object sender, EventArgs e) //Старт игры
        {
            this.Hide();//cкрываем форму
            Form2 MyForm2 = new Form2();//создаем новую форму
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show(); //показываем форму

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //Старт игры
        {
            this.Hide();//cкрываем форму
            Form2 MyForm2 = new Form2();//создаем новую форму
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show();//показываем форму
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) // Таблица рекордов
        {
            this.Hide();//cкрываем форму
            Form3 MyForm3 = new Form3();//создаем новую форму
            MyForm3.Show();//показываем форму
        }

        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e) // Таблица рекордов
        {
            this.Hide();//cкрываем форму
            Form3 MyForm3 = new Form3();//создаем новую форму
            MyForm3.Show();//показываем форму
        }

        private void button3_Click(object sender, EventArgs e) //Выход
        {
            Application.Exit();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) //Скрытие консоли
        {
            this.consoleOFF.Hide();//скрываем кнопку
            ShowWindow(GetConsoleWindow(), 0);//скрываем консоль
            this.button5.Show();//показываем button5 кнопку.
        }

        private void button5_Click(object sender, EventArgs e) //Появление консоли
        {
            this.button5.Hide();//скрываем кнопку
            ShowWindow(GetConsoleWindow(), 5);//показываем консоль
            this.consoleOFF.Show();//показываем consoleOFF кнопку 
        }
    }
}
