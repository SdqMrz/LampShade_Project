using _0_FrameWork.Application;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var Operation = new OperationResult();

            if(_productPictureRepository.Exist(x=>x.Picture==command.Picture && x.ProductId==command.ProductId))
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);

            var productPicture=new ProductPicture(command.ProductId,command.Picture,command.PictureAlt,command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return Operation.Successed();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation=new OperationResult();
            var productPicture = _productPictureRepository.Get(command.Id);

            if(productPicture== null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);

            productPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
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
