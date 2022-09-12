using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        ArticleQueryModel GetArticleWithDetails(string slug);
        List<ArticleQueryModel> GetLatesArticles();
    }
}
