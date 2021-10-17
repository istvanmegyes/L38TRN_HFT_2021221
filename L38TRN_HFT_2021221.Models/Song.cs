using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Data
{
    [Table("Songs")]
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        public string SongName { get; set; }
        [ForeignKey(nameof(Artist))]
        public Artist ArtistName { get; set; }
        [ForeignKey(nameof(Album))]
        public Album AlbumName { get; set; }
        public int Duration { get; set; }

    }
}
