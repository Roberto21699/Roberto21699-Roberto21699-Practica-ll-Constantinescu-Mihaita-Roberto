using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Restaurant.Areas.Identity.IdentityHostingStartup))]
namespace Ferma.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}