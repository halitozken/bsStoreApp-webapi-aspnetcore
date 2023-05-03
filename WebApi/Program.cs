using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(); //HttpPatch
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --Register Ýþlemi
// --Veritabaný baðlantýsý-- (IoC'ye DbContext tanýmý yapýlmýþ olur.)
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
