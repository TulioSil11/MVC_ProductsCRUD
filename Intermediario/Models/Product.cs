using System.ComponentModel.DataAnnotations.Schema;

namespace IntermediateModels.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
