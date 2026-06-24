using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CuoiKiLTMClient
{
    public class ClientInfo
    {
        public Socket sckInfo;
        public string Username;
        public byte[] data = new byte[1024];
        public override string ToString()
        {
            return Username;
        }
    }
}
