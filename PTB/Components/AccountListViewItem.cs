using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Models.ComponentModels
{
    public class AccountListViewItem : ListViewItem
    {
        public AccountListViewItem(Account account)
        {
            Account = account;

            this.Text = account.AccountName;
            this.SubItems.Add(account.Server);
        }

        public Account Account { get; set; }
    }
}
