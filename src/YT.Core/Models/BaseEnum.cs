using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YT.Models
{
    /// <summary>
    /// 全局静态类
    /// </summary>
    public static class MilkConsts
    {

    }
    /// <summary>
    /// 附件类型
    /// </summary>
    public enum FileType
    {
        身份证正面 = 1,
        身份证背面 = 2,
        监督卡 = 3,
        车头照片 = 4,
        网约车单月单量截图 = 5
    }
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderState
    {
        a=1,b=2,c=3,d=4
    }
}