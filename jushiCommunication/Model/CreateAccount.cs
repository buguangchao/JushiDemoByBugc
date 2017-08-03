using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model
{
    public class CreateAccount : BaseRequestData, IRequestModel
    {
        public CreateAccount()
        {
            cert_type = string.Empty;
            cert_no = string.Empty;
            name = string.Empty;
            mobile = string.Empty;
            sms_flag = string.Empty;
            risk_level_flag = string.Empty;
            risk_level = string.Empty;
            account_type = string.Empty;
            bind_card = string.Empty;
            gender = string.Empty;
            user_no = string.Empty;
            user_ip = string.Empty;
            testA = new List<string>();
            user = new User();
            uerList = new List<User>();
            //testB = new string[] { };
            //testAccountBalance = new List<AccountBalance>();
        }

        /// <summary>
        /// 证件类型, 必填，01-身份证18位,2
        /// </summary>
        public string cert_type { get; set; }
        /// <summary>
        /// 证件号码，必填，18
        /// </summary>
        public string cert_no { get; set; }
        /// <summary>
        /// 姓名, 必填，60
        /// </summary>
        public string name { get; set; }
        /// <summary>
        ///  手机号，必填，12
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 是否开通短信通知 ，必填，0:不需要；1:需要，1
        /// </summary>
        public string sms_flag { get; set; }
        /// <summary>
        /// 风险评估标志， 必填，1:已评估，1
        /// </summary>
        public string risk_level_flag { get; set; }
        /// <summary>
        ///  风险评级等级，留空,1
        /// </summary>
        public string risk_level { get; set; }
        /// <summary>
        ///   账户类型，当前只支持1靠档计息，必填，0：基金账户；1：靠档账户；2：活期账户，1
        /// </summary>
        public string account_type { get; set; }
        /// <summary>
        ///  绑定卡号，必填，19
        /// </summary>
        public string bind_card { get; set; }
        /// <summary>
        ///  性别 ，必填，M 男性 F 女性，1
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        ///  第三方平台用户编号，有条件必填，20
        /// </summary>
        public string user_no { get; set; }

        /// <summary>
        ///  客户IP()，32
        /// </summary>
        public string user_ip { get; set; }

        public List<string> testA { get; set; }


        public List<User> uerList { get; set; }

        public User user { get; set; }
        //public List<AccountBalance> testAccountBalance { get; set; }

        //public string[] testB { get; set; }
    }
}
