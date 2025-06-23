using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;

/**
 * RequestAuthorizationMiddlewareExtensions
 * This class includes a method extension to register RequestAuthorizationMiddleware in the ASP.NET Core pipeline.
 */
public static class RequestAuthorizationMiddlewareExtensions
{
    /**
     * UseRequestAuthorization extension method is used to register RequestAuthorizationMiddleware in the ASP.NET Core pipeline.
     */
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}