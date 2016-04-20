﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixAgentInstaller.Common
{
    public class IPHelper
    {
        /// <summary>
        /// 获取本地IP地址信息
        /// </summary>
        public static String GetInterAddressIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        public static String GetAddressIPFromKeys(List<String> keys)
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (keys.Contains(_IPAddress.ToString()))
                {
                    AddressIP = _IPAddress.ToString();
                    break;
                }
            }
            return AddressIP;
        }

        public static List<String> GetAllAddressIP()
        {
            List<String> result = new List<string>();
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                result.Add(_IPAddress.AddressFamily.ToString() + "," + _IPAddress.ToString());

            }
            return result;
        }
    }
}
