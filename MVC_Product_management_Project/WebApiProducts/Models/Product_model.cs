namespace WebApiProducts.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Product_model : DbContext
    {
        public Product_model()
            : base("name=Product_model")
        {
        }

        public virtual DbSet<Product_Table> Product_Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Table>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Table>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Table>()
                .Property(e => e.Short_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Table>()
                .Property(e => e.Long_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Table>()
                .Property(e => e.Small_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Table>()
                .Property(e => e.Large_Image)
                .IsUnicode(false);
        }
    }
}
