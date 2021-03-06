//
// Time-stamp: <2021-10-31 17:50:10 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using WebShop.Data.Identity;
using WebShop.Models.Entities.Identity;

namespace WebShop
{
    public class Program
    {
	public static async Task Main(string[] args)
	{
	    var host = CreateHostBuilder(args: args).Build();

	    using var scope = host.Services.CreateScope();
	    var services = scope.ServiceProvider;
	    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

	    try
	    {

		var userManager = services.GetRequiredService<UserManager<AppUser>>();
		var identityContext = services.GetRequiredService<AppIdentityDbContext>();
		await identityContext.Database.MigrateAsync();
		await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
	    }
	    catch (Exception ex)
	    {
		var logger = loggerFactory.CreateLogger<Program>();
		logger.LogError(ex, "An error occurred during migration");
	    }

	    host.Run();
	}

	public static IHostBuilder CreateHostBuilder(string[] args) => Host
	    .CreateDefaultBuilder(args: args)
	    .ConfigureLogging( logging => {
		logging.ClearProviders();
		logging.AddConsole();
	    } )
	    .ConfigureWebHostDefaults(webBuilder =>
	    {
		webBuilder.UseStartup<Startup>();
	    });
    }
}
