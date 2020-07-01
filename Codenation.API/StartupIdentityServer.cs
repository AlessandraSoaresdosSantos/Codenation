using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Validation;
using IdentityServer4.Services;
using Codenation.Infra.Data.Context;
using Codenation.Dominio.Services;
using Microsoft.Extensions.Hosting;

namespace Codenation.API
{
    public class StartupIdentityServer
    {
        public IWebHostEnvironment Environment { get; set; } 

        public StartupIdentityServer(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IResourceOwnerPasswordValidator, PasswordValidatorService>();
            services.AddScoped<IProfileService, UserProfileService>();
            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityConfig.GetApis())
                .AddInMemoryClients(IdentityConfig.GetClients())
                .AddTestUsers(IdentityConfig.GetUsers())
                .AddProfileService<UserProfileService>();


            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

           app.UseIdentityServer();
        }
    }
}
