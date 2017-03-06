using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Alters")]
    public class Alters
    {
        [Key]
        public int Id { get; set; }
        public int XCor { get; set; }
        public int YCor { get; set; }
        public string Color { get; set; }
        public int GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
    }
}
