using System.ComponentModel.DataAnnotations;

namespace BookTradingClub.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [MaxLength(256), Required]
        public string Title { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [MaxLength(256), Required]
        public string Author { get; set; }
    }
}
