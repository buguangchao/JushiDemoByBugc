using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model.ResultData
{
    public interface IResponse
    {
        string code { get; set; }

        /// <summary>
        /// 错误信息——错误信息描述，详见错误代码列表
        /// </summary>
        string msg { get; set; }

        string sign { get; set; }
    }
}
