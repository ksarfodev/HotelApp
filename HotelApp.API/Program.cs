using AspNetCoreRateLimit;
using HotelAppLibrary.Data;
using HotelAppLibrary.Databases;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions();
builder.Services.AddMemoryCache();

//load general configuration from appsettings.json
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));

//load ip rules from appsettings.json. * if this is also enabled, AspNetCoreRateLimit doesn't work
//builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddInMemoryRateLimiting();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddTransient<ISqliteDataAccess, SqliteDataAccess>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();

string dbChoice = builder.Configuration.GetValue<string>("DatabaseChoice").ToLower();

if (dbChoice == "sql")
{
    builder.Services.AddTransient<IDatabaseData, SqlData>();//create an instance everytime it's asked
}
else if (dbChoice == "sqlite")
{
    builder.Services.AddTransient<IDatabaseData, SqliteData>();
}
else
{
    builder.Services.AddTransient<IDatabaseData, SqlData>();// fallback / default
}

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "HotelApp",
        Version = "v1",
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "AllowOrigin",
        builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }
        );
});

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseIpRateLimiting();
app.UseCors("AllowOrigin");



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
