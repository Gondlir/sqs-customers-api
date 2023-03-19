using Microsoft.EntityFrameworkCore;
using Sqs.Customers.Application.CustomersServices;
using Sqs.Customers.Application.CustomersServices.Impl;
using Sqs.Customers.Data.Migrations.Context;
using Sqs.Customers.Data.Persistence.Repositories;
using Sqs.Customers.Data.Persistence.UoW;
using Sqs.Customers.Domain.Abstractions.Interfaces;
using Sqs.Customers.Domain.Entities.Customers;
using Sqs.Infrastructure.EventBus;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
InitializeBuilders(builder.Services);
AddDbContexts(builder.Services);
InitializeDependecies(builder.Services);
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
void InitializeDependecies(IServiceCollection services)
{
    services.AddTransient<ICustomerRepository, CustomerRepository>();
    services.AddTransient<ICustomersServices, CustomersService>();
    services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
    services.AddScoped<IUoW, UnitOfWork>();
    services.AddScoped<IEventBus, EventBus>();

    //DependencyResolver.RegisterServices(services);
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
    //app.UseAuthentication();
    //app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
    //app.UseSwagger();
    //app.UseSwaggerUI(opt =>
    //{
    //    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Swagger");
    //});
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
