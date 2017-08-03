using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jushiCommunication;
using jushiCommunication.Model;
using jushiCommunication.Model.ResultData;
using Newtonsoft.Json;

namespace JushiDemoNet.Controllers
{
    public class DeomController : Controller
    {
        // GET: Deom
        public ActionResult SendMsg()
        {
            string json = "{\"Id\":1,\"Name\":\"刘备\",\"Age\":\"22\"}";
            //此处模拟在不建实体类的情况下，反转将json返回回dynamic对象  
            var DynamicObject = JsonConvert.DeserializeObject<dynamic>(json);
            Console.WriteLine(DynamicObject.Name);  //刘备  
            return View();
        }

        [HttpPost]
        public ActionResult SendMsg(string type)
        {
            if ("account_balance".Equals(type))
            {
                //AccountBalance ab = new AccountBalance();
                //ab.service = "account_balance";
                //ab.card_no = "40908105";
                //ab.third_custom = "";

                CreateAccount ab = new CreateAccount();
                ab.service = "create_account";
                ab.timestamp = "1493792840";
                ab.uuid = "201705210033010001";
                ab.sign_type = "MD5";
                ab.encode = "UTF-8";
                ab.version = "2.0.0";
                ab.client = "000002";
                ab.cert_type = "01";
                ab.cert_no = "421302199001088235";
                ab.name = ""; //胡必武
                ab.mobile = "13717923316";
                ab.sms_flag = "1";
                ab.risk_level_flag = "1";
                ab.risk_level = "";
                ab.account_type = "1";
                ab.bind_card = "6212260200109158309";
                ab.gender = "M";
                ab.user_no = "111222333";
                ab.user_ip = "127.0.0.1";
                ab.testA.Add("a");
                ab.testA.Add("b");
                ab.testA.Add("c");
                ab.user.revoke_sign_date = "bugc";
                ab.user.revoke_sign_time = "male";
                ab.uerList.Add(new User { revoke_sign_date = "bgc", revoke_sign_time = "male",sign_date="123",sign_time="ttttt" });
                ab.uerList.Add(new User { revoke_sign_date = "xyj", revoke_sign_time = "male", sign_date = "456",sign_time="sssssssssssssssssssss" });
                //AccountBalance account = new AccountBalance();
                //account.card_no = "123456789";
                //account.third_custom = "987654321";
                //ab.testAccountBalance.Add(account);
                TestResult res = jushiCommunication.Communication.SendRequest<CreateAccount, TestResult>(ab);

                ViewBag.js = res.code + res.msg ;
            }
            return View();
        }
    }
}