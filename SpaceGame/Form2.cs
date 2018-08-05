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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void новаяИграToolStripMenuItem_Click_1(object sender, EventArgs e) // верняться в меню
        {
            this.Hide();
            Application.Restart();
            Form2 MyForm2 = new Form2();
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) //выход
        {
            Application.Exit();
        }

        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e) //рекорды
        {
            this.Hide();
            Form3 MyForm3 = new Form3();
            MyForm3.Show();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
