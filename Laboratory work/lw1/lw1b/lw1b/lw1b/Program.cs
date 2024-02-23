#region // Add services to the container.
using System.Net.WebSockets;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
} 
#endregion


app.UseStaticFiles();
app.UseWebSockets();

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        while (true)
        {
            var message = "# время: " + DateTime.Now.ToString("HH:mm:ss t z");
            var bytes = Encoding.UTF8.GetBytes(message);
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
            if (ws.State == WebSocketState.Open)
            {
                await ws.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else if (ws.State is WebSocketState.Closed or WebSocketState.Aborted)
            {
                break;
            }

            Thread.Sleep(2000);
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

app.MapGet("/", async context =>
{
    context.Response.Redirect("/html/page.html");
});

#region // Configure the HTTP request pipeline.

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run(); 

#endregion
