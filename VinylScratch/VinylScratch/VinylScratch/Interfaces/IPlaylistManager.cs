using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.Models;

namespace VinylScratch.Interfaces
{
    public interface IPlaylistManager
    {
        Task AddToPlaylist(Playlist playlist, Track song);
        Playlist CreatePlaylist(string name);
        IList<Playlist> GetPlaylists();
        Task<IList<Track>> GetPlaylistTracks(ulong playlistId);
        Task<IList<Track>> GetAllTracks();
    }
}
