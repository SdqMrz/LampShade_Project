using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public OperationResult Create(CreateProduct command)
        {
            var opertion = new OperationResult();
            if (_productRepository.Exist(x => x.Name == command.Name))
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var product = new Product(command.Name, command.Code, command.ShortDescription, command.Description,
                                      command.UnitPrice, command.Picture, command.PictureTitle, command.PictureAlt,
                                       command.KeyWords, command.MetaDescription, slug, command.CategoryId);

            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return opertion.Successed();
        }

        public OperationResult Edit(EditProduct command)
        {
            var opertion = new OperationResult();
            var product = _productRepository.Get(command.Id);

            if (product==null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exist(x => x.Name == command.Name && x.Id==command.Id))
                return opertion.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description,
                command.UnitPrice, command.Picture, command.PictureTitle, command.PictureAlt,
                command.KeyWords, command.MetaDescription, slug, command.CategoryId);

            _productRepository.SaveChanges();
            return opertion.Successed();

        }

        public OperationResult ExistInStock(long id)
        {
            var opertion = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);

            product.ExistInStock();
            _productRepository.SaveChanges();
            return opertion.Successed();
        }

        public OperationResult NotExistInStock(long id)
        {
            var opertion = new OperationResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return opertion.Failed(ApplicationMessages.RecordNotFound);

            product.NotExistInStock();
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
