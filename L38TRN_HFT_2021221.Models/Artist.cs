using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L38TRN_HFT_2021221.Models
{
    [Table("Artists")]
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string Nationality { get; set; }
        [NotMapped]
        public virtual ICollection<Song> Songs { get; set; }
        [NotMapped]
        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Songs = new HashSet<Song>();
            Albums = new HashSet<Album>();
        }
    }
}
