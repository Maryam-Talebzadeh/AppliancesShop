using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_Framework.Domain.Services
{
    public class NameGenarator
    {
        public static string GenerateUniqeCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
