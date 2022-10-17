using IntermediateModels.Models;

namespace IntermediateModels.Repositories.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        int GetPointsById(int idProduct);
    }
}
