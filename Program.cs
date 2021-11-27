using Coravel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WokerCloud.Jobs;
using WokerCloud.Contexts;
using WokerCloud.Repositories;
using WokerCloud.Services;

namespace WokerCloud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.Services.UseScheduler(scheduler =>
            {
                scheduler
                    .Schedule<Job>()
                    .EveryMinute();
            });
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;

                    services.AddScheduler();
                    services.AddTransient<Job>();
                    services.Configure<MongoDBSettings>(configuration.GetSection(nameof(MongoDBSettings)));
                    services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                    services.AddTransient<IUserRepository, UserRepository>();
                });
    }
}
