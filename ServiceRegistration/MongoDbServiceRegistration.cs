﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace MongoSourceConnectorToEventGrid.ServiceRegistration
{
    public class MongoDbServiceRegistration : IServiceRegistration
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {

            #region Register MongoDB Client driver
            services.AddSingleton<IMongoClient>(x => new MongoClient(configuration["mongoDb-connection"]));
            #endregion

            #region Register MongoDB Change Stream Service
            services.AddSingleton<MongoDBChangeStreamService, MongoDBChangeStreamService>();
            #endregion

            #region Register logging Service 
            services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            #endregion
        }
    }
}
