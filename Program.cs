using PAXSchedule;
using PAXSchedule.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRouting(options =>
    {
        options.LowercaseUrls = true;
        options.LowercaseQueryStrings = true;
    })
    .AddMvc(options =>
        options.OutputFormatters.Add(new CalendarOutputFormatter())
    )
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddSingleton<GuidebookService>()
    .AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

// Redirect www.paxschedule.com to https://paxschedule.com
app.Use((context, next) =>
{
    if (context.Request.Host.Host == "www.paxschedule.com")
    {
        context.Response.Redirect("https://paxschedule.com" + context.Request.Path, permanent: true);
        return context.Response.StartAsync();
    }
    return next(context);
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
