using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository,
            IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var Operation = new OperationResult();

            //if(_productPictureRepository.Exist(x=>x.Picture==command.Picture && x.ProductId==command.ProductId))
            //    return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            var product=_productRepository.GetWithCategory(command.ProductId);
            var filePath = new StringBuilder();
            filePath.Append(product.Category.Slug);
            filePath.Append('\x200E');
            filePath.Append('/');
            filePath.Append(product.Slug);
            filePath.Append('\x200E');
            filePath.Append('/');
            var fileName = _fileUploader.Upload(command.Picture, filePath.ToString());
            var productPicture =new ProductPicture(command.ProductId, fileName, command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return Operation.Successed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation=new OperationResult();
            var productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);

            if(productPicture== null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var filePath = new StringBuilder();
            filePath.Append(productPicture.Product.Category.Slug);
            filePath.Append('\x200E');
            filePath.Append('/');
            filePath.Append(productPicture.Product.Slug);
            filePath.Append('\x200E');
            filePath.Append('/');
            var fileName=_fileUploader.Upload(command.Picture,filePath.ToString());
            productPicture.Edit(command.ProductId, fileName, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.Successed();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
           
            productPicture.Remove(id);
            _productPictureRepository.SaveChanges();
            return operation.Successed();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(id);

            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore(id);
            _productPictureRepository.SaveChanges();
            return operation.Successed();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
