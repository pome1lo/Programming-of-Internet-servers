#region // Add services to the container.

using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

#endregion


app.MapControllerRoute(
    name: "M01",
    pattern: "{controller=TMResearch}/{action=M01}/{id?}",
    defaults: new { action = "M01" },
    constraints: new { httpMethod = new HttpMethodRouteConstraint("GET"), id = new IntRouteConstraint() }
);

app.MapControllerRoute(
    name: "M01V2V3",
    pattern: "{version}/{controller=TMResearch}/{str?}/M01",
    defaults: new { action = "M01" },
    constraints: new { httpMethod = new HttpMethodRouteConstraint("GET"), version = new RegexRouteConstraint("^V[23]$") }
);

app.MapControllerRoute(
    name: "M02",
    pattern: "V{version}/{controller=TMResearch}/{action=M02}/{str?}",
    defaults: new { action = "M02" },
    constraints: new { httpMethod = new HttpMethodRouteConstraint("GET"), version = @"2" }
);

app.MapControllerRoute(
    name: "M03",
    pattern: "V3/{controller=TMResearch}/{str?}/{action=M03}",
    defaults: new { action = "M03" },
    constraints: new { httpMethod = new HttpMethodRouteConstraint("GET") }
);

app.MapControllerRoute(
    name: "MXX",
    pattern: "{*url}",
    defaults: new { controller = "TMResearch", action = "MXX" },
    constraints: new { httpMethod = new HttpMethodRouteConstraint("GET") }
);






#region  // Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion