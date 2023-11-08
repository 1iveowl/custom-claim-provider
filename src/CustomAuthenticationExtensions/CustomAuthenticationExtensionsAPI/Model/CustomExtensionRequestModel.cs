using System.Text.Json.Serialization;

namespace CustomAuthenticationExtensionsAPI.Model
{
    public class CustomerExtensionRequest
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("data")]
        public RequestData? Data { get; set; }
    }

    public class RequestData
    {
        [JsonPropertyName("@odata.type")]
        public string? ODatatype { get; set; }

        [JsonPropertyName("tenantId")]
        public string? TenantId { get; set; }

        [JsonPropertyName("authenticationEventListenerId")]
        public string? AuthenticationEventListenerId { get; set; }

        [JsonPropertyName("customAuthenticationExtensionId")]
        public string? CustomAuthenticationExtensionId { get; set; }

        [JsonPropertyName("authenticationContext")]
        public AuthenticationContext? AuthenticationContext { get; set; }
    }

    public class AuthenticationContext
    {
        [JsonPropertyName("correlationId")]
        public string? CorrelationId { get; set; }

        [JsonPropertyName("client")]
        public Client? Client { get; set; }

        [JsonPropertyName("protocol")]
        public string? Protocol { get; set; }

        [JsonPropertyName("clientServicePrincipal")]
        public ClientServicePrincipal? ClientServicePrincipal { get; set; }

        [JsonPropertyName("resourceServicePrincipal")]
        public ResourceServicePrincipal? ResourceServicePrincipal { get; set; }

        [JsonPropertyName("user")]
        public User? User { get; set; }
    }

    public class Client
    {
        [JsonPropertyName("ip")]
        public string? Ip { get; set; }

        [JsonPropertyName("locale")]
        public string? Locale { get; set; }

        [JsonPropertyName("market")]
        public string? Market { get; set; }
    }

    public class ClientServicePrincipal
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("appId")]
        public string? AppId { get; set; }

        [JsonPropertyName("appDisplayName")]
        public string? AppDisplayName { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
    }

    public class ResourceServicePrincipal
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("appId")]
        public string? AppId { get; set; }

        [JsonPropertyName("appDisplayName")]
        public string? AppDisplayName { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("data")]
        public ResponseData? Data { get; set; }
    }

    public class User
    {
        [JsonPropertyName("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("givenName")]
        public string? GivenName { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("mail")]
        public string? Mail { get; set; }

        [JsonPropertyName("preferredLanguage")]
        public string? PreferredLanguage { get; set; }

        [JsonPropertyName("surname")]
        public string? Surname { get; set; }

        [JsonPropertyName("userPrincipalName")]
        public string? UserPrincipalName { get; set; }

        [JsonPropertyName("userType")]
        public string? UserType { get; set; }
    }
}
