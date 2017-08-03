using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model
{
    public class AccountBalance: BaseRequestData, IRequestModel
    {
        public AccountBalance()
        {
            card_no = "";
            third_custom = "";
            sign = "";
        }

        public string card_no { get; set; }
        public string third_custom { get; set; }

        public string GetOriginalData()
        {
            return "";
        }
    }
}
