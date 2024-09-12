using CloudinaryDotNet;
using MedSmart.Core.Domain.Application.IService;
using MedSmart.Core.Domain.IRepositoryContracts;
using MedSmart.Infrastructure.Persistence.Data;
using MedSmart.Infrastructure.Persistence.RepositoryContracts;
using MedSmart.Infrastructure.Services;
using MedSmart.Presentation.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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





// Add Cloudinary configuration
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddSingleton(provider =>
{
    var config = provider.GetService<IOptions<CloudinarySettings>>()?.Value;
    if (config == null)
    {
        throw new InvalidOperationException("Cloudinary settings are not configured properly.");
    }
    return new Cloudinary(new Account(config.CloudName, config.ApiKey, config.ApiSecret));
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
