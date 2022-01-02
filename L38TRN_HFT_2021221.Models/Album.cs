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
    [Table("Albums")]
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }

        public int SoldAlbums { get; set; }

        [ForeignKey(nameof(Artist))]
        public int? ArtistID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Artist Artist { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
            Songs = new HashSet<Song>();
        }

        public override string ToString()
        {
            return $"ID: {ID}\n" +
                   $"Album title: {Title}\n" +
                   $"Genre: {Genre}\n" +
                   $"Price: {Price}\n" +
                   $"No. of albums sold: {SoldAlbums}";
        }
    }
}
