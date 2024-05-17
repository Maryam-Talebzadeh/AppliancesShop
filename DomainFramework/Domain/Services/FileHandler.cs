using Microsoft.AspNetCore.Http;

namespace Base_Framework.Domain.Services
{
    public class FileHandler
    {
        public static void SaveImage(string filePath, IFormFile picture)
        {
            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                picture.CopyTo(stream);
            }
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
