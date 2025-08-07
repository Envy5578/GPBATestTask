using GPBATestTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GPBATestTask.Persistence.EntityTypeConfigurations;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(provider => provider.Id);
        builder.HasIndex(provider => provider.Id).IsUnique();
        builder.Property(provider => provider.Id).ValueGeneratedOnAdd();

        builder.HasMany(provider => provider.Offers)
            .WithOne(offer => offer.Provider)
            .HasForeignKey(offer => offer.ProviderId);
    }
}