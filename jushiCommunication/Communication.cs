using jushiCommunication.Model;
using jushiCommunication.Model.ResultData;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace jushiCommunication
{
    public class Communication
    {
        static string ApiUri = "https://apisit.rockfintech.com/2.0.0/deposit";
        static string RF_KEY = "201704281004";
        static string RFT_TOKEN = "f93350be0a3dc26166649b332aba15fb";

        static string PublieKey = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArIEJRYUYtYUFIVXxRkw3
vw4Bt8xqwySmIG9Iou1S0+i7xXzchpIR/kid1L9kJJGfk6bd6451RU+eEcaeI08B
OutsVidca051/PnkTRZl7S+Tpwau6TSUFfAMFNEYwFkuvmqGbm/EqyN0Mb0wZz7s
vmJIE6iKhgv+rGVkmXaAQQsu1f5erXKM4M6ukWSwIuStOGjgn33PK7s4TUwQK9Ay
q0QgJyT3j/WRjy8nB/D8plnitl/SI5VR7xsMkpy2giovYtp4LvFV5QOFSYobqiP2
Te0a93ey7H2IAXOBveTCihr+d3jaAh2Qdj+Lfu7UaqtdpTjR0zN707G7HPVTRXLz
bQIDAQAB".Replace("\n","");

        static string PrivateKey = @"MIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCsgQlFhRi1hQUh
VfFGTDe/DgG3zGrDJKYgb0ii7VLT6LvFfNyGkhH+SJ3Uv2QkkZ+Tpt3rjnVFT54R
xp4jTwE662xWJ1xrTnX8+eRNFmXtL5OnBq7pNJQV8AwU0RjAWS6+aoZub8SrI3Qx
vTBnPuy+YkgTqIqGC/6sZWSZdoBBCy7V/l6tcozgzq6RZLAi5K04aOCffc8ruzhN
TBAr0DKrRCAnJPeP9ZGPLycH8PymWeK2X9IjlVHvGwySnLaCKi9i2ngu8VXlA4VJ
ihuqI/ZN7Rr3d7LsfYgBc4G95MKKGv53eNoCHZB2P4t+7tRqq12lONHTM3vTsbsc
9VNFcvNtAgMBAAECggEAYvC7taEKNAqwj5cwhKZwjudkutvHHFgn5JCPc8t051Ak
argb8B9VrKhPxldkA8l2YoSh4lpaDsAEpKNrzkqhJP8kqyF2U6Gz8L4PYNuI6IqS
QImHxwA+M3r0IvhvHtvIALUul6cJgTMbkO+3FHC17tiGCKhxk0LL9mtNUOvz0dm7
P2oBzJd3xNo9DPNbTIrysLhPi0yqWNkXhkJEpdyTSviXbpXQKlkynR/pXVGqmHyl
iUTeqCDWxldPE5PxDo3Q957q2JIPH/5D5eP7yRbXLIoRIVIhBCprhSXAOxY3sUq+
0Ycmv7CgLRoMBp/hdQZmJ5+/BZJ51u85KGzt33VRIQKBgQDkmY2qFBad6NDP5DXJ
urUOZy5eHCcgAVexeIS/uL9X4MtXwL8p7TBvnWWKoz1lJG0GI5lU3I+gkv+43LzS
yLTaVWq9GPn6FE5vvMoxPs0X36zzdP/UTu59v8OMXfASpxDuqJNHkn6rHcnF0HJr
PAbmd4hoM79Lidg813NuiiqnZQKBgQDBLjfbU4k4ilev+cA8BcJKL3jn5ZehsN9v
N33NZOKFkT5yt0HRedDmwk7VqwpKRMBsRMrVwLBBdkWqQJV+fWB+z79pF0ELJrwn
exWDJrEnZxIY3wjq2hgmuHspMLOUhNAhgAEM7klkE8ZMeHH9gIFzltSQrc6YYlwz
JbHnzqnvaQKBgDyjHpjGy1kHsJv0hPAFvpEbfYkpHpe2w3Qn686PSvIchtO4JP0S
FY8FyTGFK3vwtZqzRrDj8JU/aOW4Z73hz1c64R1XyrczO7sX8OovJmf2xQGvP00p
wslIXK6XHF9WQX+M58RMb50kQalfKXqYaZwoiN5bG5sF7X32CICB1d6hAoGARl6Q
qEtgxADY+lhu5y5t3No4H7kpqBOnAHtlTyl9vovvBJiu2CCYsUZ8syawA+fRdF8G
yCB91ArCS8dk7YO8X9VLc3uuDOLaTUNvzauNgr3wALFWLT6u54PyEUoVUHek3V8k
gtJWV6dAZ+DEHUTvYuzBl8ZIaIgD7/m+OaO1kWkCgYBxfxyT9a2SbSSfra36yzMg
6w8e/JJGIAR0PrlZBZL/RLf6juf09tFNyH0P2mgq0wrK5dl6HX8PFPIlTbxJtKkE
Q4311+rudtzNEfMjAHGTK8vd7zQWq67Do/psu+nVjCvOvb/dqi0VJDRCPz74L8w1
4hHoBS4FQCvZC6OEVILagg==".Replace("\n","");

        public static S SendRequest<T,S>(T data) where T: BaseRequestData where S : BaseResult
        {
            string str = "{\"cert_type\":\"01\",\"cert_no\":\"421302199001088235\",\"name\":\"\",\"mobile\":\"13717923316\",\"sms_flag\":\"1\",\"risk_level_flag\":\"1\",\"risk_level\":\"\",\"account_type\":\"1\",\"bind_card\":\"6212260200109158309\",\"gender\":\"M\",\"user_no\":\"111222333\",\"user_ip\":\"127.0.0.1\",\"testA\":[\"a\",\"b\",\"c\"],\"uerList\":[{\"revoke_sign_date\":\"bgc\",\"revoke_sign_time\":\"male\",\"sign_date\":\"123\",\"sign_time\":\"ttttt\"},{\"revoke_sign_date\":\"xyj\",\"revoke_sign_time\":\"male\",\"sign_date\":\"456\",\"sign_time\":\"sssssssssssssssssssss\"}],\"user\":{\"revoke_sign_date\":\"bugc\",\"revoke_sign_time\":\"male\",\"sign_date\":\"\",\"sign_time\":\"\"},\"service\":\"create_account\",\"timestamp\":\"1493792840\",\"uuid\":\"201705210033010001\",\"sign_type\":\"MD5\",\"sign\":\"0c7afe20dd44090c000bc5f1c48d985a\",\"encode\":\"UTF-8\",\"version\":\"2.0.0\",\"client\":\"000002\",\"custom\":\"\"}";
            var o = JsonConvert.DeserializeObject<dynamic>(str);
            data.sign = GetSign(data);

            string param = DataConvertRsaParamStr(data);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(ApiUri));
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request.Proxy = null;
            request.Method = "Post";
            request.ContentType = "application/json";
            request.Headers.Add("Content-Encoding", "UTF-8");
            request.Headers.Add("RFT-KEY", RF_KEY);
            byte[] requesdata = Encoding.UTF8.GetBytes(param);
            request.ContentLength = requesdata.Length;
            request.GetRequestStream().Write(requesdata, 0, requesdata.Length);
            HttpWebResponse respone = (HttpWebResponse)request.GetResponse();

            string result = "";
            using (StreamReader reader = new StreamReader(respone.GetResponseStream()))
            {
                result= Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(reader.ReadToEnd()));
            }
            result = RsaParamStrConvertData(result);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            S resultData = serializer.Deserialize<S>(result);
            string sign = GetSign(resultData);
            if (!sign.Equals(resultData.sign))
            {
                resultData.code = "400";
                resultData.msg = "本地验签失败";
            }

            return resultData;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

        public static string DataConvertRsaParamStr<T>(T data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string publickey = RSAPublicKeyJava2DotNet(PublieKey);
            string strParam = serializer.Serialize(data);
            return Convert.ToBase64String(RSAEncrypt(strParam, publickey));
        }


        public static string RsaParamStrConvertData(string param)
        {
            string privatekey = RSAPrivateKeyJava2DotNet(PrivateKey);
            return RSADecrypt(Convert.FromBase64String(param), privatekey);
        }

        /// <summary>
        /// ras非window秘钥转换成windows系统下的秘钥
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string RSAPrivateKeyJava2DotNet(string privateKey)
        {
            RsaPrivateCrtKeyParameters privateKeyParam = (RsaPrivateCrtKeyParameters)PrivateKeyFactory.CreateKey(Convert.FromBase64String(privateKey));

            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                Convert.ToBase64String(privateKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.PublicExponent.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.P.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Q.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DP.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.DQ.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.QInv.ToByteArrayUnsigned()),
                Convert.ToBase64String(privateKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        /// <summary>
        /// ras非window公钥转换成windows系统下的公钥
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string RSAPublicKeyJava2DotNet(string publicKey)
        {
            RsaKeyParameters publicKeyParam = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>",
                Convert.ToBase64String(publicKeyParam.Modulus.ToByteArrayUnsigned()),
                Convert.ToBase64String(publicKeyParam.Exponent.ToByteArrayUnsigned()));
        }

        /// <summary>
        /// rsa加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="publickey"></param>
        /// <returns></returns>
        public static byte[] RSAEncrypt(string content,string publickey)
        {


            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publickey);
            int keySize = rsa.KeySize / 8;
            int bufferSize = keySize - 11;
            byte[] buffer = new byte[bufferSize];

            MemoryStream msInput = new MemoryStream(Encoding.UTF8.GetBytes(content));
            MemoryStream msOuput = new MemoryStream();
            int readLen = msInput.Read(buffer, 0, bufferSize);
            while (readLen > 0)
            {
                byte[] dataToEnc = new byte[readLen];
                Array.Copy(buffer, 0, dataToEnc, 0, readLen);
                byte[] encData = rsa.Encrypt(dataToEnc, false);
                msOuput.Write(encData, 0, encData.Length);
                readLen = msInput.Read(buffer, 0, bufferSize);
            }
            msInput.Close();
            byte[] result = msOuput.ToArray();    //得到加密结果
            msOuput.Close();
            rsa.Clear();
            return result;
        }

        /// <summary>
        /// rsa解密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="privatekey"></param>
        /// <returns></returns>
        public static string RSADecrypt(byte[] content,string privatekey)
        {
        
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privatekey);

            int keySize = rsa.KeySize / 8;
            byte[] buffer = new byte[keySize];
            MemoryStream msInput = new MemoryStream(content);
            MemoryStream msOutput = new MemoryStream();
            int readLen = msInput.Read(buffer, 0, keySize);
            while (readLen > 0)
            {
                byte[] dataToDec = new byte[readLen];
                Array.Copy(buffer, 0, dataToDec, 0, readLen);
                byte[] decData = rsa.Decrypt(dataToDec, false);
                msOutput.Write(decData, 0, decData.Length);
                readLen = msInput.Read(buffer, 0, keySize);
            }
            msInput.Close();
            byte[] result = msOutput.ToArray();    //得到解密结果
            msOutput.Close();
            rsa.Clear();
            return Encoding.UTF8.GetString(result);
        }


        /// <summary>
        /// 获取sign签名
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static string GetSign<T>(T data)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //string originalSign = GetOriginalData(data);

            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new OrderedContractResolver()
            };

            string jsondata = JsonConvert.SerializeObject(data, Formatting.None, settings);
            jsondata = jsondata.Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace(":", "=").Replace(",", "&").Replace("\"", "");
            string originalSign = jsondata;

            string key = GetMD5Code(RF_KEY + RFT_TOKEN);
            string signval = GetMD5Code(originalSign + key);
            return signval;
        }

        private static string GetOriginalData<T>(T data)
        {
            string strOriginalData = "";
            Type type = data.GetType();
            PropertyInfo []propertys = type.GetProperties();
            string value = propertys[0].GetValue(data,null).ToString();
            SortedList<string, string> propertyValues = new SortedList<string, string>();
            foreach (PropertyInfo p in propertys)
            {
                //Type t = p.PropertyType;
                //if (typeof(IList).IsAssignableFrom(p.PropertyType))
                //{
                //    List<object> list = (List<object>)p.GetValue(data, null);
                //    string strtemp = "";
                //    foreach (var item in list)
                //    {
                //        strtemp += item + "&";
                //    }
                //    strtemp = strtemp.Trim('&');
                //    propertyValues.Add(p.Name, strtemp);
                //}
                //else
                //{

                //}

                propertyValues.Add(p.Name, p.GetValue(data, null).ToString());
                //propertyValues.Add(p.Name, convertObjectToJson(p.GetValue(data, null)));

            }
            foreach (KeyValuePair<string, string> item in propertyValues)
            {
                if(item.Key!= "sign")
                    strOriginalData += item.Key + "=" + item.Value + "&";
            }
         
            return strOriginalData.Trim('&');
        }

        private static string convertObjectToJson(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            Type t = obj.GetType();
            if (typeof(IList).IsAssignableFrom(t))
            {
                Type[] arr = t.GetGenericArguments();
                return "";
                StringBuilder builder = new StringBuilder();
                foreach (var item in (IList<object>)obj)
                {
                    builder.Append(convertObjectToJson(item)).Append("&");
                }

                String result = builder.ToString();
                return result.Substring(0, result.Length - 1);
            }
            else
            {
                return obj.ToString();
            }
	    }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="code">初始字符</param>
        /// <returns>加密后的字符</returns>
        public static string GetMD5Code(string code)
        {
            byte[] b = Encoding.UTF8.GetBytes(code);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;

        }

    }
}
