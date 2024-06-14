using AM.Domain.Core.RoleAgg.Data;
using AM.Domain.Core.RoleAgg.DTOs;
using AM.Domain.Core.RoleAgg.Entities;
using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            var permissions = new List<Permission>();
            command.Permissions.ForEach(Code => permissions.Add(new Permission(Code)));
            var role = Get(command.Id);
            role.Edit(command.Name,permissions);
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
            var role = _context.Roles.Select(x => new EditRoleDTO
            {
                Id = x.Id,
                Name = x.Name,
                MappedPermissions = MapPermissions(x.Permissions)
            }).AsNoTracking()
                 .FirstOrDefault(x => x.Id == id);

            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            return role;
        }

        private static List<PermissionDto> MapPermissions(IEnumerable<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
        }

        public async Task<List<int>> GetPermissionsCodeBy(long roleId, CancellationToken cancellationToken)
        {
            var permissions = _context.Roles.Where(r => r.Id == roleId).Select(r => r.Permissions).AsNoTracking().FirstOrDefault();
            return permissions.Select(p => p.Code).ToList();
        }
    }
}
