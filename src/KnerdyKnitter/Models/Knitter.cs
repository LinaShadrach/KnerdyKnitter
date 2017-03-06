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
        public virtual List<Garment> Garments { get; set; }
        public virtual List<Color> Colors { get; set; }
        public virtual List<Comment> ReceivedComments { get; set; }
        public virtual List<Comment> SentComments { get; set; }
        public virtual List<GarmentTag> GarmentTag { get; set; }
        public virtual List<Follow> Followers { get; set; }
        public virtual List<Follow> Followings { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
