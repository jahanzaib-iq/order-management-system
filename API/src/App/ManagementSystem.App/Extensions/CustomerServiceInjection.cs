

namespace ManagementSystem.App.Extensions;

public static class CustomerServiceInjection
{
  public static void ConfigureCustomerApplicationService(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddCustomerDbContext(configuration);
    services.CustomerServiceInjection();

    var jwtSettingsSection = configuration.GetSection(nameof(JwtSettings));
    services.Configure<JwtSettings>(jwtSettingsSection);

    var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

    services.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(o =>
    {
      o.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        RequireExpirationTime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = jwtSettings!.Issuer,
        ValidAudience = jwtSettings!.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key ?? string.Empty))
      };
    });
  }
}
