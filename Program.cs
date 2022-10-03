using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFileUploadService, FileUploadService>(); //to add our product repository service
//builder.Services.AddSingleton<IProductRepository, ProductRepository>(); //to add our product repository service
builder.Services.AddScoped<IProductRepository, ProductDBRepository>(); //to add our product Database repository service
builder.Services.AddDbContext<ProductContext>(options=>options.UseSqlServer(
    "Server=ELAPC;Database=PMS;Trusted_Connection=true;MultipleActiveResultSets=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
    //dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated(); //creates the database if it doesn't already exist
    //use context
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Default MapControllerRoute
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Specialized MapControllerRoute
app.MapControllerRoute(
    name: "products",
    pattern: "{action}",
    defaults: new { controller = "Product", action = "DisplayAll" }
    );

app.Run();