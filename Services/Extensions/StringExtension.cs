using System;
using System.Text.RegularExpressions;

namespace YelpApiServer.Services.Extensions
{
	public static class StringExtension
	{
        public static string CleanCacheKey(this string uri) =>
            Regex.Replace((new Regex("[\\#%&*{}/:<>?|\"-]")).Replace(uri, " "), @"\s+", "-");
    }
}

