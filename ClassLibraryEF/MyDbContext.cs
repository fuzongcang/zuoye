using Microsoft.EntityFrameworkCore;
using Rbac.Entity;
using System;

namespace ClassLibraryEF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRole> MenuRole { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(m =>
            {
                m.Property(m => m.UserName).HasMaxLength(50).IsRequired();
                m.Property(m => m.Password).HasMaxLength(50).IsRequired();
                m.Property(m => m.Email).HasMaxLength(50).IsRequired();
                m.Property(m => m.LastLoginIP).HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<Role>(m =>
            {
                m.Property(m => m.RoleName).HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<Menu>(m =>
            {
                m.Property(m => m.MenuName).HasMaxLength(50).IsRequired();
                m.Property(m => m.LinkUrl).HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<AdminRole>(m =>
            {
                m.HasOne<Admin>().WithMany().HasForeignKey(k => k.AdminId);
                m.HasOne<Role>().WithMany().HasForeignKey(k => k.RoleId);
            });
            modelBuilder.Entity<MenuRole>(m =>
            {
                m.HasOne<Menu>().WithMany().HasForeignKey(k => k.MenuId);
                m.HasOne<Role>().WithMany().HasForeignKey(k => k.RoleId);
            });
        }
    }
}
