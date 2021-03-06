using Dos.User.Api.Data.Sql;
using Dos.User.Api.Domain.AggregateModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dos.User.Api.Web.Data
{
    public class DataGenerator
    {
        public static void Seed(string jsonData,
                            IServiceProvider serviceProvider)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
            List<UserEntity> customer = JsonConvert.DeserializeObject<List<UserEntity>>(jsonData, settings);
            using (
             var serviceScope = serviceProvider
               .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<UserDbContext>();
                if (!context.Users.Any())
                {
                    context.AddRange(customer);
                    context.SaveChanges();
                }
            }
        }
    }
}
