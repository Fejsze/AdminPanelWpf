using LearningApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LearningApp
{
    /// <summary>
    /// Globális adatok tárolása
    /// </summary>
    public static class Globals
    {
        public static UsersModel ActualUser;
        public static int ActualPoints;
        public static int MaxPoints;
        public static List<Page> ActualTasks;
        public static List<Page> ActualTasksDefault;

        public static int LvLUp()
        {
            if ((int)ActualPoints > (int)MaxPoints/2-1 && ActualPoints != 0 && MaxPoints != 0)
            {
                ActualUser.Level++;
                SqlConnectionHandler sqlConnection = new SqlConnectionHandler();
                if (sqlConnection.Open())
                    sqlConnection.UserLvLUp(Globals.ActualUser.GeneratedID, Globals.ActualUser.Level);
                else
                {
                    ActualUser.Level--;
                    return 2;
                }
                return 1;
            }
            return 0;
        }

        public static Page NextTask()
        {
            if (ActualTasks.Count > 0)
            {
                Page np = ActualTasks[0];
                ActualTasks.Remove(ActualTasks[0]);
                return np;
            }
            else return null;
        }
    }
}
