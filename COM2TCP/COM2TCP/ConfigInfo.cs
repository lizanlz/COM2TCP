using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM2TCP
{
    internal class ConfigInfo
    {
        public string TabName { get; set; } // 页签名称
        public string SPort { get; set; } // 串口号
        public int BaudRate { get; set; } // 串口波特率
        public int DataBits { get; set; } // 串口数据位
        public string Parity { get; set; } // 校验位
        public double StopBits { get; set; } // 停止位
        public int TPort { get; set; } // TCP服务监听端口
        public string MsgCode { get; set; } // 消息编码：ASCII, HEX
        public string MsgSeperator { get; set; } // 串口消息分割符
    }
}
