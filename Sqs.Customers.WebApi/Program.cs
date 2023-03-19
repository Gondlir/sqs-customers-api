using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sqs.Customers.Application.CustomersServices;
using Sqs.Customers.Application.CustomersServices.Impl;
using Sqs.Customers.Data.Migrations.Context;
using Sqs.Customers.Data.Persistence.Repositories;
using Sqs.Customers.Data.Persistence.UoW;
using Sqs.Customers.Domain.Abstractions.Commands;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.CommandHandlers.CustomerCommandHandlers;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Customers.Domain.Entities.Customers.Commands;
using Sqs.Infrastructure.EventBus;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
InitializeBuilders(builder.Services);
AddDbContexts(builder.Services);
InitializeInjectionOfDependecies(builder.Services);
AddCors(builder.Services);
//Authentication(builder.Services);


var app = builder.Build();
ConfigureApp(app);
app.MapControllers();
app.Run();

#region Services
void InitializeBuilders(IServiceCollection services)
{
    services.AddControllers();
    services.AddOptions();
    services.AddMemoryCache();
}
//void Authentication(IServiceCollection services)
//{
//    //todo
//}
void InitializeInjectionOfDependecies(IServiceCollection services)
{
    services.AddTransient<ICustomerRepository, CustomerRepository>();
    services.AddTransient<ICustomersServices, CustomersService>();
    services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
    //services.AddScoped<ICommand, CreateCustomerCommand>(); // the ideal is create a ioc
    services.AddScoped<ICommandHandler<CreateCustomerCommand>, CreateCustomerCommandHandler>();
    services.AddScoped<ICommandHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>();
    services.AddScoped<ICommandHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>();
    services.AddScoped<IUoW, UnitOfWork>();
    services.AddScoped<IEventBus, EventBus>();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

    });
}
void AddDbContexts(IServiceCollection services)
{
    services.AddDbContext<EntityFrameworkContext>(opt => opt.UseInMemoryDatabase("localhost"));
}
void AddCors(IServiceCollection services)
{
    services.AddCors(options =>
    {
        options.AddPolicy("AllowOrigins", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });
}
void ConfigureApp(IApplicationBuilder app)
{
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Swagger Documentation");
    });
    app.UseRouting();
    //app.UseMiddleware<ExceptionMiddleware>();
    app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    //app.UseAuthentication();
    //app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
#endregion
