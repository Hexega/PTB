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
            TabPage page = tempAccountPage.tabControl.TabPages[0];

            tabControl.TabPages.Add(page);

            tabControl.Visible = true;
            tabControl.Enabled = true;

            GameController gameController = new GameController(account, page);


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
