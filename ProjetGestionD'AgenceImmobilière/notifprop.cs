using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetGestionD_AgenceImmobilière
{
    public partial class notifprop : Form
    {
        private int userId;
        public notifprop(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            propriétaire p = new propriétaire(userId);
            p.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ajoutbien ab = new ajoutbien(userId);
            ab.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifprop np = new notifprop(userId);
            np.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
