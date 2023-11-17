using _0_SelfBuildFramwork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Application
{
    public class AccontApplication : IAccountApplication
    {
        
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccontApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public OperationResult ChangePassword(ChangeAccountPassword command)
        {
            var operation = new OperationResult();
            var selectedAccount = _accountRepository.GetBy(command.Id);
            if(selectedAccount == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }
            
            if(command.Password != command.RePassword)
            {
                return operation.Failed(ApplicationMessages.NotMatchPassword);
            }

            var password = _passwordHasher.Hash(command.Password);
            selectedAccount.ChangePasword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Create(CreateAccount command)
        {
            var operation = new OperationResult();
            if(_accountRepository.IsExist(x => x.UserName == command.UserName))
            {
                return operation.Failed(ApplicationMessages.ExistUserName);
            }
            if(_accountRepository.IsExist(x => x.Mobile == command.Mobile))
            {
                return operation.Failed(ApplicationMessages.ExistMobile);
            }
            var password = _passwordHasher.Hash(command.Password);
            var photo = _fileUploader.Upload(command.ProfilePhoto,command.FullName,BaseFolderForUpload.ProfilePhoto);
            var account = new Account(command.FullName,command.UserName,command.RoleId,command.Mobile,password,photo);
            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var selectedAccount = _accountRepository.GetBy(command.Id);
            if(selectedAccount == null)
            {
                return operation.Failed(ApplicationMessages.NullRecordMessage);
            }

            if(_accountRepository.IsExist(x => x.UserName == command.UserName && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.ExistUserName);
            }

            if(_accountRepository.IsExist(x => x.Mobile == command.Mobile && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.ExistMobile);
            }
           
            var photo = _fileUploader.Upload(command.ProfilePhoto,command.FullName,BaseFolderForUpload.ProfilePhoto);
            selectedAccount.Edit(command.FullName,command.UserName,command.RoleId,command.Mobile,photo);
            _accountRepository.SaveChanges();
            return operation.Succedded();

        }

        public List<AccountViewModel> GetAccount()
        {
            return _accountRepository.GetAccount();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(LoginModel command)
        {
            var operation = new OperationResult();
            var User = _accountRepository.GetWithUserName(command.UserName);
            if(User == null)
            {
                return operation.Failed(ApplicationMessages.UserNotFound);
            }
            (bool Verified, bool NeedsUpgrade) Result = _passwordHasher.Check(User.Password,command.Password);
            
            if (!Result.Verified)
            {
                return operation.Failed(ApplicationMessages.WrongPassword);
            }

            var Role = _roleRepository.GetBy(User.RoleId);
            
           var permission =  Role.Permissions.Select(x => x.Code).ToList();

            var authmodel = new AuthViewModel(User.Id ,User.FullName ,User.UserName ,User.RoleId, permission);
            _authHelper.SignIn(authmodel);
            return operation.Succedded();


        }

        public void LogOut()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel search)
        {
           return _accountRepository.Search(search);
        }
    }
}
