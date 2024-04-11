using Base_Framework.Domain.Core.Contracts;
using SM.Domain.Core.ProductAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.Data
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {

    }
}
