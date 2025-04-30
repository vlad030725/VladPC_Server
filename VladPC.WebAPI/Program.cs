using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using VladPC.BLL.Interfaces;
using VladPC.BLL.Services;
using VladPC.DAL;
using VladPC.DAL.DbInitializerSeeds;
using VladPC.DAL.Interfaces;
using VladPC.DAL.Models;
using VladPC.DAL.RepositoryPgs;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //var jwtKey = builder.Configuration["Jwt:Key"];
        //var jwtIssuer = builder.Configuration["Jwt:Issuer"];
        //var jwtAudience = builder.Configuration["Jwt:Audience"];

        //builder.Services.AddAuthentication(options => 
        //{ 
        //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
        //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
        //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
        //}).AddJwtBearer(options =>
        //{
        //    options.RequireHttpsMetadata = false;
        //    options.SaveToken = true;
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //        ValidAudience = builder.Configuration["Jwt:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //    };
        //});



        builder.Services.AddDbContext<VladPcdbContext>(options => 
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("VladPC_Server"));
        });

        builder.Services.AddIdentity<User, IdentityRole<int>>()
            .AddEntityFrameworkStores<VladPcdbContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateActor = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
            };
        });

        builder.WebHost.UseUrls("http://*:5053");

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        //Добавление CORS
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
            builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        #region Внедрение зависимостей

        builder.Services.AddTransient<IDbRepos, DbReposPgs>();
        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IOrderService, OrderService>();
        builder.Services.AddTransient<IUserService, UserService>();

        #endregion

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var VladPcdbContext = scope.ServiceProvider.GetRequiredService<VladPcdbContext>();
            //----
            await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
            await VladPCDBContextSeed.SeedAsync(VladPcdbContext);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.UseCors();

        app.Run();
    }
}