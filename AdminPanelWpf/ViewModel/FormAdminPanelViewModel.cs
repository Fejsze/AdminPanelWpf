using LearningApp.View;
using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    class FormAdminPanelViewModel : BaseViewModel
    {
        public event EventHandler onEventRaised;
        private Page displayPage;
        public Page DisplayPage
        {
            get { return displayPage; }
            set
            {
                displayPage = value;
                NotifyPropertyChanged("DisplayPage");
            }
        }

        #region CommandRegion
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LessonCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        //Completion
        public ICommand TestCommand { get; set; }
        //Pairing
        public ICommand TestCommand2 { get; set; }
        public ICommand TestCommand3 { get; set; }
        #endregion

        public FormAdminPanelViewModel()
        {
            CommandInstantiation();
        }


        private void ChangePasswordClick(object sender)
        {
            this.DisplayPage = new ChangePasswordPage();
        }
        private void TestClick1(object sender)
        {
            Test test = new Test();
            test.Show();
        }
        private void TestClick2(object sender)
        {
            MainTaskWindow mainTaskWindow = new MainTaskWindow();
            mainTaskWindow.Show();
        }
        private void TestClick3(object sender)
        {
            MainTaskWindow mainTaskWindow = new MainTaskWindow();
            mainTaskWindow.Show();
        }
        private void LessonClick(object sender)
        {
            LessonsPage lessonsPage = new LessonsPage(sender.ToString());
            DisplayPage = lessonsPage;
        }
        private void ExitClick(object sender)
        {
            if (onEventRaised != null)
                onEventRaised(this, null);
        }
        private void CommandInstantiation()
        {
            ChangePasswordCommand = new RelayCommand(o => ChangePasswordClick(o));
            ExitCommand = new RelayCommand(o => ExitClick(o));
            TestCommand = new RelayCommand(o => TestClick1(o));
            TestCommand2 = new RelayCommand(o => TestClick2(o));
            TestCommand3 = new RelayCommand(o => TestClick3(o));
            LessonCommand = new RelayCommand(o => LessonClick(o));
        }
    }
}
