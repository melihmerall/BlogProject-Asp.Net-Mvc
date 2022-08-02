using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TechnoBlogProject.Helper
{
    public static class SeoUrl
    {
        public static string ToSeoUrl(this string url)
        {
            string encodeURL = (url ?? "").ToLower();
            encodeURL = encodeURL.Replace("ç", "c")
                .Replace("ı", "i")
                .Replace("ş", "s")
                .Replace("ğ", "g")
                .Replace("ü", "u")
                .Replace("ö", "o")
                .Replace("+", "plus")
                .Replace("#", "sharp");
            encodeURL = Regex.Replace(encodeURL, @"\&+", "and");
            encodeURL = encodeURL.Replace("'", "");
            encodeURL = Regex.Replace(encodeURL, @"[^a-z0-9]", "-");
            encodeURL = Regex.Replace(encodeURL, @"-+", "-");
            encodeURL = encodeURL.Trim('-');
            return encodeURL;

        }
    }
}