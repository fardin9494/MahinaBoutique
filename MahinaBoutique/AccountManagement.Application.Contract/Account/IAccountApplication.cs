using _0_SelfBuildFramwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);

        OperationResult Edit(EditAccount command);

        void LogOut();

        OperationResult Login(LoginModel command);

        OperationResult ChangePassword(ChangeAccountPassword command);

        List<AccountViewModel> GetAccount();

        EditAccount GetDetails(long id);

        List<AccountViewModel> Search(AccountSearchModel search);

        (string Name, string mobile) GetAccountInfo(long id);
    }
}
