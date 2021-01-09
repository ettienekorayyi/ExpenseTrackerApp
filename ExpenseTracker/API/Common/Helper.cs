using ExpenseTracker.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpenseTracker.API.Common
{
    public static class Helper
    {
        // Code snippet referenced from Rick Strahl's blog for 
        // Accessing Configuration in .NET Core Test Projects
        public static ConnectionStringConfigurations GetApplicationConfiguration(string outputPath)
        {
            var configuration = new ConnectionStringConfigurations();

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            configBuilder
                .GetSection("ConnectionStrings")
                .Bind(configuration);

            return configuration;
        }

        public static DbContextOptions<T> CreateOptions<T>
            (bool throwClientServerWarning = true) where T : DbContext
        {

            var connectionStringBuilder = 
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };

            var connectionString = connectionStringBuilder.ToString();

            var connection = new SqliteConnection(connectionString);

            connection.Open();

            var builder = new DbContextOptionsBuilder<T>();

            builder.UseSqlite(connection);

            return builder.Options;
        }

    }
}