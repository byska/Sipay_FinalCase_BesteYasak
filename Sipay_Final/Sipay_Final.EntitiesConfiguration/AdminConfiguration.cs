using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Entities.DbSets;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class AdminConfiguration:BaseUserConfiguration<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            //builder.HasMany(x => x.MessageUserToAdmins).WithOne(x => x.Admin).HasForeignKey(x => x.AdminId);
            //builder.HasMany(x => x.MessageAdminToUsers).WithOne(x => x.Admin).HasForeignKey(x => x.AdminId);
            base.Configure(builder);
            builder.HasMany(x => x.IncomingToAdmin).WithOne(x => x.Admin).HasForeignKey(x => x.AdminId);
        }
    }
}
