using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Models
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string SongName { get; set; }

        public double Duration { get; set; }

        public int NumberOfListens { get; set; }

        [ForeignKey(nameof(Album))]
        public int? AlbumID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}\n" +
                   $"Song's name: {SongName}\n" +
                   $"Duration: {Duration}\n" +
                   $"Total number of listenings: {NumberOfListens}";
        }
    }
}
