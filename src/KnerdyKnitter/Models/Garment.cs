using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Garments")]
    public class Garment
    {
        [Key]
        public int Id { get; set; }
        public int RowDim { get; set; }
        public int ColDim { get; set; }
        public string Rule { get; set; }
        public DateTime CreationDate { get; set; }
        [NotMapped]
        public bool[][] Creation { get; set; }
        public int KnitterId { get; set; }
        public virtual Knitter Knitter { get; set; }
        public virtual List<Color> Colors { get; set; }
        public virtual List<Alters> Alters { get; set; }
        public virtual List<GarmentTag> GarmentTags { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
        public virtual List<Comment> Comments { get; set; } 
    }
}
