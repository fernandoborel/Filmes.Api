namespace Filmes.Infra.Security.Settings;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public int ExpirationHours { get; set; }
}
