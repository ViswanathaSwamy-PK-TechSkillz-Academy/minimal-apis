using School.Business;
using School.Data.Dtos;
using static School.ApplicationCore.Common.Constants;

namespace School.API.Endpoints;

public static class HelloWorldEndpoints
{

    public static void MapHelloWorldEndpoints(this IEndpointRouteBuilder routes)
    {
        _ = routes.MapGet(HelloWorldRoutes.Root, () => "Hello Minimal API World from Root !!")
            .WithTags("Hello World")
            .WithName("GetFromRoot");

        _ = routes.MapGet(HelloWorldRoutes.HelloWorld, () =>
        {
            return ApiResponseDto<string>.Create("Hello Minimal API World from /hw !!");
        }).WithTags("Hello World")
        .WithName("GetFromHW");

        _ = routes.MapGet(HelloWorldRoutes.Api, DefaultResponseBusiness.SendDefaultApiEndpointOutput)
            .WithTags("Hello World")
            .WithName("GetFromApi");

        _ = routes.MapGet(HelloWorldRoutes.ApiV1, () => DefaultResponseBusiness.SendDefaultApiEndpointV1Output())
            .WithTags("Hello World")
            .WithName("GetFromApiV1");
    }

}
