using Customer.Infrastructure.Extensions;

var corsPolicy = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.ConfigureAutoFacContainer();
builder.Services.ConfigureApplicationService(builder.Configuration);
builder.Services.ConfigureSwagger();

builder.Services.AddControllers();


builder.Services.AddCors(option => option.AddPolicy(name: corsPolicy, builder =>
{
  builder.AllowAnyOrigin();
  builder.AllowAnyHeader();
  builder.AllowAnyMethod();
}));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For Migrations
app.SeedingOrderData();
app.SeedingCustomerData();

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
