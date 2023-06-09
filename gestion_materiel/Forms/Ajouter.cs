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

namespace gestion_materiel.Forms
{
    public partial class Ajouter : Form
    {
        private SqlConnection connection;

        public Ajouter()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pointure = txtPointure.Text;
            string type = txtType.Text;
            string taille = txtTaille.Text;
            string saison = txtSaison.Text;
            connection = new SqlConnection("gestion_materiel");


            string tableNom = "";
            string champSupp1 = "";
            string champSupp2 = "";

            if (pointure != "" && type != "")
            {
                tableNom = "gm_monopalme";
                champSupp1 = "Pointure";
                champSupp2 = "Type";
            }
            else if (taille != "" && saison != "")
            {
                tableNom = "gm_combinaison";
                champSupp1 = "Taille";
                champSupp2 = "Saison";
            }
            else
            {
                // Les caractéristiques ne sont pas complètes
                MessageBox.Show("Veuillez entrer les caractéristiques nécessaires.");
                return;
            }

            try
            {
                connection.Open();

                string idQuery = $"SELECT MAX(IdMateriel) FROM {tableNom}";
                SqlCommand idCommand = new SqlCommand(idQuery, connection);
                object maxId = idCommand.ExecuteScalar();
                int newId = 1;
                if (maxId != DBNull.Value)
                {
                    newId = Convert.ToInt32(maxId) + 1;
                }

                string insertQuery = $"INSERT INTO {tableNom} (IdMateriel, {champSupp1}, {champSupp2}) VALUES (@IdMateriel, @{champSupp1}, @{champSupp2})";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@IdMateriel", newId);
                insertCommand.Parameters.AddWithValue($"@{champSupp1}", pointure);
                insertCommand.Parameters.AddWithValue($"@{champSupp2}", type);
                int rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Le matériel a été ajouté avec succès.
                    MessageBox.Show("Le matériel a été ajouté avec succès.");
                }
                else
                {
                    // Aucune ligne affectée, l'ajout a échoué.
                    MessageBox.Show("L'ajout du matériel a échoué.");
                }
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show("Une erreur s'est produite : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
