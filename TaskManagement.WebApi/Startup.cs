using Microsoft.EntityFrameworkCore;
using TaskManagement.WebApi.Extensions;

namespace TaskManagement.WebApi
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();
        }

        /// <summary>
        /// WebApi Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Used this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<TaskContext>(options =>
            options.UseInMemoryDatabase("TaskManagementDB"));

            // Register TaskManagement - Service
            services.AddTaskManagementService();

            // Register TaskManagement - Repository
            services.AddTaskManagementRepository();

            // Add Health Middleware
            services.AddHealthChecks();
            services.AddSwaggerGen();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggingBuilder"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

    }
}
