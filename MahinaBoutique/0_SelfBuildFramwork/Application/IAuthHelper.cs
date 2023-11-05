using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_SelfBuildFramwork.Application
{
    public interface IAuthHelper
    {
        bool IsAuthenticated();

        string AuthenticatedName();

        void SignIn(AuthViewModel account);

        void SignOut();

        string AuthenticatedRole();

        long AuthenticatedAccountId();
    }
}
