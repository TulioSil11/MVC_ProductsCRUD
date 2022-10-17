using IntermediateModels.Models;
using IntermediateModels.Repositories.Interfaces;

namespace IntermediateModels.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRepository<Category> CategoryRepostory { get; }
        void Commit();
    }
}
