using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Follows")]
    public class Follow
    {
        [Key]
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public virtual Knitter Follower { get; set; }
        public int FollowingId { get; set; }
        public virtual Knitter Following { get; set; }
    }
}
