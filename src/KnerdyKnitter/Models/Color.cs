using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnerdyKnitter.Models
{
    [Table("Colors")]
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
        public string Type { get; set; }
        public int GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
        public int KnitterId { get; set; }
        public virtual Knitter Knitter { get; set; }
    }
}
