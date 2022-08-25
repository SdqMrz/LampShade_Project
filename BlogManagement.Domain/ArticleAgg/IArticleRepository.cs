﻿using _0_FrameWork.Domain;
using BlogManagement.Application.Contract.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        EditArticle GetDetails(long id);
        Article GetWithCategory(long id);
        List<ArticleViewModel> Search(ArticleSearchModel searchModel);
    }
}
