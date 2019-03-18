using AdminPanelWpf.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelWpf
{
    class SqlConnectionHandler
    {
        MySqlConnection connection;

        public SqlConnectionHandler()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mySqlConnectionString"].ConnectionString;
            connection = new MySqlConnection(connectionString);
        }

        public bool IsOpen { get; private set; } = false;

        public bool Open()
        {
            try
            {
                connection.Open();
                IsOpen = true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool IsUserValid(string userName, string password)
        {
            MySqlCommand command = new MySqlCommand("SELECT 1 FROM Users WHERE LoginName = @username AND Password = @password AND IsAdministrator = 1", connection);
            command.Parameters.AddWithValue("username", userName);
            command.Parameters.AddWithValue("password", password);

            var loginChek = command.ExecuteScalar();
            return loginChek == null ? false : int.Parse(loginChek?.ToString()) == 1;
        }

        public UsersModel GetUserData(string userName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM Users WHERE LoginName = @username", connection);
            command.Parameters.AddWithValue("username", userName);
            UsersModel um = null;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    um = new UsersModel();
                    if (!reader.IsDBNull(reader.GetOrdinal("Created")))
                        um.Created = reader.GetDateTime(reader.GetOrdinal("Created"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                        um.Email = reader.GetString(reader.GetOrdinal("Email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID")))
                        um.ID = reader.GetString(reader.GetOrdinal("ID"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginName")))
                        um.LoginName = reader.GetString(reader.GetOrdinal("LoginName"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Name")))
                        um.Name = reader.GetString(reader.GetOrdinal("Name"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Password")))
                        um.Password = reader.GetString(reader.GetOrdinal("Password"));
                }
            }
            return um;
        }

        public void UpdatePassword(string ID, string newPassowrd)
        {
            MySqlCommand comm = new MySqlCommand("UPDATE Users SET Password = @password WHERE ID = @id", connection);
            comm.Parameters.AddWithValue("password", newPassowrd);
            comm.Parameters.AddWithValue("id", ID);
            comm.ExecuteNonQuery();
        }

        public void InsertUser(/*Insert adatai*/)
        {
            //Insert megírása
        }
    }
}
