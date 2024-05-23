using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetGestionD_AgenceImmobilière
{
    public partial class PasswordResetForm : Form
    {
        private string email;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private CheckBox checkBox1;
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=immo;Integrated Security=True;TrustServerCertificate=True";



        public PasswordResetForm(string email)
        {
            InitializeComponent();
            this.email = email;
        }






        private void UpdatePasswordInDatabase(string email, string newPassword, string ConfPassword)
        {


            SqlConnection connection1 = new SqlConnection(connectionString);

            connection1.Open();
            string Query1 = "update utilisateurs set motdepasse=@mdp , confirmermdp=@cmdp where email=@email";
            SqlCommand command1 = new SqlCommand(Query1, connection1);
            command1.Parameters.AddWithValue("@mdp", newPassword);
            command1.Parameters.AddWithValue("@cmdp", ConfPassword);
            command1.Parameters.AddWithValue("@email", email);

            if ((textBox1.Text == "") && (textBox2.Text == ""))
            {
                MessageBox.Show("Il faut remplir les champs !!");

            }
            else if (newPassword == ConfPassword)
            {
                command1.ExecuteNonQuery();
                MessageBox.Show("Mot de passe changé.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Confirmation échouée!!");
            }



        }


        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(145, 146);
            button1.Name = "button1";
            button1.Size = new Size(78, 28);
            button1.TabIndex = 0;
            button1.Text = "Valider";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(421, 0);
            button2.Name = "button2";
            button2.Size = new Size(21, 23);
            button2.TabIndex = 1;
            button2.Text = "X";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(178, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(172, 23);
            textBox1.TabIndex = 2;
            textBox1.UseSystemPasswordChar = true;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(177, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(173, 23);
            textBox2.TabIndex = 3;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(27, 45);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 4;
            label1.Text = "Nouveau mot de passe :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(27, 84);
            label2.Name = "label2";
            label2.Size = new Size(146, 15);
            label2.TabIndex = 5;
            label2.Text = "Confirmer mot de passe :";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(188, 113);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(83, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // PasswordResetForm
            // 
            ClientSize = new Size(439, 186);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PasswordResetForm";
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
            UpdatePasswordInDatabase(email, textBox1.Text, textBox2.Text);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = !checkBox1.Checked;
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }

}
