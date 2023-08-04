using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_FinalCase.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class MessageUserToAdminConfiguration:MessageConfiguration<MessageUserToAdmin>
    {
        public override void Configure(EntityTypeBuilder<MessageUserToAdmin> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.User).WithMany(x => x.MessageUserToAdmins).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Admin).WithMany(x => x.MessageUserToAdmins).HasForeignKey(x => x.AdminId);
        }
    }
}
