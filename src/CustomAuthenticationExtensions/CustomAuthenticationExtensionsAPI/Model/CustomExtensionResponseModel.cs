using System.Text.Json.Serialization;

namespace CustomAuthenticationExtensionsAPI.Model
{
    public class CustomerExtensionResponse
    {
        [JsonPropertyName("data")]
        public ResponseData Data { get; set; }
        
        public CustomerExtensionResponse()
        {
            Data = new ResponseData();
        }
    }

    public class ResponseData
    {
        [JsonPropertyName("@odata.type")]
        public string ODatatype { get; set; }

        [JsonPropertyName("actions")]
        public List<Action> Actions { get; set; }
        
        public ResponseData()
        {
            ODatatype = "microsoft.graph.onTokenIssuanceStartResponseData";
            Actions = [new Action()];
        }
    }

    public class Action
    {
        [JsonPropertyName("@odata.type")]
        public string ODatatype { get; set; }

        [JsonPropertyName("claims")]
        public Claims Claims { get; set; }
        
        public Action()
        {
            ODatatype = "microsoft.graph.tokenIssuanceStart.provideClaimsForToken";
            Claims = new Claims();
        }
    }

    public class Claims
    {
        [JsonPropertyName("correlationId")]
        public string? CorrelationId { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonPropertyName("apiVersion")]
        public string? ApiVersion { get; set; }

        [JsonPropertyName("customRoles")]
        public List<string> CustomRoles { get; set; }

        public Claims() => CustomRoles = [];
    }
}
