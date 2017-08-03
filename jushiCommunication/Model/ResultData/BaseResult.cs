using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model.ResultData
{
    [JsonObject(MemberSerialization.OptOut)]
    public class BaseResult : IResponse
    {
        /// <summary>
        /// 结果编码——“ RD000000”成功
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 错误信息——错误信息描述，详见错误代码列表
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 接口名称——必须,接口名称对应表
        /// </summary>
        public string service { get; set; }

        /// <summary>
        /// 时间戳——商户发起接口调用时服务器时间。采用Unix时间戳格式：1489000690
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        ///  通用唯一识别码——将商户生成的uuid返回给商户系统，以标识接口调用对应关系。(生成规则同demo中uuid)
        /// </summary>
        public string uuid { get; set; }

        /// <summary>
        /// 签名类型——默认为MD5，目前仅支持MD5。
        /// </summary>
        public string sign_type { get; set; }

        /// <summary>
        /// 签名——按照sign_type参数指定的签名算法对待签名数据进行签名。目前仅支持MD5详见数字签名。
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
        /// 商户自定义数据——商户发起接口调用是传递的自定义数据。如果商户没有传递此参数则返回空。
        /// </summary>
        public string custom { get; set; }

        /// <summary>
        /// sequence_id 钜石处理流水号——商户发起的接口请求都对应钜石系统内唯一的处理流水号
        /// </summary>
        public string sequence_id { get; set; }
        
    }
}
