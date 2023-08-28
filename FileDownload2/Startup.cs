using Microsoft.Extensions.FileProviders;

namespace FileDownload2
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(configuration["PublicPath"]!),
                ServeUnknownFileTypes = true,
                RequestPath = new PathString("/" + configuration["RequestUrl"])
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(configuration["PublicPath"]!),
                RequestPath = new PathString("/" + configuration["RequestUrl"])
            });
        }

    }
}