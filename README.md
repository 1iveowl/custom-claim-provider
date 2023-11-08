# Custom Claim Provider
## What is this?

As of November 4th 2023, the preview documentation for [Microsoft Entra ID for Customers](https://learn.microsoft.com/en-us/entra/external-id/customers/overview-customers-ciam) provides a guide for how to implement and configure a custom claim provider using the [token issuer start event](https://learn.microsoft.com/en-us/entra/identity-platform/custom-claims-provider-overview#token-issuance-start-event-listener). This guide can be found in the article: "[Get started with custom claims providers (preview)](https://learn.microsoft.com/en-us/entra/identity-platform/custom-extension-get-started?context=%2Fentra%2Fexternal-id%2Fcustomers%2Fcontext%2Fcustomers-context)". At the time of writing the examples provided in the documentation rest on utilizing [Easy Auth](https://learn.microsoft.com/en-us/azure/app-service/overview-authentication-authorization) and [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview). 

This sample extends the existing sample by providing a guide and some sample code for how to configure and set up a customer claims provider using an [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0) based API and [Identity.Web](https://learn.microsoft.com/en-us/entra/msal/dotnet/microsoft-identity-web/). It also utilizes certificates, rather than a secrets string, for credentials and leverages Azure KeyVault and Azure App Configuration to 

## Why this sample?

If you are a SaaS builder .... In a production scenario utilizing secrets might not be desirable. Instead, relying on Azure KeyVault to store certificate and Azure App Configuration for managing configuration, is a better path. 



 
