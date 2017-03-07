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
        KnerdyKnitterContext db = new KnerdyKnitterContext();

        public Color(string hex, string type, int garmentId, int knitterId)
        {
            Name = "";
            Hex = hex;
            Type = type;
            GarmentId = garmentId;
            KnitterId = knitterId;
        }
        public Color Save(Color color)
        {
            db.Colors.Add(color);
            db.SaveChanges();
            return color;
        }
    }
}
