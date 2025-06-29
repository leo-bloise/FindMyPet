namespace FindMyPet.Api.Infra.ExceptionHandling;

public static class ExceptionHandlingInitialize
{
    public static void InitializeExceptionHandling(this WebApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<DomainExceptionHandler>();
        builder.Services.AddExceptionHandler<BaseExceptionHandler>();
    }
}