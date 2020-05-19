using System;
using System.Collections.Generic;
using System.Text;
using VinylScratch.Models;

namespace VinylScratch.Helpers
{
    public class TrackComparer : IEqualityComparer<Track>
    {
        public bool Equals(Track t1, Track t2)
        {
            return t1.Id == t2.Id && (bool)t1.Uri?.Equals(t2.Uri);
        }

        public int GetHashCode(Track t1)
        {
            return (int)t1.Id;
        }
    }
}
