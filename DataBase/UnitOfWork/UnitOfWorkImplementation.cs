using IntermediateModels.Infra.DataBase;
using IntermediateModels.Models;
using IntermediateModels.Repositories;
using IntermediateModels.Repositories.Interfaces;
using IntermediateModels.UnitOfWork.Interfaces;

namespace IntermediateModels.UnitOfWork
{
    public class UnitOfWorkImplementation : IUnitOfWork
    {
        private readonly AppDbContext _contexto = null;
        private IProductRepository _productRepository = null;
        private IRepository<Category> _categoryRepository = null; 
        public UnitOfWorkImplementation(AppDbContext contexto, 
                                        IProductRepository productRepository)
        {
            _contexto = contexto;
            _productRepository = productRepository;
            _categoryRepository = new Repository<Category>(_contexto);
        }


        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository;
            }
        }

        public IRepository<Category> CategoryRepostory
        {
            get
            {
                return _categoryRepository;
            }
        }
    }
}
