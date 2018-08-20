using System;
using System.ComponentModel.DataAnnotations;

namespace BookTradingClub.Models
{
    public class Trade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProposerId { get; set; }

        [Required]
        public int ProposerBookId { get; set; }

        [Required]
        public int RecipientId { get; set; }

        [Required]
        public int RecipientBookId { get; set; }

        [Required]
        public DateTime OfferDate { get; set; }
    }
}
