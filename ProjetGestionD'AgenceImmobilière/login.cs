using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjetGestionD_AgenceImmobilière
{
    public partial class login : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=immo;Integrated Security=True;TrustServerCertificate=True";

        public login()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }
        private int userId;

        private void button1_Click(object sender, EventArgs e)
        {
            // Établir une connexion à la base de données

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            // Rechercher l'ID de l'utilisateur en fonction de l'adresse e-mail

            using (SqlCommand command1 = new SqlCommand("select Id from utilisateurs where email = @userName", connection))
            {
                command1.Parameters.AddWithValue("@UserName", email.Text);

                // Utiliser un DataReader pour lire les résultats de la requête
                using (SqlDataReader reader1 = command1.ExecuteReader())
                {
                    // Si un enregistrement est trouvé, extraire l'ID de l'utilisateur

                    if (reader1.Read())
                    {
                        userId = Convert.ToInt32(reader1["Id"]);
                    }

                }

            }
            // Définir les informations d'administration

            string usAdmin = "admin";
            string pwdAdmin = "admin";
            string lg = email.Text;
            string pwd = mdp.Text;

            // Vérifier si les champs email et mot de passe sont vides
            if (lg.Equals("") || pwd.Equals(""))
            {
                MessageBox.Show("Information manquante !!");
            }
            else
            {        
                // Vérifier si les informations correspondent à un compte administrateur

                if (lg.Equals(usAdmin) && pwd.Equals(pwdAdmin))
                {
                    admin a = new admin();
                    a.Show();
                    this.Hide();
                }
                else
                {



                    // Requête SQL pour récupérer les informations de tous les utilisateurs

                    using (SqlCommand command = new SqlCommand("select email,motdepasse,role from utilisateurs ", connection))
                    {
                        // Utiliser un DataReader pour lire les résultats de la requête
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Vérifier si des enregistrements existent

                            if (reader.HasRows)
                            {
                                // Parcourir les résultats de la requête

                                while (reader.Read())
                                {



                                    // Extraire les informations de chaque utilisateur

                                    string email1 = reader.GetString(0);
                                    string motdepasse = reader.GetString(1);
                                    string role = reader.GetString(2);

                                    // Vérifier si les informations d'identification correspondent à un utilisateur

                                    if (lg.Equals(email1) && pwd.Equals(motdepasse))
                                    {
                                        // Afficher l'interface en fonction du rôle de l'utilisateur

                                        if (role.Equals("client"))
                                        {
                                            client c = new client();
                                            c.Show();
                                            this.Hide();
                                        }
                                        if (role.Equals("propriétaire"))
                                        {

                                            propriétaire p = new propriétaire(userId);
                                            p.Show();
                                            this.Hide();


                                        }
                                    }


                                }
                            }
                            else
                            {
                                MessageBox.Show("L'adresse e-mail n'existe pas !!");
                            }


                        }


                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inscrire f = new inscrire();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            mdp.UseSystemPasswordChar = !checkBox1.Checked;



        }

        private void email_TextChanged(object sender, EventArgs e)
        {


        }

        private void mdp_TextChanged(object sender, EventArgs e)
        {

        }

        private void mdp_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            string lienLocalisation = $"https://www.google.com/maps/place/Hammamet/@36.407601,10.6217114,17z/data=!4m9!1m2!2m1!1s36,40737391,10,62171933!3m5!1s0x12fd61fc0dac1583:0x8f1c841291df5ff!8m2!3d36.4072574!4d10.6224706!16zL20vMDYyX3p5?entry=ttu";


            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c start {lienLocalisation}",
                CreateNoWindow = true,
                UseShellExecute = false
            });

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            {
                // Insérez le lien de profil Facebook ici
                string facebookProfileLink = "https://www.facebook.com/?locale=fr_FR";

                // Ouvrir le lien dans le navigateur par défaut
                Process.Start(new ProcessStartInfo("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", facebookProfileLink));
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            // Remplacez par votre numéro de téléphone WhatsApp
            string numeroTelephone = "94600587";

            // Générer le lien WhatsApp
            string lienWhatsApp = $"https://wa.me/{numeroTelephone}";

            // Ouvrir le lien dans le navigateur par défaut
            OuvrirDansNavigateurParDefaut(lienWhatsApp);
        }

        private void OuvrirDansNavigateurParDefaut(string lien)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = lien,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                // Gestion de l'exception en cas d'erreur
                MessageBox.Show($"Erreur lors de l'ouverture du lien : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Établir une connexion à la base de données

            SqlConnection connection1 = new SqlConnection(connectionString);

            connection1.Open();

            // Requête SQL pour récupérer l'e-mail d'un utilisateur spécifique
            string Query1 = "select email from utilisateurs where email = @email";
            SqlCommand command1 = new SqlCommand(Query1, connection1);
            command1.Parameters.AddWithValue("@email", email.Text);

            SqlDataReader reader1 = command1.ExecuteReader();

            // Variable pour stocker l'e-mail extrait de la base de données
            string email1 = null;

            // Si un enregistrement est trouvé, extraire l'e-mail
            if (reader1.Read())
            {
                email1 = reader1["email"].ToString();
            }
            if (email.Text == "")
            {
                // Vérifier si le champ email est vide
                MessageBox.Show("Champs email vide !!!");
            }
            // Vérifier si l'e-mail n'existe pas dans la base de données
            else if (email1 == null)
            {
                MessageBox.Show("email n'existe pas !!!");
            }
            else
            {
                // Si l'e-mail existe, afficher la fenêtre de réinitialisation de mot de passe
                resetPassword rp = new resetPassword(email.Text);
                rp.Show();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
