using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiosTask.Model
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PostCode { get; set; }
    }
}
