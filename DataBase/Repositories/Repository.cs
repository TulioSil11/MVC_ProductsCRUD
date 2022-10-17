using Microsoft.EntityFrameworkCore;
using IntermediateModels.Infra.DataBase;
using IntermediateModels.Repositories.Interfaces;
using System.Linq.Expressions;

namespace IntermediateModels.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext m_Context = null;
        DbSet<T> m_DbSet;

        public Repository(AppDbContext context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }


        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate = null)
        {
            IEnumerable<T> products = null;
            try
            {
                products =  predicate is not null ? await m_DbSet.Where(predicate).ToListAsync() :
                                     await m_DbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return products;
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            T product = null;
            try
            {
                product =  m_DbSet.FirstOrDefault(predicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return product;            
        }

        public void Post(T entity)
        {
            try
            {
                m_DbSet.Add(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void Put(T entity)
        {
            try
            {
                m_DbSet.Update(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public async Task Delete(int id)
        {
            try
            {
                var product = await m_DbSet.FindAsync(id);
                if (product is not null)
                {
                    m_DbSet.Remove(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
