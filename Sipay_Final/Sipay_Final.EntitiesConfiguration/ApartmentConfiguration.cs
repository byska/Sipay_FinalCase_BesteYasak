using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Entities.DbSets;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class ApartmentConfiguration:BaseEntityConfiguration<Apartment>
    {
        public override void Configure(EntityTypeBuilder<Apartment> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Block).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Floor).IsRequired();
            builder.Property(x => x.ApartmentNumber).IsRequired();
            builder.Property(x => x.Resident).IsRequired();

            builder.HasOne(x => x.User).WithOne(x => x.Apartment).HasForeignKey<User>(x => x.ApartmentId);
        }
    }
}
