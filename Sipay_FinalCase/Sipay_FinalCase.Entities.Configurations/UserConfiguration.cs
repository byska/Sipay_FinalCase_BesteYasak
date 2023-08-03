using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;
using Sipay_FinalCase.Entities.DbSets;


namespace Sipay_FinalCase.Entities.Configurations
{
    public class UserConfiguration:BaseUserConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.Tc).IsRequired().HasMaxLength(11);
            builder.Property(x=>x.Phone).IsRequired().HasMaxLength(11);
            builder.Property(x=>x.LicensePlate).IsRequired().HasMaxLength(7);

            builder.HasMany(x=>x.MessageUserToAdmins).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);
            builder.HasMany(x=>x.MessageAdminToUsers).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
