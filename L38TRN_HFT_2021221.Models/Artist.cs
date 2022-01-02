using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace L38TRN_HFT_2021221.Models
{
    [Table("Artists")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ArtistName { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }

        public int NumberOfAwards { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public override string ToString()
        {
            return $"ID: {ID}\n" +
                   $"Artist's name: {ArtistName}\n" +
                   $"Nationality: {Nationality}\n" +
                   $"Age: {Age}\n" +
                   $"Number of awards won: {NumberOfAwards}";
        }
    }
}
