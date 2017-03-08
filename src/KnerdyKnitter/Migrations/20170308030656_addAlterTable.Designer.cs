using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KnerdyKnitter.Models;

namespace KnerdyKnitter.Migrations
{
    [DbContext(typeof(KnerdyKnitterContext))]
    [Migration("20170308030656_addAlterTable")]
    partial class addAlterTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KnerdyKnitter.Models.Alter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<int>("GarmentId");

                    b.Property<int>("XCor");

                    b.Property<int>("YCor");

                    b.HasKey("Id");

                    b.HasIndex("GarmentId");

                    b.ToTable("Alters");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GarmentId");

                    b.Property<string>("Hex");

                    b.Property<int>("KnitterId");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GarmentId");

                    b.HasIndex("KnitterId");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int>("GarmentId");

                    b.Property<int>("ReceiverId");

                    b.Property<int>("SenderId");

                    b.HasKey("Id");

                    b.HasIndex("GarmentId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GarmentId");

                    b.Property<int>("KnitterId");

                    b.HasKey("Id");

                    b.HasIndex("GarmentId");

                    b.HasIndex("KnitterId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Follow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FollowerId");

                    b.Property<int>("FollowingId");

                    b.HasKey("Id");

                    b.HasIndex("FollowerId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Garment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColDim");

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("KnitterId");

                    b.Property<int>("RowDim");

                    b.Property<string>("Rule");

                    b.HasKey("Id");

                    b.HasIndex("KnitterId");

                    b.ToTable("Garments");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.GarmentTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GarmentId");

                    b.Property<int?>("KnitterId");

                    b.Property<int?>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("GarmentId");

                    b.HasIndex("KnitterId");

                    b.HasIndex("TagId");

                    b.ToTable("GarmentTags");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Knitter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("SignUpDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Knitters");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Alter", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Garment", "Garment")
                        .WithMany("Alters")
                        .HasForeignKey("GarmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Color", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Garment", "Garment")
                        .WithMany("Colors")
                        .HasForeignKey("GarmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.Knitter", "Knitter")
                        .WithMany("Colors")
                        .HasForeignKey("KnitterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Comment", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Garment", "Garment")
                        .WithMany("Comments")
                        .HasForeignKey("GarmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.Knitter", "Receiver")
                        .WithMany("ReceivedComments")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.Knitter", "Sender")
                        .WithMany("SentComments")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Favorite", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Garment", "Garment")
                        .WithMany("Favorites")
                        .HasForeignKey("GarmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.Knitter", "Knitter")
                        .WithMany("Favorites")
                        .HasForeignKey("KnitterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Follow", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Knitter", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.Knitter", "Following")
                        .WithMany("Followings")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Garment", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Knitter", "Knitter")
                        .WithMany("Garments")
                        .HasForeignKey("KnitterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KnerdyKnitter.Models.GarmentTag", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.Garment", "Garment")
                        .WithMany("GarmentTags")
                        .HasForeignKey("GarmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.Knitter")
                        .WithMany("GarmentTag")
                        .HasForeignKey("KnitterId");

                    b.HasOne("KnerdyKnitter.Models.Tag")
                        .WithMany("GarmentTags")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("KnerdyKnitter.Models.Knitter", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KnerdyKnitter.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KnerdyKnitter.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
