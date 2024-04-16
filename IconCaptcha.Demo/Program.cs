namespace IconCaptcha.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");

            builder.Services.AddControllersWithViews();
            builder.Services.AddIconCaptcha(builder.Configuration.GetSection("IconCaptcha"));
            builder.Services.Configure<IconCaptchaOptions>(options =>
            {

            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapIconCaptcha("/iconcaptcha");
            app.Run();
        }
    }
}
