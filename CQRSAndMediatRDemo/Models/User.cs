using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSAndMediatRDemo.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="sai định dạng *@gmail.com")]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
       public bool Locked { get; set; }

        public string Avatar { get; set; }

        public Role Role { get; set; }

        [Required] public DateTime CreatedAt { get; set; }

        [Required] public DateTime UpdateAt { get; set; }
    }
}
