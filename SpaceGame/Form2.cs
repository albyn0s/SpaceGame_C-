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

        private void новаяИграToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 MyForm2 = new Form2();
            Game.Init(MyForm2);
            Game.Draw();
            MyForm2.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
