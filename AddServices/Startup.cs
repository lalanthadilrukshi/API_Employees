

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using WebApp_ServicesAdvertise.Data;
using Microsoft.AspNetCore.Identity;
using AddServices.Models;
using Microsoft.Extensions.Options;
//using WebApp_ServicesAdvertise.EmailModel;
//using WebApp_ServicesAdvertise.AppServices;
//using WebApp_ServicesAdvertise.Filters;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Twilio;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using AddServices.JwtFeatures;
using AddServices.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//###Install-Package Microsoft.EntityFrameworkCore.SqlServer
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;// for file upload
using AddServices.Email_Sendgrid;
namespace AddServices
{
    public class Startup
    {

        public class CustomEmailConfirmationTokenProvider<TUser>
                                     : DataProtectorTokenProvider<TUser> where TUser : class
        {
            public CustomEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider,
                IOptions<EmailConfirmationTokenProviderOptions> options,
                ILogger<DataProtectorTokenProvider<TUser>> logger)
                                                  : base(dataProtectionProvider, options, logger)
            {

            }
        }
        public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
        {
            public EmailConfirmationTokenProviderOptions()
            {
                Name = "EmailDataProtectorTokenProvider";
                TokenLifespan = TimeSpan.FromHours(4);
            }
        }







        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            /*
            services.AddControllers();

            services.AddDbContext<AddServicesDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("WebApp_ServicesAdvertiseContext")));


            services.AddCors();






            services.AddDefaultIdentity<ApplicationUser>(config =>
            {
                //  config.SignIn.RequireConfirmedPhoneNumber = true; // to stop email confirm or account confirm check set options.SignIn.RequireConfirmedPhoneNumber =false; options.SignIn.RequireConfirmedEmail = false; if either of them are true the user wont be signed in until email and/or phone is confirmed
                config.SignIn.RequireConfirmedEmail = true; // to stop email confirm or account confirm check set options.SignIn.RequireConfirmedPhoneNumber =false; options.SignIn.RequireConfirmedEmail = false; if either of them are true the user wont be signed in until email and/or phone is confirmed
                config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                    new TokenProviderDescriptor(
                        typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
                config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            }).AddEntityFrameworkStores<AddServicesDbContext>();

            services.AddTransient<CustomEmailConfirmationTokenProvider<ApplicationUser>>();





            services.AddOptions();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AddServices", Version = "v1" });
            });
            */
            


            services.AddDbContext<AddServicesDbContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("WebApp_ServicesAdvertiseContext")));
                      services.AddCors(); // for axios, get put post  etc in react
                       //  services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AddServicesDbContext>().AddDefaultTokenProviders();
            
            /*
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AddServicesDbContext>();
            */
            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.User.RequireUniqueEmail = true;
            })
  .AddEntityFrameworkStores<AddServicesDbContext>()//;

.AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(2));




            /* // for email confirm check
            services.AddDefaultIdentity<ApplicationUser>(config =>
                {
                    //  config.SignIn.RequireConfirmedPhoneNumber = true; // to stop email confirm or account confirm check set options.SignIn.RequireConfirmedPhoneNumber =false; options.SignIn.RequireConfirmedEmail = false; if either of them are true the user wont be signed in until email and/or phone is confirmed
                    config.SignIn.RequireConfirmedEmail = true; // to stop email confirm or account confirm check set options.SignIn.RequireConfirmedPhoneNumber =false; options.SignIn.RequireConfirmedEmail = false; if either of them are true the user wont be signed in until email and/or phone is confirmed
                    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                        new TokenProviderDescriptor(
                            typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
                    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                }).AddEntityFrameworkStores<AddServicesDbContext>();
            */


            var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            services.AddScoped<JwtHandler>();

            /*
            // for user register and login 
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidAudience = Configuration["Tokens:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });
            */
            /*
             // email send not successful
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            */
           // services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            
            services.AddTransient<IMailService, SendGridMailService>();

            services.AddControllers();


          


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_Employees", Version = "v1" });
               // c.OperationFilter<SwaggerFileUploadFilter>(); // for file upload
            });
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //### the order matters
            app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
          
            /*
            // host for react app 
            app.UseCors(options =>
         //options.WithOrigins("http://localhost:3000") //### for postman i think
        // options.WithOrigins("http://localhost:4200")//### for angular
          options.WithOrigins("http://localhost:4200")
         .AllowAnyHeader()
         .AllowAnyMethod());
            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AddServices v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();



            /*


           //app.UseStaticFiles();// or use following to download images to angular frontend
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
                RequestPath = "/StaticFiles"
            });
            */

               
                app.UseStaticFiles(new StaticFileOptions() // for image download to angular front end
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @AddServices.Controllers.ServicesController.ResourcesPath)),
               // RequestPath = new PathString("/Resources")
                RequestPath = new PathString("/" + AddServices.Controllers.ServicesController.ResourcesPath)
            });
            


            app.UseAuthentication();// ###required for '[Authorize]' with jwt token method
            app.UseAuthorization();
            app.UseDeveloperExceptionPage(); // 2022-05-17 for error handling and knowing errors
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
