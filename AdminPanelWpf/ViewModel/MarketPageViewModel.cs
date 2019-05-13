using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LearningApp.ViewModel
{
    class MarketPageViewModel : BaseViewModel
    {
        public ICommand NickNameChangeCommand { get; set; }
        public ICommand MoneyIconChangedCommand { get; set; }

        public MarketPageViewModel()
        {
            NickNameChangeCommand = new RelayCommand(o => NickNameChangeClick(o));
            MoneyIconChangedCommand = new RelayCommand(o => MoneyIconChangedClick(o));
        }

        private void MoneyIconChangedClick(object sender)
        {
            Globals.ActualUser.MoneyIcon = sender.ToString();
            Globals.ActualUser.Money -= 10000;
            SqlConnectionHandler sqlConnection = new SqlConnectionHandler();
            sqlConnection.Open();
            sqlConnection.UpdateMoneyIcon(Globals.ActualUser.GeneratedID, Globals.ActualUser.MoneyIcon, Globals.ActualUser.Money);
            MessageBox.Show("Sikeres vásárlás. Az ikon rövid időn belül megváltozik!");
        }

        private void NickNameChangeClick(object o)
        {
            Globals.ActualUser.NickName = Interaction.InputBox("Add meg az új becneved!", "Becenév megadása", "Becenév helye");
            Globals.ActualUser.Money -= 5000;
            SqlConnectionHandler sqlConnection = new SqlConnectionHandler();
            sqlConnection.Open();
            sqlConnection.UpdateNickName();
        }
    }
}
