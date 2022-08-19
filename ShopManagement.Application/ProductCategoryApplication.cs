using System;
using System.Collections.Generic;
using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operationResult = new OperationResult();

            if (_productCategoryRepository.Exist(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var fileName = _fileUploader.Upload(command.Picture, command.Slug);

            var productCategory = new ProductCategory(command.Name, command.Description, fileName,
                command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operationResult.Successed();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var fileName = _fileUploader.Upload(command.Picture, command.Slug);

            productCategory.Edit(command.Name, command.Description, fileName,
                command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDescription, slug);

            _productCategoryRepository.SaveChanges();

            return operationResult.Successed();

        }

        public EditProductCategory GetByDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }
    }
}
