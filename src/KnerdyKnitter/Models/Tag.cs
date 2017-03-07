using Microsoft.EntityFrameworkCore;
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

        KnerdyKnitterContext db = new KnerdyKnitterContext();

        public Tag Save(Tag garment)
        {
            db.Tags.Add(garment);
            db.SaveChanges();
            return garment;
        }
        public Tag Edit(Tag garment)
        {
            db.Entry(garment).State = EntityState.Modified;
            db.SaveChanges();
            return garment;
        }
        public void Remove(Tag garment)
        {
            db.Tags.Remove(garment);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.RemoveRange(db.Tags);
            db.SaveChanges();
        }
    }
}
