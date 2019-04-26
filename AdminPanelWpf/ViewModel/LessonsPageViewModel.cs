using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            conn.Open();
            LessonText = conn.LessonSelect(topic);
        }

    }
}
