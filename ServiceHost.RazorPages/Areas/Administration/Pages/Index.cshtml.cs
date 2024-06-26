using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteQuery_EfCore.Contracts;
using SiteQuery_EfCore.Models;

namespace ServiceHost.RazorPages.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> ProductNames { get; set; }
        public List<string> ArticleCategoryNames { get; set; }
        public List<ChartQueryModel> BarDataSet { get; set; }
        public List<ChartQueryModel> LineDataSet { get; set; }
        public int Accounts { get; set; }
        public int Articles;
        public int Products;

        private readonly IChartQuery _ChartQuery;

        public IndexModel(IChartQuery ChartQuery)
        {
            _ChartQuery = ChartQuery;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            ProductNames = await _ChartQuery.GetAllProductNames(cancellationToken);
            ArticleCategoryNames = await _ChartQuery.GetAllArticleCategoryName(cancellationToken);
          Products = await _ChartQuery.GetNumberOfProducts(cancellationToken);
            Articles = await _ChartQuery.GetNumberOfArticles(cancellationToken);
            Accounts = await _ChartQuery.GetNumberOfRegisteredAccounts(cancellationToken);

            BarDataSet = new List<ChartQueryModel>
            {
                new ChartQueryModel
                {
                    Label = "Articles",
                    Data = await _ChartQuery.GetArticleCounts(cancellationToken),
                    BackgroundColor = new[] {"#ffcdb2"},
                    BorderColor = "#b5838d"
                }
            };

            LineDataSet = new List<ChartQueryModel>
            {
                new ChartQueryModel
                {
                    Label = "Registered acoounts",
                    Data = await _ChartQuery.GetNumberOfRegisteredAccountsByMonth(cancellationToken),
                    BackgroundColor = new[] {"#ffcdb2"},
                    BorderColor = "#b5838d"
                }
            };
           
        }
    }

}
