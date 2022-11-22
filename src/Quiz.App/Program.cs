using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quiz.App.Infrastructure;
using Quiz.App.Infrastructure.Notification;
using Quiz.App.Infrastructure.Repositories;
using Quiz.App.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QuizDbContext>(options =>
{
    var host = builder.Configuration["DBHOST"] ?? "localhost";
    var port = builder.Configuration["DBPORT"] ?? "3308";
    var password = builder.Configuration["DBPASSWORD"] ?? "numsey";

    var connection = $"server={host};port={port};userid=root;password={password};database=quiz-db";

    options.UseMySql(connection, ServerVersion.AutoDetect(connection), optionsBuilder =>
    {
        optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery); //https://docs.microsoft.com/pt-br/ef/core/querying/single-split-queries
    });
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = false;
    })
    .AddEntityFrameworkStores<QuizDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICacheRepository<>), typeof(CacheRepository<>));
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();

builder.Services.AddScoped<INotificator, Notificator>();

builder.Services.AddMemoryCache();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<QuizDbContext>();

    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

    if (pendingMigrations.Any())
    {
        await context.Database.MigrateAsync();

        const string common = "common";
        const string admin = "admin";
        
        context.Roles.AddRange(new List<IdentityRole>(2)
        {
            new(common){NormalizedName = common.ToUpper()},
            new(admin){NormalizedName = admin.ToUpper()}
        });

        await context.SaveChangesAsync();

        var user = new User("admin", "master", "admin");

        var userManager = services.GetRequiredService<UserManager<User>>();
        
        await userManager.CreateAsync(user, "Teste@123");
        await userManager.AddToRoleAsync(user, admin);
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();