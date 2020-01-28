using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl
{
    public class UrlBuilder
    {
        public Dictionary<string, string> urlData = new Dictionary<string, string>();
        int index = 0;


        // Encodes a URL to a shortened URL.
        public string encode(string longUrl)
        {
            urlData.Add(index.ToString(), longUrl);
            index++;

            return (index - 1).ToString();
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            return urlData[shortUrl];
        }
    }
}
