using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Common.String
{
    public static class URL
    {
        public static string ToUrl(this string name)
        {
            return name.Replace(" ", "-");
        }
        public static string UrlEncode(this string input)
        {
            return HttpUtility.UrlEncode(input);
        }
    }
}
