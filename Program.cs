using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"))
);

builder.Services.AddScoped<IGetProductRepository, GetProductRepository>();
builder.Services.AddScoped<IGetProductByIdRepository, GetProductByIdRepository>();
builder.Services.AddScoped<IPostProductRepository, PostProductRepository>();
builder.Services.AddScoped<IPatchProductRepository, PatchProductRepository>();
builder.Services.AddScoped<IDeleteProductRepository, DeleteProductRepository>();


// Add services to the container.

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
