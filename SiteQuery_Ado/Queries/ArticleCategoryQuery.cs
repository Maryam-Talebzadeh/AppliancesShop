using Base_Framework.Domain.General;
using Microsoft.Data.SqlClient;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using System.Data;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

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
        public async Task<ArticleCategoryQueryModel> GetArticleCategory(string slug, CancellationToken cancellationToken)
        {
            ArticleCategoryQueryModel category = new ArticleCategoryQueryModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetArticleCategoryBySlug", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            category.Name = reader.GetString(reader.GetOrdinal("c.Name"));
                            category.Slug = reader.GetString(reader.GetOrdinal("c.Slug"));
                            category.Picture = reader.GetString(reader.GetOrdinal("c.Picture"));
                            category.PictureTitle = reader.GetString(reader.GetOrdinal("c.PictureTitle"));
                            category.PictureAlt = reader.GetString(reader.GetOrdinal("c.PictureAlt"));
                            category.ArticlesCount = reader.GetInt32(reader.GetOrdinal("c.ArticlesCount"));
                            category.Description = reader.GetString(reader.GetOrdinal("c.Description"));
                            category.MetaDescription = reader.GetString(reader.GetOrdinal("c.MetaDescription"));
                            category.Keywords = reader.GetString(reader.GetOrdinal("c.Keywords"));
                            category.CanonicalAddress = reader.GetString(reader.GetOrdinal("c.CanonicalAddress"));

                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(category.Keywords))
                    category.KeywordList = category.Keywords.Split(",").ToList();

                category.Articles = await GetArticleByCategorySlug(category.Slug, cancellationToken);

            }

            return category;
        }

        private async Task<List<ArticleQueryModel>> GetArticleByCategorySlug(string categorySlug, CancellationToken cancellationToken)
        {
            var Articles = new List<ArticleQueryModel>();
            string keywords = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetArticleBySlug", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@categorySlug", SqlDbType.NVarChar));
                    command.Parameters["@categorySlug"].Value = categorySlug;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var article = new ArticleQueryModel();
                            article.Id = reader.GetInt64(reader.GetOrdinal("ar.Id"));
                            article.Title = reader.GetString(reader.GetOrdinal("ar.Title"));
                            article.CategoryName = reader.GetString(reader.GetOrdinal("ar.CategoryName"));
                            article.CategorySlug = reader.GetString(reader.GetOrdinal("ar.CategorySlug"));
                            article.Slug = reader.GetString(reader.GetOrdinal("ar.Slug"));
                            article.CanonicalAddress = reader.GetString(reader.GetOrdinal("ar.CanonicalAddress"));
                            article.Description = reader.GetString(reader.GetOrdinal("ar.Description"));
                            keywords = reader.GetString(reader.GetOrdinal("ar.Keywords"));
                            article.MetaDescription = reader.GetString(reader.GetOrdinal("ar.MetaDescription"));
                            article.Picture = reader.GetString(reader.GetOrdinal("ar.Picture"));
                            article.PictureTitle = reader.GetString(reader.GetOrdinal("ar.PictureTitle"));
                            article.PictureAlt = reader.GetString(reader.GetOrdinal("ar.PictureAlt"));
                            article.PublishDate = reader.GetDateTime(reader.GetOrdinal("ar.PublishDate")).ToFarsi();
                            article.ShortDescription = reader.GetString(reader.GetOrdinal("ar.ShortDescription"));

                            if (!string.IsNullOrWhiteSpace(keywords))
                                article.KeywordList = keywords.Split(",").ToList();

                            Articles.Add(article);
                        }
                    }
                }
            }

           

            return Articles;
        }
    }
}
