using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace efcorewebapi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //configratinBuilder 
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                 .UseMySql(configuration.GetConnectionString("sqlConnection"),
                 new MySqlServerVersion(new Version(8, 0, 2)), 
                 prj => prj.MigrationsAssembly("efcorewebapi"));

            return new RepositoryContext(builder.Options);


        }
    }
}
