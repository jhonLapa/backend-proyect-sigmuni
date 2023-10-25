﻿using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jca.Sigmuni.Core.Security.Services.Abstractions;
using Jca.Sigmuni.Core.Security.Services.Implementations;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Implementations;
using Jca.Sigmuni.WebApi.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// RouteOptions
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// PasswordHasherOptions
builder.Services.Configure<PasswordHasherOptions>(options =>
{
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
});

// JwtSecrectKey
var jwtSecrectKey = builder.Configuration.GetSection("Security:JwtSecrectKey").Get<string>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecrectKey)),
        ValidateLifetime = true,
        ValidIssuer = "",
        ValidAudience = "",
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true
    };
});

// Data base context
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped(typeof(IPaginator<>), typeof(Paginator<>));

builder.Services.AddScoped<ISecurityService, SecurityService>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterAssemblyTypes(Assembly.Load("Jca.Sigmuni.Infraestructure"))
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

        options.RegisterAssemblyTypes(Assembly.Load("Jca.Sigmuni.Application"))
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    });

builder.Services.AddAutoMapper(Assembly.Load("Jca.Sigmuni.Application"));

builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AuthorizeOperationFilter>();
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Bearer",
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Specify the authorization token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors(options =>
{
    options.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .Build();
});


app.UseAuthorization();

app.MapControllers();

app.Run();

