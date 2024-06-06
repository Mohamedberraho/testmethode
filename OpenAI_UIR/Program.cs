using Microsoft.EntityFrameworkCore;
using OpenAI_UIR.Db;
using OpenAI_UIR.Repository.Abstract;
using OpenAI_UIR.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Regiter Repos
builder.Services.AddScoped<IAdminRepository,AdminRepository>();
builder.Services.AddScoped<IConversationRepository,ConversationRepository>();
builder.Services.AddScoped<IQuestionRepository,QuestionRepository>();
builder.Services.AddScoped<IAnswerRepository,AnswerRepository>();
//
builder.Services.AddControllers();
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
