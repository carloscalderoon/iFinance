namespace iFinance.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<MonthlyExpens> MonthlyExpenses { get; set; }
        public virtual DbSet<MonthlyIncome> MonthlyIncomes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonthlyExpens>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MonthlyExpens>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MonthlyIncome>()
                .Property(e => e.Origin)
                .IsUnicode(false);

            modelBuilder.Entity<MonthlyIncome>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
