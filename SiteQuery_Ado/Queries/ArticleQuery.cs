using Base_Framework.Domain.General;
using Microsoft.Data.SqlClient;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using System.Data;
using Base_Framework.Domain.General;

namespace SiteQuery_Ado.Queries
{
    public class ArticleQuery : IArticleQuery
    {

        private readonly string _connectionString;

        public ArticleQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ArticleQueryModel> GetArticleDetails(string slug, CancellationToken cancellationToken)
        {
            var article = new ArticleQueryModel();
            string keywords = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetArticleBySlug", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@slug", SqlDbType.NVarChar));
                    command.Parameters["@slug"].Value = slug;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            article.Id = reader.GetInt64(reader.GetOrdinal("ar.Id"));
                            article.Title= reader.GetString(reader.GetOrdinal("ar.Title"));
                            article.CategoryName = reader.GetString(reader.GetOrdinal("ar.CategoryName"));
                            article.CategorySlug = reader.GetString(reader.GetOrdinal("ar.CategorySlug"));
                            article.Slug = reader.GetString(reader.GetOrdinal("ar.Slug"));
                            article.CanonicalAddress = reader.GetString(reader.GetOrdinal("ar.CanonicalAddress"));
                            article.Description = reader.GetString(reader.GetOrdinal("ar.Description"));
                            keywords = reader.GetString(reader.GetOrdinal("ar.Keywords"));
                            article.MetaDescription= reader.GetString(reader.GetOrdinal("ar.MetaDescription"));
                            article.Picture = reader.GetString(reader.GetOrdinal("ar.Picture"));
                            article.PictureTitle = reader.GetString(reader.GetOrdinal("ar.PictureTitle"));
                            article.PictureAlt = reader.GetString(reader.GetOrdinal("ar.PictureAlt"));
                            article.PublishDate = reader.GetDateTime(reader.GetOrdinal("ar.PublishDate")).ToFarsi();
                            article.ShortDescription= reader.GetString(reader.GetOrdinal("ar.ShortDescription"));
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(keywords))
                article.KeywordList = keywords.Split(",").ToList();

            article.Comments = await GetCommentsByArticleId(article.Id, cancellationToken);

            return article;
        }

        public async Task<List<ArticleQueryModel>> LatestArticles(CancellationToken cancellationToken)
        {
            var Articles = new List<ArticleQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("LatestArticles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var article = new ArticleQueryModel();

                            article.Id = reader.GetInt64(reader.GetOrdinal("ar.Id"));
                            article.Title = reader.GetString(reader.GetOrdinal("ar.Title"));                          
                            article.Slug = reader.GetString(reader.GetOrdinal("ar.Slug"));                          
                            article.Picture = reader.GetString(reader.GetOrdinal("ar.Picture"));
                            article.PictureTitle = reader.GetString(reader.GetOrdinal("ar.PictureTitle"));
                            article.PictureAlt = reader.GetString(reader.GetOrdinal("ar.PictureAlt"));
                            article.ShortDescription = reader.GetString(reader.GetOrdinal("ar.ShortDescription"));
                            article.PublishDate = reader.GetDateTime(reader.GetOrdinal("ar.PublishDate")).ToFarsi();

                            Articles.Add(article);
                        }
                    }
                }
            }

            return Articles;
        }

        private async Task<List<CommentQueryModel>> GetCommentsByArticleId(long articleId, CancellationToken cancellationToken)
        {
            var Comments = new List<CommentQueryModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCommentsByArticleId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@articleId", SqlDbType.NVarChar));
                    command.Parameters["@articleId"].Value = articleId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var comment = new CommentQueryModel();

                            comment.Id = reader.GetInt64(reader.GetOrdinal("c.Id"));
                            comment.Name = reader.GetString(reader.GetOrdinal("c.Name"));
                            comment.Message = reader.GetString(reader.GetOrdinal("c.Message"));
                            comment.CreationDate = reader.GetDateTime(reader.GetOrdinal("c.CreationDate")).ToFarsi();
                            comment.Name = reader.GetString(reader.GetOrdinal("c.Name"));

                            if (!Convert.IsDBNull(reader["c.ParentId"]))
                            {
                                comment.ParentId = reader.GetInt64(reader.GetOrdinal("c.ParentId"));
                                comment.parentName = await GetCommentNameById(comment.Id, cancellationToken);
                            }
                               


                            Comments.Add(comment);
                        }
                    }
                }
            }

            return Comments;
        }

        private async Task<string> GetCommentNameById(long id, CancellationToken cancellationToken)
        {
            var name = "";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCommentNameById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar));
                    command.Parameters["@id"].Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(reader.GetOrdinal("c.Name"));
                        }
                    }
                }
            }
            return name;
        }
    }
}
