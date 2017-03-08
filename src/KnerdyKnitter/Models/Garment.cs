using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace KnerdyKnitter.Models
{
    [Table("Garments")]
    public class Garment
    {
        [Key]
        public int Id { get; set; }
        public int RowDim { get; set; }
        public int ColDim { get; set; }
        public string Rule { get; set; }
        public DateTime CreationDate { get; set; }
        [NotMapped]
        public bool[][] Creation { get; set; }
        public int KnitterId { get; set; }
        public virtual Knitter Knitter { get; set; }
        public virtual List<Color> Colors { get; set; }
        public virtual List<Alter> Alters { get; set; }
        public virtual List<GarmentTag> GarmentTags { get; set; }
        public virtual List<Favorite> Favorites { get; set; }
        public virtual List<Comment> Comments { get; set; }

        KnerdyKnitterContext db = new KnerdyKnitterContext();
        public Garment()
        {
            RowDim = 100;
            ColDim = 20;
            Rule = "00011110";
            CreationDate = DateTime.Now;
            Creation = new bool [100][];
            Colors = new List<Color>() { };
            Alters = new List<Alter>() { };
        }
        public void MakeGarment(bool[] currentRow, int dimension)
        {
            if (dimension > 0)
            {
                bool[] nextRow = GetNextRow(currentRow);
                Creation[(RowDim - dimension)] = nextRow;
                MakeGarment((nextRow), dimension - 1);
            }
        }
        public bool[] GetNextRow(bool[] currentRow)
        {
            bool[] nextRow = new bool[currentRow.Length];
            for (var i = 0; i < currentRow.Length; i++)
            {
                var key = "";
                if (i == 0)
                {
                    key = key + currentRow[currentRow.Length - 1];
                }
                else
                {

                    key = key + currentRow[i - 1];
                }
                key = key + currentRow[i];
                if (i == (currentRow.Length - 1))
                {
                    key = key + currentRow[0];
                }
                else
                {
                    key = key + currentRow[i + 1];
                }
                var keyIndex = Array.IndexOf(Rules.BaseCombos, key);
                char[] charRule = Rule.ToCharArray();
                
                if (charRule[keyIndex]=='1')
                {
                    nextRow[i] = true;
                }
                if(charRule[keyIndex]=='0')
                {
                    nextRow[i] = false;
                }

            }
            return nextRow;
        }
        public Garment Save(Garment garment)
        {
            db.Garments.Add(garment);
            db.SaveChanges();
            return garment;
        }
        public Garment Edit(Garment garment)
        {
            db.Entry(garment).State = EntityState.Modified;
            db.SaveChanges();
            return garment;
        }
        public void Remove(Garment garment)
        {
            db.Garments.Remove(garment);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.RemoveRange(db.Garments);
            db.SaveChanges();
        }

    }
}
