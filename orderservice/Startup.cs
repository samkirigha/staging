
using Microsoft.EntityFrameworkCore;

namespace orderservice;
public class Startup
{
    const string ordersSpecifiOrigins = "_ordersSpecificOrigins";
    private IConfiguration _configuration { get; }
    private IWebHostEnvironment _environment { get; }
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGenNewtonsoftSupport();

        services.AddHttpContextAccessor();
        services.AddSwaggerGen();

        // AutoMapper
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        services.AddCors(options =>
        {
            options.AddPolicy(name: ordersSpecifiOrigins, builder =>
            {
                builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true);
            });
        });

        services.AddDbContext<OrdersDBContext>(
           options =>
           {
               options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
               if (_environment.IsDevelopment())
                   options.EnableSensitiveDataLogging();
           }
       );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders API"); });
        }

        app.UseHttpsRedirection();
        app.UseCors(ordersSpecifiOrigins);

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

    }
}