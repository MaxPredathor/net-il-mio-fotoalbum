using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace net_il_mio_fotoalbum.Data
{
    public class PhotoAlbumContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public const string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=PhotoAlbum;Integrated Security=True;Pooling=False;TrustServerCertificate=True";
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Nature" },
                new Category { Id = 2, Name = "Urban" },
                new Category { Id = 3, Name = "Portrait" },
                new Category { Id = 4, Name = "Wildlife" },
                new Category { Id = 5, Name = "Abstract" }
            );

            modelBuilder.Entity<Photo>().HasData(
                new Photo { Id = 1, Title = "Sunset in the Mountains", Description = "A beautiful sunset over the mountain range.", Image = "https://media.istockphoto.com/id/1136834574/photo/watzmann-in-alps-dramatic-reflection-at-sunset-national-park-berchtesgaden.jpg?s=612x612&w=0&k=20&c=TpbhKprAFth2Lss7ZCiK7R4d2N-YKt0d9Kh3BSpg9eI=", IsVisible = true },
                new Photo { Id = 2, Title = "City Skyline", Description = "A bustling city skyline at night.", Image = "https://img.freepik.com/premium-photo/captivating-aerial-shot-bustling-city-illuminated-by-mesmerizing-glow-its-nighttime-skyline-city-glowing-evening-skyline-from-ai-generated_538213-19212.jpg", IsVisible = true },
                new Photo { Id = 3, Title = "Forest Pathway", Description = "A serene pathway through the forest.", Image = "https://static.vecteezy.com/system/resources/previews/031/579/834/large_2x/winding-path-through-serene-forest-generative-ai-photo.jpeg", IsVisible = true },
                new Photo { Id = 4, Title = "Wild Tiger", Description = "A majestic tiger in the wild.", Image = "https://media.4-paws.org/5/4/4/c/544c2b2fd37541596134734c42bf77186f0df0ae/VIER%20PFOTEN_2017-10-20_164-3854x2667-1920x1329.jpg", IsVisible = true },
                new Photo { Id = 5, Title = "Modern Art", Description = "An abstract piece of modern art.", Image = "https://www.paulkenton.com/wp-content/uploads/2020/12/expanse-background.jpg", IsVisible = true }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
    }
}
