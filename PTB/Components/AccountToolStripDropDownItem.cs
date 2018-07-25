using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTB.Models.ComponentModels
{
    public class AccountToolStripDropDownItem : ToolStripMenuItem
    {
        public AccountToolStripDropDownItem(Account account) 
        {
            Account = account;

            this.Text = account.AccountName;
        }

        public Account Account { get; set; }
    }
}
