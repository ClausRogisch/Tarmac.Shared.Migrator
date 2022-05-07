using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarmac.Shared.Migrator
{
    public class OldArtist
    {
        public int ID { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string ArtistDetail { get; set; }
        public string ArtistLink { get; set; }
        public DateTime PlayTime { get; set; }
        public int PlayDuration { get; set; }
        public int CollectiveID { get; set; }
        public int stageID { get; set; }
        public DateTime EntryDate { get; set; }
        public string Collective { get; set; }
        public string StageName { get; set; }
        public string ArtistImageURL { get; set; }
    }
}
