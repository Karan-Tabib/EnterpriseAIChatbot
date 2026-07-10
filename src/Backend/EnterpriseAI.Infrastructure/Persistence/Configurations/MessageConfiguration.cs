using EnterpriseAI.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace EnterpriseAI.Infrastructure.Persistence.Configurations
{
    public sealed class MessageConfiguration
    : IEntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {

        }
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedNever();

            builder.Property(x => x.Content)
                   .IsRequired()
                   .HasMaxLength(4000);

            builder.Property(x => x.Role)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.CreatedOn)
                   .IsRequired();
        }
    }
}
