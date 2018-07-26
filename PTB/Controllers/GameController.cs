using PTB.Models;
using PTB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Controllers
{
    public class GameController
    {
        public Account PlayerAccount { get; set; }
        public CustomHttpClient Client { get; set; }
        public HtmlReader HtmlReader { get; set; }
        public WebBrowser WebBrowser { get; set; }

        public GameController(Account account, WebBrowser webBrowser)
        {
            PlayerAccount = account;
            WebBrowser = webBrowser;

            Client = new CustomHttpClient(account);
            HtmlReader = new HtmlReader();
        }

        public bool Login()
        {
            var result = Client.Get("/login.php");

            var html = result.Content.ReadAsStringAsync().Result;

            var ftHiddenField = HtmlReader.Find(html, "//input[@name='ft']");
            var ft = ftHiddenField.Attributes.FirstOrDefault(x => x.Name == "value").Value;

            var loginHiddenField = HtmlReader.Find(html, "//input[@name='login']");
            var login = loginHiddenField.Attributes.FirstOrDefault(x => x.Name == "value").Value;

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ft", ft), // get from html
                new KeyValuePair<string, string>("user", PlayerAccount.AccountName),
                new KeyValuePair<string, string>("pw", PlayerAccount.Password),
                new KeyValuePair<string, string>("s1", "login"),
                new KeyValuePair<string, string>("w", "1920:1080"),
                new KeyValuePair<string, string>("login", login), // get from html
            });

            result = Client.Post("/login.php", content);

            html = result.Content.ReadAsStringAsync().Result;

            DisplayHtml(html, WebBrowser);

            return false;
        }

        public bool GetPlayerData()
        {


            return false;
        }

        public void DisplayHtml(string html, WebBrowser browser)
        {

            browser.Navigate("about:blank");

            if (browser.Document != null)

            {

                browser.Document.Write(string.Empty);

            }

            browser.DocumentText = html;
        }
    }
}
