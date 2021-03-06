//
// Time-stamp: <2021-10-31 21:12:08 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using WebShop.Data;
using WebShop.Data.Identity;
using WebShop.Models.Entities.Identity;
using WebShop.Models.Repo;
using WebShop.Models.Service;

namespace WebShop
{
    public class Startup
    {
	public Startup(IConfiguration configuration)
	{
	    Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
	    services.AddCors(opt =>
	    {
		opt.AddPolicy("CorsPolicy", policy =>
		{
		    policy
			.AllowAnyHeader()
			.AllowAnyMethod()
			.WithExposedHeaders("WWW-Authenticate")
			.WithOrigins("http://localhost:3000")
			.AllowCredentials();
		});
	    });

	    services.AddScoped<IProductRepo, ProductRepo>();
	    services.AddScoped<IProductService, ProductService>();
	    services.AddScoped<IOrderRepo, OrderRepo>();
	    services.AddScoped<IOrderService, OrderService>();
	    services.AddControllersWithViews();
	    services.AddControllers()
		.AddNewtonsoftJson(options => {
		    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
		    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
		});

	    services.AddDbContext<DBWebShop>(options =>
					     options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

	    services.AddDbContext<AppIdentityDbContext>(options =>
							options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

	    var builder = services.AddIdentityCore<AppUser>();
	    builder = new IdentityBuilder(builder.UserType, builder.Services);
	    builder.AddEntityFrameworkStores<AppIdentityDbContext>();
	    builder.AddSignInManager<SignInManager<AppUser>>();

	    services.AddAuthentication();
	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
	    if (env.IsDevelopment())
	    {
		app.UseDeveloperExceptionPage();
	    }
	    else
	    {
		app.UseExceptionHandler("/Home/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	    }
	    app.UseHttpsRedirection();
	    app.UseStaticFiles();

	    app.UseRouting();

	    app.UseAuthorization();

	    app.UseCors("CorsPolicy");

	    app.UseEndpoints(endpoints =>
	    {
		endpoints.MapControllerRoute(
		    name: "default",
		    pattern: "{controller=Home}/{action=Index}/{id?}");
	    });
	}
    }
}
