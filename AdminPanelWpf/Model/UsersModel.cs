using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelWpf.Model
{
    public class UsersModel
    {
        public string ID { get; set; }
        public string GeneratedID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public string Email { get; set; }
        public string Reminder { get; set; }

    }
}
