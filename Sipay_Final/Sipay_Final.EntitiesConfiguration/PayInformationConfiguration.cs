using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Entities.DbSets;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;

namespace Sipay_FinalCase.Entities.Configurations
{
    public class PayInformationConfiguration:BaseEntityConfiguration<PayInformation>
    {
        public override void Configure(EntityTypeBuilder<PayInformation> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.GasBill).IsRequired(false).HasPrecision(2);
            builder.Property(x=>x.BillDuesDate).IsRequired(false);
            builder.Property(x=>x.ElectricityBill).IsRequired(false).HasPrecision(2);
            builder.Property(x=>x.WaterBill).IsRequired(false).HasPrecision(2);
            builder.Property(x=>x.Dues).IsRequired(false).HasPrecision(2);

            builder.HasOne(x => x.Apartment).WithMany(x => x.PayInformations).HasForeignKey(x => x.ApartmentId);
        }
    }
}
