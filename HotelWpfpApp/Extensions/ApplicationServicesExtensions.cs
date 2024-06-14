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
                opt.UseSqlServer(config.GetConnectionString("DBDefault"));
            });

            // Services and ViewModels
            //services.AddScoped<DbContext,FuminiHotelManagementContext>();

            services.AddScoped<BookingReservationService>();
            services.AddScoped<BookingDetailService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<RoomInformationService>();
            services.AddScoped<RoomTypeServices>();

            services.AddScoped<IBookingReservationRepository, BookingReservationRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IRoomInformationRepository, RoomInformationRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddTransient<Login>();
            services.AddScoped<CustomerManagementUI>();
            services.AddScoped<RoomManagementUI>();
            services.AddScoped<BookingManagementUI>();
            services.AddScoped<BookingDetailUI>();
            services.AddTransient<CustomerMainUI>();
            services.AddScoped<MyProfileUI>();

            services.AddTransient<MainWindow>();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddDbContext<FuminiHotelManagementContext>(ServiceLifetime.Scoped);

            return services;
        }
    }
}
