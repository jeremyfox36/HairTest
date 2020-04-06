using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HairTest.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace HairTest
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
            
            services.AddScoped<IBarberRepository, MockBarberRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://appleid.apple.com",
                        ValidAudiences = new[] { "com.scottbrady91.authdemo.service" },
                        IssuerSigningKeys = GetApplePublicKeys().Result,
                    };
                });
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static async Task<IList<SecurityKey>> GetApplePublicKeys()
        {
            var requestUrl = $"https://appleid.apple.com/auth/keys";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(requestUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    JsonWebKeySet jsonWebKeySet = new JsonWebKeySet(data);
                    IList<SecurityKey> keys = jsonWebKeySet.GetSigningKeys();
                    return keys;
                }
                return null;
            }
        }
    }
}
