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
    class LessonsSQLSelects
    {
        SqlConnectionHandler connection = new SqlConnectionHandler();
        public LessonsSQLSelects()
        {
            connection.Open();
        }

        public List<Page> Multiple_choiceTask(string TaskName)
        {
            List<Page> p = null;
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT point, description, tasktext, type FROM `taskname` inner JOIN `task_description` on task_description_id = `task_description`.id WHere `taskname`.`Name` = @taskname;", connection.Connection);
                command.Parameters.AddWithValue("taskname", TaskName);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        switch (reader.GetString(reader.GetOrdinal("type")))
                        {
                            case "Felelet választós":
                                var text = reader.GetString(reader.GetOrdinal("tasktext"));
                                var point = reader.GetInt32(reader.GetOrdinal("point"));
                                p = Multiple_choiceCaseReturn(text, point);
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
            List<Multiple_choice> pageData = new List<Multiple_choice>();
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
    }
}
