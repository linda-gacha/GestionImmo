using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetGestionD_AgenceImmobilière
{
    public partial class inscrire : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=immo;Integrated Security=True;TrustServerCertificate=True";


        public inscrire()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inscrire_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Vérifier si des champs obligatoires sont vides
                if (string.IsNullOrWhiteSpace(Nom.Text) || string.IsNullOrWhiteSpace(Prenom.Text) || string.IsNullOrWhiteSpace(Nationalite.Text)
                     || string.IsNullOrWhiteSpace(cin.Text) || string.IsNullOrWhiteSpace(telephone.Text) || string.IsNullOrWhiteSpace(email.Text)
                     || string.IsNullOrWhiteSpace(adresse.Text) || string.IsNullOrWhiteSpace(codepostal.Text) || string.IsNullOrWhiteSpace(motdepasse.Text)
                     || string.IsNullOrWhiteSpace(confirmermdp.Text) || (!checkBox1.Checked && !checkBox2.Checked))
                {
                    MessageBox.Show("Informations manquantes !");
                }
                // Vérifier si les champs de mot de passe correspondent
                else if (!confirmermdp.Text.Equals(motdepasse.Text))
                {
                    MessageBox.Show("Mot de passe non confirmé !");
                }

                else
                {
                    // Vérifier si l'adresse e-mail est déjà utilisée

                    string e_mail = email.Text;
                    string email1 = null;



                    using (SqlConnection con = new SqlConnection(connectionString))
                    {


                        con.Open();
                        // Requête pour récupérer toutes les adresses e-mail existantes
                        string query1 = "select email from utilisateurs ";

                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        // Utiliser un SqlDataReader pour parcourir les adresses e-mail existantes
                        using (SqlDataReader reader = cmd1.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                email1 = reader.GetString(0);
                                if (email1.Equals(e_mail))
                                {
                                    MessageBox.Show("Adresse e-mail déjà utilisée!!!!");
                                    return;
                                }
                            }

                        }

                        // Requête SQL pour insérer un nouvel utilisateur dans la base de données
                        string query = "INSERT INTO utilisateurs ([Nom], [Prenom], [Nationalite], [cin], [telephone], [email], [adresse], [codepostal], [motdepasse], [confirmermdp],[role]) VALUES ( @val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9, @val10 ,@val11,@val12)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@val2", Nom.Text);
                        cmd.Parameters.AddWithValue("@val3", Prenom.Text);
                        cmd.Parameters.AddWithValue("@val4", Nationalite.Text);
                        cmd.Parameters.AddWithValue("@val5", cin.Text);
                        cmd.Parameters.AddWithValue("@val6", telephone.Text);
                        cmd.Parameters.AddWithValue("@val7", email.Text);
                        cmd.Parameters.AddWithValue("@val8", adresse.Text);
                        cmd.Parameters.AddWithValue("@val9", codepostal.Text);
                        cmd.Parameters.AddWithValue("@val10", motdepasse.Text);
                        cmd.Parameters.AddWithValue("@val11", confirmermdp.Text);

                        // Sélectionner le rôle en fonction des cases à cocher
                        if (checkBox1.Checked)
                        {
                            cmd.Parameters.AddWithValue("@val12", "client");


                        }
                        if (checkBox2.Checked)
                        {
                            cmd.Parameters.AddWithValue("@val12", "propriétaire");

                        }


                        // Exécuter la requête SQL pour insérer le nouvel utilisateur
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Enregistrement inséré avec succès !");
                        
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cin_TextChanged(object sender, EventArgs e)
        {
            // Limiter la saisie à 8 chiffres pour le champ cin
            if (cin.Text.Length > 8)
            {
                // Afficher un message d'erreur
                MessageBox.Show("Le CIN ne doit pas dépasser 8 chiffres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Tronquer le champ cin pour contenir seulement les 8 premiers chiffres
                cin.Text = cin.Text.Substring(0, 8);
            }

            // Vérifier si le champ cin contient uniquement des chiffres
            if (!EstChiffresSeulement1(cin.Text))
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez entrer un CIN valide (contenant uniquement des chiffres).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Effacer le contenu du champ cin si nécessaire
                cin.Clear();
            }
        }

        // Méthode pour vérifier si une chaîne contient uniquement des chiffres
        private bool EstChiffresSeulement(string input)
        {
            return input.All(char.IsDigit);
        }


        // Fonction pour vérifier si une chaîne ne contient que des chiffres
        private bool EstChiffresSeulement2(string texte)
        {
            foreach (char caractere in texte)
            {
                if (!char.IsDigit(caractere))
                {
                    return false;
                }
            }
            return true;
        }


        private void cin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Autoriser n'importe quel caractère lors de la saisie
        }

        private void cin_KeyDown(object sender, KeyEventArgs e)
        {
            // Vous pouvez également ajouter une logique ici si nécessaire
        }

        private void telephone_TextChanged(object sender, EventArgs e)
        {
            string numeroTelephone = telephone.Text;

            // Vérifier si la saisie contient uniquement des chiffres
            if (!EstChiffresSeulement1(numeroTelephone))
            {
                // Afficher un message d'erreur
                MessageBox.Show("Veuillez entrer un numéro de téléphone valide (contenant uniquement des chiffres).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Effacer le contenu du champ téléphone
                telephone.Text = "";
            }
        }


        // Fonction pour vérifier si une chaîne ne contient que des chiffres
        private bool EstChiffresSeulement1(string texte)
        {
            foreach (char caractere in texte)
            {
                if (!char.IsDigit(caractere))
                {
                    return false;
                }
            }
            return true;
        }

        private bool firstInsertion = true;

        private void email_TextChanged(object sender, EventArgs e)
        {
            // Sauvegarder la position actuelle du curseur
            int cursorPosition = email.SelectionStart;

            // Ajouter automatiquement "@gmail.com" à la fin de l'adresse email si nécessaire
            if (!email.Text.EndsWith("@gmail.com"))
            {
                email.Text += "@gmail.com";
                // Déplacer le curseur au début du texte après la première insertion
                if (firstInsertion)
                {
                    email.SelectionStart = email.Text.Length;
                    firstInsertion = false;
                }

                // Restaurer la position du curseur sauvegardée
                email.SelectionStart = Math.Min(cursorPosition, email.Text.Length);

            }
        }

        private void confirmermdp_TextChanged(object sender, EventArgs e)
        {

        }

        private void motdepasse_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            motdepasse.UseSystemPasswordChar = !checkBox1.Checked;
            confirmermdp.UseSystemPasswordChar = !checkBox1.Checked;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
