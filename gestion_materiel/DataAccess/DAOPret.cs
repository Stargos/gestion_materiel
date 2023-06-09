using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestion_materiel.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using gestion_materiel.Tools;

namespace gestion_materiel.DataAccess
{
    class DAOPret
    {
        /// <summary>
        /// Obtenir le conseiller qui s'est connecté
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>L'objet Conseiller qui s'est connecté</returns>
        public static ConseillerModel GetConseiller(string login, byte[] password)
        {
            ConseillerModel conseiller = new ConseillerModel();
            SqlConnection connection = null;
            try
            {
                connection = Connection.getInstance().GetConnection();
                using (SqlCommand sqlCommand = new SqlCommand("sp_authentification", connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = login;
                    sqlCommand.Parameters.Add("@pPassword", SqlDbType.VarBinary).Value = password;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            sqlDataReader.Read();
                            conseiller.Id = sqlDataReader.GetInt32(0);
                            conseiller.Nom = sqlDataReader.GetString(1);
                            conseiller.Prenom = sqlDataReader.GetString(2);
                            using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                            {
                                Log.WriteLog(String.Concat("DBInterface : l'utilisateur ", login, " vient de se connecter"), w);
                            }
                        }
                        else
                        {
                            using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                            {
                                Log.WriteLog(String.Concat(String.Concat("DBInterface : identifiants de connexion invalide. Login :", login)), w);
                            }
                        }
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (StreamWriter w = File.AppendText("../Logs/logerror.txt"))
                {
                    Log.WriteLog("DBInterface : erreur SQL", w);
                }
            }
            finally
            {
                connection.Close();
            }
            return conseiller;
        }
    }
}
