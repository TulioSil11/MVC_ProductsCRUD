using IntermediateModels.DtoS;
using IntermediateModels.Models;
using IntermediateModels.UnitOfWork.Interfaces;

namespace IntermediateModels.Validations
{
    public static class ProductValidation
    {
        public static void ProductIsValid (ProductDto product, IUnitOfWork _unitOfWork)
        {
            var nameOfProductEmpty = product.Name is null || 
                                     product.Name.Replace(" ", String.Empty).Length <= 0;
            if (nameOfProductEmpty)
                throw new Exception("The product name cannot be empty.");

            var pointEqualsZero = product.Points <= 0;
            if (pointEqualsZero)
                throw new Exception("A product must contain a quantity of points greater than zero.");

            var categoryEnpty = product.CategoryId <= 0;
            if (categoryEnpty)
                throw new Exception("A product must contain a category.");

            var categoryExist = _unitOfWork.CategoryRepostory.GetById(
                category => category.CategoryId == product.CategoryId);
            if (categoryExist is null)
                throw new Exception("The reported category does not exist.");

        }

        public static void CategoryIsValid(CategoryDto category)
        {
            var nameOfCategoryIsEmpty = category.Name is null ||
                                        category.Name.Replace(" ", String.Empty).Length <= 0;
            if (nameOfCategoryIsEmpty)
                throw new Exception("The category name cannot be empty.");
        }
    }
}
