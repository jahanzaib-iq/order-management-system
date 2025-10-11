namespace ManagementSystem.App.Config;

public class JwtSettings(string key, string issuer, string audience, double durationInMinutes)
{
  public string? Key { get; set; } = key;

  public string? Issuer { get; set; } = issuer;

  public string? Audience { get; set; } = audience;

  public double DurationInMinutes { get; set; } = durationInMinutes;
}
