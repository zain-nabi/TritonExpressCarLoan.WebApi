using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.Quote
{
    [Table("Quote")]
    public  class Quote
    {
        [Key]
        public int QuoteID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int UserID { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
