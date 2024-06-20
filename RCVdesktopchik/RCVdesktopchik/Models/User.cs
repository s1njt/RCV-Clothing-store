using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCVdesktopchik.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string user_name { get; set; }
        public string user_surname { get; set; }
        public string user_nickname { get; set; }
        public string user_email { get; set; }
        public string user_phone { get; set; }
        public string user_password { get; set; }
        public string user_city { get; set; }
    }
}
