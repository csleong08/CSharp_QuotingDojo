using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quotes
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string quote { get; set; }
    }
}