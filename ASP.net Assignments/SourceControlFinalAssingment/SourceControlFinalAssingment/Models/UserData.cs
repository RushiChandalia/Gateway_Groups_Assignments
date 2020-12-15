namespace SourceControlFinalAssingment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserData : DbContext
    {
        public UserData()
            : base("name=UserData")
        {
        }

        public virtual DbSet<UserTable> UserTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTable>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
