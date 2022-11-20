using goglobe_API.Auth;
using goglobe_API.Auth.Model;
using goglobe_API.Data;
using goglobe_API.Data.Entities;
using goglobe_API.Data.Repository;
using goglobe_API.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace goglobe_API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<DatabaseContext>()
                    .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters.ValidAudience = _configuration["JWT:ValidAudience"];
                options.TokenValidationParameters.ValidIssuer = _configuration["JWT:ValidIssuer"];
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.SameUser, policy => policy.Requirements.Add(new SameUserRequirement()));
            });

            services.AddCors(c => c.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
            services.AddSingleton<IAuthorizationHandler, UserAuthorizationHandler>();
            services.AddDbContext<DatabaseContext>(o =>
                o.UseSqlServer(_configuration.GetConnectionString("DB_CONNECTION")));
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddTransient<IAgencyRepository, AgenciesRepository>();
            services.AddTransient<ITravelOfferRepository, TravelOffersRepository>();
            services.AddTransient<IBookingRepository, BookingsRepository>();
            services.AddTransient<ITokenManager, TokenManager>();
            services.AddTransient<DatabaseSeeder, DatabaseSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
   
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
