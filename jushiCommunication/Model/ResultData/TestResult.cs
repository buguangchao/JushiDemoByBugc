using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model.ResultData
{
    public class TestResult : BaseResult
    {

        public string name { get; set; }
        public string user_no { get; set; }
        public string cert_no { get; set; }
        public string cert_type { get; set; }
        public string card_no { get; set; }
    }
}
