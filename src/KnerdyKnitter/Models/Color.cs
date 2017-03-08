using Microsoft.EntityFrameworkCore;
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
        KnerdyKnitterContext db = new KnerdyKnitterContext();
        public Color() { }

        public Color(string hex, string type, int garmentId, int knitterId)
        {
            Name = "";
            Hex = hex;
            Type = type;
            GarmentId = garmentId;
        }
        public Color Save(Color color)
        {
            db.Colors.Add(color);
            db.SaveChanges();
            return color;
        }
        public Color Edit(Color color)
        {
            db.Entry(color).State = EntityState.Modified;
            db.SaveChanges();
            return color;
        }
        public void Remove(Color color)
        {
            db.Colors.Remove(color);
            db.SaveChanges();
        }
    }
}
