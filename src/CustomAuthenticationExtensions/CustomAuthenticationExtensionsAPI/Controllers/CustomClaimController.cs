using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomAuthenticationExtensionsAPI.Model;

namespace CustomAuthenticationExtensionsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CustomClaimController : Controller
{
    [HttpPost]
    public IActionResult Post(CustomerExtensionRequest request)
    {
        // Read the correlation ID from the Azure AD  request    
        string? correlationId = request?.Data?.AuthenticationContext?.CorrelationId;

        // Claims to return to Azure AD
        CustomerExtensionResponse responseContent = new();

        responseContent.Data.Actions[0].Claims.CorrelationId = correlationId;
        responseContent.Data.Actions[0].Claims.ApiVersion = "1.0.0";
        responseContent.Data.Actions[0].Claims.DateOfBirth = "01/01/2000";
        responseContent.Data.Actions[0].Claims.CustomRoles.Add("Writer");
        responseContent.Data.Actions[0].Claims.CustomRoles.Add("Editor");

        return new OkObjectResult(responseContent);
    }
}
