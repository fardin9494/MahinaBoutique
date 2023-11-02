using _0_SelfBuildFramwork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class AccontApplication : IAccountApplication
    {
        
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;

        public AccontApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
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

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel search)
        {
           return _accountRepository.Search(search);
        }
    }
}
