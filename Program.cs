var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR().AddAzureSignalR();
var app = builder.Build();

app.UseDefaultFiles();
app.UseRouting();
app.UseStaticFiles();
app.MapHub<TestChatHub>("/chat");
app.Run();