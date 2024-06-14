using AM.Domain.Core.RoleAgg.Data;
using AM.Domain.Core.RoleAgg.DTOs;
using AM.Domain.Core.RoleAgg.Entities;
using AM.Domain.Core.RoleAgg.Services;
using Base_Framework.Domain.Services;

namespace AM.Domain.Services.RoleAgg
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly Type _type = new RoleDTO().GetType();

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            try
            {
                await _roleRepository.Create(command, cancellationToken);
                 _roleRepository.Save();
                return operation.Succedded();
            }
            catch
            {
                return operation.Failed(ApplicationMessages.CreationFailed);
            }
        }

        public async Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (! _roleRepository.IsExist(r => r.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if ( _roleRepository.IsExist(r => r.Name == command.Name && r.Id != command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);
          
            await _roleRepository.Edit(command, cancellationToken);
           _roleRepository.Save();

            return operation.Succedded();
        }

        public async Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _roleRepository.GetAll(cancellationToken);
        }

        public async Task<EditRoleDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetDetails(id, cancellationToken);
        }
    }
}
