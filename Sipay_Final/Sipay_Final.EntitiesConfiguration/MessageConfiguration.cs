using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Core.Entities.BaseEntities;
using Sipay_Final.Entities.Base;

namespace Sipay_Final.EntitiesConfiguration
{
    public abstract class MessageConfiguration<T> : IEntityTypeConfiguration<T> where T:BaseMessage 
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
            builder.Property(x => x.Text).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.AdminId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
