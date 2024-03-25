using Microsoft.AspNetCore.Routing.Constraints;

namespace ASPCMVC06
{
    public static class RouteExtensions
    {
        public static void ConfigureM01Routes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "M01_1",
                pattern: "/M01",
                defaults: new { controller = "TMResearch", action = "M01" });

            app.MapControllerRoute(
                name: "M01_2",
                pattern: "TMResearch/M01/{id?}",
                defaults: new { controller = "TMResearch", action = "M01" });

            app.MapControllerRoute(
                name: "M01_3",
                pattern: "/",
                defaults: new { controller = "TMResearch", action = "M01", id = "" },
                constraints: new { url = "/" });

            app.MapControllerRoute(
                name: "M01_4",
                pattern: "V2/TMResearch/M01",
                defaults: new { controller = "TMResearch", action = "M01" });

            app.MapControllerRoute(
                name: "M01_5",
                pattern: "V3/TMResearch/{id}/M01",
                defaults: new { controller = "TMResearch", action = "M01", id = "{id}" });
        }

        public static void ConfigureM02Routes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "M02_1",
                pattern: "V2",
                defaults: new { controller = "TMResearch", action = "M02" });

            app.MapControllerRoute(
                name: "M02_2",
                pattern: "V2/TMResearch",
                defaults: new { controller = "TMResearch", action = "M02" });

            app.MapControllerRoute(
                name: "M02_3",
                pattern: "V2/TMResearch/M02",
                defaults: new { controller = "TMResearch", action = "M02" });

            app.MapControllerRoute(
                name: "M02_4",
                pattern: "TMResearch/M02",
                defaults: new { controller = "TMResearch", action = "M02" });

            app.MapControllerRoute(
                name: "M02_5",
                pattern: "V3/TMResearch/{id}/M02",
                defaults: new { controller = "TMResearch", action = "M02", id = "{id}" });
        }

        public static void ConfigureM03Routes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "M03_1",
                pattern: "V3",
                defaults: new { controller = "TMResearch", action = "M03" });

            app.MapControllerRoute(
                name: "M03_2",
                pattern: "V3/TMResearch/{id}",
                defaults: new { controller = "TMResearch", action = "M03", id = "{id}" });

            app.MapControllerRoute(
                name: "M03_3",
                pattern: "V3/TMResearch/{id}/M03",
                defaults: new { controller = "TMResearch", action = "M03", id = "{id}" });
        }
        public static void ConfigureMXXRoutes(this WebApplication app)
        {
            app.MapControllerRoute(
                name: "MXX",
                pattern: "{*url}",
                defaults: new { controller = "TMResearch", action = "MXX" }); 
        }
    }
}
