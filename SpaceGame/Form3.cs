using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceGame
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e) // вернуться в меню
        {
            this.Hide();//скрываем форму
            Application.Restart();// перезапускаем приложение
            Form1 MyForm2 = new Form1();//создаем новую форму.
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show();//показываем форму.
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) //выход
        {
            Application.Exit();
        }
    }
}
