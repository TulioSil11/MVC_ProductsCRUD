using System.ComponentModel.DataAnnotations.Schema;

namespace IntermediateModels.DtoS
{
    public class ProductDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
