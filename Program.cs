using InCaseIForgetMyCrochet;
using InCaseIForgetMyCrochet.Components;
var builder = WebApplication.CreateBuilder(args);

if (args.Contains("--cleardb")) Seed.Clear();
if (args.Contains("--seed")) Seed.Run();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<PatternDbContext>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();
