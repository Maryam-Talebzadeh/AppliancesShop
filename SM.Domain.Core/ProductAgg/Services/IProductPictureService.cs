using Base_Framework.Domain.Services;
using SM.Domain.Core.ProductAgg.DTOs.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Domain.Core.ProductAgg.Services
{
    public interface IProductPictureService
    {
        OperationResult Create(CreateProductPictureDTO command);
        OperationResult Edit(EditProductPictureDTO command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        EditProductPictureDTO GetDetails(long id);
        List<ProductPictureDTO> Search(SearchProductPictureDTO searchModel);
    }
}
