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
    public partial class Prêter : Form
    {
        private SqlConnection connection;

        public Prêter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nomMateriel = comboBox1.Text;
            string idMateriel = textBox2.Text;
            connection = new SqlConnection("gestion_materiel");


            string tableNom = "";
            if (nomMateriel.ToLower() == "palme")
            {
                tableNom = "gm_monopalme";
            }
            else if (nomMateriel.ToLower() == "combinaison")
            {
                tableNom = "gm_combinaison";
            }
            else
            {
                // Le nom du matériel n'est pas valide
                MessageBox.Show("Le nom du matériel saisi n'est pas valide.");
                return;
            }

            try
            {
                connection.Open();

                string query = $"SELECT * FROM {tableNom} WHERE NomMateriel = @NomMateriel AND IdMateriel = @IdMateriel";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomMateriel", nomMateriel);
                command.Parameters.AddWithValue("@IdMateriel", idMateriel);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();

                    string deleteQuery = $"DELETE FROM {tableNom} WHERE NomMateriel = @NomMateriel AND IdMateriel = @IdMateriel";
                    SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@NomMateriel", nomMateriel);
                    deleteCommand.Parameters.AddWithValue("@IdMateriel", idMateriel);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Le matériel a été retiré avec succès.
                        MessageBox.Show("Le matériel a été retiré avec succès.");
                    }
                    else
                    {
                        // Aucune ligne affectée, le retrait a échoué.
                        MessageBox.Show("Le retrait du matériel a échoué.");
                    }
                }
                else
                {
                    // Le matériel correspondant au nom et à l'ID saisis n'existe pas dans la table correspondante.
                    MessageBox.Show("Le matériel correspondant au nom et à l'ID saisis n'existe pas dans la table correspondante.");
                }

                reader.Close();
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


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
