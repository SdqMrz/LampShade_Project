using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository,IPasswordHasher passwordHasher
            ,IFileUploader fileUploader,IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation=new OperationResult();
            var account=_accountRepository.Get(command.Id);
            if (account==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordNotMatch);

            var password=_passwordHasher.Hash(command.Password);
            account.ChangePassword(password);

            _accountRepository.SaveChanges();

            return operation.Successed();
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation=new OperationResult();
            if(_accountRepository.Exist(x=>x.UserName == command.UserName || x.Mobile==command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var path = $"profilephoto";
            var fileName = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.FullName, command.UserName, password, command.Mobile,command.RoleId, fileName);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();

            return operation.Successed();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);

            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exist(x => (x.UserName == command.UserName || x.Mobile == command.Mobile) && x.Id==command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"profilephoto";
            var fileName = _fileUploader.Upload(command.ProfilePhoto, path);
            var password = _passwordHasher.Hash(command.Password);
            account.Edit(command.FullName, command.UserName, command.Mobile, command.RoleId, fileName);

            _accountRepository.SaveChanges();

            return operation.Successed();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public OperationResult Login(Login command)
        {
            var operation=new OperationResult();
            var account = _accountRepository.GetBy(command.UserName);

            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);

            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var authViewModel = new AuthViewModel(account.Id, account.RoleId, account.FullName, command.UserName, account.Mobile);

            _authHelper.SignIn(authViewModel);
            return operation.Successed();
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }
    }
}
