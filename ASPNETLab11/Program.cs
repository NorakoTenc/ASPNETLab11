using ASPNETLab11.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LogActionFilter>(provider => new LogActionFilter("./Logs/log.txt"));
builder.Services.AddScoped<UniqueUsersFilter>(provider => new UniqueUsersFilter("./Logs/uuserlog.txt"));

builder.Services.AddMvc(options =>
{
    options.Filters.AddService<LogActionFilter>();
    options.Filters.AddService<UniqueUsersFilter>();

});
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Consultation}/{action=Index}/{id?}");
app.Run();