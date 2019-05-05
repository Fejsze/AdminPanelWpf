using LearningApp.View;
using LearningApp.View.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private string money;
        private Thread moneySyncThread;

        public Page DisplayPage
        {
            get { return displayPage; }
            set
            {
                displayPage = value;
                NotifyPropertyChanged("DisplayPage");
            }
        }
        public string Money
        {
            get => money; set
            {
                money = "Egyenleg: " + value;
                NotifyPropertyChanged("Money");
            }
        }

        public FormAdminPanelViewModel()
        {
            CommandInstantiation();
            moneySyncThread = new Thread(() =>                                           //Aktuális pénz egyenleg megjelenítésének a frissítése
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    Money = Globals.ActualUser.Money.ToString();
                    Thread.Sleep(6000);
                }
            }).Start();
        }

        #region CommandRegion
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LessonCommand { get; set; }
        public ICommand MarketCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand TestCommand3 { get; set; }
        #endregion

        #region ClickRegion
        private void ChangePasswordClick(object sender)
        {
            this.DisplayPage = new ChangePasswordPage();
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
        private void MarketClick(object sender)
        {
            MarketPage marketPage = new MarketPage();
            DisplayPage = marketPage;
        }
        private void ExitClick(object sender)
        {
            if (onEventRaised != null)
            {
                moneySyncThread.Abort();
                onEventRaised(this, null);
            }
        }
        #endregion

        private void CommandInstantiation()
        {
            ChangePasswordCommand = new RelayCommand(o => ChangePasswordClick(o));
            ExitCommand = new RelayCommand(o => ExitClick(o));
            MarketCommand = new RelayCommand(o => MarketClick(o));
            TestCommand3 = new RelayCommand(o => TestClick3(o));
            LessonCommand = new RelayCommand(o => LessonClick(o));
        }
    }
}
