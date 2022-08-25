using _0_FrameWork.Domain;
using BlogManagement.Application.Contract.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
        EditArticleCategory GetDetails(long id);
        string GetSlugBy(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
