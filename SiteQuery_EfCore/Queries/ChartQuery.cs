using AM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using BM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using SiteQuery_EfCore.Contracts;
using SM.Infrastructure.DB.SqlServer.EFCore.Contexts;
using System.Globalization;

namespace SiteQuery_EfCore.Queries
{
    public class ChartQuery : IChartQuery
    {
        private readonly ShopContext _shopContext;
        private readonly BlogContext _blogContext;
        private readonly AccountContext _accountContext;

        public ChartQuery(ShopContext shopContext, BlogContext blogContext, AccountContext accountContext)
        {
            _shopContext = shopContext;
            _blogContext = blogContext;
            _accountContext = accountContext;
        }

        public async Task<List<string>> GetAllArticleCategoryName(CancellationToken cancellationToken)
        {
           return _blogContext.ArticleCategories.Select(x => x.Name).ToList();
        }

        public async Task<List<string>> GetAllProductNames(CancellationToken cancellationToken)
        {
            return _shopContext.Products.Select(x => x.Name).ToList();
        }

        public async Task<List<int>> GetArticleCounts(CancellationToken cancellationToken)
        {
            var counts = new List<int>();
            var categories = await GetAllArticleCategoryName(cancellationToken);

            foreach(var  category in categories)
            {
                var count = _blogContext.Articles.Count(x => x.Category.Name == category);
                counts.Add(count);
            }

            return counts;
        }

        public async Task<int> GetNumberOfArticles(CancellationToken cancellationToken)
        {
           return _blogContext.Articles.Count();
        }

        public async Task<int> GetNumberOfProducts(CancellationToken cancellationToken)
        {
            return _shopContext.Products.Count();
        }

        public async Task<int> GetNumberOfRegisteredAccounts(CancellationToken cancellationToken)
        {
            return _accountContext.Accounts.Count();
        }

        public async Task<List<int>> GetNumberOfRegisteredAccountsByMonth(CancellationToken cancellationToken)
        {
            var persianCalendar = new PersianCalendar();
            var counts = new List<int>();

            for (int i = 1; i < 13; i++)
            {
                var count = _accountContext.Accounts.ToList()
    .Count(x => persianCalendar.GetMonth(x.CreationDate) == i);
                counts.Add(count);
            }

            return counts;
        }

    }
}
