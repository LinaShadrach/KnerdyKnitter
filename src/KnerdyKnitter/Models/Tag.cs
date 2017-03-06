using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<GarmentTag> GarmentTags { get; set; }
    }
}
