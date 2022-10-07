using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace work_01_With_SP.Models
{
    public partial class r49DBContext : DbContext
    {
        public r49DBContext()
        {
        }

        public r49DBContext(DbContextOptions<r49DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BDPNT-AZMAN;Database=r49DB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public IQueryable<Customers> SearchCustomer(string name)
        {
            SqlParameter pName = new SqlParameter("@name", name);
            return this.Customers.FromSqlRaw("EXEC spSearchCustomers @name", pName);
        }
        public void InsertCustomer(Customers customers)
        {
            SqlParameter pName = new SqlParameter("@name", customers.Name);
            SqlParameter pCountry = new SqlParameter("@country", customers.Country);
            this.Database.ExecuteSqlCommand("EXEC spCustomerInsert @name,@country", pName, pCountry);
        }
        public void UpdateCustomer(Customers customers)
        {
            SqlParameter id = new SqlParameter("@customerId", customers.CustomerId);
            SqlParameter pName = new SqlParameter("@name", customers.Name);
            SqlParameter pCountry = new SqlParameter("@country", customers.Country);
            this.Database.ExecuteSqlCommand("EXEC spCustonerUpdate @customerId ,@name,@country", id, pName, pCountry);
        }
        public void DeleteCustomer(int id)
        {
            SqlParameter pId = new SqlParameter("@customerId", id);
            this.Database.ExecuteSqlCommand("EXEC spDeleteCustomer @customerId", pId);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__B611CB7D6B947D19");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
