using ePizza.Repositories;
using ePizzaHub.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Services.Configuration
{
    public class ConfigureRepository
    {
        public static void AddServices(IServiceCollection services , IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
            });
            services.AddIdentity<User, Role>().AddEntityFrameworkStores < AppDbContext>().AddDefaultTokenProviders();

            services.AddScoped<DbContext,AppDbContext>();


        }
    }
}
