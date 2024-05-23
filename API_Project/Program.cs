
using ECommerce.DAL;
using ECommerce.BL;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Context;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
namespace API_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDALServices(builder.Configuration);
            builder.Services.AddBLServices();
            #region Identity Stuff
            builder.Services.AddIdentityCore<User>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<EcommerceContext>();
            #endregion
            #region Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "EcommerceJwt";
                options.DefaultChallengeScheme = "EcommerceJwt";
            }
                )
                .AddJwtBearer("EcommerceJwt",options => 
                {
                    var keyFromConfig = builder.Configuration.GetValue<string>(Constants.AppSettings.SecretKey)!;
                    var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
                    var key = new SymmetricSecurityKey(keyInBytes);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = key
                    };
                });
            #endregion

            #region Authorization
            builder.Services.AddAuthorization(options => 
            {
                options.AddPolicy("AdminOnly", b => b.RequireClaim(ClaimTypes.Role,"Admin"));
            });
            #endregion

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
            #endregion
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAllOrigins");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
