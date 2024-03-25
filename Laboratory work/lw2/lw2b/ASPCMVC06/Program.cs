#region Add services to the container.

using ASPCMVC06;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllersWithViews();

var app = builder.Build();
 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

#endregion

app.ConfigureM01Routes();
app.ConfigureM02Routes();
app.ConfigureM03Routes(); 
app.ConfigureMXXRoutes(); 
#region Configure the HTTP request pipeline.

app.UseRouting();
 
app.UseAuthorization();
 
app.Run();

#endregion