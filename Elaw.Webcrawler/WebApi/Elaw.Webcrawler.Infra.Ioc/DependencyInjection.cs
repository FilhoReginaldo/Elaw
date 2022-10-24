using Elaw.Webcrawler.Application.Interfaces;
using Elaw.Webcrawler.Application.Mappings;
using Elaw.Webcrawler.Application.Services;
using Elaw.Webcrawler.Domain.Interfaces;
using Elaw.Webcrawler.Infra.Data.Context;
using Elaw.Webcrawler.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ElawDbContext>(options =>
         options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped<IExecutionRepository, ExecutionRepository>();

        services.AddScoped<IExecutionService, ExecutionService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("Elaw.Webcrawler.Application");
        services.AddMediatR(myhandlers);

        return services;
    }
}
