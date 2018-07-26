using PTB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Utilities
{
    public class CustomHttpClient
    {
        public CookieContainer CookieContainer { get; set; }
        public HttpClientHandler Handler { get; set; }
        public HttpClient Client { get; set; }
        public Account account { get; set; }
        public string Referer { get; set; }

        // Constructor
        public CustomHttpClient(Account account)
        {
            // Set local variables
            this.account = account;
            Referer = "";
            CookieContainer = new CookieContainer();
            Handler = new HttpClientHandler() { CookieContainer = CookieContainer };
            Client = new HttpClient(Handler) { BaseAddress = new Uri(account.Server) };

            // Emulate chrome browsing.
            Client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            Client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            Client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36");

            // Add some default cookies
            CookieContainer.Add(new Uri(account.Server), new Cookie("tt_lang", "en"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("tt_mlang", "en"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("highlightsToggle", "false"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("c_name", "0|Win32|Windows%20NT%2010.0|1920px*1080px|amd64|-%2C-%2C-"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("chatmaninwindowtab", "0"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("chatmainwindow", "minimized"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("WMBlueprints", "%5B%5D"));
            CookieContainer.Add(new Uri(account.Server), new Cookie("tt_lang", "en"));


        }

        public HttpResponseMessage Get(string path)
        {
            Client.DefaultRequestHeaders.Remove("Referer");
            Client.DefaultRequestHeaders.Add("Referer", Referer);
            // Execute get request
            HttpResponseMessage result = Client.GetAsync(path).Result;
            result.EnsureSuccessStatusCode();

            // Set new cookies if recieved any
            IEnumerable<string> stringCookies;
            result.Headers.TryGetValues("Set-Cookie", out stringCookies);

            // fill cookie container with new to set cookies.
            foreach (string cookie in stringCookies)
            {
                CookieContainer.SetCookies(new Uri(account.Server), cookie);
            }

            Referer = account.Server + path;

            // return result
            return result;
        }

        public HttpResponseMessage Post(string path, FormUrlEncodedContent content)
        {
            Client.DefaultRequestHeaders.Remove("Referer");
            Client.DefaultRequestHeaders.Add("Referer", Referer);
            // Execute get request
            HttpResponseMessage result = Client.PostAsync(path, content).Result;
            result.EnsureSuccessStatusCode();

            // Set new cookies if recieved any
            IEnumerable<string> stringCookies;
            result.Headers.TryGetValues("Set-Cookie", out stringCookies);

            // fill cookie container with new to set cookies.
            foreach (string cookie in stringCookies)
            {
                CookieContainer.SetCookies(new Uri(account.Server), cookie);
            }

            // return result
            return result;
        }
    }
}
