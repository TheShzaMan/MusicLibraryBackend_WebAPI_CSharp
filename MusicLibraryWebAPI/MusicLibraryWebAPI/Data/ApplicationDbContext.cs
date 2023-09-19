using Microsoft.EntityFrameworkCore;
using MusicLibraryWebAPI.Model;

namespace MusicLibraryWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Song entity
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "Forever Young",
                    Artist = "Alphaville",
                    Album = "Forever Young",
                    ReleaseDate = 1984,
                    Genre = "New Wave"
                },
                new Song
                {
                    Id = 2,
                    Title = "Just Like Heaven",
                    Artist = "The Cure",
                    Album = "Kiss Me Kiss Me Kiss Me",
                    ReleaseDate = 1987,
                    Genre = "New Wave"
                },
                new Song
                {
                    Id = 3,
                    Title = "The Promise",
                    Artist = "When In Rome",
                    Album = "When In Rome",
                    ReleaseDate = 1988,
                    Genre = "New Wave"
                },
                new Song
                {
                    Id = 4,
                    Title = "Everybody Wants To Rule The World",
                    Artist = "Tears For Fears",
                    Album = "Songs From The Big Chair",
                    ReleaseDate = 1985,
                    Genre = "New Wave"
                },
                new Song
                {
                    Id = 5,
                    Title = "The Lovecats",
                    Artist = "The Cure",
                    Album = "Japanese Whispers",
                    ReleaseDate = 1983,
                    Genre = "New Wave"
                });
        }
    }
}
