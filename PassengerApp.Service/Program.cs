var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();
Configure(app, builder.Environment);


static void ConfigureServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddControllers();
    services.AddMemoryCache();

}

static void Configure(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseRouting();
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    app.Run();
}