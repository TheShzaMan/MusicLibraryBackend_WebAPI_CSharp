using Microsoft.EntityFrameworkCore;
using MusicLibrary_WebAPI.Models;

namespace MusicLibrary_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
    
    
