using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbacApplication
{
    public class ResultDto
    {
        /// <summary>
        /// 0表示出错
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Msg { get; set; }
    }
}
