using ForumSystem.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartGarage.Helpers.Contracts;
using SmartGarage.Repositories;
using SmartGarage.Repositories.Contracts;
using SmartGarage.Services;
using SmartGarage.Services.Contracts;
using SmartGarage.Services.TokenGenerator;
using System.Text;
using freecurrencyapi;
using SmartGarage.Services.FreeCurrencyApi;

namespace SmartGarage
{
    public class Program
    {
        public static void Main(string[] args)
        {        
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.Configure<FreeCurrencyApiSettings>(
    builder.Configuration.GetSection("FreeCurrencyAPI"));
            builder.Services.AddDbContext<GarageContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            //Authentication
            AuthenticationConfiguration authenticationConfiguration = new AuthenticationConfiguration();
            builder.Configuration.Bind("Authentication", authenticationConfiguration);
            builder.Services.AddSingleton(authenticationConfiguration);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfiguration.AccessTokenSecret)),
                ValidIssuer = authenticationConfiguration.Issuer,
                ValidAudience = authenticationConfiguration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,

            });
            builder.Services.AddScoped<AccessTokenGenerator>();
            ////////////////

            //Momcheta tuka registrirame REpositories
            builder.Services.AddScoped<ILinkedVehiclesRepository, LinkedVehiclesRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ILinkedVehicleServiceRepository, LinkedVehicleServiceRepository>();

            //Momcheta tuka registrirame Services
            builder.Services.AddTransient<ICustomerProfileService, CustomerProfileService>();
            builder.Services.AddTransient<ILinkedVehicleServiceService, LinkedVehicleServiceService>();
            builder.Services.AddTransient<ICurrencyConversionDataService, CurrencyConversionDataService>();
            builder.Services.AddTransient<IEmployeeDataService, EmployeeDataService>();
            builder.Services.AddTransient<ILinkedVehiclesDataService, LinkedVehiclesDataService>();
            builder.Services.AddTransient<IInvoiceDataService, InvoiceDataService>();
            builder.Services.AddTransient<IManufacturerDataService, ManufacturerDataService>();
            builder.Services.AddTransient<ICustomerDataService, CustomerDataService>();
            builder.Services.AddTransient<ICarModelDataService, CarModelDataService>();
            builder.Services.AddTransient<IServiceDataService, ServiceDataService>();
            builder.Services.AddTransient<IUserDataService, UserDataService>();
            builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
            builder.Services.AddTransient<IVehicleDataService ,  VehicleDataService>();
            builder.Services.AddTransient<IAccountService ,  AccountService>();


            //
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://brave-sand-0cf191d03.4.azurestaticapps.net", "http://localhost:5173")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            //Here we fill DB with information for testing
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<GarageContext>();
                DataFeeder.DataFeeder.Initialize(dbContext);
            }

            
          ///Singleton --congig
          ///Scopped - DB
          ///
          ///Transient -services
          ///
          /// vmesto exception controller ako prieme null da vrushta status - bad request , unAuth ,etc.. -- toaster library visuals
          /// axios
          //Background service class build in library
           // app.MapGet("/", () => "Hello World!");
            app.MapDefaultControllerRoute();
            app.UseCors("AllowSpecificOrigin");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.Run();
        }
    }
}
