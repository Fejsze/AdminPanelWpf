using LearningApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LearningApp
{
    public static class Globals
    {
        public static UsersModel ActualUser;
        public static int ActualPoints;
        public static List<Page> ActualTasks;
        public static List<Page> ActualTasksDefault;

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
