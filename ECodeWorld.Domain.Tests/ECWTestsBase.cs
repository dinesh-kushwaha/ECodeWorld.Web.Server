using Autofac;
using ECodeWorld.Domain.CrossCutting.DIResolver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace ECodeWorld.Domain.Tests
{
    public abstract class ECWTestsBase
    {
        public ECWTestsBase()
        {
            Init();

        }

        private void Init()
        {
            Configuration = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: true)
          //.AddXmlFile("app.config")
          //.Add(new LegacyConfigurationProvider())
          .Build();
        }
        protected IConfiguration Configuration { get; private set; }
        private IContainer _autofacContainer;
        protected IContainer AutofacContainer
        {
            get
            {
                if (_autofacContainer == null)
                {
                    var builder = new ContainerBuilder();
                    var connectionString = Configuration.GetConnectionString("ECodeWorldDatabase");
                    builder.RegisterModule(new DIRepositoriesModule
                    {
                        connectionString = connectionString,
                        cacheTimespan = new TimeSpan(100)
                    });
                    builder.RegisterModule<DIAppServicesModule>();
                    builder.RegisterModule<DIAdaptersModule>();

                    var container = builder.Build();
                    _autofacContainer = container;
                }
                return _autofacContainer;
            }
        }

    }
}
