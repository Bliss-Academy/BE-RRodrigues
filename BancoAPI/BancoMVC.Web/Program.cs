using BancoAPI.Business.Services;
using BancoAPI.Data;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<BancoDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    var migrationsAssembly = typeof(BancoDbContext).Assembly.GetName().Name;

    opts.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(migrationsAssembly);
        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(15), null);
    });
});

//add custom services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IModelViewFactory, ModelViewFactory>();
builder.Services.AddScoped<IDTOFactory, DTOFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
