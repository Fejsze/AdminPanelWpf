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
            MySqlCommand command = new MySqlCommand("SELECT 1 FROM login WHERE username = @username AND password = @password", connection);
            command.Parameters.AddWithValue("username", userName);
            command.Parameters.AddWithValue("password", password);

            var loginChek = command.ExecuteScalar();
            return loginChek == null ? false : int.Parse(loginChek?.ToString()) == 1;
        }

        public UsersModel GetUserData(string userName)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM login WHERE username = @username", connection);
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
                    if (!reader.IsDBNull(reader.GetOrdinal("username")))
                        um.Username = reader.GetString(reader.GetOrdinal("username"));
                    if (!reader.IsDBNull(reader.GetOrdinal("generatedid")))
                        um.GeneratedID = reader.GetString(reader.GetOrdinal("generatedid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Password")))
                        um.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Reminder")))
                        um.Reminder = reader.GetString(reader.GetOrdinal("Reminder"));
                }
            }
            return um;
        }

        public void UpdatePassword(string ID, string newPassowrd)
        {
            MySqlCommand comm = new MySqlCommand("UPDATE login SET password = @password WHERE id = @id", connection);
            comm.Parameters.AddWithValue("password", newPassowrd);
            comm.Parameters.AddWithValue("id", ID);
            comm.ExecuteNonQuery();
        }

        public void InsertUser(string username, string password, string email, string reminder)
        {
            MySqlCommand comm = new MySqlCommand("INSERT INTO login (`generatedid`, `username`, `password`, `created`, `email`, `Reminder`) VALUES (@generatedid, @username, @password, @created, @email, @Reminder);", connection);
            comm.Parameters.AddWithValue("generatedid", IDGenerator());
            comm.Parameters.AddWithValue("username", username);
            comm.Parameters.AddWithValue("password", password);
            comm.Parameters.AddWithValue("created", DateTime.UtcNow);
            comm.Parameters.AddWithValue("email", email);
            comm.Parameters.AddWithValue("Reminder", reminder);
            comm.ExecuteNonQuery();
        }

        private string IDGenerator()
        {
            return "asd";
        }
    }
}
