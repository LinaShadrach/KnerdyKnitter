using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    [Table("Alters")]
    public class Alter
    {
        [Key]
        public int Id { get; set; }
        public int XCor { get; set; }
        public int YCor { get; set; }
        public string Color { get; set; }
        public int GarmentId { get; set; }
        public virtual Garment Garment { get; set; }
        public Alter(string color, string coors)
        {
            string pattern = @"\d+";
            string[] coorsArr = coors.Split('-');
            XCor = Convert.ToInt32(Regex.Match(coorsArr[0], pattern));
            YCor = Convert.ToInt32(coorsArr[1]);
            Color = color;
        }
    }
}
