
using IntermediateModels.DtoS;
using IntermediateModels.Models;

namespace IntermediateModels.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategory();
        CategoryDto GetCategoryById(int? IdCategory);
        void PostCategory(CategoryDto category);
        void PutCategory(int id, CategoryDto category);
        void DeleteCategory(int IdCategory);
    }
}
