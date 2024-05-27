﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using net_il_mio_fotoalbum.Data;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    [DbContext(typeof(PhotoAlbumContext))]
    partial class PhotoAlbumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryPhoto", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "PhotoId");

                    b.HasIndex("PhotoId");

                    b.ToTable("CategoryPhoto");
                });

            modelBuilder.Entity("net_il_mio_fotoalbum.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nature"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Urban"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Portrait"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wildlife"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Abstract"
                        });
                });

            modelBuilder.Entity("net_il_mio_fotoalbum.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A beautiful sunset over the mountain range.",
                            Image = "https://media.istockphoto.com/id/1136834574/photo/watzmann-in-alps-dramatic-reflection-at-sunset-national-park-berchtesgaden.jpg?s=612x612&w=0&k=20&c=TpbhKprAFth2Lss7ZCiK7R4d2N-YKt0d9Kh3BSpg9eI=",
                            IsVisible = true,
                            Title = "Sunset in the Mountains"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A bustling city skyline at night.",
                            Image = "https://img.freepik.com/premium-photo/captivating-aerial-shot-bustling-city-illuminated-by-mesmerizing-glow-its-nighttime-skyline-city-glowing-evening-skyline-from-ai-generated_538213-19212.jpg",
                            IsVisible = true,
                            Title = "City Skyline"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A serene pathway through the forest.",
                            Image = "https://static.vecteezy.com/system/resources/previews/031/579/834/large_2x/winding-path-through-serene-forest-generative-ai-photo.jpeg",
                            IsVisible = true,
                            Title = "Forest Pathway"
                        },
                        new
                        {
                            Id = 4,
                            Description = "A majestic tiger in the wild.",
                            Image = "https://media.4-paws.org/5/4/4/c/544c2b2fd37541596134734c42bf77186f0df0ae/VIER%20PFOTEN_2017-10-20_164-3854x2667-1920x1329.jpg",
                            IsVisible = true,
                            Title = "Wild Tiger"
                        },
                        new
                        {
                            Id = 5,
                            Description = "An abstract piece of modern art.",
                            Image = "https://www.paulkenton.com/wp-content/uploads/2020/12/expanse-background.jpg",
                            IsVisible = true,
                            Title = "Modern Art"
                        });
                });

            modelBuilder.Entity("CategoryPhoto", b =>
                {
                    b.HasOne("net_il_mio_fotoalbum.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("net_il_mio_fotoalbum.Models.Photo", null)
                        .WithMany()
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
