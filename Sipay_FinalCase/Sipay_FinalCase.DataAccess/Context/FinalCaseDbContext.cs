using Microsoft.EntityFrameworkCore;
using Sipay_FinalCase.Entities.Configurations;
using Sipay_FinalCase.Entities.DbSets;

namespace Sipay_FinalCase.DataAccess.Context
{
    public class FinalCaseDbContext :DbContext
    {
        public FinalCaseDbContext(DbContextOptions<FinalCaseDbContext> options):base(options) 
        {
            
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageAdminToUser> MessageAdminToUsers { get; set; }
        public DbSet<MessageUserToAdmin> MessageUserToAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PayInformation> PayInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new MessageAdminToUserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageUserToAdminConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PayInformationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
