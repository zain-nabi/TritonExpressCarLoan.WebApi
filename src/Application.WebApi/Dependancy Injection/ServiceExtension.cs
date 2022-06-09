using Application.Interface.LoanDocument;
using Application.Repository.LoanDocument;
using Microsoft.Extensions.DependencyInjection;

namespace Application.WebApi.Dependancy_Injection
{
    public static class ServiceExtension
    {
        public static void ConfigureTransient(this IServiceCollection services)
        {
            services.AddTransient<ICarLoanDocument, CarLoanRepository>();
        }
    }
}
