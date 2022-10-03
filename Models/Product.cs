using System.ComponentModel.DataAnnotations;

namespace ProductManagementSystem.Models
{
    public class Product
    {
        [Required]
        [Range(1, 2147483647,ErrorMessage = "Product ID value must be within 1 to 2147483647")]
        [Display(Name="Product ID")]
        public int ID { get; set; }

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
