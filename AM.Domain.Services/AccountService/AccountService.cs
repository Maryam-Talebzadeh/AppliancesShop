using AM.Domain.Core.AccountAgg.Data;
using AM.Domain.Core.AccountAgg.DTOs;
using AM.Domain.Core.AccountAgg.Services;
using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;

namespace AM.Domain.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
        }

        public async Task<OperationResult> ChangePassword(ChangePasswordDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (!_accountRepository.IsExist(a => a.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            await _accountRepository.ChangePassword(command, cancellationToken);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditAccountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (!_accountRepository.IsExist(a => a.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.IsExist(x =>
                (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"profilePhotos";
            command.ProfileName = _fileUploader.Upload(command.ProfilePhoto, path);
           await _accountRepository.Edit(command, cancellationToken);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public async Task<AccountDTO> GetAccountBy(long id, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetBy(id, cancellationToken);
        }

        public async Task<List<AccountDTO>> GetAccounts(CancellationToken cancellationToken)
        {
            return await _accountRepository.GetAccounts(cancellationToken);
        }

        public async Task<AccountDTO> GetBy(string username, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetBy(username, cancellationToken);
        }

        public async Task<EditAccountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _accountRepository.GetDetails(id, cancellationToken);
        }

        public async Task<OperationResult> Login(LoginAccountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            var account = await _accountRepository.GetBy(command.Username, cancellationToken);

            if (account == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            return operation.Succedded();
        }

        public async Task<OperationResult> Register(RegisterAccountDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (_accountRepository.IsExist(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            command.Password = _passwordHasher.Hash(command.Password);
            string path = "";

            if(command.ProfilePhoto != null)
            {
                path = $"ProfilePhotos";
                command.ProfileName = _fileUploader.Upload(command.ProfilePhoto, path);
            }
            else
            {
                command.ProfileName = "DefaultAvatar.jpg";
            }
           
          await  _accountRepository.Create(command, cancellationToken);
            _accountRepository.Save();
            return operation.Succedded();
        }

        public async Task<List<AccountDTO>> Search(SearchAccountDTO searchModel, CancellationToken cancellationToken)
        {
            return await _accountRepository.Search(searchModel, cancellationToken);
        }
    }
}
