using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Umr.BlogCraft.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});

builder.Services.AddDbContext<BlogCraftDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Minimal API endpoints (unchanged)
app.MapGet("/api/posts", async (BlogCraftDbContext db) =>
    await db.Posts.Include(p => p.Tags).ToListAsync()
);

app.MapGet("/api/posts/{id}", async (int id, BlogCraftDbContext db) =>
    await db.Posts.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == id)
);

app.MapGet("/api/posts/{postId}/comments", async (int postId, BlogCraftDbContext db) =>
    await db.Comments.Where(c => c.PostId == postId).ToListAsync()
);

app.MapGet("/api/tags", async (BlogCraftDbContext db) =>
    await db.Tags.ToListAsync()
);

app.MapGet("/api/users", async (BlogCraftDbContext db) =>
    await db.Users.ToListAsync()
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    // In production serve the pre-built Angular files
    app.UseSpaStaticFiles();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BlogCraftDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Only map SPA middleware for non-API requests so API routes are handled by ASP.NET.
app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api"), spaApp =>
{
    spaApp.UseSpa(spa =>
    {
        spa.Options.SourcePath = "ClientApp";
        spa.Options.StartupTimeout = new TimeSpan(0, 4, 0);
        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                //https://stackoverflow.com/questions/57970442
                ctx.Context.Response.Headers.Append("Cache-Control", "no-store, no-cache");
            }
        };

        // In Development let ASP.NET start the Angular CLI so you don't need to run ng serve separately.
        if (app.Environment.IsDevelopment())
        {
            // Runs `npm start` in ClientApp. Ensure Node/npm are on PATH and package.json start script exists.
            spa.UseAngularCliServer(npmScript: "start");
        }
        // In Production the prebuilt files from ClientApp/dist are served (configured above).
    });
});

app.Run();
