using BookRoom.Application.Commands.CreateBook;
using Microsoft.Extensions.DependencyInjection;

namespace BookRoom.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddHandlers();

            return services;
        }

        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssemblyContaining<CreateBookCommand>());

            return services;
        }

    }
}