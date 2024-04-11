using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
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
        void Create(CreateProductPictureDTO command);
        void Edit(EditProductPictureDTO command);
        void Remove(long id);
        void Restore(long id);
        DetailProductPictureDTO GetDetails(long id);
        List<ProductPictureDTO> Search(SearchProductPictureDTO searchModel);
    }
}
