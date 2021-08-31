using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace OpenDataWeb.DAL
{
    public class DBManager
    {
        public static List<Fermata> OttieniFermate(SearchBy option = SearchBy.Default, string parameter = "")
        {
            List<Fermata> Fermate = new List<Fermata>();

            using (SqlConnection con = new SqlConnection(Utility.ConnectionString))
            {
                string command = "SELECT * FROM Fermate";

                SqlParameter sqlParameter = new SqlParameter();
                SqlCommand sqlCommand = new SqlCommand();

                con.Open();

                sqlCommand.Connection = con;

                switch (option)
                {
                    case SearchBy.Default: break;
                    case SearchBy.Provincia: 
                        command = "select * FROM Fermate where Provincia LIKE @provincia";

                        sqlParameter.ParameterName = "@provincia";
                        sqlParameter.Value = $"%{parameter}%";
                        sqlParameter.SqlDbType = SqlDbType.VarChar;
                        sqlParameter.Size = 255;

                        sqlCommand.Parameters.Add(sqlParameter);
                        break;
                    case SearchBy.Regione: 
                        command = "select * FROM Fermate where Regione LIKE @regione";

                        sqlParameter.ParameterName = "@regione";
                        sqlParameter.Value = $"%{parameter}%";
                        sqlParameter.SqlDbType = SqlDbType.VarChar;
                        sqlParameter.Size = 255;

                        sqlCommand.Parameters.Add(sqlParameter);
                        break;
                    case SearchBy.Lettera: 
                        command = "select * FROM Fermate where Regione LIKE @lettera or Nome LIKE @lettera or Provincia LIKE @lettera or Comune LIKE @lettera";

                        sqlParameter.ParameterName = "@lettera";
                        sqlParameter.Value = $"%{parameter}%";
                        sqlParameter.SqlDbType = SqlDbType.VarChar;
                        sqlParameter.Size = 255;

                        sqlCommand.Parameters.Add(sqlParameter);
                        break;
                    case SearchBy.Nome: 
                        command = "select * FROM Fermate where Nome LIKE @nome";

                        sqlParameter.ParameterName = "@nome";
                        sqlParameter.Value = $"%{parameter}%";
                        sqlParameter.SqlDbType = SqlDbType.VarChar;
                        sqlParameter.Size = 255;

                        sqlCommand.Parameters.Add(sqlParameter);
                        break;
                }

                sqlCommand.CommandText = command;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Fermate.Add(CreaFermata(sqlDataReader));
                }

                con.Close();
            }

            return Fermate;

        }

        private static Fermata CreaFermata(SqlDataReader reader)
        {
            Fermata Fermata = new Fermata();

            Fermata.Comune = Utility.GetAsString(reader["Comune"]);
            Fermata.Regione = Utility.GetAsString(reader["Regione"]);
            Fermata.Provincia = Utility.GetAsString(reader["Provincia"]);
            Fermata.Nome = Utility.GetAsString(reader["Nome"]);
            Fermata.ID = Utility.GetAsDouble(reader["Identificatore_OpenStreetMap"]);
            Fermata.Longitudine = Utility.GetAsDouble(reader["Longitudine"]);
            Fermata.Latitudine = Utility.GetAsDouble(reader["Latitudine"]);

            return Fermata;
        }
    }
}
