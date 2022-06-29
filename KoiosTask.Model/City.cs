using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KoiosTask.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PostCode { get; set; }
    }
}
