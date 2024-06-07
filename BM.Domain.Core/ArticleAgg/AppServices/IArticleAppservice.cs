using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Domain.Core.ArticleAgg.AppServices
{
    public interface IArticleAppService
    {
        Task<OperationResult> Create(CreateArticleDTO command, CancellationToken cancellationToken);
        Task<OperationResult> Edit(EditArticleDTO command, CancellationToken cancellationToken);
        Task<EditArticleDTO> GetDetails(long id, CancellationToken cancellationToken);
        Task<List<ArticleDTO>> Search(SearchArticleDTO searchModel, CancellationToken cancellationToken);
    }
}
