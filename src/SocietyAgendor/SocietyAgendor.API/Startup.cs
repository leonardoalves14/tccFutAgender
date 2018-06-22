using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocietyAgendor.API.Concrete;
using SocietyAgendor.API.Services;

namespace SocietyAgendor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Dependency Injection
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IClienteRepository, ClienteRepository>();

        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
