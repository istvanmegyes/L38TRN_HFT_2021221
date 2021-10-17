using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Data
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        public string SongName { get; set; }
        public Artist ArtistName { get; set; }
        public Album AlbumName { get; set; }
    }
}
