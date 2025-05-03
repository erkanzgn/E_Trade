using ETrade.Cargo.BusinessLayer.Abstract;
using ETrade.Cargo.BusinessLayer.Concrete;
using ETrade.Cargo.DataAccessLayer.Abstract;
using ETrade.Cargo.DataAccessLayer.Concrete;
using ETrade.Cargo.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;


});

builder.Services.AddDbContext<CargoContext>();
builder.Services.AddScoped<ICargoCompanyDal,EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoCustomerDal,EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoDetailDal,EfCargoDetailDal>();
builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();

builder.Services.AddScoped<ICargoCompanyService,CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService,CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService,CargoDetailManager>();
builder.Services.AddScoped<ICargoOperationService,CargoOperationManager>();


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
