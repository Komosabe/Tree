using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Application.Mappings;
using Tree.Application.Services;

namespace Tree.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITreeService, TreeService>();

            services.AddAutoMapper(typeof(TreeMappingProfile));
        }
    }
}
