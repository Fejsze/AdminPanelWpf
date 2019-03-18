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
        public string LoginName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime? Created { get; set; }
        public string Email { get; set; }
    }
}
