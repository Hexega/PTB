using PTB.Context;
using PTB.Models;
using PTB.Models.ComponentModels;
using PTB.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Forms
{
    public partial class AccountsForm : Form
    {
        AccountService accountService;
        List<Account> accounts;
        MainForm main;

        public AccountsForm(MainForm main)
        {
            InitializeComponent();

            accountService = new AccountService();

            accounts = accountService.GetAll();

            foreach (Account account in accounts)
            {
                lvAccounts.Items.Add(new AccountListViewItem(account));
            }

            this.main = main;
        }

        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count == 1)
            {
                AccountListViewItem alvi = (AccountListViewItem)lvAccounts.SelectedItems[0];

                txtAccountName.Text = alvi.Account.AccountName;
                txtPassword.Text = alvi.Account.Password;
                txtServer.Text = alvi.Account.Server;
                switch (alvi.Account.Tribe)
                {
                    case TribeType.Gaul:
                        rbGauls.Checked = true;
                        rbRomans.Checked = false;
                        rbTeutons.Checked = false;
                        break;
                    case TribeType.Roman:
                        rbGauls.Checked = false;
                        rbRomans.Checked = true;
                        rbTeutons.Checked = false;
                        break;
                    case TribeType.Teutons:
                        rbGauls.Checked = false;
                        rbRomans.Checked = false;
                        rbTeutons.Checked = true;
                        break;
                }
            }
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            txtAccountName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtServer.Text = string.Empty;
            rbGauls.Checked = false;
            rbRomans.Checked = false;
            rbTeutons.Checked = false;
        }

        private void btnSaveAccount_Click(object sender, EventArgs e) {

            if (!rbTeutons.Checked && !rbRomans.Checked && !rbGauls.Checked)
            {
                MessageBox.Show("Please select a tribe.");
                return;
            }

            if(txtAccountName.Text.Length < 1 || txtPassword.Text.Length < 1 || txtServer.Text.Length < 1)
            {
                MessageBox.Show("Please insert valid information for the bot to work.");
                return;
            }

            Account account = new Account();

            account.AccountName = txtAccountName.Text;
            account.Server = txtServer.Text;
            account.Password = txtPassword.Text;

            if (rbTeutons.Checked) { account.Tribe = TribeType.Teutons; }
            if (rbRomans.Checked) { account.Tribe = TribeType.Roman; }
            if (rbGauls.Checked) { account.Tribe = TribeType.Gaul; }

            accountService.Save(account);

            lvAccounts.Items.Add(new AccountListViewItem(account));

            main.UpdateAccounts();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count == 1)
            {
                AccountListViewItem alvi = (AccountListViewItem)lvAccounts.SelectedItems[0];

                DialogResult dialogResult = MessageBox.Show("Are you sure?", "Deletion", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    accountService.Delete(alvi.Account);
                    lvAccounts.Items.Remove(alvi);

                    txtAccountName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtServer.Text = string.Empty;
                }
            }
        }
    }
}
