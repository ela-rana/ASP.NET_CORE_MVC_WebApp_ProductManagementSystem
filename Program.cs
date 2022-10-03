using ProductManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductRepository, ProductRepository>(); //to add our product repository service
builder.Services.AddScoped<IFileUploadService, FileUploadService>(); //to add our product repository service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
