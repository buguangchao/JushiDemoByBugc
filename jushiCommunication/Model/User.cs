using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model
{
    public class User
    {
        public User()
        {
            revoke_sign_date = "";
            revoke_sign_time = "";
            sign_date = "";
            sign_time = "";
        }
        public string revoke_sign_date { get; set; }

        public string revoke_sign_time { get; set; }

        public string sign_date { get; set; }

        public string sign_time { get; set; }
    }
}
