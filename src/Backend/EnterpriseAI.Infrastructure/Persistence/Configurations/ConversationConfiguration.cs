using EnterpriseAI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Infrastructure.Persistence.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.ToTable("Conversations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
            // builder.HasMany<Message>("_messages").WithOne().HasForeignKey("ConversationId").OnDelete(DeleteBehavior.Cascade);
            //builder.Navigation("_messages").UsePropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Messages)
                                       .WithOne()
                           .HasForeignKey("ConversationId")
                           .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Messages)
                   .HasField("_messages")
                   .UsePropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
