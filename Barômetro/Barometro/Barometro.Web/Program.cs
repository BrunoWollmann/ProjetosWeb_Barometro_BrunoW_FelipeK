using Barometro.Web.Filtros;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "internacionalizacao");
builder.Services.AddMvc()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


builder.Services.AddControllersWithViews();


builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
    option.Cookie.Name = "Barometro";
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential= true;
});


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ExibirAdsActionFilter>();
    options.Filters.Add<FiltroExcessao>();
});




builder.Services.AddHttpContextAccessor();

var app = builder.Build();

var supportedCultures = new[] { "pt-BR", "en-US" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Barometro}/{action=Index}/{id?}");

app.Run();
