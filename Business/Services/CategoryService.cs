using IntermediateModels.Services.Interfaces;
using IntermediateModels.Models;
using IntermediateModels.UnitOfWork.Interfaces;
using IntermediateModels.Validations;
using IntermediateModels.DtoS;
using AutoMapper;

namespace IntermediateModels.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategory()
        {
            var categories = await _unitOfWork.CategoryRepostory.Get();

            if (categories is null)
            {
                throw new Exception("There are no categories records in the database. " +
                        "Register new categories so you can be displayed.");
            }

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategoryById(int? IdCategory)
        {
            var categoryIdNotInformed = IdCategory <= 0;
            if (categoryIdNotInformed)
                throw new Exception("The idCategory field is null or empty. Enter this field and try again.");

            var category = _unitOfWork.CategoryRepostory.GetById(category => category.CategoryId == IdCategory);

            if (category is null)
                throw new Exception("No categories found with this id.");

            return _mapper.Map<CategoryDto>(category);
        }

        public void PostCategory(CategoryDto category)
        {
            ProductValidation.CategoryIsValid(category);

            _unitOfWork.CategoryRepostory.Post(_mapper.Map<Category>(category));
            _unitOfWork.Commit();
        }

        public void PutCategory(int id, CategoryDto category)
        {
            if (id != category.CategoryId) throw new Exception("Id is invalid.");

            ProductValidation.CategoryIsValid(category);

            _unitOfWork.CategoryRepostory.Put(_mapper.Map<Category>(category));
            _unitOfWork.Commit();
        }

        public void DeleteCategory(int IdCategory)
        {
            if (IdCategory <= 0)
                throw new Exception("The IdCategory field is null or empty. " +
                                    "Enter this field and try again.");

            var existCategories = _unitOfWork.CategoryRepostory.Get();
            if (existCategories is null)
                throw new Exception("Entity set 'AppDbContext.Category'  is null.");

            _unitOfWork.CategoryRepostory.Delete(IdCategory);
            _unitOfWork.Commit();
        }
    }
}
