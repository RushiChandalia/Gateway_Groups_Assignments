namespace productwebapi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class productApi_model : DbContext
    {
        public productApi_model()
            : base("name=productApi_model")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Short_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Long_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Small_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Large_Image)
                .IsUnicode(false);
        }
    }
}
