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
    public partial class clientacheter : Form
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=immo;Integrated Security=True;TrustServerCertificate=True";

        public clientacheter()
        {
            InitializeComponent();
            // Subscribe the DataGridView_CellContentClick method to the CellContentClick event
            dataGridView.CellContentClick += DataGridView_CellContentClick;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void clientacheter_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientacheter ca = new clientacheter();
            ca.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifclient nc = new notifclient();
            nc.Show();
            this.Hide();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Get the selected item from the ComboBox(louer/vendre)
                string selectedTypeAnnonce = comboBox.SelectedItem.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT *  FROM ajoutimmo WHERE typeannonce = @typeannonce AND etat=@etat ";

                    // Create a SqlCommand with parameters
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@typeannonce", selectedTypeAnnonce);
                    command.Parameters.AddWithValue("@etat", "true");

                    // Use a SqlDataAdapter to fill a DataTable with the results of the query
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView.Columns.Clear();

                    // Add specific columns to the DataGridView
                    dataGridView.Columns.Add("typebien", "Type de Bien");
                    dataGridView.Columns.Add("general", "general");
                    dataGridView.Columns.Add("etage", "etage");
                    dataGridView.Columns.Add("chambre", "chambre");
                    dataGridView.Columns.Add("HiddenId", "HiddenId");
                    dataGridView.Columns["HiddenId"].Visible = false;


                    // Populate the DataGridView with data from the DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int hiddenId = Convert.ToInt32(row["Id"]);
                        dataGridView.Rows.Add(row["typebien"], row["general"], row["etage"], row["chambre"], hiddenId);
                    }

                    // Add a button column to the DataGridView for viewing 
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Annonce Details";
                    buttonColumn.Text = "Details";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView.Columns.Add(buttonColumn);




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the "Annonce Details" column and not in the header row
            if (e.ColumnIndex == dataGridView.Columns["Annonce Details"].Index && e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                // Extract the hidden ID value from the selected row
                int annonceId = Convert.ToInt32(selectedRow.Cells["HiddenId"].Value);
                // Create a new instance of the Details form, passing the annonceId
                Details df = new Details(annonceId);
                df.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
