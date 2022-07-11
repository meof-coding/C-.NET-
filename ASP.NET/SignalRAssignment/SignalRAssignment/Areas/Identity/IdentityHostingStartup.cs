using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRAssignment.Areas.Identity.Data;
using SignalRAssignment.Data;

[assembly: HostingStartup(typeof(SignalRAssignment.Areas.Identity.IdentityHostingStartup))]
namespace SignalRAssignment.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                //services.AddDbContext<SignalRAssignmentContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("Lab2")));

                //services.AddDefaultIdentity<SignalRAssignmentUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<SignalRAssignmentContext>();
            });
        }
    }
}