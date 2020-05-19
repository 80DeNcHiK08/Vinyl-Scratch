using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VinylScratch.Models;

namespace VinylScratch.Interfaces
{
    public interface IMusicManager
    {
        void Init(Action<bool> IsPlaying, Action<double> GetSongPos, Action<int> GetQueuePos, Action<IList<Track>> GetQueue);
        Task SetQueue(IList<Track> tracks);
        void StartQueue(IList<Track> tracks, int pos);
        void Start(int pos);
        void Play();
        void Pause();
        void Next();
        void Prev();
        void Shuffle();
        void Seek(double position);
        void ClearQueue();
        void AddToEndOfQueue(IList<Track> tracks);
        void PlayNext(Track track);
    }
}
