using BiuroPodrozy_Zad_dom.Data;
using Microsoft.EntityFrameworkCore;
using BiuroPodrozy_Zad_dom.Repository;
using BiuroPodrozy_Zad_dom.Service;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using BiuroPodrozy_Zad_dom.Models;
using Trips.DAL.Infrastructure;


namespace BiuroPodrozy_Zad_dom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ReservationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddRazorPages();

            builder.Services.AddIdentity<Client, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddDefaultUI()
                .AddRoles<IdentityRole>().AddEntityFrameworkStores<ReservationContext>().AddDefaultTokenProviders();

            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<ITourRepository, TourRepository>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ITourService, TourService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            try
            {
                var scope = app.Services.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ReservationContext>();
                DbInitializer.Initialize(db);


                var startup = new Startup(app.Configuration);

                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Client>>();

                startup.Configure(roleManager, userManager);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}