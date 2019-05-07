using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    /// <summary>
    /// Felhasználói adatok
    /// </summary>
    public class UsersModel
    {
        public string GeneratedID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public string Email { get; set; }
        public string Reminder { get; set; }
        public int Money { get; set; }
        public int Level { get; set; }
        public string NickName { get; set; }
    }
}
