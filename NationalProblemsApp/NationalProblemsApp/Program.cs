using Microsoft.EntityFrameworkCore;
using NationalProblemsApp.Data;
using NationalProblemsApp.GlobalMethods;
using NationalProblemsApp.Mappers;
using NationalProblemsApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<NationalProblemsDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("NationalProblemsAppConnection")));

builder.Services.AddAutoMapper(typeof(ModalsMappingProfile));
builder.Services.AddScoped<IHelper,Helper>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

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
