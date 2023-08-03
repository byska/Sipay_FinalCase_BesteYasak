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
    public class MessageConfiguration<T>:AuditableEntityConfiguration<T> where T : Message
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Admin).IsRequired();
            builder.Property(x => x.AdminId).IsRequired();
            builder.Property(x => x.User).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

        }
    }
}
