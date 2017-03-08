using Microsoft.EntityFrameworkCore;
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
        KnerdyKnitterContext db = new KnerdyKnitterContext();

        public Alter(string color, string coors, int garmentId)
        {
            string pattern = @"\d+";
            string[] coorsArr = coors.Split('-');
            var match = Regex.Match(coorsArr[0], pattern).ToString();
            XCor = Convert.ToInt32(match);
            YCor = Convert.ToInt32(coorsArr[1]);
            Color = color;
            GarmentId = garmentId;
        }
        public Alter Save(Alter alter)
        {
            db.Alters.Add(alter);
            db.SaveChanges();
            return alter;
        }
        public Alter Edit(Alter alter)
        {
            db.Entry(alter).State = EntityState.Modified;
            db.SaveChanges();
            return alter;
        }
        public void Remove(Alter alter)
        {
            db.Alters.Remove(alter);
            db.SaveChanges();
        }
    }
}
