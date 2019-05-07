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

        public MarketPageViewModel()
        {
            NickNameChangeCommand = new RelayCommand(o => NickNameChangeClick(o));
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
