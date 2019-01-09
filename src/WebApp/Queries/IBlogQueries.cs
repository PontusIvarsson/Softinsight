using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Dapper;

namespace WebApp.Queries
{
    public interface IBlogQueries
    {
        Task<IEnumerable<BlogSearchResult>> GetBlogsContainingTag(string tagtext);
    }

    public class BlogQueries : IBlogQueries
    {
        private string _connectionString;

        public BlogQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<IEnumerable<BlogSearchResult>> GetBlogsContainingTag(string tagtext)
        {
            IEnumerable<BlogSearchResult> result;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<BlogSearchResult>("SELECT b.Id BlogId, b.name as BlogName, i.Id as InsightId, ht.Value as Hashtag from Hashtag as ht" +
                                                " LEFT JOIN Insight i on i.Id = ht.InsightId" +
                                                " LEFT JOIN blog b on b.id = i.BlogId" +
                                                " WHERE ht.value like @tagtext",
                                                new { tagtext = "%" + tagtext + "%" });
            }

        }
    }
}
