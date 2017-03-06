using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("GarmentTags")]
    public class GarmentTag
    {
        [Key]
        public int Id { get; set; }
        public int GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
    }
}
