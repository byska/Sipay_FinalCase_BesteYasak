using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Entities.DbSets;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;

namespace Sipay_Final.EntitiesConfiguration
{
    public class MessageToAdminConfiguration:MessageConfiguration<MessageToAdmin>
    {
        public override void Configure(EntityTypeBuilder<MessageToAdmin> builder)
        {
            base.Configure(builder);
            
        }
    }
}
