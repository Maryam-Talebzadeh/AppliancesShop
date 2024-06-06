using Microsoft.AspNetCore.Http;

namespace Base_Framework.Domain.Core.Contracts
{
    public interface IFileUploader
    {
        string Upload(IFormFile file, string path);
    }
}
