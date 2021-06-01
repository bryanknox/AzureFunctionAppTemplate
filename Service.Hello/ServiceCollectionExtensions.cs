using Microsoft.Extensions.DependencyInjection;

namespace Service.Hello
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHelloService(this IServiceCollection services)
        {
            services.AddScoped<IHelloService, HelloService>();
        }
    }
}
