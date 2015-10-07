using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PROJECT.Core.Models
{
    public class UserAccountModel
    {
        public int UserId { get; set; }

        public int RegistrationId { get; set; }
        public Int16 RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserEmail { get; set; }

        public string PhotoName { get; set; }


        public UserAccountModel()
        {


            UserEmail = string.Empty;


        }
    }
}
