using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Entities.DbSets;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class AdminConfiguration:BaseUserConfiguration<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            
            base.Configure(builder);
            builder.HasMany(x => x.IncomingToAdmin).WithOne(x => x.Admin).HasForeignKey(x => x.AdminId);
        }
    }
}
