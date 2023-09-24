using BeeForum.Domain.UseCases.CreateTopic;
using BeeForum.Domain.UseCases.GetForum;
using BeeForum.Domain.UseCases.GetForums;
using BeeForum.Storage.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<BeeForumDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("EvaFloraConnectionString")));

builder.Services.AddScoped<IGetForumsUseCase, GetForumsUseCase>();
builder.Services.AddScoped<ICreateTopicUseCase, ICreateTopicUseCase>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
