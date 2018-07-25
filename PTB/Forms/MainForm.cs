using PTB.Components;
using PTB.Forms;
using PTB.Models;
using PTB.Models.ComponentModels;
using PTB.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB
{
    public partial class MainForm : Form
    {
        // Settings Forms
        private AccountsForm _accountsForm;
        public AccountsForm AccountsForm
        {
            get
            {
                if (_accountsForm == null || _accountsForm.IsDisposed)
                    _accountsForm = new AccountsForm(this);
                return _accountsForm;
            }
            set
            {
                _accountsForm = value;
            }
        }

        // Services
        AccountService accountService;

        // Variables
        List<Account> accounts;


        public MainForm()
        {
            InitializeComponent();

            // Forms init

            // Service init
            accountService = new AccountService();

            // variable init

            UpdateAccounts();
        }

        public void UpdateAccounts()
        {
            // Get all updated accounts
            accounts = accountService.GetAll();

            // Clear current menu
            tsmiStartAccount.DropDownItems.Clear();

            // Build new menu
            foreach(Account account in accounts)
            {
                AccountToolStripDropDownItem atsddi = new AccountToolStripDropDownItem(account);
                tsmiStartAccount.DropDownItems.Add(atsddi);
                atsddi.Click += StartAccountClick;
            }
        }

        private void StartAccountClick(object sender, EventArgs e)
        {
            Account account = ((AccountToolStripDropDownItem)sender).Account;

            TempAccountPage tempAccountPage = new TempAccountPage();
            WebBrowser webBrowser = (WebBrowser)tempAccountPage.tabControl.TabPages[0].Controls.Find("webBrowser", true)[0];
            webBrowser.ScriptErrorsSuppressed = true;

            tabControl.TabPages.Add(tempAccountPage.tabControl.TabPages[0]);

            tabControl.Visible = true;
            tabControl.Enabled = true;

            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            var client = new HttpClient(handler) { BaseAddress = new Uri(account.Server) };

            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36");

            cookieContainer.Add(new Uri(account.Server), new Cookie("tt_lang", "en"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("tt_mlang", "en"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("highlightsToggle", "false"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("c_name", "0|Win32|Windows%20NT%2010.0|1920px*1080px|amd64|-%2C-%2C-"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("chatmaninwindowtab", "0"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("chatmainwindow", "minimized"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("WMBlueprints", "%5B%5D"));
            cookieContainer.Add(new Uri(account.Server), new Cookie("tt_lang", "en"));

            var result = client.GetAsync("/login.php").Result;

            DisplayHtml(result.Content.ReadAsStringAsync().Result, webBrowser);
            
            result.EnsureSuccessStatusCode();

            IEnumerable<string> temp;
            result.Headers.TryGetValues("Set-Cookie", out temp);

            foreach(string cookie in temp)
            {
                if(cookie.Contains("path") || cookie.Contains("expires"))
                {


                } else
                {
                    string key = cookie.Substring(0, cookie.IndexOf('='));
                    string value = cookie.Substring(cookie.IndexOf('='),);

                    cookieContainer.Add(new Uri(account.Server), new Cookie());
                }
            }
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

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsForm.Show();
            AccountsForm.Focus();
        }


    }
}
