#region Add services to the container.
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

var app = builder.Build();

#endregion


//  TASK 1
app.MapGet("PAA", context =>
{
    var parameterA = context.Request.Query["ParmA"];
    var parameterB = context.Request.Query["ParmB"];

    var response = $"GET-Http-PAA:ParmA = {parameterA},ParmB = {parameterB}";

    context.Response.ContentType = "text/plain";

    return context.Response.WriteAsync(response);
});


//  TASK 2
app.MapPost("PAA", context =>
{
    var form = context.Request.ReadFormAsync();
    var parameterA = form.Result["ParmA"];
    var parameterB = form.Result["ParmB"];

    var response = $"POST-Http-PAA:ParmA = {parameterA},ParmB = {parameterB}";

    context.Response.ContentType = "text/plain";

    return context.Response.WriteAsync(response);
});


//  TASK 3
app.MapPut("PAA", context =>
{
    var form = context.Request.ReadFormAsync();
    var parameterA = form.Result["ParmA"];
    var parameterB = form.Result["ParmB"];

    var response = $"PUT-Http-PAA:ParmA = {parameterA},ParmB = {parameterB}";

    context.Response.ContentType = "text/plain";

    return context.Response.WriteAsync(response);
});


//  TASK 4
app.MapPost("PAA/SUM", context =>
{
    var request = context.Request;
    var form = request.ReadFormAsync();

    int x = Convert.ToInt32(form.Result["X"]);
    int y = Convert.ToInt32(form.Result["Y"]);
    int sum = x + y;

    var response = sum.ToString();
    context.Response.ContentType = "text/plain";
    return context.Response.WriteAsync(response);
});


//  TASK 5
app.Map("PAA/TASK5", (HttpContext context) =>
{
    switch (context.Request.Method) 
    {
        case "GET":
        {
            var webRoot = context.RequestServices.GetRequiredService<IWebHostEnvironment>().WebRootPath;
            var file = Path.Combine(webRoot, "html/task5.html");
            
            context.Response.ContentType = "text/html";
            context.Response.SendFileAsync(file);
            break;
        }
        case "POST":
        {
            int x = Convert.ToInt32(context.Request.Form["x"]);
            int y = Convert.ToInt32(context.Request.Form["y"]);

            int result = x * y;

            context.Response.WriteAsync(result.ToString());
            break;
        }
        default:
            context.Response.StatusCode = 404;
            break;
    }
});


//  TASK 6
app.Map("PAA/TASK6", (HttpContext context) =>
{
    switch (context.Request.Method)
    {
        case "GET":
            {
                var webRoot = context.RequestServices.GetRequiredService<IWebHostEnvironment>().WebRootPath;
                var file = Path.Combine(webRoot, "html/task6.html");

                context.Response.ContentType = "text/html";
                context.Response.SendFileAsync(file);
                break;
            }
        case "POST":
            {
                int x = Convert.ToInt32(context.Request.Form["x"]);
                int y = Convert.ToInt32(context.Request.Form["y"]);

                int result = x * y;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Result: " + result);
                context.Response.WriteAsync(result.ToString());
                break;
            }
        default:
            context.Response.StatusCode = 404;
            break;
    }
});



#region Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

#endregion