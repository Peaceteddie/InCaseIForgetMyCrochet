using InCaseIForgetMyCrochet;
using InCaseIForgetMyCrochet.Components;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

if (args.Contains("--cleardb")) Seed.Clear();
if (args.Contains("--seed")) Seed.Run();


builder.Services.AddAuth0WebAppAuthentication(Auth0Options(builder));
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PatternDbContext>();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.Configure(CookieOptions());

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();
app.Run();

static Action<Auth0WebAppOptions> Auth0Options(WebApplicationBuilder builder)
{
    var env = Env
    .TraversePath()
    .Load()
    .ToDictionary();

    return options =>
    {
        options.Domain = env["AUTH0DOMAIN"]!;
        options.ClientId = env["AUTH0CLIENTID"]!;
        options.CookieAuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    };
}

static Action<CookiePolicyOptions> CookieOptions()
{
    return options =>
    {
        options.MinimumSameSitePolicy = SameSiteMode.None;
        options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None;
        options.Secure = CookieSecurePolicy.Always;
    };
}