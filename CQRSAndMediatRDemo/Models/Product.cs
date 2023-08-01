using System.ComponentModel.DataAnnotations;

namespace CQRSAndMediatRDemo.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required (AllowEmptyStrings =false, ErrorMessage ="Please enter the name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter the price!")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
