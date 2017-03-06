using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    public class Knitter
    {
        public int Id { get; set; }
        public DateTime SignUpDate { get; set; }
        public virtual List<Garment> Garments { get; set; }

    }
}
