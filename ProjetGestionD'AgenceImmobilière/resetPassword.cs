using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionD_AgenceImmobilière
{
    public partial class resetPassword : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=immo;Integrated Security=True;TrustServerCertificate=True";
        private Label label4;
        private string email;
        public resetPassword(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private Button button2;
        private Label label3;

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(31, 56);
            label1.Name = "label1";
            label1.Size = new Size(154, 15);
            label1.TabIndex = 0;
            label1.Text = "C'est quoi ton nationalité ?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(31, 101);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 1;
            label2.Text = "C'est quoi ton CIN ?";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(31, 145);
            label3.Name = "label3";
            label3.Size = new Size(219, 15);
            label3.TabIndex = 2;
            label3.Text = "C'est quoi ton Numéro de Telephone ?";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(285, 53);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(285, 98);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(121, 23);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(285, 142);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(121, 23);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(213, 189);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(489, 3);
            button2.Name = "button2";
            button2.Size = new Size(22, 23);
            button2.TabIndex = 7;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(101, 3);
            label4.Name = "label4";
            label4.Size = new Size(276, 32);
            label4.TabIndex = 8;
            label4.Text = "Trouver Votre Compte";
            label4.Click += label4_Click;
            // 
            // resetPassword
            // 
            ClientSize = new Size(513, 238);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "resetPassword";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(connectionString);

            connection1.Open();

            // Requête SQL pour récupérer toutes les informations de l'utilisateur associé à l'e-mail fourni
            string Query1 = "select * from utilisateurs where email = @email";
            SqlCommand command1 = new SqlCommand(Query1, connection1);
            command1.Parameters.AddWithValue("@email", email);
            // Utiliser un DataReader pour lire les résultats de la requête
            SqlDataReader reader1 = command1.ExecuteReader();

            // Variables pour stocker les informations de l'utilisateur extraites de la base de données
            string nationalite = null;
            string cin = null;
            string telephone = null;

            // Si un enregistrement est trouvé, extraire les informations
            if (reader1.Read())
            {

                nationalite = reader1["nationalite"].ToString();
                cin = reader1["cin"].ToString();
                telephone = reader1["telephone"].ToString();
            }

            // Vérifier si les informations fournies correspondent à celles extraites de la base de données
            if ((nationalite.Equals(textBox1.Text)) && (cin.Equals(textBox2.Text)) && (telephone.Equals(textBox3.Text)))
            {
                // Si les informations correspondent, afficher la fenêtre de réinitialisation du mot de passe
                PasswordResetForm prf = new PasswordResetForm(email);
                prf.Show();
                this.Close();
            }
            else
            {
                // Afficher un message d'erreur si les informations ne correspondent pas
                MessageBox.Show("verifier votre informations !!!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
