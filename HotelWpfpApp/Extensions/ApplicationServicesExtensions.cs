using HotelWpfpApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;

namespace JewelryWpfApp.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config)
        {
            // DbContext
            services.AddDbContext<FuminiHotelManagementContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DBDefault"),
                    sqlOptions => sqlOptions.EnableRetryOnFailure());
            });
            // Services and ViewModels
            services.AddScoped<BookingService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<RoomInformationService>();
            services.AddScoped<RoomTypeServices>();
            services.AddScoped<BookingReservationRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<RoomInformationRepository>();
            services.AddScoped<RoomTypeRepository>();

            services.AddTransient<Login>();
            services.AddTransient<Admin>();
            services.AddTransient<Customer>();
            services.AddTransient<CustomerManagementUI>();
            services.AddTransient<RoomManagementUI>();
            services.AddTransient<BookingManagementUI>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
