using IntermediateModels.DtoS;
using IntermediateModels.Models;

namespace IntermediateModels.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        ProductDto GetProductById(int? IdProduct);
        void PostProduct(ProductDto product);
        void PutProduct(int id, ProductDto product);
        void DeleteProduct(int IdProduct);    
    }
}
