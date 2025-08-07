using GPBATestTask.Domain.Entities;

namespace GPBATestTask.Persistence;

public static class DbInitializer
{
    public static void Initialize(GPBATestTaskDbContext context)
    {
        context.Database.EnsureCreated();

        var providers = FillProviderTestData(context);
        FillOfferTestData(providers, context);
    }
    
    private static void FillOfferTestData(List<Provider> providers, GPBATestTaskDbContext context)
    {
        var offers = new List<Offer>
        {
            new Offer
            {
                Stamp = "Test stamp 1",
                Model = "Test model 1",
                ProviderId = providers[0].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 2",
                Model = "Test model 2",
                ProviderId = providers[0].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 3",
                Model = "Test model 3",
                ProviderId = providers[0].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 4",
                Model = "Test model 4",
                ProviderId = providers[0].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 5",
                Model = "Test model 5",
                ProviderId = providers[0].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 6",
                Model = "Test model 6",
                ProviderId = providers[1].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 7",
                Model = "Test model 7",
                ProviderId = providers[1].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 8",
                Model = "Test model 8",
                ProviderId = providers[1].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 9",
                Model = "Test model 9",
                ProviderId = providers[1].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 10",
                Model = "Test model 10",
                ProviderId = providers[2].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 11",
                Model = "Test model 11",
                ProviderId = providers[2].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 12",
                Model = "Test model 12",
                ProviderId = providers[2].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 13",
                Model = "Test model 13",
                ProviderId = providers[3].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 14",
                Model = "Test model 14",
                ProviderId = providers[4].Id,
                RegistrationDate = DateTime.UtcNow,
            },
            new Offer
            {
                Stamp = "Test stamp 15",
                Model = "Test model 15",
                ProviderId = providers[4].Id,
                RegistrationDate = DateTime.UtcNow,
            },
        };
        
        context.Offers.AddRange(offers);
        context.SaveChanges();
    }
    
    private static List<Provider> FillProviderTestData(GPBATestTaskDbContext context)
    {
        var providers = new List<Provider>
        {
            new Provider
            {
                Name = "Test1",
                CreationDate = DateTime.UtcNow,
            },
            new Provider
            {
                Name = "Test2",
                CreationDate = DateTime.UtcNow,
            },
            new Provider
            {
                Name = "Test3",
                CreationDate = DateTime.UtcNow,
            },
            new Provider
            {
                Name = "Test4",
                CreationDate = DateTime.UtcNow,
            },
            new Provider
            {
                Name = "Test5",
                CreationDate = DateTime.UtcNow,
            },
        };
        
        context.Providers.AddRange(providers);
        context.SaveChanges();
        
        return providers;
    }
}