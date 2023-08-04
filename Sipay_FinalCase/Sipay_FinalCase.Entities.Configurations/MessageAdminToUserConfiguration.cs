using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_FinalCase.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class MessageAdminToUserConfiguration:MessageConfiguration<MessageAdminToUser>
    {
        public override void Configure(EntityTypeBuilder<MessageAdminToUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.Admin).WithMany(x => x.MessageAdminToUsers).HasForeignKey(x => x.AdminId);
            builder.HasOne(x => x.User).WithMany(x => x.MessageAdminToUsers).HasForeignKey(x => x.UserId);

        }
    }
}
