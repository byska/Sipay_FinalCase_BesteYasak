using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_FinalCase.Core.Entities.BaseEntities;

namespace Sipay_FinalCase.Core.Entities.EntityTypeConfigurations
{
    public class BaseUserConfiguration<T>:AuditableEntityConfiguration<T> where T : BaseUser
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Firstname).HasMaxLength(125).IsRequired();
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(125);
            builder.Property(x => x.Email).HasMaxLength(125).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(125);
            builder.Property(x => x.LastActivity).IsRequired();
        }
    }
}
