using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CreditSio.DataAccess;
using System.Security.Cryptography;

namespace gestion_materiel.Forms
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnConnecter_Click(object sender, EventArgs e)
        {
            string login, password;
            login = tbxLogin.Text;
            password = tbxPassword.Text;
            // Appeler la fonction de login pour vérifier les informations d'identification
            if (login == "Tom" & password == "1234")
            {
                // Rendre visible le contrôle "connexion"
                connexion.Text = "Vous êtes connecté.";
                Accueil accueil = new Accueil();
                accueil.Show();
                this.Hide();
            }
            else
            {
                // Les informations d'identification sont incorrectes, affichez un message d'erreur
                connexion.Text = "Identifiant ou mot de passe incorrect !";
            }
        }

        private void FTestConnexion_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}