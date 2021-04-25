﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAndFragman.DAL;

namespace MovieAndFragman.DAL.Migrations
{
    [DbContext(typeof(MovieAndFragmanDbContext))]
    partial class MovieAndFragmanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieAndFragman.Model.Entities.FragComment", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("FragmanID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID", "FragmanID");

                    b.HasIndex("FragmanID");

                    b.ToTable("FragComment");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Fragman", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CounterDisLike")
                        .HasColumnType("int");

                    b.Property<int>("CounterLike")
                        .HasColumnType("int");

                    b.Property<int>("CounterView")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MediumPoster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Ratio")
                        .HasColumnType("real");

                    b.Property<string>("SmallPoster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Fragman");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.GenreFragman", b =>
                {
                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<int>("FragmanID")
                        .HasColumnType("int");

                    b.HasKey("GenreID", "FragmanID");

                    b.HasIndex("FragmanID");

                    b.ToTable("GenreFragman");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Live", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BroadcastPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageLPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Live");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Podcast", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BroadcastPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageLPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Podcast");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Rating", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("FragmanID")
                        .HasColumnType("int");

                    b.Property<bool>("LoveLike")
                        .HasColumnType("bit");

                    b.Property<bool>("UnLike")
                        .HasColumnType("bit");

                    b.HasKey("UserID", "FragmanID");

                    b.HasIndex("FragmanID");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Url", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FragmanID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.Property<string>("UrlPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FragmanID");

                    b.HasIndex("LanguageID");

                    b.ToTable("Url");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ActivationCode")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BrithDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            ActivationCode = new Guid("e88f92b9-6f39-4a66-a758-1659e261aa75"),
                            BrithDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2021, 4, 25, 15, 15, 25, 354, DateTimeKind.Local).AddTicks(8084),
                            FirstName = "admin",
                            IsActive = false,
                            LastName = "admin",
                            PasswordHash = new byte[] { 38, 149, 53, 208, 13, 74, 156, 152, 159, 177, 153, 230, 227, 53, 103, 220, 129, 108, 36, 209, 189, 95, 200, 124, 219, 158, 212, 254, 108, 196, 207, 54, 245, 217, 139, 80, 38, 148, 68, 102, 41, 57, 139, 212, 37, 9, 131, 162, 222, 76, 140, 140, 153, 93, 110, 207, 189, 233, 107, 199, 55, 249, 110, 73 },
                            PasswordSalt = new byte[] { 80, 81, 118, 55, 233, 16, 124, 239, 92, 238, 95, 93, 63, 44, 215, 61, 212, 81, 131, 139, 71, 42, 161, 126, 94, 37, 87, 102, 224, 92, 208, 251, 148, 29, 141, 61, 144, 52, 167, 74, 205, 220, 247, 54, 8, 123, 206, 157, 8, 96, 9, 79, 218, 8, 85, 137, 13, 184, 44, 190, 163, 52, 135, 121, 69, 37, 194, 78, 11, 65, 248, 65, 120, 88, 237, 125, 33, 79, 192, 175, 146, 71, 115, 19, 58, 107, 14, 181, 45, 40, 34, 107, 222, 41, 254, 122, 198, 109, 192, 47, 241, 80, 71, 38, 129, 249, 198, 139, 157, 239, 208, 75, 230, 210, 149, 251, 48, 242, 28, 25, 67, 204, 160, 69, 104, 214, 158, 199 },
                            UserName = "admin",
                            UserRole = 1
                        });
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.FragComment", b =>
                {
                    b.HasOne("MovieAndFragman.Model.Entities.Fragman", "Fragman")
                        .WithMany("FragComments")
                        .HasForeignKey("FragmanID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieAndFragman.Model.Entities.User", "User")
                        .WithMany("FragComments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fragman");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Fragman", b =>
                {
                    b.HasOne("MovieAndFragman.Model.Entities.User", "User")
                        .WithMany("Fragmans")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.GenreFragman", b =>
                {
                    b.HasOne("MovieAndFragman.Model.Entities.Fragman", "Fragman")
                        .WithMany("GenreFragmens")
                        .HasForeignKey("FragmanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAndFragman.Model.Entities.Genre", "Genre")
                        .WithMany("GenreFragmens")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fragman");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Rating", b =>
                {
                    b.HasOne("MovieAndFragman.Model.Entities.Fragman", "Fragman")
                        .WithMany("Ratings")
                        .HasForeignKey("FragmanID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieAndFragman.Model.Entities.User", "User")
                        .WithMany("Ratings")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fragman");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Url", b =>
                {
                    b.HasOne("MovieAndFragman.Model.Entities.Fragman", "Fragman")
                        .WithMany("Urls")
                        .HasForeignKey("FragmanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAndFragman.Model.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fragman");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Fragman", b =>
                {
                    b.Navigation("FragComments");

                    b.Navigation("GenreFragmens");

                    b.Navigation("Ratings");

                    b.Navigation("Urls");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.Genre", b =>
                {
                    b.Navigation("GenreFragmens");
                });

            modelBuilder.Entity("MovieAndFragman.Model.Entities.User", b =>
                {
                    b.Navigation("FragComments");

                    b.Navigation("Fragmans");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
