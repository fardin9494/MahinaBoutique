using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastracture.EfCore.Repositories
{
    public class AccountRepository : BaseRepository<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                FullName = x.FullName,
                Id = x.Id,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel search)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel{
                FullName = x.FullName,
                Id = x.Id,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                UserName = x.UserName,
                Role = x.Role.Name,
                RoleId = x.RoleId,
                CreationDate = x.CreationDate.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(search.FullName))
            {
                query = query.Where(x => x.FullName.Contains(search.FullName));
            }

            if (!string.IsNullOrWhiteSpace(search.UserName))
            {
                query = query.Where(x => x.UserName.Contains(search.UserName));
            }

            if (!string.IsNullOrWhiteSpace(search.Mobile))
            {
                query = query.Where(x => x.Mobile.Contains(search.Mobile));
            }

            if (search.RoleId > 0)
            {
                query = query.Where(x => x.RoleId == search.RoleId);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
