using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECodeWorld.Domain.CrossCutting.DIResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace ECodeWorld.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.AddMvc().AddControllersAsServices();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "e Code World API", Version = "v1" });
            });

            //https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.1
            //Register CORS services
            //services.AddCors();

            /*
                 Define one or more named CORS policies and select the policy by name at runtime.
                 The following example adds a user-defined CORS policy named AllowSpecificOrigin. 
                 To select the policy, pass the name to
             */

            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod()); 
            //});

            //services.AddDbContext<BloggingContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("ECodeWorldDatabase")));

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder =>
            //        {
            //            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
            //        });
            //});

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigins",
            //        builder =>
            //        {
            //            builder.WithOrigins("https://www.ecodeworld.com", "https://www.tecshapers.com");
            //        });
            //});

            //Set the allowed HTTP methods
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder =>
            //        {
            //            builder.WithOrigins("https://www.ecodeworld.com").AllowAnyMethod();
            //        });
            //});


            //Set the allowed request headers
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowHeaders",
            //         builder =>
            //         {
            //             builder.WithOrigins("https://www.ecodeworld.com")
            //                    .WithHeaders(HeaderNames.ContentType, "x-custom-header");
            //         });
            //});

            //To allow all author request headers, call AllowAnyHeader:
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAllHeaders",
            //        builder =>
            //        {
            //            builder.WithOrigins("https://www.ecodeworld.com").AllowAnyHeader();
            //        });
            //});
            return GetAutoFacDIService(services);
        }

        private IServiceProvider GetAutoFacDIService(IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);
            var connectionString = Configuration.GetConnectionString("ECodeWorldDatabase");
            builder.RegisterModule(new DIRepositoriesModule
            {
                connectionString = connectionString,
                cacheTimespan = new TimeSpan(100)
            });
            builder.RegisterModule<DIAppServicesModule>();
            builder.RegisterModule<DIAdaptersModule>();

            this.ApplicationContainer = builder.Build();
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public IConfigurationRoot ConfigurationRoot { get; private set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles(); // For the wwwroot folder
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "static")),
                RequestPath = "/files"
            });
            // Do Startup-ish things like read configuration.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
            // Set up the application.

            this.ConfigurationRoot = builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            // Shows UseCors with named policy.
            app.UseCors("CorsPolicy");

            //Enable CORS
            /*
             After registering CORS services, use either of the following approaches to enable CORS in an ASP.NET Core app:
                CORS Middleware – Apply CORS policies globally to the app via middleware.
                CORS in MVC – Apply CORS policies per action or per controller. CORS Middleware isn't used.
             */

            //Enable CORS with CORS Middleware
            // Shows UseCors with CorsPolicyBuilder.
            // app.UseCors(builder =>builder.WithOrigins("https://www.ecodeworld.com"));
            // app.UseCors(builder =>builder.WithOrigins("https://www.ecodeworld.com").AllowAnyHeader());

            // IMPORTANT: Make sure UseCors() is called BEFORE this
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "e Code World API V1");
            });

        }
    }

    //public class Startup
    //{
    //    public IContainer ApplicationContainer { get; private set; }
    //    public IConfigurationRoot Configuration { get; private set; }

    //    public Startup(IHostingEnvironment env)
    //    {
    //        // Do Startup-ish things like read configuration.
    //        var builder = new ConfigurationBuilder()
    //    .SetBasePath(env.ContentRootPath)
    //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
    //    .AddEnvironmentVariables();
    //        this.Configuration = builder.Build();
    //        // Set up the application.

    //    }

    //    private IServiceProvider GetAutoFacDIService(IServiceCollection services)
    //    {
    //        // Create the container builder.
    //        var builder = new ContainerBuilder();

    //        // Register dependencies, populate the services from
    //        // the collection, and build the container.
    //        //
    //        // Note that Populate is basically a foreach to add things
    //        // into Autofac that are in the collection. If you register
    //        // things in Autofac BEFORE Populate then the stuff in the
    //        // ServiceCollection can override those things; if you register
    //        // AFTER Populate those registrations can override things
    //        // in the ServiceCollection. Mix and match as needed.
    //        builder.Populate(services);
    //        var connectionString = Configuration.GetConnectionString("ECodeWorldDatabase");
    //        builder.RegisterModule(new DIRepositoriesModule
    //        {
    //            connectionString = connectionString,
    //            cacheTimespan = new TimeSpan(100)
    //        });
    //        builder.RegisterModule<DIAppServicesModule>();
    //        this.ApplicationContainer = builder.Build();
    //        // Create the IServiceProvider based on the container.
    //        return new AutofacServiceProvider(this.ApplicationContainer);
    //    }
    //    // This is the default if you don't have an environment specific method.
    //    public IServiceProvider ConfigureServices(IServiceCollection services)
    //    {
    //        // Add things to the service collection.
    //        // Add services to the collection.
    //        services.AddMvc().AddControllersAsServices();
    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new Info { Title = "e Code World API", Version = "v1" });
    //        });

    //        services.AddCors(options =>
    //        {
    //            options.AddPolicy("CorsPolicy",
    //                (policyBuilder) => policyBuilder.AllowAnyOrigin()
    //                .AllowAnyMethod()
    //                .AllowAnyHeader()
    //                .AllowCredentials());
    //        });
    //        return GetAutoFacDIService(services);
    //    }

    //    // This only gets called if your environment is Development. The
    //    // default ConfigureServices won't be automatically called if this
    //    // one is called.
    //    public IServiceProvider ConfigureDevelopmentServices(IServiceCollection services)
    //    {
    //        // Add things to the service collection.
    //        // Add services to the collection.
    //        services.AddMvc().AddControllersAsServices();
    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new Info { Title = "e Code World API", Version = "v1" });
    //        });

    //        services.AddCors(options =>
    //        {
    //            options.AddPolicy("CorsPolicy",
    //                (policyBuilder) => policyBuilder.AllowAnyOrigin()
    //                .AllowAnyMethod()
    //                .AllowAnyHeader()
    //                .AllowCredentials());
    //        });
    //        return GetAutoFacDIService(services);
    //    }

    //    // This is the default if you don't have an environment specific method.
    //    public void ConfigureContainer(ContainerBuilder builder)
    //    {
    //        // Add things to the Autofac ContainerBuilder.
    //    }

    //    // This only gets called if your environment is Production. The
    //    // default ConfigureContainer won't be automatically called if this
    //    // one is called.
    //    public IServiceProvider ConfigureProductionContainer(ContainerBuilder builder)
    //    {
    //        // Add things to the ContainerBuilder that are only for the
    //        // production environment.
    //        var connectionString = Configuration.GetConnectionString("ECodeWorldDatabase");
    //        builder.RegisterModule(new DIRepositoriesModule {
    //            connectionString= connectionString,
    //            cacheTimespan=new TimeSpan(100)
    //        });
    //        builder.RegisterModule(new DIAppServicesModule());
    //        this.ApplicationContainer = builder.Build();
    //        // Create the IServiceProvider based on the container.
    //        return new AutofacServiceProvider(this.ApplicationContainer);
    //    }

    //    // This is the default if you don't have an environment specific method.
    //    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    //    {
    //        // Shows UseCors with named policy.
    //        app.UseCors("CorsPolicy");
    //        app.UseMvc(routes =>
    //        {
    //            routes.MapRoute(
    //                name: "default",
    //                template: "{controller=Home}/{action=Index}/{id?}");
    //        });


    //        //Enable middleware to serve generated Swagger as a JSON endpoint.  
    //        app.UseSwagger();
    //        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.  
    //        app.UseSwaggerUI(c =>
    //        {
    //            c.SwaggerEndpoint("/swagger/v1/swagger.json", "e Code World API V1");
    //        });
    //    }

    //    // This only gets called if your environment is Staging. The
    //    // default Configure won't be automatically called if this one is called.
    //    public void ConfigureStaging(IApplicationBuilder app, ILoggerFactory loggerFactory)
    //    {
    //        // Set up the application for staging.
    //    }
    //}
}
