using ANIMAL.DAL.DataModel;

using ANIMAL.Repository.Automaper;
using ANIMAL.Repository.Common;
using ANIMAL.Service.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMAL.WebApi
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
     
            services.AddDbContext<AnimalRescueDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("ANIMAL_DBConnection")));
            services.AddScoped<IService, Service.Service>();
            services.AddScoped<IRepository, Repository.Repository>();    
            services.AddScoped<IRepositoryMappingService, RepositoryMappingService>();

                    services.AddIdentity<ApplicationUser, IdentityRole>()
                                .AddEntityFrameworkStores<AnimalRescueDbContext>()
                                .AddDefaultTokenProviders();

                    services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(option =>
                    {
                        option.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = Configuration["Jwt:Issuer"],
                            ValidAudience = Configuration["Jwt:Issuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                        };
                    });

                    services.AddCors(options =>
                    {
                        options.AddPolicy("AllowSpecificOrigin",
                            builder => builder.WithOrigins("http://localhost:5173") // Dozvoljava pristup s odreðenog URL-a
                                              .AllowAnyHeader() // Dozvoljava sve zaglavlja
                                              .AllowAnyMethod()); // Dozvoljava sve HTTP metode
                    });
                        services.AddControllers();
                }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            CreateRoles(serviceProvider).Wait();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "User","Vet","HeadVet","Surenderer", "AnimalWelffereOfficer","Association","Worker","Menager","HeadAdmin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        //probat æu složit da kad se pokrene migracija da se u tablicu SystemRecord automatski doda sve što treba
        //to æu si ostavit kao dio za završni
        private async Task CreateRecord(IServiceProvider serviceProvider)
        {
            var recordMenager = serviceProvider.GetRequiredService<SystemRecord>();
            Dictionary<string, string> list = new Dictionary<string,string>();
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            list.Add("", "");
            foreach(var l in list)
            {

            }

        }
    }
}
