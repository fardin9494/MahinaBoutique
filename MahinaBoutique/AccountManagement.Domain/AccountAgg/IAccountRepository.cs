using _0_SelfBuildFramwork.Domain;
using AccountManagement.Application.Contract.Account;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository:IRepository<long,Account>
    {
        EditAccount GetDetails(long id);

        Account GetWithUserName(string Username);

        List<AccountViewModel> Search(AccountSearchModel search);

        List<AccountViewModel> GetAccount();
    }
}
