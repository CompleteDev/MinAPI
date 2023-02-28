using DataAccess.Data.OrderLines;
using DataAccess.Data.Velociti;
using DataAccess.DbAccess;
using MMSMinAPI.APIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//services cors
builder.Services.AddCors(opt => {
    opt.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IOrderHeaderData, OrderHeaderData>();
builder.Services.AddSingleton<IOrderLinesData, OrderLinesData>();
builder.Services.AddSingleton<IRouteFileData, RouteFileData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.ConfigureApi();
app.ConfigureOrderHeaderApi();
app.ConfigureOrderLineApi();
app.ConfigureVelocitApi();

app.Run();
