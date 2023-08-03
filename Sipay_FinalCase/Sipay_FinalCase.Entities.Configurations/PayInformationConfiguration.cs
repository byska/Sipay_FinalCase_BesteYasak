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
    public class PayInformationConfiguration:AuditableEntityConfiguration<PayInformation>
    {
        public override void Configure(EntityTypeBuilder<PayInformation> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.GasBill).IsRequired(false).HasPrecision(2);
            builder.Property(x=>x.GasBillDate).IsRequired(false);
            builder.Property(x=>x.ElectricityBill).IsRequired(false).HasPrecision(2);
            builder.Property(x=>x.ElectricityBillDate).IsRequired(false);
            builder.Property(x=>x.WaterBill).IsRequired(false).HasPrecision(2);
            builder.Property(x=>x.WaterBillDate).IsRequired(false);

            builder.HasOne(x => x.Apartment).WithOne(x => x.PayInformation).HasForeignKey<Apartment>(x => x.PayInformationId);
        }
    }
}
