using Microsoft.AspNetCore.Http;

namespace Base_Framework.Domain.Services
{
    public class FileHandler
    {
        public static void SaveImage(string filePath, IFormFile picture)
        {
           

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
