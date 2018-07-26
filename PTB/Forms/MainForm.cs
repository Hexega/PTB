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
using HtmlAgilityPack;
using PTB.Utilities;
using PTB.Controllers;

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

            GameController gameController = new GameController(account, webBrowser);

            

            var result = client.Get("/login.php");

            var html = result.Content.ReadAsStringAsync().Result;

            var ftHiddenField = htmlReader.Find(html, "//input[@name='ft']");
            var ft = ftHiddenField.Attributes.FirstOrDefault(x => x.Name == "value").Value;

            var loginHiddenField = htmlReader.Find(html, "//input[@name='login']");
            var login = loginHiddenField.Attributes.FirstOrDefault(x => x.Name == "value").Value;

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ft", ft), // get from html
                new KeyValuePair<string, string>("user", account.AccountName),
                new KeyValuePair<string, string>("pw", account.Password),
                new KeyValuePair<string, string>("s1", "login"),
                new KeyValuePair<string, string>("w", "1920:1080"),
                new KeyValuePair<string, string>("login", login), // get from html
            });

            result = client.Post("/login.php", content);

            html = result.Content.ReadAsStringAsync().Result;

            DisplayHtml(html, webBrowser);

            bool b = false;
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
