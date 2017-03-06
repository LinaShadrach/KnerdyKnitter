using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Knitters")]
    public class Knitter
    {
        [Key]
        public int Id { get; set; }
        public DateTime SignUpDate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual List<Garment> Garments { get; set; }
        public virtual List<Color> Colors { get; set; }
        public virtual List<Comment> ReceivedComments { get; set; }
        public virtual List<Comment> SentComments { get; set; }
        public virtual List<GarmentTag> GarmentTag { get; set; }
        public virtual List<Follow> Followers { get; set; }
        public virtual List<Follow> Followings { get; set; }
        public virtual List<Favorite> Favorites { get; set; }

        KnerdyKnitterContext db = new KnerdyKnitterContext();

        public Knitter Save(Knitter knitter)
        {
            db.Knitters.Add(knitter);
            db.SaveChanges();
            return knitter;
        }

        public Knitter Edit(Knitter knitter)
        {
            db.Entry(knitter).State = EntityState.Modified;
            db.SaveChanges();
            return knitter;
        }

        public void Remove(Knitter knitter)
        {
            db.Knitters.Remove(knitter);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.RemoveRange(db.Knitters);
            db.SaveChanges();
        }
    }
}

