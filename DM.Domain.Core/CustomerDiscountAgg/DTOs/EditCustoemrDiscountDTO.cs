using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Domain.Core.CustomerDiscountAgg.DTOs
{
    public class EditCustomerDiscountDTO: DefineCustomerDiscountDTO
    {
        public long Id { get; set; }
    }
}
