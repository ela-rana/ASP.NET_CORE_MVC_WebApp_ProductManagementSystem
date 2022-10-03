using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        [Required]
        [Display(Name="Product Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [MaxLength(50,ErrorMessage ="Maximum number of characters for this field is 50")]
        public string? Name { get; set; }

        [MaxLength(2000, ErrorMessage = "Maximum number of characters for this field is 2000")]
        public string? Description { get; set; }

        [DataType(DataType.Currency,ErrorMessage ="Price must be an integer or decimal number value")]
        public double Price { get; set; }

        [Display(Name = "Product Image")]
        public string? Image { get; set; }
    }

}
