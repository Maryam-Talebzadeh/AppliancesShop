using AM.Domain.Core.AccountAgg.DTOs;
using AM.Domain.Core.AccountAgg.Entities;
using AM.Domain.Core.Data;
using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Base_Framework.Domain.General;

namespace AM.Infrastructure.DataAccess.Repos.EFCore.AccountAgg
{
    public class AccountRepository : BaseRepository_EFCore<Account>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangePassword(ChangePasswordDTO changePasswordDTO, CancellationToken cancellationToken)
        {
           var account = Get(changePasswordDTO.Id);
            account.ChangePassword(changePasswordDTO.Password);
        }

        public async Task Create(RegisterAccountDTO registerAccountDTO, CancellationToken cancellationToken)
        {
            var account = new Account(registerAccountDTO.Fullname, registerAccountDTO.Username, registerAccountDTO.Password, registerAccountDTO.Mobile, registerAccountDTO.RoleId, registerAccountDTO.ProfileName);
            _context.Accounts.Add(account);
        }

        public async Task Edit(EditAccountDTO editAccountDTO, CancellationToken cancellationToken)
        {
            var account = Get(editAccountDTO.Id);
            account.Edit(editAccountDTO.Fullname, editAccountDTO.Username, editAccountDTO.Mobile, editAccountDTO.RoleId, editAccountDTO.ProfileName);
        }

        public async Task<List<AccountDTO>> GetAccounts(CancellationToken cancellationToken)
        {
            return _context.Accounts.Select(x => new AccountDTO
            {
                Id = x.Id,
                Fullname = x.Fullname
            }).ToList();
        }

        public async Task<AccountDTO> GetBy(string username, CancellationToken cancellationToken)
        {
            return _context.Accounts.Select(x => new AccountDTO
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Username == username);
        }

        public async Task<EditAccountDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.Accounts.Select(x => new EditAccountDTO
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<AccountDTO>> Search(SearchAccountDTO searchModel, CancellationToken cancellationToken)
        {
            var query = _context.Accounts.Select(x => new AccountDTO
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                RoleId = x.RoleId,
                Username = x.Username,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
