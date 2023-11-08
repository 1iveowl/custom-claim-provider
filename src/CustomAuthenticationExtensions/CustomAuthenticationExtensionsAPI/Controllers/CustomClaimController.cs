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
        // Read the correlation ID from the Azure AD request    
        string? correlationId = request?.Data?.AuthenticationContext?.CorrelationId;

        // Claims to return to Azure AD
        CustomerExtensionResponse response = new();

        response.Data.Actions[0].Claims.CorrelationId = correlationId;
        response.Data.Actions[0].Claims.ApiVersion = "1.0.0";
        response.Data.Actions[0].Claims.DateOfBirth = "01/01/2000";
        response.Data.Actions[0].Claims.CustomRoles.Add("Writer");
        response.Data.Actions[0].Claims.CustomRoles.Add("Editor");

        return new OkObjectResult(response);
    }
}
