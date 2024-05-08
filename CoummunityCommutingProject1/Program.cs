using Microsoft.EntityFrameworkCore;
using CommunityCommuting_DAL.DBContext;
using CommunityCommuting_DAL.Interface;
using CommunityCommuting_DAL.Repository;
using CommunityCommuting_BAL.Interface;
using CommunityCommuting_BAL.Service;
using CommunityCommuting_DAL;




var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.

builder.Services.AddDbContext<CommunityCommutingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
builder.Services.AddScoped<IRideProvide, RideProvideRepository>();
builder.Services.AddScoped<IRideProvideService, RideProvideService>();
builder.Services.AddScoped<ISmile, SmileRepository>();
builder.Services.AddScoped<IBill, BillRepository>(); 
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<ISmileService, SmileService>();
builder.Services.AddScoped<ITripManager, TripManageRepository>();
builder.Services.AddScoped<ITripService, TripService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(option =>
{
    option.AddPolicy(name: "CORS", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
