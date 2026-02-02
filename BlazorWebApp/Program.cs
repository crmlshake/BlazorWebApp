using BlazorWebApp.Components;

namespace BlazorWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Kestrel so konfigurieren, dass er auf die IP und den Port lauscht!
            builder.WebHost.ConfigureKestrel(options =>
            {
                //Hier wird Kestrel auf die IP-Adresse des VPS (198.7.127.52) und Port 8080 gesetzt!
                options.Listen(System.Net.IPAddress.Parse("198.7.127.52"), 8080);
            });

            //Add services to the container!
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            //Configure the HTTP request pipeline!
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts(); //Optional: Nur für HTTPS, aber auch bei HTTP verfügbar!
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
               .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}