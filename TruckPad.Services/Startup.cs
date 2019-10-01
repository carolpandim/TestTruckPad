using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TruckPad.Services.Models;
using Swashbuckle.AspNetCore.Swagger;
using TruckPad.Services.Repository;

namespace TruckPad.Services
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
            //services.AddCors(option => option.AddPolicy("MyTruckPadPolicy", builder => {
            //    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //}));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<TruckPadContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TruckPadDB")));

            services.AddScoped<IMotoristaRepository, MotoristaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "APITruckPad",
                    Version = "v1",
                    Contact = new Contact
                    {
                        Name ="Ana Carolina Louverbeck Pandim Alves",
                        Email ="anapandim@outlook.com",
                        Url= "https://www.linkedin.com/in/carolinapandimalves/"
                    },
                    License = new License
                    {
                        Name = "TruckPad",
                        Url = "https://www.truckpad.com.br/"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseHttpsRedirection();

            //app.UseCors("MyTruckPadPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "APITruckPad V1");
            });

        }
    }
}
