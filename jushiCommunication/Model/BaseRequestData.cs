using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model
{
    [JsonObject(MemberSerialization.OptOut)]
    public class BaseRequestData
    {
        public BaseRequestData()
        {
            uuid = Guid.NewGuid().ToString();

            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            timestamp = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            client = "000002";

            sign_type = "";
            encode = "";
            version = "";
            custom = "";
            sign = "";
        }
        /// <summary>
        ///  接口名称——必须,接口名称对应表
        /// </summary>
        public string service { get; set; }
        /// <summary>
        /// 时间戳——必须,商户发起接口调用时服务器时间。采用Unix时间戳格式：1489000690
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 通用唯一识别码——必须,商户发起接口调用之前必须生成一个唯一标识发送给服务器。
        /// </summary>
        public string uuid { get; set; }
        /// <summary>
        /// 签名类型——可选,默认为MD5，目前仅支持MD5
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 签名——必须,按照sign_type参数指定的签名算法对待签名数据进行签名。目前仅支持MD5.详见数字签名。
        /// </summary>
        [JsonIgnore]
        public string sign { get; set; }
        /// <summary>
        /// 参数编码——可选,默认为UTF-8。
        /// </summary>
        public string encode { get; set; }
        /// <summary>
        /// 版本号——可选,默认为当前文档版本号2.0.0。
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 交易终端, 必填，000001手机APP 000002网页 000003微信 000004柜面
        /// </summary>
        public string client { get; set; }
        /// <summary>
        /// 商户自定义数据——可选,用于传递商户自定义数据，商户上传的数据会直接返回给商户
        /// </summary>
        public string custom { get; set; }
    }
}
