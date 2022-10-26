
using ECommerceAPI.Data;
using ECommerceAPI.Repository;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data.Entity;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
               .AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = "http://localhost:7135",
                       ValidAudiences = new List<string>
                       {
                            "http://localhost:7135",
                            "http://localhost:4200"
                       },
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe"))
                   };
               });
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<UserDetailsServices, UserDetailsServices>();

builder.Services.AddTransient<IProduct, ProductRepository>();
builder.Services.AddTransient<ProductServices, ProductServices>();

builder.Services.AddTransient<IPayment, PaymentRepository>();
builder.Services.AddTransient<PaymentServices, PaymentServices>();

builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddTransient<OrderServices, OrderServices>();

builder.Services.AddTransient<ICart, CartRepository>();
builder.Services.AddTransient<CartServices, CartServices>();

builder.Services.AddTransient<IAddress, AddressRepository>();
builder.Services.AddTransient<AddressServices, AddressServices>();

//DI for DBContext
builder.Services.AddDbContext<ECommerceDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("Connectionname")));
builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerceAPI", Version = "v1" });
});

var app = builder.Build();
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
   
   app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerceAPI v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
