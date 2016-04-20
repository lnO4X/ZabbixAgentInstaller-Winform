using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZabbixAgentInstaller.Common
{
    public class SerializeHelper
    {
        /// <summary>
        /// For Serialize JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static String SerializeJson<T>(T model)
        {
            String result = String.Empty;
            throw new NotImplementedException();

        }
        /// <summary>
        /// For Deserialize JSON to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content">Json file</param>
        /// <returns></returns>
        public static T DeserializeJson<T>(String content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Deserialize JSON to T from file path
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T DeserializeJsonFromFile<T>(String path)
        {
            String content = String.Empty;
            var result = FileHelper.FindInChildDirectory(AppDomain.CurrentDomain.BaseDirectory, path);
            if (result.IsNullOrEmpty())
                result = FileHelper.FindParentDirectory(AppDomain.CurrentDomain.BaseDirectory, path);
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(result))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (Exception ee)
            {
                throw new Exception("File Not Exist All directory . File: " + path, ee);

            }
            return DeserializeJson<T>(content);

        }




    }
}
