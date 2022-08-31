using _0_FrameWork.Application;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleCateoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleCateoryApplication(IArticleCategoryRepository articleCategoryRepository,IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exist(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug=command.Slug.Slugify();
            var fileName=_fileUploader.Upload(command.Picture,slug);

            var articleCategory = new ArticleCategory(command.Name, fileName, command.Description, command.OrderShow,
                command.PictureAlt,command.PictureTitle,slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);

            if (articleCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_articleCategoryRepository.Exist(x => x.Name == command.Name && x.Id!=command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var fileName = _fileUploader.Upload(command.Picture, slug);

            articleCategory.Edit(command.Name, fileName, command.Description, command.OrderShow,
               command.PictureAlt, command.PictureTitle, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.SaveChanges();
            return operation.Successed();
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
