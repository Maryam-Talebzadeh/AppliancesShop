using Microsoft.Data.SqlClient;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using System.Data;

namespace SiteQuery_Ado.Queries
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {

        private readonly string _connectionString;

        public ArticleCategoryQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ArticleCategoryQueryModel>> GetArticleCategories(CancellationToken cancellationToken)
        {
            var Categories = new List<ArticleCategoryQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetArticleCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new ArticleCategoryQueryModel();

                            category.Name = reader.GetString(reader.GetOrdinal("c.Name"));
                            category.Slug = reader.GetString(reader.GetOrdinal("c.Slug"));
                            category.Picture = reader.GetString(reader.GetOrdinal("c.Picture"));
                            category.PictureTitle = reader.GetString(reader.GetOrdinal("c.PictureTitle"));
                            category.PictureAlt = reader.GetString(reader.GetOrdinal("c.PictureAlt"));
                            category.ArticlesCount = reader.GetInt32(reader.GetOrdinal("c.ArticlesCount"));

                            Categories.Add(category);
                        }
                    }
                }
                
            }

            return Categories;
        }
        public Task<ArticleCategoryQueryModel> GetArticleCategory(string slug, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
