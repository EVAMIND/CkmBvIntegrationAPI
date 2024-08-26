namespace CkmBvIntegration.Domain.Models.Authentication;

public class AuthenticationResponse
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public int expires_in { get; set; }
    public string scope { get; set; }

    public DateTime TokenDate { get; set; }
    public bool IsTimeValid => DateTime.Now >=  TokenDate.AddSeconds(expires_in).AddMinutes(-5);

    public bool IsValid
    {
        get
        {
            if (!string.IsNullOrWhiteSpace(access_token))
            {
                return IsTimeValid;
            }

            return false;
        }
    }
}
