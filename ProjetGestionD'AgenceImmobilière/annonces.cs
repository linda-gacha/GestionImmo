using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetGestionD_AgenceImmobilière
{
    public partial class annonces : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=immo;Integrated Security=True;TrustServerCertificate=True";

        public annonces()
        {
            InitializeComponent();
            DisplayAnnonce();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listeclient lc = new listeclient();
            lc.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Listepropriétaire lp = new Listepropriétaire();
            lp.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            annonces a = new annonces();
            a.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            admin f = new admin();
            f.Show();
            this.Hide();
        }
        public static int id = 0;
        private void DisplayAnnonce()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT a.Id, a.typebien, u.Nom, u.Prenom, u.telephone " +
                                   "FROM ajoutimmo a " +
                                   "JOIN utilisateurs u ON a.userId = u.Id " +
                                   "WHERE u.Id IS NOT NULL";
                    // Create a SqlCommand with parameters

                    SqlCommand command = new SqlCommand(query, connection);
                    // Use a SqlDataAdapter to fill a DataTable with the results of the query
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Set the DataGridView's DataSource to the filled DataTable
                    dataGridView1.Columns.Clear();


                    dataGridView1.Columns.Add("typebien", "Type de Bien");
                    dataGridView1.Columns.Add("Nom", "Nom");
                    dataGridView1.Columns.Add("Prenom", "Prenom");
                    dataGridView1.Columns.Add("telephone", "Téléphone");


                    dataGridView1.Columns.Add("HiddenId", "HiddenId");
                    dataGridView1.Columns["HiddenId"].Visible = false;


                    foreach (DataRow row in dataTable.Rows)
                    {
                        int hiddenId = Convert.ToInt32(row["Id"]);
                        dataGridView1.Rows.Add(row["typebien"], row["Nom"], row["Prenom"], row["telephone"], hiddenId);
                    }


                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Annonce Details";
                    buttonColumn.Text = "Details";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Add(buttonColumn);


                    dataGridView1.CellContentClick += DataGridView1_CellContentClick;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Annonce Details"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                int annonceId = Convert.ToInt32(selectedRow.Cells["HiddenId"].Value);
                Details df = new Details(annonceId);
                df.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int annonceId = Convert.ToInt32(selectedRow.Cells["HiddenId"].Value);
                string req = "update ajoutimmo set etat=@etat where Id=@id";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(req, connection);
                command.Parameters.AddWithValue("@etat", "true");
                command.Parameters.AddWithValue("@id", annonceId);
                MessageBox.Show("Annonce validée ");
                command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("pas d'annonce selectionnée");
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {   
            // Check if any row is selected in the DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {        // Ask for confirmation before deleting
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette annonce ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // If the user confirms the deletion

                if (result == DialogResult.Yes)
                {
                    // Get the selected row and extract the annonceId
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int annonceId = Convert.ToInt32(selectedRow.Cells["HiddenId"].Value);

                    // SQL query to delete the record from the database table
                    string req = "delete from ajoutimmo where Id=@id";
                    // Establish a connection to the database
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    // Create a SqlCommand with parameters
                    SqlCommand command = new SqlCommand(req, connection);
                    command.Parameters.AddWithValue("@id", annonceId);
                    // Execute the delete command and get the number of rows affected,(tekho valeur ken sarit execution tekho valeur positive sinon tekho valeur negative)
                   
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check if the deletion was successful(valeur positive )
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Annonce supprimée");
                        // Refresh the display of annonces after deletion
                        DisplayAnnonce();
                    }
                    else 
                    //negative valeur or 0
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'annonce.");
                    }
                }

            }
            else
            {
                MessageBox.Show("pas d'annonce selectionnée");
            }

        }


        private void button4_Click(object sender, EventArgs e)
        {

            transaction t = new transaction();
            t.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

