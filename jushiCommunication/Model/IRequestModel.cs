using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jushiCommunication.Model
{
    public interface IRequestModel
    {

        string sign { get; set;}
        ///// <summary>
        ///// 获取原始签名拼接字符串
        ///// </summary>
        ///// <returns></returns>
        //string GetOriginalData();
    }
}
