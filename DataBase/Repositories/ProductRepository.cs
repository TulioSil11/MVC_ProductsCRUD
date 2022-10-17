using IntermediateModels.Infra.DataBase;
using IntermediateModels.Models;
using IntermediateModels.Repositories.Interfaces;

namespace IntermediateModels.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext m_Context = null;
        public ProductRepository(AppDbContext context) : base(context)
        {
            m_Context = context;
        }

        public int GetPointsById(int idProduct)
        {
           return m_Context.Products.Where(product => product.ProductId == idProduct)
                              .FirstOrDefault().Points;

        }
    }
}
