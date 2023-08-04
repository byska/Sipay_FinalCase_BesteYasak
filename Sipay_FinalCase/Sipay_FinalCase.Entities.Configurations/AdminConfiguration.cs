using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;
using Sipay_FinalCase.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class AdminConfiguration:BaseUserConfiguration<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            //builder.HasMany(x => x.MessageUserToAdmins).WithOne(x => x.Admin).HasForeignKey(x => x.AdminId);
            //builder.HasMany(x => x.MessageAdminToUsers).WithOne(x => x.Admin).HasForeignKey(x => x.AdminId);
            base.Configure(builder);
        }
    }
}
