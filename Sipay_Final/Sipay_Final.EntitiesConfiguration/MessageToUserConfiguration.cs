using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Final.Entities.DbSets;
using Sipay_FinalCase.Core.Entities.EntityTypeConfigurations;

namespace Sipay_Final.EntitiesConfiguration
{
    public class MessageToUserConfiguration: MessageConfiguration<MessageToUser>
    {
        public override void Configure(EntityTypeBuilder<MessageToUser> builder)
        {
            base.Configure(builder);
           

        }
    }
}
