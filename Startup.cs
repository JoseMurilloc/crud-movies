using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dotnet.Mvc.Data;
using Microsoft.EntityFrameworkCore;
using System;
using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Http;

namespace Dotnet.Mvc
{
  public class Startup
  {
  public Startup(IConfiguration configuration,  IWebHostEnvironment env)
  {
  Environment = env;
  Configuration = configuration;
  }

  public IConfiguration Configuration { get; }
  public IWebHostEnvironment Environment { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  public void ConfigureServices(IServiceCollection services)
  {

  if (Environment.IsDevelopment()) {
    services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlite(
      Configuration.GetConnectionString("DefaultConnection")));
  } else {
    services.AddDbContext<RazorPagesMovieContext>(options =>
      options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
  }

  services.AddRouteAnalyzer();
  services.AddControllersWithViews();

  services.AddRazorPages();
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

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
      );


      // endpoints.MapGet("/", async context =>
      // {
      //   await context.Response.WriteAsync("Hello World!");
      // });

    });

    }
  }
}
