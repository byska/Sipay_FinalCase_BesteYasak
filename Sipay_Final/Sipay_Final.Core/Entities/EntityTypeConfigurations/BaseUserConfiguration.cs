using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Core.Entities.BaseEntities;

namespace Sipay_FinalCase.Core.Entities.EntityTypeConfigurations
{
    public class BaseUserConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseUser
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(128).IsRequired(false);
            builder.Property(x => x.DeletedDate).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(128).IsRequired(false);
            builder.Property(x => x.Firstname).HasMaxLength(125).IsRequired();
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(125);
            builder.Property(x => x.Email).HasMaxLength(125).IsRequired();
            builder.Property(x => x.Password).IsRequired(false).HasMaxLength(125);
            builder.Property(x => x.LastActivity).IsRequired(false);
            builder.Property(x => x.Role).IsRequired();
        }
    }
}
