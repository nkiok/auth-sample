using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AuthSample.Areas.Identity.IdentityHostingStartup))]
namespace AuthSample.Areas.Identity
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