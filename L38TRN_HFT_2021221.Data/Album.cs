using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Data
{
    [Table("Albums")]
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        [ForeignKey(nameof(Artist))]
        public Artist ArtistName { get; set; }

        [NotMapped]
        public string AllData => $"";

        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
            Songs = new HashSet<Song>();
        }
    }
}
