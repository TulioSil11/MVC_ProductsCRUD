using System.Collections.ObjectModel;


namespace IntermediateModels.DtoS
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            Products = new Collection<ProductDto>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}
