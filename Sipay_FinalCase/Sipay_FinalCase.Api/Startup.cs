using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sipay_FinalCase.Core.UnitOfWork;
using Sipay_FinalCase.DataAccess.Context;

namespace Sipay_FinalCase.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Final Case", Version = "v1" });
            });

            //dbcontext
            var dbType = Configuration.GetConnectionString("DbType");
            if (dbType == "Sql")
            {
                var dbConfig = Configuration.GetConnectionString("MsSqlConnection");
                services.AddDbContext<FinalCaseDbContext>(opts =>
                opts.UseSqlServer(dbConfig));
            }
            //services.AddScoped<IUow, Uow>();

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new MappingProfile());
            //});
            //services.AddSingleton(config.CreateMapper());

            //services.AddScoped<IApartmentService, ApartmentService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IMessageAdminToUserService, MessageAdminToUserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalCase v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
