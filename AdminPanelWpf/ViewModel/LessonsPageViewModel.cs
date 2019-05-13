using LearningApp.Model;
using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    class LessonsPageViewModel : BaseViewModel
    {
        private bool isVisisbleButton;
        private string lessonText;
        private string LessonTopic;
        public ICommand TaskCommand { get; set; }

        public string LessonText
        {
            get => lessonText;
            set
            {
                lessonText = value;
                NotifyPropertyChanged("LessonText");
            }
        }

        public bool IsVisisbleButton
        {
            get => isVisisbleButton;
            set
            {
                isVisisbleButton = value;
                NotifyPropertyChanged("IsVisisbleButton");
            }
        }

        public LessonsPageViewModel(string topic)
        {
            TaskCommand = new RelayCommand(o => TaskCommandClick(o));
            SetUp(topic);
        }

        private void TaskCommandClick(object o)
        {
            MainTaskWindow mainTaskWindow = new MainTaskWindow();
            mainTaskWindow.Show();
        }

        private void SetUp(string topic)
        {
            MessageBox.Show(topic);
            IsVisisbleButton = false;
            SqlConnectionHandler conn = new SqlConnectionHandler();
            try
            {
                if (conn.Open())
                {
                    Lesson x = conn.LessonSelect(topic);
                    LessonText = x.Text;
                    IsVisisbleButton = x.TopicEnd;
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
