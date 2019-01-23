using FestivalManager.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FestivalManager.Entities.Sets
{
    public abstract class Set : ISet
    {
        private readonly List<IPerformer> performers;
        private readonly List<ISong> songs;

        public Set(string name, TimeSpan duration)
        {
            this.Name = name;
            this.MaxDuration = duration;

            this.performers = new List<IPerformer>();
            this.songs = new List<ISong>();
        }

        public string Name { get; }

        public TimeSpan MaxDuration { get; }

        public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public bool CanPerform()
        {
            if (!this.Performers.Any())
            {
                return false;
            }

            if (!this.Songs.Any())
            {
                return false;
            }

            var allPerformersHaveInstruments = this.Performers.All(p => p.Instruments.Any());

            if (!allPerformersHaveInstruments)
            {
                return false;
            }

            var allPerformersHaveFunctioningInstruments = this.performers.All(p => p.Instruments.Any(i => !i.IsBroken));

            if (!allPerformersHaveFunctioningInstruments)
            {
                return false;
            }

            return true;
        }
    }
}
