using Api.Middlewares;
using Domain.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence.Repository;
using Services.Abstractions;
using Services;
using Persistence.UnitOfWork;
using Domain.Entities;
using Domain.Identity;
using Persistence.Database;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.UsersController).Assembly);

            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" }));

            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            ConfigureDatabase(services);

            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        { 
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("ApplicationDatabaseDebug"), x => x.MigrationsAssembly("Api")));

            services.AddIdentity<User, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}