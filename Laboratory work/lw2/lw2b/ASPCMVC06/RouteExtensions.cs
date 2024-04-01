using Microsoft.AspNetCore.Routing.Constraints;

namespace ASPCMVC06
{
    public static class RouteExtensions
    {
        public static void ConfigureRoutes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "V2",
                pattern: "V2/{controller=TMResearch}/{action=M02}",
                constraints: new { action = "(?!M03).*" });

            app.MapControllerRoute(
                name: "V3",
                pattern: "V3/{controller=TMResearch}/{string?}/{action=M03}");

            app.MapControllerRoute(
                name: "TMResearch",
                pattern: "{controller=TMResearch}/{action=M01}/{id?}",
                constraints: new { action = "(?!M03).*" });
             
            app.MapControllerRoute(
                name: "MXX",
                pattern: "{*url}",
                defaults: new { controller = "TMResearch", action = "MXX" }); 
        } 
    }
}
