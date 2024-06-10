using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Services;
using BM.Domain.Core.ArticleCategoryAgg.Data;
using BM.Domain.Core.ArticleCategoryAgg.DTOs;
using BM.Domain.Core.ArticleCategoryAgg.Services;

namespace BM.Domain.Services.ArticleCategoryAgg
{
    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryService(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public async Task<OperationResult> Create(CreateArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.IsExist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"ArticleCategories/{slug}";
            command.PictureName = _fileUploader.Upload(command.Picture, path);

           await _articleCategoryRepository.Create(command, cancellationToken);
            _articleCategoryRepository.Save();
            return operation.Succedded();
        }

        public async Task<OperationResult> Edit(EditArticleCategoryDTO command, CancellationToken cancellationToken)
        {
            var operation = new OperationResult();

            if (!_articleCategoryRepository.IsExist(x => x.Id == command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleCategoryRepository.IsExist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
           command.PictureName = _fileUploader.Upload(command.Picture, slug);;

           await _articleCategoryRepository.Edit(command, cancellationToken);
            _articleCategoryRepository.Save();
            return operation.Succedded();
        }

        public async Task<List<ArticleCategoryDTO>> GetArticleCategories(CancellationToken cancellationToken)
        {
            return await _articleCategoryRepository.GetArticleCategories(cancellationToken);
        }

        public async Task<EditArticleCategoryDTO> GetDetails(long id, CancellationToken cancellationToken)
        {
            return await _articleCategoryRepository.GetDetails(id, cancellationToken);
        }

        public async Task<List<ArticleCategoryDTO>> Search(SearchArticleCategoryDTO searchModel, CancellationToken cancellationToken)
        {
            return await _articleCategoryRepository.Search(searchModel, cancellationToken);
        }
    }
}
