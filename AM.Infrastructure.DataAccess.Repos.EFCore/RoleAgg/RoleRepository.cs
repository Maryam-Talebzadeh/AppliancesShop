using AM.Domain.Core.RoleAgg.Data;
using AM.Domain.Core.RoleAgg.DTOs;
using AM.Domain.Core.RoleAgg.Entities;
using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.Infrastructure.DataAccess;

namespace AM.Infrastructure.DataAccess.Repos.EFCore.RoleAgg
{
    public class RoleRepository : BaseRepository_EFCore<Role>, IRoleRepository
    {
        private readonly AccountContext _context;
        public RoleRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public async Task Create(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var role = new Role(command.Name, new List<Permission>());
            _context.Roles.Add(role);
        }

        public async Task Edit(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var role = Get(command.Id);
            role.Edit(command.Name, new List<Permission>());
        }

        public async Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Roles.Select(r =>
            new RoleDTO()
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }

        public async Task<EditRoleDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return _context.Roles.Select(r =>
           new EditRoleDTO()
           {
               Id = r.Id,
               Name = r.Name
           }).FirstOrDefault(r => r.Id == id);
        }
    }
}
