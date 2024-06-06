using HotelWpfpApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Interfaces;
using Services;
using System.Windows.Controls;
using System.Windows.Forms;

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
            services.AddScoped<BookingReservationService>();
            services.AddScoped<BookingDetailService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<RoomInformationService>();
            services.AddScoped<RoomTypeServices>();

            services.AddScoped<BookingReservationRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<RoomInformationRepository>();
            services.AddScoped<RoomTypeRepository>();

            services.AddTransient<Login>();
            services.AddTransient<CustomerManagementUI>();
            services.AddTransient<RoomManagementUI>();
            services.AddTransient<BookingManagementUI>();
            services.AddTransient<BookingDetailUI>();
            
            services.AddTransient<MainWindow>();
            services.AddTransient<Frame>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<FuminiHotelManagementContext>(ServiceLifetime.Scoped);

            return services;
        }
    }
}
