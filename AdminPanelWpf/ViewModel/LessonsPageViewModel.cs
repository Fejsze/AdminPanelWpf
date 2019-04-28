using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearningApp.ViewModel
{
    class LessonsPageViewModel : BaseViewModel
    {
        private string lessonText;

        public string LessonText
        {
            get => lessonText;
            set
            {
                lessonText = value;
                NotifyPropertyChanged("LessonText");
            }
        }

        public LessonsPageViewModel(string topic)
        {
            SqlConnectionHandler conn = new SqlConnectionHandler();
            try
            {
                if (conn.Open())
                {
                    string x = conn.LessonSelect(topic).Result;
                    LessonText = x;
                }
                else MessageBox.Show("Hiba!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
