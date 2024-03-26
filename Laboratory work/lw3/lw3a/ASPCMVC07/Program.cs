#region // Add services to the container.

using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Calc/Error");
    app.UseHsts();
} 
#endregion

//app.MapControllerRoute(
//    name: "default",
//    pattern: "Calc/Sum",
//    defaults: new { controller = "Calc", action = "Sum" }
//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "Calc/Sub",
//    defaults: new { controller = "Calc", action = "Sub" }
//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "Calc/Div",
//    defaults: new { controller = "Calc", action = "Div" }
//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "Calc/Mul",
//    defaults: new { controller = "Calc", action = "Mul" }
//);

#region // Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calc}/{action=Index}/{id?}");

app.Run();

#endregion