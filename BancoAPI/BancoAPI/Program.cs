using BancoAPI.Business.Services;
using BancoAPI.Data;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddScoped<IDTOFactory, DTOFactory>();
builder.Services.AddScoped<IModelViewFactory, ModelViewFactory>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
