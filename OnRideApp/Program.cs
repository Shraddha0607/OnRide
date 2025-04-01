using OnRideApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnRideApp.Repositories;
using OnRideApp.Services;
using OnRideApp.Transformer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RideDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RideConnectionString")));

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<DriverRequestTransform>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<CustomerRequestTransformer>();

builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICouponService, CouponService>();

builder.Services.AddScoped<ITripBookingRepository, TripBookingRepository>();
builder.Services.AddScoped<ITripBookingService, TripBookingService>();
builder.Services.AddScoped<TripBookingTransformer>();

builder.Services.AddScoped<ICabRepository, CabRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
