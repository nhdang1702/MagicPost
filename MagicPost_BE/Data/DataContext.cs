using MagicPost_BE.Enum;
using MagicPost_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicPost_BE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Office>().HasData(
                new Office { OfficeId = 100, OfficeType = OfficeType.Gathering, OfficeName = "Ha Dong" },
                new Office { OfficeId = 101, OfficeType = OfficeType.Transaction, OfficeName = "Cau Giay" },
                new Office { OfficeId = 102, OfficeType = OfficeType.Transaction, OfficeName = "Hai Ba Trung" }
    );
            modelBuilder.Entity<Account>().HasData
                (
                new Account()
                {
                    AccountId = 1,
                    FullName = "Nguyen Hong Dang",
                    Email = "dang@vnu.edu.vn",
                    Password = "123",
                    Phone = "0888888888",
                    Role = Role.CEO,

                    //WorkAtOfficeId = 100

                }

                );
            modelBuilder.Entity<Account>().HasData
                (
                new Account()
                {
                    AccountId = 2,
                    FullName = "Nguyen Hoang Duong",
                    Role = Role.CEO,
                    Email = "duong@vnu.edu.vn",
                    Password = "123",
                    Phone = "0999999999",
                    //WorkAtOfficeId = 101,
                    


                }

                );
            modelBuilder.Entity<Account>().HasData
                (
                new Account()
                {
                    AccountId = 3,
                    FullName = "Vu Huu An",
                    Role = Role.TĐGD,
                    Email = "an@vnu.edu.vn",
                    Password = "123",
                    Phone = "0777777777",
                    //WorkAtId = 103,
                    //WorkAtOfficeId = 102


                }

                );
            modelBuilder.Entity<Account>().HasData
                (
                new Account()
                {
                    AccountId = 4,
                    FullName = "Andy",
                    Role = Role.GDV,
                    Email = "andy@vnu.edu.vn",
                    Password = "123",
                    Phone = "0152345688",
                    //WorkAtOfficeId = 102,
                    
                    

                }

                );
        }
    }
}
