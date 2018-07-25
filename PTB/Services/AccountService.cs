using PTB.Context;
using PTB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTB.Services
{
    public class AccountService
    {
        DatabaseContext dbContext = new DatabaseContext();

        public List<Account> GetAll()
        {
            return dbContext.Accounts.ToList();
        }

        public Account Save(Account account)
        {
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();
            return account;
        }

        public void Delete(Account account)
        {
            dbContext.Accounts.Remove(account);
            dbContext.SaveChanges();
        }
    }
}
