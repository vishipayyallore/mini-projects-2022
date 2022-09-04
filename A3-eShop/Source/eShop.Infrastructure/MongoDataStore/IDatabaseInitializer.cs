namespace eShop.Infrastructure.MongoDataStore
{

    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }

}
