

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}
