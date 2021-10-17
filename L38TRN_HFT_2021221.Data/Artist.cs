using System;
using System.ComponentModel.DataAnnotations;

namespace L38TRN_HFT_2021221.Data
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
    }
}
