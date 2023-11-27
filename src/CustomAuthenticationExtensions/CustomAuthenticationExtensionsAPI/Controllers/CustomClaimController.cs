using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CustomAuthenticationExtensionsAPI.Model;

namespace CustomAuthenticationExtensionsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CustomClaimController : Controller
{

    // Claims to return to Azure AD
    [HttpPost]
    public IActionResult Post(CustomerExtensionRequest request) =>
        new OkObjectResult(new CustomerExtensionResponse
        {
            Data = new()
            {
                Actions = [
                    new()
                    {
                        Claims = new()
                        {
                            // Read the correlation ID from the Azure AD request    
                            CorrelationId = request?.Data?.AuthenticationContext?.CorrelationId,
                            ApiVersion = "1.0.0",
                            DateOfBirth = "01/01/2000",
                            CustomRoles =
                            [
                                "Writer",
                                "Editor"
                            ]
                        }
                    }
                ]
            }
        });
}
