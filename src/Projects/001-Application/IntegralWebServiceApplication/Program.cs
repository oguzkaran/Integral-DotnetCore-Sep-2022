using Integral.CRM.Data.DAL;
using Integral.CRM.Data.Repository;
using CSD.Util.Mappers;
using CSD.Util.Mappers.Mapster;
using Integral.CRM.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

//Add dependency injections
builder.Services.AddSingleton<IntegralCrmdbContext>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ICustomerInfoRepository, CustomerInfoRepository>();
builder.Services.AddSingleton<IntegralCRMAppHelper>();
builder.Services.AddSingleton<IMapper, Mapper>();
builder.Services.AddSingleton<IntegralCrmDbAppService>();

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
