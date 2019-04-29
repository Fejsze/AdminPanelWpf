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
            return IsOpen;
        }

        public bool IsUserValid(string userName, string password)
        {
            MySqlCommand command = new MySqlCommand("SELECT password FROM login WHERE username = @username", connection);
            command.Parameters.AddWithValue("username", userName);
            var loginChek = command.ExecuteScalar();
            return loginChek == null ? false : StringCipher.Decrypt(loginChek.ToString(), "Fejsze").ToString() == password;
        }

        public UsersModel GetUserData(string userName)
        {
            UsersModel um = null;
            try
            {
                MySqlCommand comm = new MySqlCommand("SELECT * FROM login inner join user_data on login.user_data_id = user_data.id WHERE username = @username", connection);
                comm.Parameters.AddWithValue("username", userName);
                using (MySqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        um = new UsersModel();
                        if (!reader.IsDBNull(reader.GetOrdinal("Created")))
                            um.Created = reader.GetDateTime(reader.GetOrdinal("Created"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                            um.Email = reader.GetString(reader.GetOrdinal("Email"));
                        if (!reader.IsDBNull(reader.GetOrdinal("username")))
                            um.Username = reader.GetString(reader.GetOrdinal("username"));
                        if (!reader.IsDBNull(reader.GetOrdinal("generatedid")))
                            um.GeneratedID = reader.GetString(reader.GetOrdinal("generatedid"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Password")))
                            um.Password = StringCipher.Decrypt(reader.GetString(reader.GetOrdinal("Password")), "Fejsze");
                        if (!reader.IsDBNull(reader.GetOrdinal("Reminder")))
                            um.Reminder = reader.GetString(reader.GetOrdinal("Reminder"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Money")))
                            um.Money = reader.GetInt32(reader.GetOrdinal("Money"));
                        if (!reader.IsDBNull(reader.GetOrdinal("Level")))
                            um.Level = reader.GetInt32(reader.GetOrdinal("Level"));
                        if (!reader.IsDBNull(reader.GetOrdinal("NickName")))
                            um.NickName = reader.GetString(reader.GetOrdinal("NickName"));
                    }
                }
                return um;
            }
            catch (Exception)
            {
                return um;
            }
        }

        public void UpdatePassword(string GeneratedId, string newPassoword)
        {
            MySqlCommand comm = new MySqlCommand("UPDATE login SET password = @password WHERE generatedid = @generatedid", connection);
            comm.Parameters.AddWithValue("password", StringCipher.Encrypt(newPassoword, "Fejsze"));
            comm.Parameters.AddWithValue("generatedid", GeneratedId);
            comm.ExecuteNonQuery();
        }

        public bool InsertUser(string username, string nickname, string password, string email, string reminder)
        {
            UsersModel um = GetUserData(username);
            if (um == null)
            {
                //User data beszúrása
                MySqlCommand commUD = new MySqlCommand("INSERT INTO `user_data` (`level`, `nickname`,`money`) VALUES ( 0, @nickname, @money );", connection);
                    commUD.Parameters.AddWithValue("nickname", nickname);
                    commUD.Parameters.AddWithValue("money", 1000);
                    commUD.ExecuteNonQuery();
                //Login beszúrása
                MySqlCommand commL = new MySqlCommand("INSERT INTO login (`generatedid`, `username`, `password`, `created`, `email`, `Reminder`, `user_data_id`) VALUES (@generatedid, @username, @password, @created, @email, @Reminder, @user_data_id);", connection);
                    commL.Parameters.AddWithValue("generatedid", IDGenerator);
                    commL.Parameters.AddWithValue("username", username);
                    commL.Parameters.AddWithValue("password", StringCipher.Encrypt(password, "Fejsze"));
                    commL.Parameters.AddWithValue("created", DateTime.UtcNow);
                    commL.Parameters.AddWithValue("email", email);
                    commL.Parameters.AddWithValue("Reminder", reminder);
                    commL.Parameters.AddWithValue("user_data_id", LastInsertIDUserData());
                    commL.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public string DefaultSelect(string columnNames, string tableName, string where)
        {
            MySqlCommand comm;
            if (where!="") comm = new MySqlCommand($"Select {columnNames} From {tableName} Where {where}", connection);
            else comm = new MySqlCommand($"Select {columnNames} From {tableName}");
            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                string selectValue = "";
                foreach (var item in reader)
                {
                    selectValue += item;
                }
                return selectValue;
            }
        }
        public async Task<string> LessonSelect(string topic)
        {
            MySqlCommand comm;
            if (topic != "")
            {
                comm = new MySqlCommand($"Select text, requirement From lessons Where topic=@topic;", connection);
                comm.Parameters.AddWithValue("topic", topic);
                System.Data.Common.DbDataReader reader = await comm.ExecuteReaderAsync();
                using (reader)
                {
                    string selectedValue;
                    reader.Read();
                    if (int.Parse(reader["requirement"].ToString()) == Globals.ActualUser.Level || int.Parse(reader["requirement"].ToString()) < Globals.ActualUser.Level)
                    {
                        selectedValue = reader["text"].ToString();
                    }
                    else
                    {
                        selectedValue = "Még nem érted el a megfelelő szintet. Kérlek sorba haladj a tananyaggal!";
                    }
                    return selectedValue;
                }
            }
            return null;
        }

        private int LastInsertIDUserData()
        {
            MySqlCommand comm = new MySqlCommand($"Select Max(`id`) From `user_data`;", connection);
            using (MySqlDataReader reader = comm.ExecuteReader())
            {
                int result = reader.GetOrdinal("id");
                return result;
            }
        }

        private string IDGenerator => Guid.NewGuid().ToString("N");
    }
}