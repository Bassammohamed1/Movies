﻿using CoreLayer.Models;
using CoreLayer.Models.Cart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(x => x.ProviderKey);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(x => x.UserId);

            modelBuilder.Entity<ActorMovie>().HasKey(k => new { k.MovieId, k.ActorId });
            modelBuilder.Entity<ActorMovie>().HasOne(o => o.Actor).WithMany(m => m.ActorMovies).HasForeignKey(o => o.ActorId);
            modelBuilder.Entity<ActorMovie>().HasOne(o => o.Movie).WithMany(m => m.ActorMovies).HasForeignKey(o => o.MovieId);
        }
    }
}
