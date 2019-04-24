using LearningApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApp
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
            MySqlCommand command = new MySqlCommand("SELECT password FROM login WHERE username = @username", connection);
            command.Parameters.AddWithValue("username", userName);

            var loginChek = command.ExecuteScalar();
            //MessageBox.Show(StringCipher.Decrypt(loginChek.ToString(), "Fejsze"));
            return loginChek == null ? false : StringCipher.Decrypt(loginChek.ToString(), "Fejsze").ToString() == password;
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
                        um.Password = StringCipher.Decrypt(reader.GetString(reader.GetOrdinal("Password")), "Fejsze");
                    if (!reader.IsDBNull(reader.GetOrdinal("Reminder")))
                        um.Reminder = reader.GetString(reader.GetOrdinal("Reminder"));
                }
            }
            return um;
        }

        public void UpdatePassword(string ID, string newPassoword)
        {
            MySqlCommand comm = new MySqlCommand("UPDATE login SET password = @password WHERE id = @id", connection);
            comm.Parameters.AddWithValue("password", StringCipher.Encrypt(newPassoword, "Fejsze"));
            comm.Parameters.AddWithValue("id", ID);
            comm.ExecuteNonQuery();
        }

        public void InsertUser(string username, string password, string email, string reminder)
        {
            MySqlCommand comm = new MySqlCommand("INSERT INTO login (`generatedid`, `username`, `password`, `created`, `email`, `Reminder`) VALUES (@generatedid, @username, @password, @created, @email, @Reminder);", connection);
            comm.Parameters.AddWithValue("generatedid", IDGenerator());
            comm.Parameters.AddWithValue("username", username);
            comm.Parameters.AddWithValue("password", StringCipher.Encrypt(password, "Fejsze"));
            comm.Parameters.AddWithValue("created", DateTime.UtcNow);
            comm.Parameters.AddWithValue("email", email);
            comm.Parameters.AddWithValue("Reminder", reminder);
            comm.ExecuteNonQuery();
        }

        private string IDGenerator()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
