using _0_FrameWork.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader,
            IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository= articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation=new OperationResult();
            if(_articleRepository.Exist(x=>x.Title==command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug=command.Slug.Slugify();
            var articleCategorySlug=_articleCategoryRepository.GetSlugBy(command.CategoryId);
            var fileName=_fileUploader.Upload(command.Picture,$"{articleCategorySlug}/{slug}");
            var publishDate=command.PublishDate.ToGeorgianDateTime();

            var article = new Article(command.Title, command.ShortDescription, command.Description, publishDate,
               fileName, command.PictureAlt,command.PictureTitle,command.MetaDescription,command.KeyWords,
               slug,command.CanonicalAddress,command.CategoryId);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.Successed();

        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article=_articleRepository.GetWithCategory(command.Id);

            if(article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_articleRepository.Exist(x => x.Title == command.Title && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            var slug = command.Slug.Slugify();
            var fileName = _fileUploader.Upload(command.Picture, $"{article.Category.Slug}/{slug}");
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            article.Edit(command.Title, command.ShortDescription, command.Description, publishDate,
               fileName, command.PictureAlt, command.PictureTitle, command.MetaDescription, command.KeyWords,
               slug, command.CanonicalAddress, command.CategoryId);

            _articleRepository.SaveChanges();
            return operation.Successed();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
