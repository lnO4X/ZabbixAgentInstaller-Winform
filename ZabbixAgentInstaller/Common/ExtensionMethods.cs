
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZabbixAgentInstaller.Common
{
    public static class ExtensionMethods
    {
        #region DateTime
        public static Boolean EqualsDate(this DateTime d1, DateTime d2)
        {
            return d1.Date == d2.Date;
        }



        public static int GetAbsDiffDays(this DateTime d1, DateTime d2)
        {

            return Math.Abs((d1 - d2).Days);
        }
        #endregion

        #region String
        public static Boolean IsNullOrEmpty(this String str)
        {
            return String.IsNullOrEmpty(str);
        }
        public static String FormatFolderName(this String str)
        {
            return str.Replace(@"\\", @"\");
        }
        public static String GetFileName(this String str)
        {
            var index = str.LastIndexOf('\\');
            if (index > 0)
            {
                str = str.Substring(index + 1, str.Length - index - 1);
            }
            return str;
        }
      

        #endregion


        #region List
        public static String GetStringFromList<T>(this List<T> ls)
        {
            var result = new StringBuilder();
            ls.ForEach(l =>
            {
                result.Append(l.ToString());
                if (!l.Equals(ls.Last()))
                    result.Append(",");
            });
            return result.ToString();
        }

        /// <summary>
        /// 检查队列是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ls"></param>
        /// <returns></returns>
        public static Boolean IsNullOrEmpty<T>(this List<T> ls)
        {
            if (ls == null || ls.Count == 0) return true;
            return false;
        }
        public static List<T> ToNotNullList<T>(this IList<T> ls)
        {
            if (ls == null) return new List<T>();
            else return ls.ToList();
        }


        #endregion


        #region int
        public static String GetEnumName<T>(this int value)
        {
            return Enum.GetName(typeof(T), value);
        }
        public static int IfBigThenMinus(this int thisvalue, int value)
        {
            if (thisvalue > value)
                return thisvalue - value;
            else return thisvalue;
        }

        #endregion

        #region T
        public static List<T> MakeList<T>(this Object cell)
            where T : class
        {
            if (cell == null) throw new ArgumentNullException("Make List Failed");
            return new List<T>() { cell as T };
        }
        #endregion
    }
}
