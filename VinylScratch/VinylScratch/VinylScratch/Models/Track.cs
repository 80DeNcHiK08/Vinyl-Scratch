using System;
using System.Collections.Generic;
using System.Text;

namespace VinylScratch.Models
{
    public class Track
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public bool HasImage { get { return Image != null && !String.IsNullOrEmpty(Image.ToString()); } }
        public object Image { get; set; }
        public double Duration { get; set; }
        public string Uri { get; set; }

        public Track() { }
        public Track(Track othTrack)
        {
            Id = othTrack.Id;
            Title = othTrack.Title;
            Artist = othTrack.Artist;
            Album = othTrack.Album;
            Genre = othTrack.Genre;
            Image = othTrack.Image;
            Duration = othTrack.Duration;
            Uri = othTrack.Uri;
        }
    }
}
