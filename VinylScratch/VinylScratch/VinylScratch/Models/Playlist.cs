using System;
using System.Collections.Generic;
using System.Text;

namespace VinylScratch.Models
{
    public class Playlist
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public IList<Track> Tracks { get; set; }
        public bool IsDynamic { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool HasImage { get { return Image != null && !String.IsNullOrEmpty(Image.ToString()); } }
        public object Image { get; set; }
    }
}
