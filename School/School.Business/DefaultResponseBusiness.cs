using School.Data.Dtos;

namespace School.Business;

public static class DefaultResponseBusiness
{
    public static ApiResponseDto<string> SendDefaultApiEndpointOutput() => ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint");

    public static ApiResponseDto<string> SendDefaultApiEndpointV1Output() => ApiResponseDto<string>.Create("Welcome to Minimal API Endpoint V1");
}
