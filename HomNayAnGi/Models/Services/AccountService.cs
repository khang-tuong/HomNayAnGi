using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomNayAnGi.Models.Entities;

namespace HomNayAnGi.Models.Services
{
    public interface IAccountService
    {
        int GetAccountId(string userId);
    }

    public class AccountService : BaseService, IAccountService
    {
        public int GetAccountId(string userId)
        {
            Account account = this.Repository.SingleOrDefault<Account>(q => q.userId == userId);
            return account == null ? 0 : account.id;
        }
    }
}