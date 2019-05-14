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
    class MainContentViewModel : BaseViewModel
    {
        /// <summary>
        /// MainContentViewModel konstruktora
        /// </summary>
        public MainContentViewModel()
        {
            CommandInstantiation();
            DisplayPage = new HomePage();
            moneySyncThread = new Thread(() =>                                           //Aktuális pénz egyenleg megjelenítésének a frissítése
            {
                Thread();
            });
            moneySyncThread.Start();
        }

        private void Thread()
        {
            System.Threading.Thread.CurrentThread.IsBackground = true;
            SqlConnectionHandler sqlConnection = new SqlConnectionHandler();
            while (true)
            {
                if (sqlConnection.Open())
                {
                    sqlConnection.SelectMoneyData(Globals.ActualUser.GeneratedID);
                }
                sqlConnection.Connection.Close();
                Money = Globals.ActualUser.Money.ToString();
                MoneyIcon = Globals.ActualUser.MoneyIcon;
                System.Threading.Thread.Sleep(6000);
            }
        }

        public event EventHandler onEventRaised;
        private Page displayPage;
        private string money;
        private string moneyIcon;
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
                money = value + " Fabatka";
                NotifyPropertyChanged("Money");
            }
        }
        public string MoneyIcon
        {
            get => moneyIcon; set
            {
                moneyIcon = "/LearningApp;component/Resource/" + value;
                NotifyPropertyChanged("MoneyIcon");
            }
        }

        #region CommandRegion
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LessonCommand { get; set; }
        public ICommand MarketCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand KeyBindingCommand { get; set; }
        #endregion

        #region ClickRegion
        private void ChangePasswordClick(object sender)
        {
            this.DisplayPage = new ChangePasswordPage();
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
        private void HomeClick(object sender)
        {
            HomePage homePage = new HomePage();
            DisplayPage = homePage;
            SqlConnectionHandler sqlConnection = new SqlConnectionHandler();
            sqlConnection.Open();
            sqlConnection.SelectMoneyData(Globals.ActualUser.GeneratedID);
        }
        private void ExitClick(object sender)
        {
            if (onEventRaised != null)
            {
                moneySyncThread.Abort();
                onEventRaised(this, null);
            }
        }
        private void KeyBindingClick(object sender)
        {
            MainTaskWindow mainTaskWindow = new MainTaskWindow("Hotkeys");
            mainTaskWindow.Show();
        }
        #endregion

        /// <summary>
        /// Klikk események meghívása.
        /// </summary>
        private void CommandInstantiation()
        {
            ChangePasswordCommand = new RelayCommand(o => ChangePasswordClick(o));
            ExitCommand = new RelayCommand(o => ExitClick(o));
            MarketCommand = new RelayCommand(o => MarketClick(o));
            LessonCommand = new RelayCommand(o => LessonClick(o));
            HomeCommand = new RelayCommand(o => HomeClick(o));
            KeyBindingCommand = new RelayCommand(o => KeyBindingClick(o));
        }
    }
}
