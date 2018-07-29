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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void стартToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form2 MyForm2 = new Form2();
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 MyForm2 = new Form2();
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 MyForm3 = new Form3();
            MyForm3.Show();
        }

        private void рекордыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 MyForm3 = new Form3();
            MyForm3.Show();
        }
    }
}
