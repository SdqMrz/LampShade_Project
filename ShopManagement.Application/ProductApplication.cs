using System.Collections.Generic;
using System.Text;
using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }


        public OperationResult Create(CreateProduct command)
        {
            var opertion = new OperationResult();
            if (_productRepository.Exist(x => x.Name == command.Name))
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = _productCategoryRepository.GetSlugBy(command.CategoryId);
            var filePath = $"{categorySlug}/{slug}";
            var fileName = _fileUploader.Upload(command.Picture, filePath);

            var product = new Product(command.Name, command.Code, command.ShortDescription, command.Description,
                                      fileName, command.PictureTitle, command.PictureAlt,
                                       command.KeyWords, command.MetaDescription, slug, command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return opertion.Successed();
        }

        public OperationResult Edit(EditProduct command)
        {
            var opertion = new OperationResult();
            var product = _productRepository.GetWithCategory(command.Id);

            if (product == null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exist(x => x.Name == command.Name && x.Id == command.Id))
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var categorySlug = product.Category.Slug;
            var filePath =new StringBuilder();
             filePath.Append(categorySlug);
            filePath.Append('\x200E');
            filePath.Append('/');
            filePath.Append(slug);
            filePath.Append('\x200E');
            filePath.Append('/');

            var fileName = _fileUploader.Upload(command.Picture,filePath.ToString());

            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
               fileName, command.PictureTitle, command.PictureAlt,
                command.KeyWords, command.MetaDescription, slug, command.CategoryId);

            _productRepository.SaveChanges();
            return opertion.Successed();

        }

        public EditProduct GetByDetails(long id)
        {
            return _productRepository.GetByDetails(id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }
    }
}
