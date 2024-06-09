﻿using AM.Domain.Core.RoleAgg.DTOs;
using Base_Framework.Domain.Services;

namespace AM.Domain.Core.RoleAgg.AppServices
{
    public interface IRoleAppService
    {
        Task<OperationResult> Create(CreateRoleDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditRoleDTO command, CancellationToken cancellationToken);
        Task<EditRoleDTO> GetDetails(int id, CancellationToken cancellationToken);
        Task<List<RoleDTO>> GetAll(CancellationToken cancellationToken);
    }
}
