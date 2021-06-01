using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Service.Hello;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]
namespace FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHelloService();
        }
    }
}
