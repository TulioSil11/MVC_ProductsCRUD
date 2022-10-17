using AutoMapper;
using IntermediateModels.DtoS;
using IntermediateModels.Models;
using IntermediateModels.Services.Interfaces;
using IntermediateModels.UnitOfWork.Interfaces;
using IntermediateModels.Validations;
using System.Linq;

namespace IntermediateModels.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.Get();

            if (products is null)
            {
                throw new Exception("There are no product records in the database. " +
                        "Register new products so them can be displayed.");
            }

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProductById(int? IdProduct)
        {
            var productIdNotInformed = IdProduct <= 0;
            if (productIdNotInformed)
                throw new Exception("The idProduct field is null or empty. Enter this field and try again.");

            var product = _unitOfWork.ProductRepository.GetById(product => product.ProductId == IdProduct);

            if (product is null)
                throw new Exception("No products found with this id.");

            return _mapper.Map<ProductDto>(product);
        }

        public void PostProduct(ProductDto product)
        {
            ProductValidation.ProductIsValid(product, _unitOfWork);

            _unitOfWork.ProductRepository.Post(_mapper.Map<Product>(product));
            _unitOfWork.Commit();
        }

        public void PutProduct(int id, ProductDto product)
        {
            if (id != product.ProductId) throw new Exception("Id is invalid.");

            ProductValidation.ProductIsValid(product, _unitOfWork);

            _unitOfWork.ProductRepository.Put(_mapper.Map<Product>(product));
            _unitOfWork.Commit();
        }

        public void DeleteProduct(int IdProduct)
        {
            if (IdProduct <= 0)
                throw new Exception("The idProduct field is null or empty. " +
                                    "Enter this field and try again.");

            var existProducts = _unitOfWork.ProductRepository.Get();
            if (existProducts is null)
                throw new Exception("Entity set 'AppDbContext.Products'  is null.");

            _unitOfWork.ProductRepository.Delete(IdProduct);
            _unitOfWork.Commit();
        }
    }
}
