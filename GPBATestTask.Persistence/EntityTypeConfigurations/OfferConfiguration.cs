using GPBATestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPBATestTask.Persistence.EntityTypeConfigurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(provider => provider.Id);
        builder.HasIndex(provider => provider.Id).IsUnique();
        builder.Property(provider => provider.Id).ValueGeneratedOnAdd();
        
        builder.HasOne(provider => provider.Provider)
            .WithMany(provider => provider.Offers)
            .HasForeignKey(provider => provider.ProviderId);
    }
}