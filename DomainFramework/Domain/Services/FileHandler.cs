using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
