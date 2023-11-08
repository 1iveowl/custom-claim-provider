using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


// Adding authentication protecting the API.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
           {
               // Using the configuration from the appsettings.json file, from the section "AzureAd".
               builder.Configuration.Bind("Entra", options);

               // When Entra external ID makes a call to the custom API "The bearer token contains an appid or azp claim. Validate that the
               // respective claim contains the 99045fe1-7639-4a75-9d4a-577b6ca3810f value.
               // This value ensures that the Microsoft Entra ID is the one who calls the REST API."
               // See: https://learn.microsoft.com/en-us/entra/identity-platform/custom-extension-overview#protect-your-rest-api
               // Here we're extending the authorized party to an array of values including the client id (aka. app id) of the app registration
               // for the API. This is done for testing and debugging purposes. In production, you would want to allow ONLY the Entra ID to call your API.
               string[] authorizedPartyArray = builder.Configuration.GetRequiredSection("Entra:AuthorizedParty").Get<string[]>() 
                    ?? throw new NullReferenceException("No authorized party specified in configuration.");

               // Extending the token validation to include validation of authorized party.
               // See: https://learn.microsoft.com/en-us/entra/identity-platform/custom-extension-overview#protect-your-rest-api
               options.Events = new JwtBearerEvents
               {
                   OnTokenValidated = async context =>
                   {

                       if (context.Principal?.Claims is null)
                       {
                           context.Fail("Token Validation Has Failed. No claims found in token.");
                           return;
                       }

                       if (!TryGetAuthorizedPartyValue(context.Principal.Claims, out var authorizedParty))
                       {
                           context.Fail("Token Validation Has Failed. No authorized party specified in claims.");
                           return;
                       }

                       if (!authorizedPartyArray.Contains(authorizedParty))
                       {
                           context.Fail("Token Validation Has Failed. Unauthorized party specified in claims.");
                           return;
                       }

                       context.Success();

                       await Task.CompletedTask;

                       static bool TryGetAuthorizedPartyValue(IEnumerable<Claim> claims, out string? authorizedParty)
                       {
                           string? version = claims.FirstOrDefault(context => context.Type.Equals("ver", StringComparison.OrdinalIgnoreCase))?.Value;

                           authorizedParty = version switch
                           {
                               "1.0" => claims.FirstOrDefault(context => context.Type.Equals("appid", StringComparison.OrdinalIgnoreCase))?.Value,
                               "2.0" => claims.FirstOrDefault(context => context.Type.Equals("azp", StringComparison.OrdinalIgnoreCase))?.Value,
                               _ => null
                           };

                           return authorizedParty is not null;
                       }
                   }
               };
           });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
