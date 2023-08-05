using Microsoft.EntityFrameworkCore;
using Sipay_Final.Core.Entities.Enums;
using Sipay_Final.Entities.DbSets;
using Sipay_Final.EntitiesConfiguration;
using Sipay_FinalCase.Entities.Configurations;

namespace Sipay_Final.DataAccess.Context
{
    public class FinalDbContext:DbContext
    {
        public FinalDbContext(DbContextOptions<FinalDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PayInformation> PayInformations { get; set; }
        public DbSet<MessageToAdmin> MessageToAdmins { get; set; }
        public DbSet<MessageToUser> MessageToUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new ApartmentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PayInformationConfiguration());
            modelBuilder.ApplyConfiguration(new MessageToUserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageToAdminConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().HasData( new Admin() {Id=1, Firstname="admin",Lastname="admin", Email="admin@gmail.com",Password="Beste123456",CreatedBy="admin@gmail.com", CreatedDate= DateTime.UtcNow,Role=Role.admin });
            modelBuilder.Entity<User>().HasData(new User() {Id=1, Firstname = "John", Lastname = "Doe", Email = "johndoe@gmail.com", Password = "Beste123456", CreatedBy = "admin@gmail.com", ApartmentId = 1, Phone = "05342569312", Tc = "23674356974", LicensePlate = "34BY428" },
            new User() {Id = 2, Firstname = "Jeyn", Lastname = "Doe", Email = "jeyndoe@gmail.com", Password = "Beste123456", CreatedBy = "admin@gmail.com", ApartmentId = 2, Phone = "05317241735", Tc = "45832173821" });
            modelBuilder.Entity<Apartment>().HasData(new Apartment() {Id=1, ApartmentNumber=4,Block=Entities.Enums.Block.A, Type=Entities.Enums.Type.twoPlusOne,Floor=2,CreatedBy="admin@gmail.com",Resident=Entities.Enums.Resident.Tenant,Status=Entities.Enums.ApartmentStatus.Full},
            new Apartment() {Id = 2, ApartmentNumber = 2, Block = Entities.Enums.Block.B, Type = Entities.Enums.Type.onePlusOne, Floor = 1, CreatedBy = "admin@gmail.com", Resident = Entities.Enums.Resident.Tenant, Status = Entities.Enums.ApartmentStatus.Full });
            modelBuilder.Entity<PayInformation>().HasData(new PayInformation() {Id=1, CreatedBy = "admin@gmail.com", Dues = 250, ElectricityBill = 200, GasBill = 800, WaterBill = 150,ApartmentId = 2 },
            new PayInformation() {Id = 2, CreatedBy = "admin@gmail.com", Dues = 300, ElectricityBill = 150, GasBill = 600, WaterBill = 200,ApartmentId=1 });
            modelBuilder.Entity<MessageToAdmin>().HasData(new MessageToAdmin() {Id=1, AdminId = 1, Status = Entities.Enums.MessageStatus.Read, Text = "Hi,Our water pipe burst. Could you direct me to the plumber? ", UserId = 1, CreatedBy = "johndoe@gmail.com" });
            modelBuilder.Entity<MessageToUser>().HasData(new MessageToAdmin() {Id = 1, AdminId = 1, Status = Entities.Enums.MessageStatus.New, Text = "Hi,please pay your bill.", UserId = 2, CreatedBy = "admin@gmail.com" });

        }
    }
}
