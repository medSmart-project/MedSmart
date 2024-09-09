using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;
using MedSmart.Infrastructure.Persistence.RepositoryContracts;
using MedSmart.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
// builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRepositoryFactory, RepositoryFactory>();
builder.Services.AddScoped<IImageTextExtractorService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var subscriptionKey = configuration.GetValue<string>("AzureCognitiveServices:SubscriptionKey");
    var endpoint = configuration.GetValue<string>("AzureCognitiveServices:Endpoint");
    return new ImageTextExtractorService(subscriptionKey, endpoint);
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
