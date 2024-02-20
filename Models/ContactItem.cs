using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
	public class ContactItem
	{
        public long Id { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 10 characters.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 10 characters.")]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{7,}$", ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }
    }
}

