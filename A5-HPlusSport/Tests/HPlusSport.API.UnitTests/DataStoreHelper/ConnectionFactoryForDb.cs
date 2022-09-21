using HPlusSport.API.DataStore;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.UnitTests.DataStoreHelper
{
    public class ConnectionFactoryForDb : IDisposable
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public ShopDbContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<ShopDbContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new ShopDbContext(option);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }

}
