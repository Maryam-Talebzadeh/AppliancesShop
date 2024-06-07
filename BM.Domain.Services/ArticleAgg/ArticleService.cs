using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleAgg.DTOs;
using BM.Domain.Core.ArticleAgg.Services;
using BM.Domain.Core.ArticleAgg.Data;
using BM.Domain.Core.ArticleCategoryAgg.Data;

namespace BM.Domain.Services.ArticleAgg
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleService(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
           _fileUploader = fileUploader;
        }

        public async Task<OperationResult> Create(CreateArticleDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            if ( _articleRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = await _articleCategoryRepository.GetSlugBy(command.CategoryId, cancellationToken);
            var path = $"{categorySlug}/{slug}";
            command.PictureName = _fileUploader.Upload(command.Picture, path);

           await _articleRepository.Create(command, cancellationToken);
            _articleRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditArticleDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (!_articleRepository.IsExist(x => x.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = await _articleCategoryRepository.GetSlugBy(command.CategoryId, cancellationToken);
            var path = $"{categorySlug}/{slug}";
            command.PictureName = _fileUploader.Upload(command.Picture, path);

            await _articleRepository.Edit(command, cancellationToken);
            _articleRepository.Save();
            return operation.Succedded();
        }


        public async Task<EditArticleDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _articleRepository.GetDetails(id, cancellationToken);
        }

        public async Task<List<ArticleDTO>> Search(SearchArticleDTO searchModel, CancellationToken cancellationToken)
        {
            return await _articleRepository.Search(searchModel, cancellationToken);
        }
    }
}
