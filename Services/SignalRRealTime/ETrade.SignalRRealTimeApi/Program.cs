using ETrade.SignalRRealTimeApi.Hubs;
using ETrade.SignalRRealTimeApi.Services.SignalRCommentServices;
using ETrade.SignalRRealTimeApi.Services.SignalRMessageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt => {

        opt.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
        });
});
builder.Services.AddHttpClient();

builder.Services.AddScoped<ISignalRCommetService,SignalRCommentService>();
builder.Services.AddScoped<ISignalRMessageService,SignalRMessageService>();

builder.Services.AddSignalR();

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
