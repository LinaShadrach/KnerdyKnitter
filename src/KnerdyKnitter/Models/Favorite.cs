﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnerdyKnitter.Models
{
    [Table("Favorites")]

    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public int GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
        public int KnitterId { get; set; }
        public virtual Knitter Knitter { get; set; }
    }
}
