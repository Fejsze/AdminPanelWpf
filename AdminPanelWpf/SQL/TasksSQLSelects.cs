using LearningApp.Model.Task;
using LearningApp.View.Task;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LearningApp.SQL
{
    /// <summary>
    /// Feladatok lekérése az adatbázisról.
    /// </summary>
    class TasksSQLSelects
    {
        public TasksSQLSelects()
        {
            connection.Open();
        }

        SqlConnectionHandler connection = new SqlConnectionHandler();

        /// <summary>
        /// Feladat lekérdezése.
        /// </summary>
        /// <param name="TaskName">Feladat neve</param>
        /// <returns>Az adott feladat Page-ével tér vissza.</returns>
        public List<Page> SelectTask(string TaskName)
        {
            List<Page> p = new List<Page>();
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT point, description, tasktext, type FROM `taskname` inner JOIN `task_description` on task_description_id = `task_description`.id WHere `taskname`.`Name` = @taskname;", connection.Connection);
                command.Parameters.AddWithValue("taskname", TaskName);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch (reader.GetString(reader.GetOrdinal("type")).ToLower())
                        {
                            case "felelet választós":
                                var textMC = reader.GetString(reader.GetOrdinal("tasktext"));
                                var pointMC = reader.GetInt32(reader.GetOrdinal("point"));
                                p = Multiple_choiceCaseReturn(textMC, pointMC);
                                return p; 
                            
                                case "igaz-hamis":
                                var textTF = reader.GetString(reader.GetOrdinal("tasktext"));
                                var pointTF = reader.GetInt32(reader.GetOrdinal("point"));
                                p = TrueFalseCaseReturn(textTF, pointTF);
                                return p;

                                case "kiegészítős":
                                var textComp = reader.GetString(reader.GetOrdinal("tasktext"));
                                var pointComp = reader.GetInt32(reader.GetOrdinal("point"));
                                p.Add(new CompletionPage(textComp, pointComp));
                                return p;

                            default: return p;
                        }
                    }
                }
                return p;
            }
            catch(Exception)
            {
                return p;
            }
        }

        private List<Page> Multiple_choiceCaseReturn(string text, int point)
        {
            List<Page> pages = new List<Page>();
            string[] tasks = text.Split('$');
            for (int i = 0; i < tasks.Length-1; i++)
            {
                var question = tasks[i].Split('#')[0];
                string[] Answers = tasks[i].Split('#')[1].Split(',');
                var goodAnswer = Answers[Answers.Length - 1];
                pages.Add(new Multiple_choicePage(question, goodAnswer, Answers, point));
            }
            return pages;
        }

        private List<Page> TrueFalseCaseReturn(string text, int point)
        {
            List<Page> pages = new List<Page>();
            string[] tasks = text.Split('$');
            for (int i = 0; i < tasks.Length - 1; i++)
            {
                var question = tasks[i].Split('#')[0];
                string goodAnswer = tasks[i].Split('#')[1];
                pages.Add(new TrueFalsePage(question, goodAnswer, point));
            }
            return pages;
        }        
    }
}
