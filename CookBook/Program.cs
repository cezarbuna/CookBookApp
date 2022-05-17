using CookBook.Application.Commands.AdminCommands;
using CookBook.Application.Commands.CommentCommands;
using CookBook.Application.Commands.PostCommands;
using CookBook.Application.Commands.UserCommands;
using CookBook.Dal;
using CookBook.Dal.Repositories;
using CookBook.Domain.IRepositories;
using CookBook.Middleware;
using CookBook.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddMediatR(typeof(CreateUser));
builder.Services.AddMediatR(typeof(CreateAdmin));
builder.Services.AddMediatR(typeof(CreatePost));
builder.Services.AddMediatR(typeof(CreateComment));

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddDbContext<CookBookDbContext>(options
 => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMyMiddleware();

app.MapControllers();

app.Run();
