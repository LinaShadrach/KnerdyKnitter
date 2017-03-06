using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("SenderId")]
        public int SenderId { get; set; }
        public virtual Knitter Sender { get; set; }
        [ForeignKey("ReceiverId")]
        public int ReceiverId { get; set; }
        public virtual Knitter Receiver { get; set; }
        public string Body { get; set; }
        public int GarmentId { get; set; }
        public virtual Garment Garment { get; set; }

    }
}
